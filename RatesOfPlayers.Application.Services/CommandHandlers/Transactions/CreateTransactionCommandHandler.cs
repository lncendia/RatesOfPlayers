using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Transactions;

/// <summary>
/// Обработчик команды для создания транзакции
/// </summary>
/// <param name="uow">Единица работы</param>
public class CreateTransactionCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateTransactionCommand, long>
{
    /// <summary>
    /// Метод обработчик команды для создания транзакции
    /// </summary>
    /// <param name="request">Команда для создания транзакции</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<long> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        // Проверяем существование игрока
        var playerExists = await uow.Query<PlayerWithBalance>()
            .AnyAsync(p => p.Id == request.PlayerId, cancellationToken);
        
        if (!playerExists)
            throw new PlayerNotFoundException(request.PlayerId);
        
        // Создаём Модель транзакции
        var transaction = new Transaction
        {
            PlayerId = request.PlayerId,
            Amount = request.Amount,
            Date = request.Date,
            Type = request.Type,
        };

        // Добавляем транзакцию в базу данных
        await uow.AddAsync(transaction, cancellationToken);

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);

        // Возвращаем уникальный идентификатор транзакции
        return transaction.Id;
    }
}