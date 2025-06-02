using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Bets;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Bets;

public class UpdateBetCommandHandler(
    IUnitOfWork uow) : IRequestHandler<UpdateBetCommand>
{
    /// <summary>
    /// Метод обработчик команды для обновления ставки
    /// </summary>
    /// <param name="request">Команда для обновления ставки</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(UpdateBetCommand request, CancellationToken cancellationToken)
    {
        // Получаем ставку по идентификатору из запроса
        var bet = await uow.Query<BetAggregate>().FirstOrDefaultAsync(p => p.Id == request.BetId, cancellationToken);
        
        // Если ставка не найдена, выбрасываем исключение
        if (bet is null)
            throw new BetNotFoundException(request.BetId);
        
        // Устанавливаем сумму ставки, если она указана в запросе
        if (request.Amount is not null)
            bet.Amount = request.Amount.Value;
        
        // Устанавливаем идентификатор игрока, если он указан в запросе
        if (request.PlayerId is not null)
        {
            // Асинхронно ищем игрока по идентификатору в базе данных
            var player = await uow.Query<PlayerAggregate>()
                .FirstOrDefaultAsync(p=>p.Id == request.PlayerId, cancellationToken);
            
            // Проверяем, найден ли игрок, и выбрасываем исключение, если нет
            if (player is null)
                throw new PlayerNotFoundException(request.PlayerId.Value);
            
            // Устанавливаем идентификатор игрока для ставки
            bet.PlayerId = request.PlayerId.Value;
        }

        // Устанавливаем сумму выигрыша, если она указан в запросе
        if (request.Prize is not null)
        {
            // Устанавливаем размер выигрыша
            bet.Prize = request.Prize;
            
            // Устанавливаем дату расчёта
            bet.SettlementDate = DateTime.Today;
        }

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}