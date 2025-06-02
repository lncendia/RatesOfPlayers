using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;
using RatesOfPlayers.Application.Abstractions.Queries.Bets;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;

namespace RatesOfPlayers.Application.Services.QueryHandlers.Bets;

/// <summary>
/// Обработчик запроса на получение ставок игрока
/// </summary>
/// <param name="uow">Единица работы</param>
public class GetBetsQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBetsQuery, IReadOnlyList<BetDto>>
{
    /// <summary>
    /// Метод обработчик запроса на получение ставок игрока
    /// </summary>
    /// <param name="request">Запрос на получение ставок игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<IReadOnlyList<BetDto>> Handle(GetBetsQuery request, CancellationToken cancellationToken)
    {
        // Получение и проекция ставок в DTO
        return await uow.Query<Bet>().Select(b => new BetDto
        {
            Id = b.Id,
            PlayerId = b.PlayerId,
            Amount = b.Amount,
            Date = b.Date,
            Prize = b.Prize,
            SettlementDate = b.SettlementDate
        }).ToArrayAsync(cancellationToken);
    }
}