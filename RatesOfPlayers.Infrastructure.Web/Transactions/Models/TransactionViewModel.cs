namespace RatesOfPlayers.Infrastructure.Web.Transactions.Models;

/// <summary>
/// 
/// </summary>
public class TransactionViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public required long PlayerId { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    public required decimal Amount { get; init; }
    
    /// <summary>
    /// 
    /// </summary>
    public required DateTime Date { get; init; }
}