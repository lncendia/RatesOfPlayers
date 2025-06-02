namespace RatesOfPlayers.Infrastructure.Web.Players.ViewModels;

/// <summary>
/// Модель входных данных для создания игрока.
/// </summary>
public class PlayerViewModel
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string? Name { get; init; }
    
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string? SecondName { get; init; }
    
    /// <summary>
    /// Отчество.
    /// </summary>
    public string? ThirdName { get; init; }
}