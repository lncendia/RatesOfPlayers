namespace RatesOfPlayers.Application.Abstractions.Exceptions;

/// <summary>
/// Исключение возникающие, если встречен неизвестный тип транзакции.
/// </summary>
public class UnknownTransactionTypeException : Exception
{
    /// <summary>
    /// Тип транзакции, который не был найден.
    /// </summary>
    public string TransactionType { get; }

    /// <summary>
    /// Конструктор исключения.
    /// </summary>
    /// <param name="transactionType">Тип транзакции.</param>
    public UnknownTransactionTypeException(string transactionType) : base($"Transaction type with name {transactionType} not found.")
    {
        TransactionType = transactionType;
    }
}