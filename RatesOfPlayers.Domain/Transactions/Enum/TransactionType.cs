namespace RatesOfPlayers.Domain.Transactions.Enum;

/// <summary>
/// Перечисление типов транзакции.
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// Внесение
    /// </summary>
    Deposit = 1,

    /// <summary>
    /// Снятие
    /// </summary>
    Withdrawal = 2
}