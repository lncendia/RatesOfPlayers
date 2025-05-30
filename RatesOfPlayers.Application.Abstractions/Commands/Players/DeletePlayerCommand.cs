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
    public required Guid PlayerId { get; init; }
}