namespace RatesOfPlayers.Domain.Bets;

/// <summary>
/// Агрегат ставки.
/// </summary>
public class BetAggregate
{
    /// <summary>
    /// Идентификатор ставки.
    /// </summary>
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required Guid PlayerId { get; init; }
    
    /// <summary>
    /// Сумма ставки.
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата ставки.
    /// </summary>
    public required DateTime BetDate { get; init; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    public required DateTime SettlementDate { get; init; }
}