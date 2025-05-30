using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatesOfPlayers.Domain.Bets;

namespace RatesOfPlayers.Infrastructure.Storage.Configurations;

public class BetConfiguration : IEntityTypeConfiguration<BetAggregate>
{
    /// <summary>
    /// Настраивает таблицу игроков.
    /// </summary>
    /// <param name="builder">Строитель для настройки таблицы.</param>
    public void Configure(EntityTypeBuilder<BetAggregate> builder)
    {
        // Указываем имя таблицы в БД для хранения статей
        builder.ToTable("Bets");
        
        // Настраиваем поле Id как первичный ключ статьи
        builder.HasKey(r => r.Id);
        
        // todo
    }
}