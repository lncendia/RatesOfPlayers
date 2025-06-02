using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;

namespace RatesOfPlayers.Application.Abstractions.Queries.Players;

/// <summary>
/// Запрос на получение игрока.
/// </summary>
public class GetPlayerQuery : IRequest<PlayerDto>
{
    /// <summary>
    /// Уникальный идентификатор игрока.
    /// </summary>
    public required long Id { get; init; }
}