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
        
        // Устанавливаем сумму транзакции, если она указана в запросе
        if (request.Amount is not null)
            transaction.Amount = request.Amount.Value;

        // Устанавливаем тип транзакции, если он указан в запросе
        if (request.Type is not null)
        {
            // Проверяем, существует ли указанный тип транзакции в словаре TransactionType
            if (!TransactionType.TryGetValue(request.Type, out var type))
                throw new UnknownTransactionTypeException(request.Type);
            
            // Устанавливаем тип транзакции
            transaction.Type = type;
        }
        
        // Устанавливаем идентификатор игрока, если он указан в запросе
        if (request.PlayerId is not null)
        {
            // Асинхронно ищем игрока по идентификатору в базе данных
            var player = await uow.Query<PlayerAggregate>()
                .FirstOrDefaultAsync(p=>p.Id == request.PlayerId, cancellationToken);
            
            // Проверяем, найден ли игрок, и выбрасываем исключение, если нет
            if (player is null)
                throw new PlayerNotFoundException(request.PlayerId.Value);
            
            // Устанавливаем идентификатор игрока для транзакции
            transaction.PlayerId = request.PlayerId.Value;
        }

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}