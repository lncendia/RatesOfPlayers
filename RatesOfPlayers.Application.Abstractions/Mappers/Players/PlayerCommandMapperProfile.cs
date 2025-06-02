using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Abstractions.Mappers.Players;

/// <summary>
/// Класс для маппинга команд для работы с игроками
/// </summary>
public class PlayerCommandMapperProfile : AutoMapper.Profile
{
    /// <summary>
    /// Маппинга команд для работы с игроками
    /// </summary>
    public PlayerCommandMapperProfile()
    {
        //
        CreateMap<Player, PlayerDto>();
    }
}