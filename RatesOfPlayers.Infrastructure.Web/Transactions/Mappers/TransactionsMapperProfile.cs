using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;
using RatesOfPlayers.Infrastructure.Web.Transactions.ViewModels;

namespace RatesOfPlayers.Infrastructure.Web.Transactions.Mappers;

/// <summary>
/// Класс для маппинга входных моделей в команды
/// </summary>
public class TransactionsMapperProfile : AutoMapper.Profile
{
    /// <summary>
    /// Маппинг входных моделей в команды
    /// </summary>
    public TransactionsMapperProfile()
    {
        CreateMap<TransactionDto, TransactionViewModel>();
        CreateMap<TransactionDto, EditTransactionViewModel>();
        CreateMap<CreateTransactionViewModel, CreateTransactionCommand>();
        CreateMap<EditTransactionViewModel, UpdateTransactionCommand>()
            .ForMember(x => x.Id, opt => opt.MapFrom((_, _, _, context) => context.Items["id"]));
    }
}