using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;

namespace RatesOfPlayers.Application.Abstractions.Queries.Transactions;

/// <summary>
/// Запрос на получение транзакции.
/// </summary>
public class GetTransactionQuery : IRequest<TransactionDto>
{
    /// <summary>
    /// Уникальный идентификатор транзакции.
    /// </summary>
    public required long Id { get; init; }
}