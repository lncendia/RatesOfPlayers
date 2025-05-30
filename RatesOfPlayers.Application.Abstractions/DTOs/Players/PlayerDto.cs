namespace RatesOfPlayers.Application.Abstractions.DTOs.Players;

/// <summary>
/// Класс, представляющий данные игрока.
/// </summary>
public class PlayerDto
{
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Имя игрока.
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Баланс игрока.
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public required DateTime RegistrationDate { get; init; }
    
    /// <summary>
    /// Статус игрока.
    /// </summary>
    public required string Status { get; init; }
}