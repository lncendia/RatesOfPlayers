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
    [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s\.\-]+$", ErrorMessage = "Допустимы только буквы, пробелы, точки и дефисы")]
    public required string Name { get; init; }

    /// <summary>
    /// Текущий статус игрока
    /// </summary>
    [Display(Name = "Статус")]
    [Required(ErrorMessage = "Необходимо указать статус игрока")]
    public PlayerStatusForView Status { get; init; }
}