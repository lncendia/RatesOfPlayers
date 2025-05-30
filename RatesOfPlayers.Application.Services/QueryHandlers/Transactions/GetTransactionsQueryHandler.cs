using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.DTOs.Common;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Application.Abstractions.Queries.Transactions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.QueryHandlers.Transactions;

/// <summary>
/// Обработчик запроса на получение транзакций игрока
/// </summary>
/// <param name="uow">Единица работы</param>
public class GetTransactionsQueryHandler(
    IUnitOfWork uow) : IRequestHandler<GetTransactionsQuery, CountResult<TransactionDto>>
{
    /// <summary>
    /// Метод обработчик запроса на получение транзакций игрока
    /// </summary>
    /// <param name="request">Запрос на получение транзакций игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<CountResult<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        // Получаем игрока по идентификатору из запроса
        var player = await uow.Query<PlayerAggregate>()
            .FirstOrDefaultAsync(p => p.Id == request.PlayerId, cancellationToken);
        
        // Если игрок не найден, выбрасываем исключение
        if (player == null)
            throw new PlayerNotFoundException(request.PlayerId);
        
        // Фильтрация транзакций по игроку
        var betsQueryable = uow.Query<TransactionAggregate>().Where(b => b.PlayerId == request.PlayerId);

        // Подсчёт общего количества транзакций
        var count = await betsQueryable.CountAsync(cancellationToken);
        
        // Если транзакций нет — вернуть пустой результат
        if (count == 0)
            return CountResult<TransactionDto>.NoValues();

        // Получение и проекция транзакций в DTO
        var bets = await betsQueryable.Select(b => new TransactionDto
        {
            Id = b.Id,
            PlayerId = b.PlayerId,
            Amount = b.Amount,
            Date = b.Date,
            Type = b.Type.ToString()
        }).ToArrayAsync(cancellationToken);

        // Возврат списка и общего количества
        return new CountResult<TransactionDto>
        {
            List = bets,
            TotalCount = count
        };
    }
}