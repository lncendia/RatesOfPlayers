using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Common;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;

namespace RatesOfPlayers.Application.Abstractions.Queries.Transactions;

public class GetTransactionsQuery : IRequest<CountResult<TransactionDto>>
{
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public required Guid PlayerId { get; init; }
}