using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Players;

/// <summary>
/// Команда для удаления игрока.
/// </summary>
public class DeletePlayerCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор игрока.
    /// </summary>
    public required long PlayerId { get; init; }
}