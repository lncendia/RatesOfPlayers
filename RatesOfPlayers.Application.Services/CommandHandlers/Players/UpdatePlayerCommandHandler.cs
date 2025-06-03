using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Players;

/// <summary>
/// Обработчик команды для изменения данных игрока
/// </summary>
/// <param name="uow">Единица работы</param>
public class UpdatePlayerCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdatePlayerCommand>
{
    /// <summary>
    /// Метод обработчик команды для изменения данных игрока
    /// </summary>
    /// <param name="request">Команда для изменения данных игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        // Получаем игрока по идентификатору из запроса
        var player = await uow.Query<Player>().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        
        // Если игрок не найден, выбрасываем исключение
        if (player == null) throw new PlayerNotFoundException(request.Id);
        
        // Устанавливаем новое имя
        player.Name = request.Name;
        
        // Устанавливаем новый статус
        player.Status = request.Status;
        
        // Обновляет информацию об игроке в контексте базы данных
        uow.Update(player);

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}