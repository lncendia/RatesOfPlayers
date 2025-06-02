using MediatR;
using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Transactions;

/// <summary>
/// Обработчик команды для создания транзакции
/// </summary>
/// <param name="uow">Единица работы</param>
public class CreateTransactionCommandHandler(
    IUnitOfWork uow) : IRequestHandler<CreateTransactionCommand, Guid>
{
    /// <summary>
    /// Метод обработчик команды для создания транзакции
    /// </summary>
    /// <param name="request">Команда для создания транзакции</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        // Создаём агрегат транзакции
        var transaction = new Transaction
        {
            PlayerId = request.PlayerId,
            Amount = request.Amount,
            Type = request.Type,
        };
        
        // Добавляем транзакцию в базу данных
        await uow.AddAsync(transaction, cancellationToken);
        
        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
        
        // Возвращаем уникальный идентификатор транзакции
        return transaction.Id;
    }
}