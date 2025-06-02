using AutoMapper;
using MediatR;
using RatesOfPlayers.Application.Abstractions.Commands.Players;
using RatesOfPlayers.Application.Abstractions.DTOs.Players;
using RatesOfPlayers.Domain;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Application.Services.CommandHandlers.Players;

/// <summary>
/// Обработчик команды для создания игрока
/// </summary>
/// <param name="uow">Единица работы</param>
/// <param name="mapper">Маппер данных</param>
public class CreatePlayerCommandHandler(IUnitOfWork uow, IMapper mapper) : IRequestHandler<CreatePlayerCommand, PlayerDto>
{
    /// <summary>
    /// Метод обработчик команды для создания игрока
    /// </summary>
    /// <param name="request">Команда для создания игрока</param>
    /// <param name="cancellationToken">Токен отмены операции</param>
    public async Task<PlayerDto> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        // Создаём агрегат игрока
        var player = new Player
        {
            Name = request.Name,
        };
        
        // Добавляем агрегат игрока в контекст базы данных
        await uow.AddAsync(player, cancellationToken);

        // Сохраняем изменения в базе данных
        await uow.SaveChangesAsync(cancellationToken);

        // Возвращаем идентификатор созданного игрока
        return mapper.Map<PlayerDto>(player);
    }
}