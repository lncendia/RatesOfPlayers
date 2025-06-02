using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;

namespace RatesOfPlayers.Application.Abstractions.Commands.Players;

/// <summary>
/// Команда для создания игрока.
/// </summary>
public class CreatePlayerCommand : IRequest<PlayerDto>
{
    /// <summary>
    /// Полное имя.
    /// </summary>
    public required string Name { get; init; }
}