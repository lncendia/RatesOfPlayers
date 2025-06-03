using RatesOfPlayers.Application.Abstractions.Commands.Bets;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;
using RatesOfPlayers.Infrastructure.Web.Bets.ViewModels;

namespace RatesOfPlayers.Infrastructure.Web.Bets.Mappers;

public class BetsMapperProfile : AutoMapper.Profile
{
    /// <summary>
    /// Маппинг входных моделей в команды
    /// </summary>
    public BetsMapperProfile()
    {
        CreateMap<BetDto, BetViewModel>();
        CreateMap<BetDto, EditBetViewModel>();
        CreateMap<CreateBetViewModel, CreateBetCommand>();
        CreateMap<EditBetViewModel, UpdateBetCommand>()
            .ForMember(x => x.Id, opt => opt.MapFrom((_, _, _, context) => context.Items["id"]));
    }
}