namespace RatesOfPlayers.Domain.Players.ValueObjects;

/// <summary>
/// Представляет баланс счета.
/// </summary>
public class Balance
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="amount">Остаток</param>
    /// <exception cref="ArgumentException">Вызывается, если остаток меньше нуля</exception>
    public Balance(decimal amount)
    {
        // Если остаток меньше нуля - вызываем исключение
        if (amount < 0) throw new ArgumentException("Amount can't be less then zero", nameof(amount));
        
        // Устанавливаем остаток
        Amount = amount;
    }

    /// <summary>
    /// Получает или задает текущий остаток на балансе.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Выполняет операцию сложения текущего баланса и указанного значения.
    /// </summary>
    /// <param name="balance">Текущий баланс.</param>
    /// <param name="amount">Значение, которое нужно прибавить к балансу.</param>
    /// <returns>Новый баланс, представляющий собой сумму текущего баланса и указанного значения.</returns>
    public static Balance operator +(Balance balance, decimal amount)
    {
        return new Balance(balance.Amount + amount);
    }

    /// <summary>
    /// Выполняет операцию вычитания указанного значения из текущего баланса.
    /// </summary>
    /// <param name="balance">Текущий баланс.</param>
    /// <param name="amount">Значение, которое нужно вычесть из баланса.</param>
    /// <returns>Новый баланс, представляющий собой разность текущего баланса и указанного значения.</returns>
    public static Balance operator -(Balance balance, decimal amount)
    {
        return new Balance(balance.Amount - amount);
    }
}