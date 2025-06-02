namespace RatesOfPlayers.Application.Abstractions.DTOs.Bets;

/// <summary>
/// Класс, представляющий данные о ставке.
/// </summary>
public class BetDto
{
    /// <summary>
    /// Идентификатор ставки.
    /// </summary>
    public required long Id { get; init; }
    
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма ставки.
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата ставки.
    /// </summary>
    public required DateTime Date { get; init; }

    /// <summary>
    /// Сумма выигрыша.
    /// </summary>
    public decimal? Prize { get; init; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    public DateTime? SettlementDate { get; init; }
}