using RatesOfPlayers.Application.Abstractions.DTOs.Bets;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;
using RatesOfPlayers.Domain.Bets;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services;

public class ApplicationMapperProfile : AutoMapper.Profile
{
    public ApplicationMapperProfile()
    {
        CreateMap<PlayerWithBalance, PlayerReportDto>();
        CreateMap<PlayerWithBalance, PlayerDto>();
        CreateMap<Player, PlayerDto>();
        CreateMap<Bet, BetDto>();
        CreateMap<Transaction, TransactionDto>();
    }
}