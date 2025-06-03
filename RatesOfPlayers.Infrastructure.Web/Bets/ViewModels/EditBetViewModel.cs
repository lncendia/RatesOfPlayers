using System.ComponentModel.DataAnnotations;

namespace RatesOfPlayers.Infrastructure.Web.Bets.ViewModels;

/// <summary>
/// Модель входных данных для изменения ставки.
/// </summary>
public class EditBetViewModel
{
    /// <summary>
    /// Уникальный идентификатор ставки.
    /// </summary>
    /// <remarks>
    /// Должен быть положительным числом
    /// </remarks>
    [Display(Name = "Идентификатор ставки")]
    [Required(ErrorMessage = "Идентификатор ставки обязателен")]
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор ставки должен быть положительным числом")]
    public required long Id { get; init; }
    
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    /// <remarks>
    /// Должен быть положительным числом
    /// </remarks>
    [Display(Name = "ID игрока")]
    [Required(ErrorMessage = "Идентификатор игрока обязателен")]
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор игрока должен быть положительным числом")]
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма ставки.
    /// </summary>
    [Display(Name = "Сумма ставки")]
    [Required(ErrorMessage = "Сумма ставки обязательна")]
    [DataType(DataType.Currency, ErrorMessage = "Некорректный формат суммы")]
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Дата ставки.
    /// </summary>
    /// <remarks>
    /// Не может быть будущей датой
    /// </remarks>
    [Display(Name = "Дата ставки")]
    [Required(ErrorMessage = "Дата ставки обязательна для заполнения")]
    [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты")]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public required DateTime Date { get; init; }
    
    /// <summary>
    /// Сумма выигрыша.
    /// </summary>
    [Display(Name = "Сумма выигрыша")]
    [Required(ErrorMessage = "Сумма выигрыша обязательна")]
    [DataType(DataType.Currency, ErrorMessage = "Некорректный формат суммы")]
    public required decimal Prize { get; init; }
    
    /// <summary>
    /// Дата расчёта.
    /// </summary>
    [Display(Name = "Дата расчёта")]
    [Required(ErrorMessage = "Дата расчёта обязательна для заполнения")]
    [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты")]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public required DateTime SettlementDate { get; init; }
}