using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;

namespace RatesOfPlayers.Application.Abstractions.Queries.Players;

public class GetPlayersQuery : IRequest<IReadOnlyList<PlayerDto>>;