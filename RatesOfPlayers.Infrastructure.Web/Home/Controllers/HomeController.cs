using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Infrastructure.Web.Home.ViewModels;

namespace RatesOfPlayers.Infrastructure.Web.Home.Controllers;

/// <summary>
/// Контроллер домашней страницы.
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    /// Логгер.
    /// </summary>
    private readonly ILogger<HomeController> _logger;
    
    /// <summary>
    /// Конструктор класса HomeController.
    /// </summary>
    /// <param name="logger">Логгер.</param>
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// Действие для отображения домашней страницы.
    /// </summary>
    /// <returns>Результат действия.</returns>
    public IActionResult Index()
    {
        return View();
    }
    
    /// <summary>
    /// Показывает страницу ошибки.
    /// </summary>
    /// <returns>Результат действия.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(string? errorId)
    {
        // Получаем контекст ошибки из HttpContext.
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

        // Если контекст ошибки существует.
        if (context != null)
        {
            // Получаем исключение из контекста ошибки.
            var requestException = context.Error;

            // Логгируем исключение
            _logger.LogError(requestException, "Ошибка при обработке запроса");
            
            // Определяем ресурс для отображения сообщения об ошибке на основе типа исключения.
            string? resource;
            switch (requestException)
            {
                case PlayerNotFoundException x:
                    resource = $"Игрок с идентификатором {x.PlayerId} не найден."; 
                    break;
                
                case BetNotFoundException x: 
                    resource = $"Ставка c идентификатором {x.BetId} не найдена."; 
                    break;
                case TransactionNotFoundException x: 
                    resource = $"Транзакция с идентификатором {x.TransactionId} не найдена."; 
                    break;
                default:
                    resource = "Возникла ошибка при обработке запроса.";
                    break;
            }
            // Возвращаем представление с моделью ErrorViewModel, передавая сообщение об ошибке и идентификатор запроса.
            return View(new ErrorViewModel
            {
                // Сообщение с ошибкой
                Message = resource,

                // Идентификатор запроса
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,

                // Url возврата
                ReturnUrl = "/"
            });
        }
        // Возвращаем ответ Ok.
        return Ok();
    }
}