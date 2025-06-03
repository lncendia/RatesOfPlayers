using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Application.Abstractions.Queries.Transactions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.QueryHandlers.Transactions;

/// <summary>
/// Обработчик запроса на получение транзакции по идентификатору
/// </summary>
/// <param name="uow">Единица работы</param>
/// <param name="mapper">Маппер данных</param>
public class GetTransactionQueryHandler(
    IUnitOfWork uow,
    IMapper mapper) : IRequestHandler<GetTransactionQuery, TransactionDto>
{
    /// <summary>
    /// Метод обработчик запроса на получение данных транзакции
    /// </summary>
    /// <param name="request">Запрос на получение данных транзакции</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<TransactionDto> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        // Получаем транзакцию по идентификатору из запроса
        var transaction = await uow
            .Query<Transaction>()
            .ProjectTo<TransactionDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        // Возвращаем проекцию транзакции или выбрасываем исключение
        return transaction ?? throw new TransactionNotFoundException(request.Id); 
    }
}