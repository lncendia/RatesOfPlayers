using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Transactions;
using RatesOfPlayers.Domain.Transactions.ValueObjects;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Transactions;

/// <summary>
/// Обработчик команды для обновления транзакции
/// </summary>
/// <param name="uow">Единица работы</param>
public class UpdateTransactionCommandHandler(
    IUnitOfWork uow) : IRequestHandler<UpdateTransactionCommand>
{
    /// <summary>
    /// Метод обработчик команды для обновления транзакции
    /// </summary>
    /// <param name="request">Команда для обновления транзакции</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        // Получаем транзакцию по идентификатору из запроса
        var transaction = await uow.Query<TransactionAggregate>().FirstOrDefaultAsync(p => p.Id == request.TransactionId, cancellationToken);
        
        // Если транзакция не найдена, выбрасываем исключение
        if (transaction is null)
            throw new TransactionNotFoundException(request.TransactionId);
        
        //
        if (request.Amount is not null)
            transaction.Amount = request.Amount.Value;

        if (request.Type is not null)
        {
            if (TransactionType.TryGet(request.Type) is not null)
            transaction.Type = request.Type;
        }
        
        //
        if (request.PlayerId is not null)
        {
            //
            var player = await uow.Query<PlayerAggregate>()
                .FirstOrDefaultAsync(p=>p.Id == request.PlayerId, cancellationToken);
            
            //
            if (player is null)
                throw new PlayerNotFoundException(request.PlayerId.Value);
            
            //
            transaction.PlayerId = request.PlayerId.Value;
        }

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}