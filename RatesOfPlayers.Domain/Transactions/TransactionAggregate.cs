using RatesOfPlayers.Domain.Transactions.Enum;

namespace RatesOfPlayers.Domain.Transactions;

/// <summary>
/// Агрегат транзакции.
/// </summary>
public class TransactionAggregate
{
    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public required Guid PlayerId { get; init; }
    
    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата транзакции.
    /// </summary>
    public required DateTime Date { get; init; }
    
    /// <summary>
    /// Тип транзакции.
    /// </summary>
    public required TransactionType Type { get; init; }
}