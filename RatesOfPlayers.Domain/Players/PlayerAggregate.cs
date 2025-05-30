using RatesOfPlayers.Domain.Players.Enum;
using RatesOfPlayers.Domain.Players.ValueObjects;

namespace RatesOfPlayers.Domain.Players;

/// <summary>
/// Агрегат игрока.
/// </summary>
public class PlayerAggregate
{
    /// <summary>
    /// Идентификатор игрока.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public required FullName Name { get; init; }
    
    /// <summary>
    /// Баланс игрока.
    /// </summary>
    public Balance Balance { get; private set; } = new(0);
    
    /// <summary>
    /// Дата регистрации.
    /// </summary>
    public DateTime RegistrationDate { get; private set; } = DateTime.Today;
    
    /// <summary>
    /// Статус игрока.
    /// </summary>
    public Status Status { get; private set; } = Status.New;
    
    

    /// <summary>
    /// Пополнение баланса
    /// </summary>
    /// <param name="amount"></param>
    public void DepositBallance(decimal amount)
    {
        Balance += amount;
    }

    /// <summary>
    /// Снятие с баланса
    /// </summary>
    /// <param name="amount">Сумма</param>
    public void WithdrawalBallance(decimal amount)
    {
        Balance -= amount;
    }
}