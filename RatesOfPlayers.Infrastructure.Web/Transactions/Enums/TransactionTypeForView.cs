using System.ComponentModel.DataAnnotations;

namespace RatesOfPlayers.Infrastructure.Web.Transactions.Enums;

/// <summary>
/// Типы финансовых транзакций
/// </summary>
public enum TransactionTypeForView
{
    /// <summary>
    /// Операция пополнения средств
    /// </summary>
    /// <remarks>
    /// Используется для зачисления денег на счет игрока
    /// </remarks>
    [Display(Name = "Пополнение", Description = "Зачисление средств на счет")]
    Deposit = 1,
    
    /// <summary>
    /// Операция списания средств
    /// </summary>
    /// <remarks>
    /// Используется для вывода денег со счета игрока
    /// </remarks>
    [Display(Name = "Списание", Description = "Снятие средств со счета")]
    Withdrawal = 2
}