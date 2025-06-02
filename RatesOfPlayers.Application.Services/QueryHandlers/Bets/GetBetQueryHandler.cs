using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Application.Abstractions.Queries.Bets;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;

namespace RatesOfPlayers.Application.Services.QueryHandlers.Bets;

/// <summary>
/// Обработчик запроса на получение ставки по идентификатору
/// </summary>
/// <param name="uow">Единица работы</param>
/// <param name="mapper">Маппер данных</param>
public class GetBetQueryHandler(
    IUnitOfWork uow,
    IMapper mapper) : IRequestHandler<GetBetQuery, BetDto>
{
    /// <summary>
    /// Метод обработчик запроса на получение данных ставки
    /// </summary>
    /// <param name="request">Запрос на получение данных ставки</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<BetDto> Handle(GetBetQuery request, CancellationToken cancellationToken)
    {
        // Получаем ставку по идентификатору из запроса
        var bet = await uow.Query<Bet>().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        // Если ставка не найдена, выбрасываем исключение
        if (bet == null)
            throw new BetNotFoundException(request.Id);

        // Возвращаем проекцию ставки в DTO
        return mapper.Map<BetDto>(bet); 
    }
}