namespace RatesOfPlayers.Domain.Bets;

/// <summary>
/// Агрегат ставки.
/// </summary>
public class BetAggregate
{
    /// <summary>
    /// Идентификатор ставки.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();
    
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required Guid PlayerId { get; set; }
    
    /// <summary>
    /// Сумма ставки.
    /// </summary>
    public required decimal Amount { get; set; }
    
    /// <summary>
    /// Дата ставки.
    /// </summary>
    public required DateTime Date { get; init; }

    /// <summary>
    /// Сумма выигрыша.
    /// </summary>
    public decimal? Prize { get; set; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    public DateTime? SettlementDate { get; set; }
}