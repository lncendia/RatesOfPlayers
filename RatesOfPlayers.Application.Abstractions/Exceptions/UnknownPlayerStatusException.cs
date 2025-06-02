namespace RatesOfPlayers.Application.Abstractions.Exceptions;

/// <summary>
/// Исключение возникающие, если встречен неизвестный статус игрока.
/// </summary>
public class UnknownPlayerStatusException : Exception
{
    /// <summary>
    /// Статус игрока, который не был найден.
    /// </summary>
    public string PlayerStatus { get; }

    /// <summary>
    /// Конструктор исключения.
    /// </summary>
    /// <param name="playerStatus">Статус игрока.</param>
    public UnknownPlayerStatusException(string playerStatus) : base($"Status for player with name {playerStatus} not found.")
    {
        PlayerStatus = playerStatus;
    }
}