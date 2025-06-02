using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;

namespace RatesOfPlayers.Application.Abstractions.Queries.Bets;

/// <summary>
/// Запрос на получение ставок.
/// </summary>
public class GetBetsQuery : IRequest<IReadOnlyList<BetDto>>;