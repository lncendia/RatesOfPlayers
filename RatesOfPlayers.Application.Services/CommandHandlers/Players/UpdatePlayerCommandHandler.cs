using MediatR;
using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.Exceptions;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Players.ValueObjects;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Players;

/// <summary>
/// Обработчик команды для изменения данных игрока
/// </summary>
/// <param name="uow">Единица работы</param>
public class UpdatePlayerCommandHandler(
    IUnitOfWork uow) : IRequestHandler<UpdatePlayerCommand>
{
    /// <summary>
    /// Метод обработчик команды для изменения данных игрока
    /// </summary>
    /// <param name="request">Команда для изменения данных игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        // Получаем игрока по идентификатору из запроса
        var player = uow.Query<PlayerAggregate>().FirstOrDefault(p => p.Id == request.PlayerId);
        
        // Если игрок не найден, выбрасываем исключение
        if (player == null)
            throw new PlayerNotFoundException(request.PlayerId);
        
        // Обновляем имя игрока, если оно указано в запросе
        if(request.FirstName != null)
            player.Name.FirstName = request.FirstName;
        
        // Обновляем фамилию игрока, если оно указано в запросе
        if(request.SecondName != null)
            player.Name.SecondName = request.SecondName;
        
        // Обновляем отчество игрока, если оно указано в запросе
        if(request.ThirdName != null)
            player.Name.ThirdName = request.ThirdName;
        
        var statusDictionary = new []
        {
            PlayerStatus.New,
            PlayerStatus.Bad
        };
        
        // Обновляем отчество игрока, если оно указано в запросе
        if (request.Status != null)
        {
            if (statusDictionary.Contains(request.Status))
                player.Name.ThirdName = request.ThirdName;
            else
                throw new UnknownPlayerStatusException(request.Status);
        }

        // Обновляет информацию об игроке в контексте базы данных
        uow.Update(player);

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);
    }
}