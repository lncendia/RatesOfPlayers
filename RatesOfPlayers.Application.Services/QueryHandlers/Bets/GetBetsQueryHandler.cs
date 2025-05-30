using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;
using RatesOfPlayers.Application.Abstractions.DTOs.Common;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Application.Abstractions.Queries.Bets;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.QueryHandlers.Bets;

/// <summary>
/// Обработчик запроса на получение ставок игрока
/// </summary>
/// <param name="uow">Единица работы</param>
public class GetBetsQueryHandler(
    IUnitOfWork uow) : IRequestHandler<GetBetsQuery, CountResult<BetDto>>
{
    /// <summary>
    /// Метод обработчик запроса на получение ставок игрока
    /// </summary>
    /// <param name="request">Запрос на получение ставок игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<CountResult<BetDto>> Handle(GetBetsQuery request, CancellationToken cancellationToken)
    {
        // Получаем игрока по идентификатору из запроса
        var player = await uow.Query<PlayerAggregate>()
            .FirstOrDefaultAsync(p => p.Id == request.PlayerId, cancellationToken);
        
        // Если игрок не найден, выбрасываем исключение
        if (player == null)
            throw new PlayerNotFoundException(request.PlayerId);
        
        // Фильтрация ставок по игроку
        var betsQueryable = uow.Query<BetAggregate>().Where(b => b.PlayerId == request.PlayerId);
        
        // Подсчёт общего количества ставок
        var count = await betsQueryable.CountAsync(cancellationToken);
        
        // Если ставок нет — вернуть пустой результат
        if (count == 0)
            return CountResult<BetDto>.NoValues();

        // Получение и проекция ставок в DTO
        var bets = await betsQueryable.Select(b => new BetDto
        {
            Id = b.Id,
            PlayerId = b.PlayerId,
            Amount = b.Amount,
            Date = b.Date,
            Prize = b.Prize,
            SettlementDate = b.SettlementDate
        }).ToArrayAsync(cancellationToken);

        // Возврат списка и общего количества
        return new CountResult<BetDto>
        {
            List = bets,
            TotalCount = count
        };
    }
}