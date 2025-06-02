using MediatR;
using RatesOfPlayers.Application.Abstractions.Commands.Bets;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Bets;

/// <summary>
/// Обработчик команды для создания ставки
/// </summary>
/// <param name="uow">Единица работы</param>
public class CreateBetCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateBetCommand, Guid>
{
    /// <summary>
    /// Метод обработчик команды для создания ставки
    /// </summary>
    /// <param name="request">Команда для создания ставки</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<Guid> Handle(CreateBetCommand request, CancellationToken cancellationToken)
    {
        // Создаём агрегат ставки
        var bet = new Bet
        {
            PlayerId = request.PlayerId,
            Amount = request.Amount,
            Date = request.Date ?? DateTime.Today,
            Prize = request.Prize,
            SettlementDate = request.SettlementDate,
        };

        // Добавляем транзакцию в базу данных
        await uow.AddAsync(bet, cancellationToken);
        
        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
        
        return bet.Id;
    }
}