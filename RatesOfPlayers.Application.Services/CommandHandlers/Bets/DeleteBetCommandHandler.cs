using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Bets;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Bets;

/// <summary>
/// Обработчик команды для удаления ставки
/// </summary>
/// <param name="uow">Единица работы</param>
public class DeleteBetCommandHandler(
    IUnitOfWork uow) : IRequestHandler<DeleteBetCommand>
{
    /// <summary>
    /// Метод обработчик команды для удаления ставки
    /// </summary>
    /// <param name="request">Команда для удаления ставки</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(DeleteBetCommand request, CancellationToken cancellationToken)
    {
        // Получаем ставку по идентификатору из запроса
        var bet = await uow.Query<BetAggregate>().FirstOrDefaultAsync(p => p.Id == request.BetId, cancellationToken);
        
        // Если ставка не найдена, выбрасываем исключение
        if (bet == null)
            throw new BetNotFoundException(request.BetId);
        
        // Удаляем ставку из контекста базы данных
        await uow.DeleteAsync(bet, cancellationToken);

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}