using MediatR;
using RatesOfPlayers.Domain.Transactions.Enum;

namespace RatesOfPlayers.Application.Abstractions.Commands.Bets;

/// <summary>
/// Команда для создания игрока.
/// </summary>
public class CreateBetCommand : IRequest<Guid>
{
    /// <summary>
    /// Уникальный идентификатор игрока.
    /// </summary>
    public required Guid PlayerId { get; init; }
    
    /// <summary>
    /// Сумма ставки.
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата ставки.
    /// </summary>
    public DateTime? Date { get; init; }
    
    /// <summary>
    /// Сумма выигрыша.
    /// </summary>
    public decimal? Prize { get; init; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    public DateTime? SettlementDate { get; init; }
}