using System.ComponentModel.DataAnnotations;
using RatesOfPlayers.Infrastructure.Web.Transactions.Enums;

namespace RatesOfPlayers.Infrastructure.Web.Transactions.ViewModels;

/// <summary>
/// Модель представления для редактирования транзакции
/// </summary>
public class EditTransactionViewModel
{
    /// <summary>
    /// Идентификатор игрока, связанного с транзакцией
    /// </summary>
    /// <remarks>
    /// Должен быть положительным числом
    /// </remarks>
    [Display(Name = "ID игрока")]
    [Required(ErrorMessage = "Идентификатор игрока обязателен для заполнения")]
    [Range(1, long.MaxValue, ErrorMessage = "Идентификатор игрока должен быть положительным числом")]
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма транзакции
    /// </summary>
    [Display(Name = "Сумма транзакции")]
    [Required(ErrorMessage = "Сумма транзакции обязательна для заполнения")]
    [DataType(DataType.Currency, ErrorMessage = "Некорректный формат суммы")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Сумма должна быть положительной")]
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Тип транзакции
    /// </summary>
    [Display(Name = "Тип транзакции")]
    [Required(ErrorMessage = "Тип транзакции обязателен для заполнения")]
    [EnumDataType(typeof(TransactionTypeForView), ErrorMessage = "Некорректный тип транзакции")]
    public required TransactionTypeForView Type { get; init; }
    
    /// <summary>
    /// Дата проведения транзакции
    /// </summary>
    [Display(Name = "Дата транзакции")]
    [Required(ErrorMessage = "Дата транзакции обязательна для заполнения")]
    [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты")]
    public required DateTime Date { get; init; }
}