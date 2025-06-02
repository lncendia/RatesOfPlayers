using System.ComponentModel.DataAnnotations;
using RatesOfPlayers.Infrastructure.Web.Players.Enums;

namespace RatesOfPlayers.Infrastructure.Web.Players.ViewModels;

/// <summary>
/// Модель представления игрока
/// </summary>
public class PlayerViewModel
{
    /// <summary>
    /// Уникальный идентификатор игрока
    /// </summary>
    [Display(Name = "ID")]
    public int Id { get; init; }

    /// <summary>
    /// Полное имя игрока
    /// </summary>
    [Display(Name = "Имя игрока")]
    public required string Name { get; init; }

    /// <summary>
    /// Текущий баланс игрока
    /// </summary>
    [Display(Name = "Баланс")]
    [DataType(DataType.Currency)]
    public decimal Balance { get; init; }

    /// <summary>
    /// Дата регистрации
    /// </summary>
    [Display(Name = "Дата регистрации")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
    public DateTime RegistrationDate { get; init; }

    /// <summary>
    /// Текущий статус игрока
    /// </summary>
    [Display(Name = "Статус")]
    public PlayerStatusForView Status { get; init; }
}