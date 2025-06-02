namespace RatesOfPlayers.Domain.Transactions.ValueObjects;

/// <summary>
/// Класс типов транзакции.
/// </summary>
public static class TransactionType
{
    /// <summary>
    /// Словарь для сопоставления ключей типов транзакции с их значениями
    /// </summary>
    private readonly static Dictionary<string, string> TransactionDictionary = new Dictionary<string, string>
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
    /// <returns>Значение типа транзакции или null, если ключ не найден.</returns>
    public static string? TryGet(string key)
    {
        // Пытается найти значение типа транзакции в словаре по ключу
        TransactionDictionary.TryGetValue(key, out var value);   
        
        // Возвращает найденное значение или null, если ключ отсутствует
        return value;
    }
}