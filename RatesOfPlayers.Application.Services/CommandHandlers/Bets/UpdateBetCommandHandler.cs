using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Bets;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Bets;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Bets;

/// <summary>
/// 
/// </summary>
/// <param name="uow"></param>
public class UpdateBetCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateBetCommand>
{
    /// <summary>
    /// Метод обработчик команды для обновления ставки
    /// </summary>
    /// <param name="request">Команда для обновления ставки</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(UpdateBetCommand request, CancellationToken cancellationToken)
    {
        // Получаем ставку по идентификатору из запроса
        var bet = await uow.Query<Bet>().FirstOrDefaultAsync(p => p.Id == request.BetId, cancellationToken);

        // Если ставка не найдена, выбрасываем исключение
        if (bet == null)
            throw new BetNotFoundException(request.BetId);

        // Устанавливаем сумму ставки, если она указана в запросе
        bet.Amount = request.Amount;

        // Устанавливаем идентификатор игрока для ставки
        bet.PlayerId = request.PlayerId;

        // Устанавливаем размер выигрыша
        bet.Prize = request.Prize;

        // Устанавливаем дату расчёта
        bet.SettlementDate = DateTime.Today;

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}