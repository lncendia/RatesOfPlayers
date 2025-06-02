using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.Queries.Players;
using RatesOfPlayers.Infrastructure.Web.Players.ViewModels;

namespace RatesOfPlayers.Infrastructure.Web.Players.Controllers;

/// <summary>
/// Контроллер для управления игроками (CRUD-операции)
/// </summary>
/// <param name="mediator">Медиатор для обработки CQRS-запросов</param>
/// <param name="mapper">Автомаппер для преобразования моделей</param>
public class PlayersController(ISender mediator, IMapper mapper) : Controller
{
    /// <summary>
    /// Отображает список всех игроков
    /// </summary>
    /// <returns>Представление со списком игроков</returns>
    public async Task<ActionResult> Index()
    {
        // Создание запроса на получение списка игроков
        var query = new GetPlayersQuery();
        
        // Отправка запроса через медиатор
        var players = await mediator.Send(query);
        
        // Преобразование данных в ViewModel
        var viewModel = mapper.Map<IEnumerable<PlayerViewModel>>(players);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Отображает детальную информацию об игроке
    /// </summary>
    /// <param name="id">ID игрока</param>
    /// <returns>Представление с деталями игрока</returns>
    public async Task<ActionResult> Details(int id)
    {
        // Создание запроса с указанным ID игрока
        var query = new GetPlayerQuery { Id = id };
        
        // Отправка запроса через медиатор
        var players = await mediator.Send(query);
        
        // Преобразование данных в ViewModel
        var viewModel = mapper.Map<PlayerViewModel>(players);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Отображает форму создания нового игрока
    /// </summary>
    /// <returns>Пустая форма создания</returns>
    public ActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// Обрабатывает данные формы создания игрока
    /// </summary>
    /// <param name="model">Данные игрока из формы</param>
    /// <returns>Перенаправление на страницу деталей при успехе, возврат формы при ошибке</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreatePlayerViewModel model)
    {
        // Проверка валидности модели
        if (!ModelState.IsValid) return View(model);
        
        // Преобразование ViewModel в команду
        var command = mapper.Map<CreatePlayerCommand>(model);
        
        // Отправка команды через медиатор и получение ID нового игрока
        var id = await mediator.Send(command);
        
        // Перенаправление на страницу деталей
        return RedirectToAction(nameof(Details), new { id });
    }

    /// <summary>
    /// Отображает форму редактирования игрока
    /// </summary>
    /// <param name="id">ID редактируемого игрока</param>
    /// <returns>Форма редактирования с заполненными данными</returns>
    public async Task<ActionResult> Edit(int id)
    {
        // Создание запроса с указанным ID
        var query = new GetPlayerQuery { Id = id };
        
        // Отправка запроса через медиатор
        var players = await mediator.Send(query);
        
        // Преобразование данных в ViewModel для редактирования
        var viewModel = mapper.Map<EditPlayerViewModel>(players);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Обрабатывает данные формы редактирования
    /// </summary>
    /// <param name="id">ID игрока</param>
    /// <param name="model">Обновленные данные игрока</param>
    /// <returns>Перенаправление на страницу деталей при успехе, возврат формы при ошибке</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, EditPlayerViewModel model)
    {
        // Проверка валидности модели
        if (!ModelState.IsValid) return View(model);
        
        // Преобразование ViewModel в команду с добавлением ID
        var command = mapper.Map<UpdatePlayerCommand>(model, opt => opt.Items.Add("id", id));
        
        // Отправка команды через медиатор
        await mediator.Send(command);
        
        // Перенаправление на страницу деталей
        return RedirectToAction(nameof(Details), new { id });
    }

    /// <summary>
    /// Отображает форму подтверждения удаления
    /// </summary>
    /// <param name="id">ID игрока для удаления</param>
    /// <returns>Представление с подтверждением удаления</returns>
    public async Task<ActionResult> Delete(int id)
    {
        // Создание запроса с указанным ID
        var query = new GetPlayerQuery { Id = id };
        
        // Отправка запроса через медиатор
        var players = await mediator.Send(query);
        
        // Преобразование данных в ViewModel
        var viewModel = mapper.Map<PlayerViewModel>(players);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Обрабатывает удаление игрока
    /// </summary>
    /// <param name="id">ID игрока</param>
    /// <param name="_">Неиспользуемый параметр (требуется для маршрутизации)</param>
    /// <returns>Перенаправление на список игроков</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection _)
    {
        // Создание команды на удаление
        var command = new DeletePlayerCommand { Id = id };
        
        // Отправка команды через медиатор
        await mediator.Send(command);
        
        // Перенаправление на список игроков
        return RedirectToAction(nameof(Index));
    }
}