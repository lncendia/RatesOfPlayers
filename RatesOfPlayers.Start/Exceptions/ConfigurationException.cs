namespace RatesOfPlayers.Start.Exceptions;

/// <summary>
/// Исключение, вызывается при отсутствии значения в конфигурации
/// </summary>
public class ConfigurationException : Exception
{
    /// <summary>
    /// Путь конфигурации
    /// </summary>
    public string Path { get; }
    
    /// <summary>
    /// Конструктор исключения
    /// </summary>
    /// <param name="path">Путь конфигурации</param>
    public ConfigurationException(string path) : base($"The configuration does not contain a path for {path}")
    {
        Path = path;
    }
}