namespace RatesOfPlayers.Application.Abstractions.DTOs.Transactions;

/// <summary>
/// Класс, представляющий данные о транзакции.
/// </summary>
public class TransactionDto
{
    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public required long Id { get; init; }
    
    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public required long PlayerId { get; init; }
    
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
    public required string Type { get; init; }
}