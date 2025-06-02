using RatesOfPlayers.Application.Abstractions.Commands.Bets;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;
using RatesOfPlayers.Domain.Bets;

namespace RatesOfPlayers.Application.Abstractions.Mappers.Bets;

/// <summary>
/// Класс для маппинга команд для работы со ставками
/// </summary>
public class BetCommandMapperProfile : AutoMapper.Profile
{
    /// <summary>
    /// Маппинга команд для работы со ставками
    /// </summary>
    public BetCommandMapperProfile()
    {
        //
        CreateMap<CreateBetCommand, Bet>();
        
        //
        CreateMap<Bet, BetDto>();
    }
}