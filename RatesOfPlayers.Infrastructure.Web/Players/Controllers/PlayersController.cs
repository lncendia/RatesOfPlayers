using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;
using RatesOfPlayers.Application.Abstractions.Queries.Players;
using RatesOfPlayers.Infrastructure.Web.Players.ViewModels;

namespace RatesOfPlayers.Infrastructure.Web.Players.Controllers;

/// <summary>
/// Контроллер управления игроками
/// </summary>
/// <param name="mediator">Медиатор</param>
/// <param name="mapper">Маппер</param>
public class PlayersController(ISender mediator, IMapper mapper) : Controller
{
    /// <summary>
    /// Создаёт игрока.
    /// </summary>
    /// <param name="model">Модель данных игрока.</param>
    /// <param name="token">Токен для отмены операции.</param> 
    /// <response code="200">Команда успешно выполнена</response> 
    /// <response code="400">Некорректные входные данные или невалидная команда</response>
    /// <response code="500">Возникла ошибка на сервере</response>
    [HttpPost]
    public async Task CreatePlayer(PlayerViewModel model, CancellationToken token)
    {
        // Создаем команду
        var command = mapper.Map<CreatePlayerCommand>(model);

        // Отправляем команду медиатору на создание игрока
        await mediator.Send(command, token);
    }
    
    /// <summary>
    /// Изменяет игрока.
    /// </summary>
    /// <param name="playerId">Идентификатор игрока.</param>
    /// <param name="model">Модель данных игрока.</param>
    /// <param name="token">Токен для отмены операции.</param> 
    /// <response code="200">Команда успешно выполнена</response> 
    /// <response code="400">Некорректные входные данные или невалидная команда</response>
    /// <response code="500">Возникла ошибка на сервере</response>
    [HttpPut]
    public async Task UpdatePlayer(long PlayerId, PlayerViewModel model, CancellationToken token)
    {
        // Создаем команду
        var command = mapper.Map<UpdatePlayerCommand>(model, 
            opt => opt.Items["PlayerId"] = playerId);

        // Отправляем команду медиатору на обновление данных игрока
        await mediator.Send(command, token);
    }
    
    /// <summary>
    /// Получает игрока.
    /// </summary>
    /// <param name="playerId">Идентификатор игрока.</param>
    /// <param name="token">Токен для отмены операции.</param> 
    /// <response code="200">Команда успешно выполнена</response> 
    /// <response code="400">Некорректные входные данные или невалидная команда</response>
    /// <response code="500">Возникла ошибка на сервере</response>
    [HttpGet]
    public async Task<PlayerDto> GetPlayer(long PlayerId, CancellationToken token)
    {
        // Создаем запрос
        var query = new GetPlayerQuery
        {
            Id = playerId
        };

        // Отправляем запрос медиатору на получение игрока
        return await mediator.Send(query, token);
    }
}