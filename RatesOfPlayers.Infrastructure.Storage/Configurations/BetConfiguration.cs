using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatesOfPlayers.Domain.Bets;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Infrastructure.Storage.Configurations;

/// <summary>
/// Конфигурация таблицы ставок в базе данных.
/// </summary>
public class BetConfiguration : IEntityTypeConfiguration<Bet>
{
    /// <summary>
    /// Настраивает таблицу ставок в базе данных.
    /// </summary>
    /// <param name="builder">Строитель для настройки таблицы.</param>
    public void Configure(EntityTypeBuilder<Bet> builder)
    {
        // Указываем имя таблицы в БД для хранения ставок
        builder.ToTable("Bets");
        
        // Настраиваем поле Id как первичный ключ ставки
        builder.HasKey(b => b.Id);
        
        // Настраиваем свойства ставки
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd(); // Значение генерируется при добавлении

        // Связь один ко многим с игроком
        builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(b => b.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Настраиваем Version для оптимистичной блокировки
        builder.Property(b => b.Version)
            .IsConcurrencyToken(); // Помечаем как токен параллелизма
        
        // Индекс по дате ставки
        builder.HasIndex(b => b.Date);
        
        // Сумма ставки должна быть положительной
        builder.ToTable(t => t.HasCheckConstraint("CK_Bets_Amount", "Amount > 0"));
        
        // Выигрыш не может быть отрицательным
        builder.ToTable(t => t.HasCheckConstraint("CK_Bets_Prize", "Prize > 0 OR Prize IS NULL"));
        
        // Дата расчета не может быть раньше даты ставки
        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Bets_Settlement_after_bet", 
            "SettlementDate IS NULL OR SettlementDate >= Date"));
    }
}