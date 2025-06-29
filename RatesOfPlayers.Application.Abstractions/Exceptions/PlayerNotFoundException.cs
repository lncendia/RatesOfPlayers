namespace RatesOfPlayers.Application.Abstractions.Exceptions;

/// <summary>
/// Исключение возникающие, если игрок не был найден.
/// </summary>
public class PlayerNotFoundException : Exception
{
    /// <summary>
    /// Идентификатор игрока, который не был найден.
    /// </summary>
    public long PlayerId { get; }

    /// <summary>
    /// Конструктор исключения.
    /// </summary>
    /// <param name="playerId">Идентификатор игрока.</param>
    public PlayerNotFoundException(long playerId) : base($"Player with ID {playerId} not found.")
    {
        PlayerId = playerId;
    }
}