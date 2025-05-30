using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Players;

/// <summary>
/// Обработчик команды для удаления игрока
/// </summary>
/// <param name="uow">Единица работы</param>
public class DeletePlayerCommandHandler(
    IUnitOfWork uow) : IRequestHandler<DeletePlayerCommand>
{
    /// <summary>
    /// Метод обработчик команды для удаления игрока
    /// </summary>
    /// <param name="request">Команда для удаления игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
        // Получаем игрока по идентификатору из запроса
        var player = await uow.Query<PlayerAggregate>().FirstOrDefaultAsync(p => p.Id == request.PlayerId, cancellationToken);
        
        // Если игрок не найден, выбрасываем исключение
        if (player == null)
            throw new PlayerNotFoundException(request.PlayerId);

        // Получаем массив транзакций по идентификатору игрока
        var transactions = await uow.Query<TransactionAggregate>()
            .Where(t => t.PlayerId == request.PlayerId).ToArrayAsync(cancellationToken);

        // Получаем массив ставок по идентификатору игрока
        var bets = await uow.Query<BetAggregate>()
            .Where(t => t.PlayerId == request.PlayerId).ToArrayAsync(cancellationToken);
        
        // Если транзакции присутствуют, удаляем их из контекста базы данных
        if (transactions.Length > 0)
            await uow.DeleteRangeAsync(transactions, cancellationToken);
        
        // Если ставки присутствуют, удаляем их из контекста базы данных
        if (bets.Length > 0)
            await uow.DeleteRangeAsync(bets, cancellationToken);
        
        // Удаляем игрока из контекста базы данных
        await uow.DeleteAsync(player, cancellationToken);

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}