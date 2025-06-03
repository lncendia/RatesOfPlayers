using System.ComponentModel.DataAnnotations;
using RatesOfPlayers.Infrastructure.Web.Players.Enums;

namespace RatesOfPlayers.Infrastructure.Web.Players.ViewModels;

/// <summary>
/// Модель представления для фильтрации отчета по игрокам
/// </summary>
/// <remarks>
/// Используется для передачи параметров фильтрации в запрос отчета
/// </remarks>
public class GetReportViewModel
{
    /// <summary>
    /// Флаг фильтрации игроков с суммой ставок выше депозитов
    /// </summary>
    [Display(Name = "Ставка выше внесения")]
    public bool BetHigherDeposits { get; init; }

    /// <summary>
    /// Текущий статус игрока
    /// </summary>
    [Display(Name = "Статус")]
    [EnumDataType(typeof(PlayerStatusForView), ErrorMessage = "Некорректный тип статуса")]
    public PlayerStatusForView? Status { get; init; }

    /// <summary>
    /// Игроки
    /// </summary>
    public PlayerReportViewModel[] Players { get; set; } = [];
}