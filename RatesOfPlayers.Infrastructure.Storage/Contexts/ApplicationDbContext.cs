using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Infrastructure.Storage.Configurations;

namespace RatesOfPlayers.Infrastructure.Storage.Contexts;

/// <summary>
/// Контекст базы данных для приложения.
/// </summary>
/// <param name="options">Опции конфигурации для DbContext.</param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Конфигурирует модель базы данных.
    /// </summary>
    /// <param name="modelBuilder">Объект для построения модели базы данных.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Применяем конфигурацию для сущности Player
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        
        // Применяем конфигурацию для сущности PlayerWithBalance
        modelBuilder.ApplyConfiguration(new PlayerWithBalanceConfiguration());

        // Применяем конфигурацию для сущности Bet
        modelBuilder.ApplyConfiguration(new BetConfiguration());

        // Применяем конфигурацию для сущности Bet
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());

        // Вызываем базовую реализацию метода
        base.OnModelCreating(modelBuilder);
    }
}