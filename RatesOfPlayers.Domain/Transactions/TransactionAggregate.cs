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
    public Guid Id { get; init; } = Guid.NewGuid();
    
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
    public DateTime Date { get; private set; } = DateTime.Today;
    
    /// <summary>
    /// Тип транзакции.
    /// </summary>
    public required string Type { get; init; }
}