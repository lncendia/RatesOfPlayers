using System.ComponentModel.DataAnnotations;
using RatesOfPlayers.Infrastructure.Web.Transactions.Enums;

namespace RatesOfPlayers.Infrastructure.Web.Transactions.ViewModels;

/// <summary>
/// Модель представления для отображения информации о транзакции
/// </summary>
public class TransactionViewModel
{
    /// <summary>
    /// Идентификатор транзакции
    /// </summary>
    [Display(Name = "ID")]
    public required long Id { get; init; }
    
    /// <summary>
    /// Идентификатор игрока, связанного с транзакцией
    /// </summary>
    [Display(Name = "ID игрока")]
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// Сумма транзакции
    /// </summary>
    [Display(Name = "Сумма")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Тип транзакции
    /// </summary>
    [Display(Name = "Тип операции")]
    public required TransactionTypeForView Type { get; init; }
    
    /// <summary>
    /// Дата и время совершения транзакции
    /// </summary>
    [Display(Name = "Дата транзакции")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public required DateTime Date { get; init; }
}