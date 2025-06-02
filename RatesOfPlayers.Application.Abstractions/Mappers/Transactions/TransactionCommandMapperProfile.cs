using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Abstractions.Mappers.Transactions;

/// <summary>
/// Класс для маппинга команд для работы с транзакциями
/// </summary>
public class TransactionCommandMapperProfile : AutoMapper.Profile
{
    /// <summary>
    /// Маппинга команд для работы со ставками
    /// </summary>
    public TransactionCommandMapperProfile()
    {
        //
        CreateMap<CreateTransactionCommand, Transaction>();
        
        //
        CreateMap<Transaction, TransactionDto>();
    }
}