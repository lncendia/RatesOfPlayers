using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Infrastructure.Storage.Configurations;

/// <summary>
/// Конфигурация Fluent API для сущности PlayerAggregate.
/// </summary>
public class PlayerConfiguration : IEntityTypeConfiguration<PlayerAggregate>
{
    /// <summary>
    /// Настраивает таблицу игроков.
    /// </summary>
    /// <param name="builder">Строитель для настройки таблицы.</param>
    public void Configure(EntityTypeBuilder<PlayerAggregate> builder)
    {
        // Указываем имя таблицы в БД для хранения статей
        builder.ToTable("Players");
        
        // Настраиваем поле Id как первичный ключ статьи
        builder.HasKey(r => r.Id);
        
        // todo
    }
}