using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;
using RatesOfPlayers.Application.Abstractions.Queries.Transactions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.QueryHandlers.Transactions;

/// <summary>
/// Обработчик запроса на получение транзакций игрока
/// </summary>
/// <param name="uow">Единица работы</param>
/// <param name="mapper">Маппер данных</param>
public class GetTransactionsQueryHandler(
    IUnitOfWork uow,
    IMapper mapper) : IRequestHandler<GetTransactionsQuery, IReadOnlyList<TransactionDto>>
{
    /// <summary>
    /// Метод обработчик запроса на получение транзакций игрока
    /// </summary>
    /// <param name="request">Запрос на получение транзакций игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<IReadOnlyList<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        // Получение и проекций транзакций в DTO
        return await uow.Query<Transaction>()
            .Select(b => mapper.Map<TransactionDto>(b))
            .ToArrayAsync(cancellationToken);
    }
}