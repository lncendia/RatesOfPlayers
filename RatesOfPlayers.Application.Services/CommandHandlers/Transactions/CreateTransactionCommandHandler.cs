using MediatR;
using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Transactions;
using RatesOfPlayers.Domain.Transactions.Enum;

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
        // Получаем игрока по идентификатору из запроса
        var player = uow.Query<PlayerAggregate>().FirstOrDefault(p => p.Id == request.PlayerId);
        
        // Если игрок не найден, выбрасываем исключение
        if (player == null)
            throw new PlayerNotFoundException(request.PlayerId);
        
        // Если тип транзакции пополнение, тогда пополняем баланс на сумму из запроса
        if (request.Type == TransactionType.Deposit)
            player.DepositBalance(request.Amount);
        
        // Если тип транзакции списание, тогда списываем с баланса сумму из запроса
        if (request.Type == TransactionType.Withdrawal)
            player.WithdrawalBalance(request.Amount);
        
        // Создаём агрегат транзакции
        var transaction = new TransactionAggregate
        {
            PlayerId = request.PlayerId,
            Amount = request.Amount,
            Type = request.Type,
        };
        
        // Обновляет информацию об игроке в контексте базы данных
        uow.Update(player);

        // Добавляем транзакцию в базу данных
        await uow.AddAsync(transaction, cancellationToken);
        
        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
        
        // Возвращаем уникальный идентификатор транзакции
        return transaction.Id;
    }
}