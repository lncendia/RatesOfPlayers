using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;

namespace RatesOfPlayers.Application.Abstractions.Queries.Bets;

public class GetBetsQuery : IRequest<IReadOnlyList<BetDto>>;