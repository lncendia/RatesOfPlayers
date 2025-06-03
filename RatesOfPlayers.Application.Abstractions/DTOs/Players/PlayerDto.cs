using RatesOfPlayers.Domain.Players.Enums;

namespace RatesOfPlayers.Application.Abstractions.DTOs.Players;

/// <summary>
/// Класс, представляющий данные игрока.
/// </summary>
public class PlayerDto
{
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required long Id { get; init; }

    /// <summary>
    /// Имя игрока.
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Баланс игрока.
    /// </summary>
    public required decimal Balance { get; init; }
    
    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public required DateTime RegistrationDate { get; init; }
    
    /// <summary>
    /// Статус игрока.
    /// </summary>
    public required PlayerStatus Status { get; init; }
}