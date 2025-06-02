using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Transactions;

/// <summary>
/// Команда для создания игрока.
/// </summary>
public class CreateTransactionCommand : IRequest<Guid>
{
    /// <summary>
    /// Уникальный идентификатор игрока.
    /// </summary>
    public required Guid PlayerId { get; init; }
    
    /// <summary>
    /// Сумма транзакции.
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// Сумма транзакции.
    /// </summary>
    public required string Type { get; init; }
}