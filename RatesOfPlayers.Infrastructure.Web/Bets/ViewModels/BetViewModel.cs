using System.ComponentModel.DataAnnotations;

namespace RatesOfPlayers.Infrastructure.Web.Bets.ViewModels;

/// <summary>
/// Модель представления для отображения информации о ставке
/// </summary>
public class BetViewModel
{
    /// <summary>
    /// Уникальный идентификатор ставки.
    /// </summary>
    /// <remarks>
    /// Должен быть положительным числом
    /// </remarks>
    [Display(Name = "Идентификатор ставки")]
    public required long Id { get; init; }
    
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    /// <remarks>
    /// Должен быть положительным числом
    /// </remarks>
    [Display(Name = "ID игрока")]
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма ставки.
    /// </summary>
    [Display(Name = "Сумма ставки")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата ставки.
    /// </summary>
    [Display(Name = "Дата ставки")]
    [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты")]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
    public required DateTime Date { get; init; }
    
    /// <summary>
    /// Сумма выигрыша.
    /// </summary>
    [Display(Name = "Сумма выигрыша")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal Prize { get; init; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    [Display(Name = "Дата расчёта")]
    [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты")]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
    public required DateTime SettlementDate { get; init; }
}