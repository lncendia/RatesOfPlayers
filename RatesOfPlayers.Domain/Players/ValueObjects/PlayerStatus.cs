using System.Diagnostics.CodeAnalysis;

namespace RatesOfPlayers.Domain.Players.ValueObjects;

/// <summary>
/// Класс типов статуса.
/// </summary>
public static class PlayerStatus
{
    /// <summary>
    /// Словарь для сопоставления ключей статусов с их значениями
    /// </summary>
    private static readonly Dictionary<string, string> StatusDictionary = new Dictionary<string, string>
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
    /// <param name="value">Возвращаемое значение.</param>
    /// <returns>True если ключ найден иначе false.</returns>
    public static bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
    {
        // Пытается найти значение статуса в словаре по ключу
        return StatusDictionary.TryGetValue(key, out value);   
    }
}