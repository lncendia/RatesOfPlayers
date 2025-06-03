namespace RatesOfPlayers.Domain.Transactions.Enums;

/// <summary>
/// Типы финансовых транзакций
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// Операция пополнения средств
    /// </summary>
    /// <remarks>
    /// Используется для зачисления денег на счет игрока
    /// </remarks>
    Deposit = 1,
    
    /// <summary>
    /// Операция списания средств
    /// </summary>
    /// <remarks>
    /// Используется для вывода денег со счета игрока
    /// </remarks>
    Withdrawal = 2
}