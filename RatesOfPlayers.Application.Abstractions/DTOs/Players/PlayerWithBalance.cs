using RatesOfPlayers.Domain.Players.Enums;

namespace RatesOfPlayers.Application.Abstractions.DTOs.Players;

/// <summary>
/// Расширенная модель игрока с финансовой информацией
/// </summary>
/// <remarks>
/// Наследует базовые свойства от класса Player и добавляет финансовые показатели
/// </remarks>
public class PlayerWithBalance
{
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public long Id { get; init; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public DateTime RegistrationDate { get; init; }

    /// <summary>
    /// Статус игрока.
    /// </summary>
    public PlayerStatus Status { get; init; }

    /// <summary>
    /// Общая сумма всех ставок игрока
    /// </summary>
    public required decimal TotalBets { get; init; }

    /// <summary>
    /// Общая сумма всех депозитов игрока
    /// </summary>
    public required decimal TotalDeposits { get; init; }

    /// <summary>
    /// Текущий баланс игрока
    /// </summary>
    public required decimal Balance { get; init; }
}