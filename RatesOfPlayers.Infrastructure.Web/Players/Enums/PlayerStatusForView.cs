using System.ComponentModel.DataAnnotations;

namespace RatesOfPlayers.Infrastructure.Web.Players.Enums;

/// <summary>
/// Статусы игрока в системе
/// </summary>
public enum PlayerStatusForView
{
    /// <summary>
    /// Новый игрок
    /// </summary>
    [Display(Name = "Новый", Description = "Недавно зарегистрированный игрок")]
    New = 1,

    /// <summary>
    /// Плохой игрок
    /// </summary>
    [Display(Name = "Плохой", Description = "Игрок с нарушениями правил")]
    Bad = 2,
}