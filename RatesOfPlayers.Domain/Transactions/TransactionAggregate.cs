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
    public required Guid PlayerId { get; set; }
    
    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public required decimal Amount { get; set; }
    
    /// <summary>
    /// Дата транзакции.
    /// </summary>
    public DateTime Date { get; private set; } = DateTime.Today;
    
    /// <summary>
    /// Тип транзакции.
    /// </summary>
    public required string Type { get; set; }
}