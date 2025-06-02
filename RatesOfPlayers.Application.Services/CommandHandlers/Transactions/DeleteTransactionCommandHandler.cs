using MediatR;
using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Transactions;

/// <summary>
/// Обработчик команды для удаления транзакции
/// </summary>
/// <param name="uow">Единица работы</param>
public class DeleteTransactionCommandHandler(
    IUnitOfWork uow) : IRequestHandler<DeleteTransactionCommand>
{
    /// <summary>
    /// Метод обработчик команды для удаления транзакции
    /// </summary>
    /// <param name="request">Команда для удаления транзакции</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        // Получаем транзакцию по идентификатору из запроса
        var transaction = await uow.Query<Transaction>().FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        
        // Если транзакция не найдена, выбрасываем исключение
        if (transaction == null)
            throw new TransactionNotFoundException(request.Id);
        
        // Удаляем транзакцию из контекста базы данных
        await uow.DeleteAsync(transaction, cancellationToken);

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}