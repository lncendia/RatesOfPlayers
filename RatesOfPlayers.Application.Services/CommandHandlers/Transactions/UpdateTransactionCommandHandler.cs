using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Transactions;

/// <summary>
/// Обработчик команды для обновления транзакции
/// </summary>
/// <param name="uow">Единица работы</param>
public class UpdateTransactionCommandHandler(
    IUnitOfWork uow) : IRequestHandler<UpdateTransactionCommand>
{
    /// <summary>
    /// Метод обработчик команды для обновления транзакции
    /// </summary>
    /// <param name="request">Команда для обновления транзакции</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        // Получаем транзакцию по идентификатору из запроса
        var transaction = await uow.Query<Transaction>()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        // Если транзакция не найдена, выбрасываем исключение
        if (transaction is null)
            throw new TransactionNotFoundException(request.Id);

        // Проверяем существование игрока
        var playerExists = request.PlayerId == transaction.PlayerId || await uow.Query<Player>()
            .AnyAsync(p => p.Id == request.PlayerId, cancellationToken);
        
        if (!playerExists)
            throw new PlayerNotFoundException(request.PlayerId);
        
        // Устанавливаем сумму транзакции, если она указана в запросе
        transaction.Amount = request.Amount;

        // Устанавливаем тип транзакции
        transaction.Type = request.Type;

        // Устанавливаем идентификатор игрока для транзакции
        transaction.PlayerId = request.PlayerId;
        
        // Устанавливаем дату транзакции
        transaction.Date = request.Date;

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}