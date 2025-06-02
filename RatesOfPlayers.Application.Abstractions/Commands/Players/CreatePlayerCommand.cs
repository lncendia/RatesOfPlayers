using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Players;

/// <summary>
/// Команда для создания игрока.
/// </summary>
public class CreatePlayerCommand : IRequest<long>
{
    /// <summary>
    /// Полное имя.
    /// </summary>
    public required string Name { get; init; }
}