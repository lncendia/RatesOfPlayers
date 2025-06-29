namespace RatesOfPlayers.Domain.Bets;

/// <summary>
/// Модель ставки.
/// </summary>
public class Bet : IVersionedEntity
{
    /// <summary>
    /// Идентификатор ставки.
    /// </summary>
    public long Id { get; init; }
    
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required long PlayerId { get; set; }
    
    /// <summary>
    /// Сумма ставки.
    /// </summary>
    public required decimal Amount { get; set; }
    
    /// <summary>
    /// Дата ставки.
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Сумма выигрыша.
    /// </summary>
    public required decimal Prize { get; set; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    public required DateTime SettlementDate { get; set; }
    
    /// <summary>
    /// Поле для оптимистичной блокировки
    /// </summary>
    public int Version { get; set; }
}