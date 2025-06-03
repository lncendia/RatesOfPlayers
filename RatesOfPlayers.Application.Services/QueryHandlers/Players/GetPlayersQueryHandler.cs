using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;
using RatesOfPlayers.Application.Abstractions.Queries.Players;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.QueryHandlers.Players;

/// <summary>
/// Обработчик запроса на получение данных игроков
/// </summary>
/// <param name="uow">Единица работы</param>
public class GetPlayersQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetPlayersQuery, IReadOnlyList<PlayerDto>>
{
    /// <summary>
    /// Метод обработчик запроса на получение ставок игроков
    /// </summary>
    /// <param name="request">Запрос на получение ставок игроков</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<IReadOnlyList<PlayerDto>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        // Получение и проекция игроков в DTO
        return await uow.Query<PlayerWithBalance>()
            .ProjectTo<PlayerDto>(mapper.ConfigurationProvider)
            .OrderByDescending(p => p.Name)
            .ToArrayAsync(cancellationToken);
    }
}