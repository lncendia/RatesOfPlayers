namespace RatesOfPlayers.Domain.Transactions.Enum;

/// <summary>
/// Класс типов транзакции.
/// </summary>
public static class TransactionType
{
    /// <summary>
    /// Внесение
    /// </summary>
    public const string Deposit = "deposit+";

    /// <summary>
    /// Снятие
    /// </summary>
    public const string Withdrawal = "withdrawal-";
}