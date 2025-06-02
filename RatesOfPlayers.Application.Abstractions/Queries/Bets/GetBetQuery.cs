using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;

namespace RatesOfPlayers.Application.Abstractions.Queries.Bets;

/// <summary>
/// Запрос на получение игрока.
/// </summary>
public class GetBetQuery : IRequest<BetDto>
{
    /// <summary>
    /// Уникальный идентификатор ставки.
    /// </summary>
    public required long Id { get; init; }
}