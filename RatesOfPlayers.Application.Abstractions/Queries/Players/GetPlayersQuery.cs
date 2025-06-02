using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;

namespace RatesOfPlayers.Application.Abstractions.Queries.Players;

/// <summary>
/// Запрос на получение игроков
/// </summary>
public class GetPlayersQuery : IRequest<IReadOnlyList<PlayerDto>>;