using AutoMapper;
using MediatR;
using RatesOfPlayers.Application.Abstractions.Commands.Bets;
using RatesOfPlayers.Application.Abstractions.DTOs.Bets;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Bets;

/// <summary>
/// Обработчик команды для создания ставки
/// </summary>
/// <param name="uow">Единица работы</param>
/// <param name="mapper">Маппер данных</param>
public class CreateBetCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<CreateBetCommand, long>
{
    /// <summary>
    /// Метод обработчик команды для создания ставки
    /// </summary>
    /// <param name="request">Команда для создания ставки</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<long> Handle(CreateBetCommand request, CancellationToken cancellationToken)
    {
        // Создаём Модель ставки
        var bet = new Bet
        {
            PlayerId = request.PlayerId,
            Amount = request.Amount,
            Date = request.Date,
            Prize = request.Prize,
            SettlementDate = request.SettlementDate
        };

        // Добавляем транзакцию в базу данных
        await uow.AddAsync(bet, cancellationToken);
        
        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
        
        // Возвращаем идентификатор созданной ставки
        return bet.Id;
    }
}