namespace RatesOfPlayers.Application.Abstractions.Exceptions;

/// <summary>
/// Исключение возникающие, если транзакция не была найдена.
/// </summary>
public class TransactionNotFoundException : Exception
{
    /// <summary>
    /// Идентификатор транзакции, которая не была найдена.
    /// </summary>
    public long TransactionId { get; }

    /// <summary>
    /// Конструктор исключения.
    /// </summary>
    /// <param name="transactionId">Идентификатор транзакции.</param>
    public TransactionNotFoundException(long transactionId) : base($"Transaction with ID {transactionId} not found.")
    {
        TransactionId = transactionId;
    }
}