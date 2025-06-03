using MediatR;
using Microsoft.EntityFrameworkCore;
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
public class CreateBetCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateBetCommand, long>
{
    /// <summary>
    /// Метод обработчик команды для создания ставки
    /// </summary>
    /// <param name="request">Команда для создания ставки</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<long> Handle(CreateBetCommand request, CancellationToken cancellationToken)
    {
        // Проверяем существование игрока
        var playerExists = await uow.Query<Player>()
            .AnyAsync(p => p.Id == request.PlayerId, cancellationToken);
        
        if (!playerExists)
            throw new PlayerNotFoundException(request.PlayerId);
        
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