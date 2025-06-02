using AutoMapper;
using MediatR;
using RatesOfPlayers.Application.Abstractions.Commands.Transactions;
using RatesOfPlayers.Application.Abstractions.DTOs.Transactions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Transactions;

/// <summary>
/// Обработчик команды для создания транзакции
/// </summary>
/// <param name="uow">Единица работы</param>
/// <param name="mapper">Маппер данных</param>
public class CreateTransactionCommandHandler(
    IUnitOfWork uow,
    IMapper mapper) : IRequestHandler<CreateTransactionCommand, TransactionDto>
{
    /// <summary>
    /// Метод обработчик команды для создания транзакции
    /// </summary>
    /// <param name="request">Команда для создания транзакции</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<TransactionDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        // Создаём агрегат транзакции
        var transaction = mapper.Map<Transaction>(request);
        
        // Добавляем транзакцию в базу данных
        await uow.AddAsync(transaction, cancellationToken);
        
        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
        
        // Возвращаем уникальный идентификатор транзакции
        return mapper.Map<TransactionDto>(transaction);
    }
}