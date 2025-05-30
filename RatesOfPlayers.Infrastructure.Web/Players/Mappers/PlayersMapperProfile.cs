using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Domain.Players.ValueObjects;
using RatesOfPlayers.Infrastructure.Web.Players.InputModels;

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
        // Карта для CreatePlayerInputModel в FullName
        CreateMap<PlayerInputModel, FullName>();
        
        // Карта для CreatePlayerInputModel в CreatePlayerCommand
        CreateMap<PlayerInputModel, CreatePlayerCommand>()
            .ForMember(dest => dest.FullName, 
                opt =>
                    opt.MapFrom(src => src));;
        
        // Карта для PlayerInputModel в UpdatePlayerCommand
        CreateMap<PlayerInputModel, UpdatePlayerCommand>().ForMember(dest => dest.PlayerId,
            opt => 
                opt.MapFrom((_, _, _, context) => context.Items["PlayerId"]));
    }
}