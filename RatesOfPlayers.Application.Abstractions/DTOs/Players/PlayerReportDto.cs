namespace RatesOfPlayers.Application.Abstractions.DTOs.Players;

/// <summary>
/// Расширенная модель игрока с финансовой информацией
/// </summary>
/// <remarks>
/// Наследует базовые свойства от класса Player и добавляет финансовые показатели
/// </remarks>
public class PlayerReportDto : PlayerDto
{
    /// <summary>
    /// Общая сумма всех ставок игрока
    /// </summary>
    public required decimal TotalBets { get; init; }
    
    /// <summary>
    /// Общая сумма всех депозитов игрока
    /// </summary>
    public required decimal TotalDeposits { get; init; }
}