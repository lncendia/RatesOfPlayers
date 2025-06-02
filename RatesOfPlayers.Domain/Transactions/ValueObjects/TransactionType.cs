using System.Diagnostics.CodeAnalysis;

namespace RatesOfPlayers.Domain.Transactions.ValueObjects;

/// <summary>
/// Класс типов транзакции.
/// </summary>
public static class TransactionType
{
    /// <summary>
    /// Словарь для сопоставления ключей типов транзакции с их значениями
    /// </summary>
    private static readonly Dictionary<string, string> TransactionDictionary = new Dictionary<string, string>
    {
        {"Deposit", Deposit},
        {"Withdrawal", Withdrawal},
    };
    
    /// <summary>
    /// Внесение
    /// </summary>
    public const string Deposit = "deposit+";

    /// <summary>
    /// Снятие
    /// </summary>
    public const string Withdrawal = "withdrawal-";

    /// <summary>
    /// Получает значение типа транзакции по ключу.
    /// </summary>
    /// <param name="key">Ключ типа транзакции.</param>
    /// <param name="value">Возвращаемое значение.</param>
    /// <returns>True если ключ найден иначе false.</returns>
    public static bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
    {
        // Пытается найти значение статуса в словаре по ключу
        return TransactionDictionary.TryGetValue(key, out value);   
    }
}