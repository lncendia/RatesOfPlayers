using MediatR;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;
using RatesOfPlayers.Domain.Players.Enums;

namespace RatesOfPlayers.Application.Abstractions.Queries.Players;

/// <summary>
/// Запрос на получение отчёта по игрокам
/// </summary>
/// <remarks>
/// Используется для получения списка игроков с финансовыми показателями,
/// отфильтрованного по указанным критериям
/// </remarks>
public class GetReportQuery : IRequest<IReadOnlyList<PlayerReportDto>>
{
    /// <summary>
    /// Статус игрока для фильтрации
    /// </summary>
    /// <value>Одно из значений перечисления PlayerStatus</value>
    public PlayerStatus? Status { get; init; }
    
    /// <summary>
    /// Флаг фильтрации игроков с суммой ставок выше депозитов
    /// </summary>
    /// <value>
    /// true - только игроки, у которых сумма ставок превышает сумму депозитов;
    /// false - без дополнительной фильтрации
    /// </value>
    /// <example>true</example>
    public required bool BetHigherDeposits { get; init; }
}