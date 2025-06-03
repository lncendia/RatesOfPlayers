using System.ComponentModel.DataAnnotations;

namespace RatesOfPlayers.Infrastructure.Web.Players.ViewModels;

/// <summary>
/// Модель представления для отчета по игроку
/// </summary>
/// <remarks>
/// Содержит расширенную информацию о финансовой активности игрока
/// </remarks>
public class PlayerReportViewModel : PlayerViewModel
{
    /// <summary>
    /// Общая сумма всех ставок игрока
    /// </summary>
    /// <remarks>
    /// Включает все завершенные ставки за весь период
    /// </remarks>
    [Display(Name = "Сумма ставок", Description = "Общая сумма всех ставок")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal TotalBets { get; init; }
    
    /// <summary>
    /// Общая сумма всех депозитов игрока
    /// </summary>
    /// <remarks>
    /// Включает все успешные пополнения счета
    /// </remarks>
    [Display(Name = "Сумма внесений", Description = "Общая сумма пополнений")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal TotalDeposits { get; init; }
}