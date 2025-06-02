using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Players;

/// <summary>
/// Обработчик команды для удаления игрока
/// </summary>
/// <param name="uow">Единица работы</param>
public class DeletePlayerCommandHandler(IUnitOfWork uow) : IRequestHandler<DeletePlayerCommand>
{
    /// <summary>
    /// Метод обработчик команды для удаления игрока
    /// </summary>
    /// <param name="request">Команда для удаления игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
        // Получаем игрока по идентификатору из запроса
        var player = await uow.Query<Player>().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        // Если игрок не найден, выбрасываем исключение
        if (player == null) throw new PlayerNotFoundException(request.Id);
        
        // Удаляем игрока из контекста базы данных
        await uow.DeleteAsync(player, cancellationToken);

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}