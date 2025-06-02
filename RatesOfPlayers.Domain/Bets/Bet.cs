namespace RatesOfPlayers.Domain.Bets;

/// <summary>
/// Модель ставки.
/// </summary>
public class Bet
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
    public required DateTime Date { get; init; }

    /// <summary>
    /// Сумма выигрыша.
    /// </summary>
    public required decimal Prize { get; set; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    public required DateTime SettlementDate { get; set; }
}