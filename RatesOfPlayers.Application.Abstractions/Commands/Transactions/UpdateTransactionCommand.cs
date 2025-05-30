using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Transactions;

/// <summary>
/// Команда для изменения транзакции.
/// </summary>
public class UpdateTransactionCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор транзакции.
    /// </summary>
    public required Guid TransactionId { get; init; }
}