using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Infrastructure.Storage.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    /// <summary>
    /// Настраивает таблицу игроков.
    /// </summary>
    /// <param name="builder">Строитель для настройки таблицы.</param>
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        // Указываем имя таблицы в БД для хранения статей
        builder.ToTable("Transactions");
        
        // Настраиваем поле Id как первичный ключ статьи
        builder.HasKey(r => r.Id);
        
        // todo
    }
}