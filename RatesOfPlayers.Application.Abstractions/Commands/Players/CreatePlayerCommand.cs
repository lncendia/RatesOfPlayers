using MediatR;
using RatesOfPlayers.Domain.Players.ValueObjects;

namespace RatesOfPlayers.Application.Abstractions.Commands.Players;

/// <summary>
/// Команда для создания игрока.
/// </summary>
public class CreatePlayerCommand : IRequest<Guid>
{
    /// <summary>
    /// Полное имя.
    /// </summary>
    public required FullName FullName { get; init; }
}