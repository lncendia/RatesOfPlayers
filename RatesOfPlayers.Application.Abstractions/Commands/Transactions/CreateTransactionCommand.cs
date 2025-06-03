using MediatR;
using RatesOfPlayers.Domain.Transactions.Enums;

namespace RatesOfPlayers.Application.Abstractions.Commands.Transactions;

/// <summary>
/// Команда для создания игрока.
/// </summary>
public class CreateTransactionCommand : IRequest<long>
{
    /// <summary>
    /// Уникальный идентификатор игрока.
    /// </summary>
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма транзакции.
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата транзакции.
    /// </summary>
    public required DateTime Date { get; init; }
    
    /// <summary>
    /// Сумма транзакции.
    /// </summary>
    public required TransactionType Type { get; init; }
}