using AutoMapper;
using AutoMapper.QueryableExtensions;
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
/// <param name="mapper">Маппер данных</param>
public class GetPlayerQueryHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<GetPlayerQuery, PlayerDto>
{
    /// <summary>
    /// Метод обработчик запроса на получение данных игрока
    /// </summary>
    /// <param name="request">Запрос на получение данных игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<PlayerDto> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        // Получаем игрока по идентификатору из запроса
        var player = await uow
            .Query<PlayerWithBalance>()
            .ProjectTo<PlayerDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        // Возвращаем проекцию игрока или выбрасываем исключение
        return player ?? throw new PlayerNotFoundException(request.Id); 
    }
}