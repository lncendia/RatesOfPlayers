using System.ComponentModel.DataAnnotations;
using RatesOfPlayers.Infrastructure.Web.Transactions.Enums;

namespace RatesOfPlayers.Infrastructure.Web.Transactions.ViewModels;

/// <summary>
/// Модель представления для редактирования транзакции
/// </summary>
public class EditTransactionViewModel
{
    /// <summary>
    /// Уникальный идентификатор транзакции
    /// </summary>
    /// <remarks>
    /// Должен быть положительным числом
    /// </remarks>
    [Required(ErrorMessage = "Идентификатор транзакции обязателен")]
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор транзакции должен быть положительным числом")]
    public required long Id { get; init; }
    
    /// <summary>
    /// Идентификатор игрока, связанного с транзакцией
    /// </summary>
    /// <remarks>
    /// Должен быть положительным числом
    /// </remarks>
    [Required(ErrorMessage = "Идентификатор игрока обязателен")]
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор игрока должен быть положительным числом")]
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма транзакции
    /// </summary>
    [Required(ErrorMessage = "Сумма транзакции обязательна")]
    [DataType(DataType.Currency, ErrorMessage = "Некорректный формат суммы")]
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Тип транзакции
    /// </summary>
    [Required(ErrorMessage = "Тип транзакции обязателен для заполнения")]
    [EnumDataType(typeof(TransactionTypeForView), ErrorMessage = "Некорректный тип транзакции")]
    public required TransactionTypeForView Type { get; init; }
    
    /// <summary>
    /// Дата проведения транзакции
    /// </summary>
    /// <remarks>
    /// Не может быть будущей датой
    /// </remarks>
    [Display(Name = "Дата транзакции")]
    [Required(ErrorMessage = "Дата транзакции обязательна для заполнения")]
    [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты")]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public required DateTime Date { get; init; }
}