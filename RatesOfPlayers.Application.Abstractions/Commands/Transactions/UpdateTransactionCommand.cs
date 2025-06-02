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
    
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public Guid? PlayerId { get; init; }
    
    /// <summary>
    /// Сумма транзакции.
    /// </summary>
    public decimal? Amount { get; init; }
    
    /// <summary>
    /// Тип транзакции.
    /// </summary>
    public string? Type { get; init; }
}