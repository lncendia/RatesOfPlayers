using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;
using RatesOfPlayers.Application.Abstractions.Queries.Players;
using RatesOfPlayers.Infrastructure.Web.Players.ViewModels;

namespace RatesOfPlayers.Infrastructure.Web.Players.Mappers;

/// <summary>
/// Класс для маппинга входных моделей в команды
/// </summary>
public class PlayersMapperProfile : AutoMapper.Profile
{
    /// <summary>
    /// Маппинг входных моделей в команды
    /// </summary>
    public PlayersMapperProfile()
    {
        CreateMap<PlayerReportDto, PlayerReportViewModel>();
        CreateMap<PlayerDto, PlayerViewModel>();
        CreateMap<PlayerDto, EditPlayerViewModel>();
        CreateMap<CreatePlayerViewModel, CreatePlayerCommand>();
        CreateMap<GetReportViewModel, GetReportQuery>();
        CreateMap<EditPlayerViewModel, UpdatePlayerCommand>()
            .ForMember(x => x.Id, opt => opt.MapFrom((_, _, _, context) => context.Items["id"]));
    }
}