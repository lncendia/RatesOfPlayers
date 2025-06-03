using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Bets;

/// <summary>
/// Команда для создания игрока.
/// </summary>
public class CreateBetCommand : IRequest<long>
{
    /// <summary>
    /// Уникальный идентификатор игрока.
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