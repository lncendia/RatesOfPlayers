using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Application.Abstractions.Queries.Players;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.QueryHandlers.Players;

/// <summary>
/// Обработчик запроса на получение данных игрока
/// </summary>
/// <param name="uow">Единица работы</param>
public class GetPlayerQueryHandler(
    IUnitOfWork uow) : IRequestHandler<GetPlayerQuery, PlayerDto>
{
    /// <summary>
    /// Метод обработчик запроса на получение данных игрока
    /// </summary>
    /// <param name="request">Запрос на получение данных игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<PlayerDto> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        // Получаем игрока по идентификатору из запроса
        var player = await uow.Query<Player>().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        // Если игрок не найден, выбрасываем исключение
        if (player == null)
            throw new PlayerNotFoundException(request.Id);

        // Возвращаем идентификатор созданного игрока
        return new PlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            Amount = 0,
            RegistrationDate = player.RegistrationDate,
            Status = player.Status.ToString()
        };
    }
}