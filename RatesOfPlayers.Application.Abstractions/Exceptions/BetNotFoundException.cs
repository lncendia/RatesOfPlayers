namespace RatesOfPlayers.Application.Abstractions.Exceptions;

/// <summary>
/// Исключение возникающие, если ставка не была найдена.
/// </summary>
public class BetNotFoundException : Exception
{
    /// <summary>
    /// Идентификатор ставки, которая не была найдена.
    /// </summary>
    public long BetId { get; }

    /// <summary>
    /// Конструктор исключения.
    /// </summary>
    /// <param name="betId">Идентификатор ставки.</param>
    public BetNotFoundException(long betId) : base($"Transaction with ID {betId} not found.")
    {
        BetId = betId;
    }
}