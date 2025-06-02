using MediatR;
using RatesOfPlayers.Domain.Players.Enums;

namespace RatesOfPlayers.Application.Abstractions.Commands.Players;

/// <summary>
/// Команда для изменения данных игрока.
/// </summary>
public class UpdatePlayerCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор игрока.
    /// </summary>
    public required long Id { get; init; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Статус игрока.
    /// </summary>
    public required PlayerStatus Status { get; init; }
}