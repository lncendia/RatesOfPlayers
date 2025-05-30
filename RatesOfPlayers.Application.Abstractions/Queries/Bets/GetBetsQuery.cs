using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;
using RatesOfPlayers.Application.Abstractions.DTOs.Common;

namespace RatesOfPlayers.Application.Abstractions.Queries.Bets;

public class GetBetsQuery : IRequest<CountResult<BetDto>>
{
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required Guid PlayerId { get; init; }
}