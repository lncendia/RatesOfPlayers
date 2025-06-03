using System.ComponentModel.DataAnnotations;

namespace RatesOfPlayers.Infrastructure.Web.Bets.ViewModels;

/// <summary>
/// Модель входных данных для создания ставки.
/// </summary>
public class CreateBetViewModel
{
    /// <summary>
    /// Идентификатор игрока
    /// </summary>
    /// <remarks>
    /// Должен быть положительным числом
    /// </remarks>
    [Display(Name = "ID игрока")]
    [Required(ErrorMessage = "Идентификатор игрока обязателен для заполнения")]
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор игрока должен быть положительным числом")]
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма ставки
    /// </summary>
    [Display(Name = "Сумма ставки")]
    [Required(ErrorMessage = "Сумма ставки обязательна для заполнения")]
    [DataType(DataType.Currency, ErrorMessage = "Некорректный формат суммы")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Сумма должна быть положительной")]
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата проведения ставки
    /// </summary>
    [Display(Name = "Дата ставки")]
    [Required(ErrorMessage = "Дата ставки обязательна для заполнения")]
    [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты")]
    public required DateTime Date { get; init; }
    
    /// <summary>
    /// Сумма выигрыша
    /// </summary>
    [Display(Name = "Сумма выигрыша")]
    [Required(ErrorMessage = "Сумма выигрыша обязательна для заполнения")]
    [DataType(DataType.Currency, ErrorMessage = "Некорректный формат суммы выигрыша")]
    [Range(0, double.MaxValue, ErrorMessage = "Сумма должна быть положительной")]
    public required decimal Prize { get; init; }
    
    /// <summary>
    /// Дата рассчёта
    /// </summary>
    [Display(Name = "Дата рассчёта")]
    [Required(ErrorMessage = "Дата рассчёта обязательна для заполнения")]
    [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты")]
    public required DateTime SettlementDate { get; init; }
}