using RatesOfPlayers.Domain.Transactions.Enums;

namespace RatesOfPlayers.Domain.Transactions;

/// <summary>
/// Модель транзакции.
/// </summary>
public class Transaction : IVersionedEntity
{
    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public long Id { get; init; }

    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public required long PlayerId { get; set; }

    /// <summary>
    /// Идентификатор транзакции.
    /// </summary>
    public required decimal Amount { get; set; }

    /// <summary>
    /// Дата транзакции.
    /// </summary>
    public DateTime Date { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Тип транзакции.
    /// </summary>
    public required TransactionType Type { get; set; }

    /// <summary>
    /// Поле для оптимистичной блокировки
    /// </summary>
    public int Version { get; set; }
}