namespace RatesOfPlayers.Infrastructure.Web.Players.InputModels;

/// <summary>
/// Модель входных данных для создания игрока.
/// </summary>
public class PlayerInputModel
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string? FirstName { get; init; }
    
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string? SecondName { get; init; }
    
    /// <summary>
    /// Отчество.
    /// </summary>
    public string? ThirdName { get; init; }
}