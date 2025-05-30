using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Transactions;

/// <summary>
/// Команда для удаления транзакции.
/// </summary>
public class DeleteTransactionCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор транзакции.
    /// </summary>
    public required Guid TransactionId { get; init; }
}