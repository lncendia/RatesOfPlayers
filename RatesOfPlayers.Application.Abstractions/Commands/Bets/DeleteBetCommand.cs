using MediatR;

namespace RatesOfPlayers.Application.Abstractions.Commands.Bets;

/// <summary>
/// Команда для удаления ставки.
/// </summary>
public class DeleteBetCommand : IRequest
{
    /// <summary>
    /// Уникальный идентификатор ставки.
    /// </summary>
    public required long Id { get; init; }
}