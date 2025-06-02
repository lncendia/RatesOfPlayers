using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;

namespace RatesOfPlayers.Application.Abstractions.Queries.Transactions;

/// <summary>
/// Запрос на получение транзакций.
/// </summary>
public class GetTransactionsQuery : IRequest<IReadOnlyList<TransactionDto>>;