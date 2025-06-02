using RatesOfPlayers.Domain.Players.Enums;

namespace RatesOfPlayers.Domain.Players;

/// <summary>
/// Модель игрока.
/// </summary>
public class Player
{
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public long Id { get; init; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public DateTime RegistrationDate { get; private set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Статус игрока.
    /// </summary>
    public PlayerStatus Status { get; set; } = PlayerStatus.New;
}