using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;

namespace RatesOfPlayers.Application.Abstractions.Queries.Transactions;

public class GetTransactionsQuery : IRequest<IReadOnlyList<TransactionDto>>;