namespace RatesOfPlayers.Domain.Players.ValueObjects;

/// <summary>
/// Класс типов статуса.
/// </summary>
public static class PlayerStatus
{
    /// <summary>
    /// Словарь для сопоставления ключей статусов с их значениями
    /// </summary>
    private readonly static Dictionary<string, string> StatusDictionary = new Dictionary<string, string>
    {
        {"New", New},
        {"Bad", Bad},
    };
    
    /// <summary>
    /// Новый
    /// </summary>
    public const string New = "new";

    /// <summary>
    /// Плохой
    /// </summary>
    public const string Bad = "bad";
    
    /// <summary>
    /// Получает значение статуса по ключу.
    /// </summary>
    /// <param name="key">Ключ статуса.</param>
    /// <returns>Значение статуса или null, если ключ не найден.</returns>
    public static string? TryGet(string key)
    {
        // Пытается найти значение статуса в словаре по ключу
        StatusDictionary.TryGetValue(key, out var value);   
        
        // Возвращает найденное значение или null, если ключ отсутствует
        return value;
    }
}