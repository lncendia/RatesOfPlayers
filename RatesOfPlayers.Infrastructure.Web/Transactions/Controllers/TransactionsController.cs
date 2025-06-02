using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.Queries.Transactions;
using RatesOfPlayers.Infrastructure.Web.Transactions.ViewModels;

namespace RatesOfPlayers.Infrastructure.Web.Transactions.Controllers;

/// <summary>
/// Контроллер для управления транзакциями (CRUD-операции)
/// </summary>
/// <param name="mediator">Медиатор для обработки CQRS-запросов</param>
/// <param name="mapper">Автомаппер для преобразования моделей</param>
public class TransactionsController(ISender mediator, IMapper mapper) : Controller
{
    /// <summary>
    /// Отображает список всех транзакций
    /// </summary>
    /// <returns>Представление со списком транзакций</returns>
    public async Task<ActionResult> Index()
    {
        // Создание запроса на получение списка транзакций
        var query = new GetTransactionsQuery();
        
        // Отправка запроса через медиатор
        var transactions = await mediator.Send(query);
        
        // Преобразование данных в ViewModel
        var viewModel = mapper.Map<IEnumerable<TransactionViewModel>>(transactions);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Отображает детальную информацию об транзакции
    /// </summary>
    /// <param name="id">ID транзакции</param>
    /// <returns>Представление с деталями транзакции</returns>
    public async Task<ActionResult> Details(int id)
    {
        // Создание запроса с указанным ID транзакции
        var query = new GetTransactionQuery { Id = id };
        
        // Отправка запроса через медиатор
        var transactions = await mediator.Send(query);
        
        // Преобразование данных в ViewModel
        var viewModel = mapper.Map<TransactionViewModel>(transactions);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Отображает форму создания новой транзакции
    /// </summary>
    /// <returns>Пустая форма создания</returns>
    public ActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// Обрабатывает данные формы создания транзакции
    /// </summary>
    /// <param name="model">Данные транзакции из формы</param>
    /// <returns>Перенаправление на страницу деталей при успехе, возврат формы при ошибке</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateTransactionViewModel model)
    {
        // Проверка валидности модели
        if (!ModelState.IsValid) return View(model);
        
        // Преобразование ViewModel в команду
        var command = mapper.Map<CreateTransactionCommand>(model);
        
        // Отправка команды через медиатор и получение ID нового транзакции
        var id = await mediator.Send(command);
        
        // Перенаправление на страницу деталей
        return RedirectToAction(nameof(Details), new { id });
    }

    /// <summary>
    /// Отображает форму редактирования транзакции
    /// </summary>
    /// <param name="id">ID редактируемого транзакции</param>
    /// <returns>Форма редактирования с заполненными данными</returns>
    public async Task<ActionResult> Edit(int id)
    {
        // Создание запроса с указанным ID
        var query = new GetTransactionQuery { Id = id };
        
        // Отправка запроса через медиатор
        var transactions = await mediator.Send(query);
        
        // Преобразование данных в ViewModel для редактирования
        var viewModel = mapper.Map<EditTransactionViewModel>(transactions);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Обрабатывает данные формы редактирования
    /// </summary>
    /// <param name="id">ID транзакции</param>
    /// <param name="model">Обновленные данные транзакции</param>
    /// <returns>Перенаправление на страницу деталей при успехе, возврат формы при ошибке</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, EditTransactionViewModel model)
    {
        // Проверка валидности модели
        if (!ModelState.IsValid) return View(model);
        
        // Преобразование ViewModel в команду с добавлением ID
        var command = mapper.Map<UpdateTransactionCommand>(model, opt => opt.Items.Add("id", id));
        
        // Отправка команды через медиатор
        await mediator.Send(command);
        
        // Перенаправление на страницу деталей
        return RedirectToAction(nameof(Details), new { id });
    }

    /// <summary>
    /// Отображает форму подтверждения удаления
    /// </summary>
    /// <param name="id">ID транзакции для удаления</param>
    /// <returns>Представление с подтверждением удаления</returns>
    public async Task<ActionResult> Delete(int id)
    {
        // Создание запроса с указанным ID
        var query = new GetTransactionQuery { Id = id };
        
        // Отправка запроса через медиатор
        var transactions = await mediator.Send(query);
        
        // Преобразование данных в ViewModel
        var viewModel = mapper.Map<TransactionViewModel>(transactions);
        
        // Возврат представления с данными
        return View(viewModel);
    }

    /// <summary>
    /// Обрабатывает удаление транзакции
    /// </summary>
    /// <param name="id">ID транзакции</param>
    /// <param name="_">Неиспользуемый параметр (требуется для маршрутизации)</param>
    /// <returns>Перенаправление на список транзакций</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, IFormCollection _)
    {
        // Создание команды на удаление
        var command = new DeleteTransactionCommand { Id = id };
        
        // Отправка команды через медиатор
        await mediator.Send(command);
        
        // Перенаправление на список транзакций
        return RedirectToAction(nameof(Index));
    }
}