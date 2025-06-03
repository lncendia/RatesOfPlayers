using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Infrastructure.Storage.Configurations;

/// <summary>
/// Конфигурация таблицы игроков в базе данных.
/// </summary>
public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    /// <summary>
    /// Настраивает таблицу игроков.
    /// </summary>
    /// <param name="builder">Строитель для настройки таблицы.</param>
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        // Указываем имя таблицы в БД
        builder.ToTable("Players");
        
        // Настраиваем первичный ключ
        builder.HasKey(p => p.Id);
        
        // Настраиваем свойства
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Name)
            .HasMaxLength(100) // Ограничение длины имени
            .IsRequired();
        
        // Настраиваем Version для оптимистичной блокировки
        builder.Property(b => b.Version)
            .IsConcurrencyToken();  // Помечаем как токен параллелизма
        
        // Индексы для ускорения запросов
        builder.HasIndex(p => p.Name).IsUnique();

        builder.HasIndex(p => p.Status);
        
        // Проверочные ограничения
        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Players_Name_Length", 
            "LENGTH(Name) >= 3")); // Минимальная длина имени 3 символа
    }
}