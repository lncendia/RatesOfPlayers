using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RatesOfPlayers.Application.Abstractions.Commands.Bets;
using RatesOfPlayers.Application.Abstractions.Queries.Bets;
using RatesOfPlayers.Infrastructure.Web.Bets.ViewModels;

namespace RatesOfPlayers.Infrastructure.Web.Bets.Controllers;

/// <summary>
/// Контроллер для управления ставками (CRUD-операции)
/// </summary>
/// <param name="mediator">Медиатор для обработки CQRS-запросов</param>
/// <param name="mapper">Автомаппер для преобразования моделей</param>
public class BetsController(ISender mediator, IMapper mapper) : Controller
{
    /// <summary>
    /// Отображает список всех ставок
    /// </summary>
    /// <returns>Представление со списком ставок</returns>
    public async Task<ActionResult> Index()
    {
        // Создание запроса на получение списка ставок
        var query = new GetBetsQuery();
        
        // Отправка запроса через медиатор
        var bets = await mediator.Send(query);

        // Преобразование данных в ViewModel
        var viewModel = mapper.Map<IEnumerable<BetViewModel>>(bets);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Отображает детальную информацию об ставке
    /// </summary>
    /// <param name="id">ID ставки</param>
    /// <returns>Представление с деталями ставки</returns>
    public async Task<ActionResult> Details(int id)
    {
        // Создание запроса с указанным ID ставки
        var query = new GetBetQuery { Id = id };
        
        // Отправка запроса через медиатор
        var bet = await mediator.Send(query);
        
        // Преобразование данных в ViewModel
        var viewModel  = mapper.Map<BetViewModel>(bet);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Отображает форму создания новой ставки
    /// </summary>
    /// <returns>Пустая форма создания</returns>
    public ActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// Обрабатывает данные формы создания ставки
    /// </summary>
    /// <param name="model">Данные ставки из формы</param>
    /// <returns>Перенаправление на страницу деталей при успехе, возврат формы при ошибке</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateBetViewModel model)
    {
        // Проверка валидности модели
        if (!ModelState.IsValid) return View(model);

        // Преобразование ViewModel в команду
        var command = mapper.Map<CreateBetCommand>(model);

        // Отправка команды через медиатор и получение ID нового ставки
        var id = await mediator.Send(command);
        
        // Перенаправление на страницу деталей
        return RedirectToAction(nameof(Details), new { id });
    }

    /// <summary>
    /// Отображает форму редактирования ставки
    /// </summary>
    /// <param name="id">ID редактируемой ставки</param>
    /// <returns>Форма редактирования с заполненными данными</returns>
    public async Task<ActionResult> Edit(int id)
    {
        // Создание запроса с указанным ID
        var query = new GetBetQuery { Id = id };
        
        // Отправка запроса через медиатор
        var bet = await mediator.Send(query);
        
        // Преобразование данных в ViewModel для редактирования
        var viewModel = mapper.Map<EditBetViewModel>(bet);
        
        return View(viewModel);
    }

    /// <summary>
    /// Обрабатывает данные формы редактирования
    /// </summary>
    /// <param name="id">ID ставки</param>
    /// <param name="model">Обновленные данные ставки</param>
    /// <returns>Перенаправление на страницу деталей при успехе, возврат формы при ошибке</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, EditBetViewModel model)
    {
        // Проверка валидности модели
        if (!ModelState.IsValid) return View(model);
        
        // Преобразование ViewModel в команду с добавлением ID
        var command = mapper.Map<UpdateBetCommand>(model, opt => opt.Items.Add("id", id));
        
        // Отправка команды через медиатор
        await mediator.Send(command);
        
        // Перенаправление на страницу деталей
        return RedirectToAction(nameof(Details), new { id });
    }
    
    /// <summary>
    /// Отображает форму подтверждения удаления
    /// </summary>
    /// <param name="id">ID ставки для удаления</param>
    /// <returns>Представление с подтверждением удаления</returns>
    public async Task<ActionResult> Delete(int id)
    {
        // Создание запроса с указанным ID
        var query = new GetBetQuery { Id = id };
        
        // Отправка запроса через медиатор
        var bet = await mediator.Send(query);
        
        // Преобразование данных в ViewModel
        var viewModel = mapper.Map<BetViewModel>(bet);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Обрабатывает удаление ставки
    /// </summary>
    /// <param name="id">ID ставки</param>
    /// <param name="_">Неиспользуемый параметр (требуется для маршрутизации)</param>
    /// <returns>Перенаправление на список ставок</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(long id, IFormCollection _)
    {
        // Создание команды на удаление
        var command = new DeleteBetCommand { Id = id };
        
        // Отправка команды через медиатор
        await mediator.Send(command);
          
        // Перенаправление на список ставок  
        return RedirectToAction(nameof(Index));
    }
}