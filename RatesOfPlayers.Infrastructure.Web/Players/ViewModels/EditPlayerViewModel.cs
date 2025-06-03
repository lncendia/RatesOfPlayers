using System.ComponentModel.DataAnnotations;
using RatesOfPlayers.Infrastructure.Web.Players.Enums;

namespace RatesOfPlayers.Infrastructure.Web.Players.ViewModels;

/// <summary>
/// Модель для редактирования игрока
/// </summary>
public class EditPlayerViewModel
{
    /// <summary>
    /// Полное имя игрока
    /// </summary>
    [Display(Name = "Имя игрока")]
    [Required(ErrorMessage = "Имя игрока обязательно для заполнения")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 100 символов")]
    [RegularExpression(@"^[А-ЯЁ][а-яё]+(-[А-ЯЁ][а-яё]+)?\s[А-ЯЁ]\.[А-ЯЁ]\.$", 
        ErrorMessage = "Формат: 'Фамилия И.О.' или 'Фамилия-Фамилия И.О.'")]
    public required string Name { get; init; }

    /// <summary>
    /// Текущий статус игрока
    /// </summary>
    [Display(Name = "Статус")]
    [EnumDataType(typeof(PlayerStatusForView), ErrorMessage = "Некорректный тип статуса")]
    [Required(ErrorMessage = "Необходимо указать статус игрока")]
    public PlayerStatusForView Status { get; init; }
}