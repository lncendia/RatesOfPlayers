namespace RatesOfPlayers.Domain;

/// <summary>
/// Интерфейс для сущностей с поддержкой оптимистичной блокировки
/// </summary>
public interface IVersionedEntity
{
    /// <summary>
    /// Версия записи для контроля параллелизма
    /// </summary>
    /// <remarks>
    /// Значение должно автоматически увеличиваться при каждом обновлении записи.
    /// Используется для обнаружения конфликтов параллельного редактирования.
    /// </remarks>
    int Version { get; set; }
}