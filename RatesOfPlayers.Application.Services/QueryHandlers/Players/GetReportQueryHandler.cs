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
/// Обработчик запроса на получение финансового отчета по игрокам
/// </summary>
/// <remarks>
/// Реализует логику выборки игроков с агрегированными финансовыми показателями
/// с учетом фильтров из запроса
/// </remarks>
/// <param name="uow">Единица работы (Unit of Work) для доступа к репозиториям</param>
/// <param name="mapper">Автомаппер для преобразования сущностей в DTO</param>
public class GetReportQueryHandler(IUnitOfWork uow, IMapper mapper)
    : IRequestHandler<GetReportQuery, IReadOnlyList<PlayerReportDto>>
{
    /// <summary>
    /// Обрабатывает запрос на получение отчета
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <param name="cancellationToken">Токен отмены для прерывания операции</param>
    /// <returns>Коллекция DTO с игроками и их финансовыми показателями</returns>
    public async Task<IReadOnlyList<PlayerReportDto>> Handle(GetReportQuery request, CancellationToken cancellationToken)
    {
        // Создание базового запроса с учетом фильтра по статусу
        var query = uow.Query<PlayerWithBalance>();

        // Применение фильтра по статусу, если он указан
        if (request.Status.HasValue)
        {
            query = query.Where(x => x.Status == request.Status);
        }

        // Применение дополнительного фильтра при необходимости
        if (request.BetHigherDeposits)
        {
            query = query.Where(p => p.TotalBets > p.TotalDeposits);
        }

        // Проекция данных в DTO и выполнение запроса
        return await query
            .ProjectTo<PlayerReportDto>(mapper.ConfigurationProvider)
            .OrderByDescending(p => p.Name)
            .ToArrayAsync(cancellationToken);
    }
}