using AutoMapper;
using AutoMapper.QueryableExtensions;
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
/// <param name="mapper">Маппер данных</param>
public class GetBetsQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetBetsQuery, IReadOnlyList<BetDto>>
{
    /// <summary>
    /// Метод обработчик запроса на получение ставок игрока
    /// </summary>
    /// <param name="request">Запрос на получение ставок игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<IReadOnlyList<BetDto>> Handle(GetBetsQuery request, CancellationToken cancellationToken)
    {
        // Получение и проекция ставок в DTO
        return await uow.Query<Bet>()
            .ProjectTo<BetDto>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
    }
}