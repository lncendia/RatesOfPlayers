using RatesOfPlayers.Application.Services.CommandHandlers.Players;

namespace RatesOfPlayers.Start.Extensions;

/// <summary>
/// Статический класс для регистрации сервисов, связанных с MediatR и обработкой команд
/// </summary>
public static class MediatorServices
{
    /// <summary>
    /// Регистрирует сервисы MediatR и настраивает систему обработки команд
    /// </summary>
    /// <param name="services">Коллекция служб DI-контейнера</param>
    /// <remarks>
    /// Метод выполняет:
    /// 1. Регистрацию MediatR с автоматическим сканированием обработчиков команд
    /// 2. Настройку фонового сервиса для обработки асинхронных команд
    /// 3. Регистрацию IAsyncSender для постановки команд в очередь
    /// </remarks>
    public static void AddMediatorServices(this IServiceCollection services)
    {
        // Регистрация MediatR с автоматическим обнаружением обработчиков команд
        services.AddMediatR(mediatrConfiguration =>
        {
            // Сканируем сборку, содержащую StartCommandHandler, для поиска всех обработчиков
            mediatrConfiguration.RegisterServicesFromAssembly(typeof(CreatePlayerCommandHandler).Assembly);
        });
    }
}