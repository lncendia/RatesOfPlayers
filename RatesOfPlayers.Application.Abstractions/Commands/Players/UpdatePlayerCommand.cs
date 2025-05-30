using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Players;

/// <summary>
/// Команда для изменения данных игрока.
/// </summary>
public class UpdatePlayerCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор игрока.
    /// </summary>
    public required Guid PlayerId { get; init; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public string? FirstName { get; init; }
    
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string? SecondName { get; init; }
    
    /// <summary>
    /// Отчество.
    /// </summary>
    public string? ThirdName { get; init; }
}