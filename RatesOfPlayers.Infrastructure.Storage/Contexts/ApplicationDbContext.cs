using Microsoft.EntityFrameworkCore;
using RatesOfPlayers.Domain;
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
    
    /// <summary>
    /// Переопределение синхронного метода сохранения изменений в БД
    /// </summary>
    /// <returns>Количество затронутых записей в БД</returns>
    public override int SaveChanges()
    {
        UpdateVersionedEntities();
        return base.SaveChanges();
    }

    /// <summary>
    /// Асинхронная версия метода сохранения изменений в БД
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции</param>
    /// <returns>Task с количеством затронутых записей в БД</returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateVersionedEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Обновляет версии сущностей, реализующих IVersionedEntity
    /// </summary>
    private void UpdateVersionedEntities()
    {
        var versionedEntries = ChangeTracker.Entries<IVersionedEntity>()
            .Where(entry => entry.State == EntityState.Modified);

        foreach (var entry in versionedEntries)
        {
            entry.Entity.Version++;
        }
    }
}