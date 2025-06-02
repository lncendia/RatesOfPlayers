using MediatR;
using RatesOfPlayers.Domain.Transactions.Enums;

namespace RatesOfPlayers.Application.Abstractions.Commands.Transactions;

/// <summary>
/// Команда для изменения транзакции.
/// </summary>
public class UpdateTransactionCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор транзакции.
    /// </summary>
    public required long Id { get; init; }
    
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма транзакции.
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Тип транзакции.
    /// </summary>
    public required TransactionType Type { get; init; }
}