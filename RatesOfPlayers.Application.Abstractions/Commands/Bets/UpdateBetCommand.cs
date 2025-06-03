using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Bets;

/// <summary>
/// Команда для изменения ставки.
/// </summary>
public class UpdateBetCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор ставки.
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
    public required decimal Prize { get; init; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    public required DateTime SettlementDate { get; init; }
}