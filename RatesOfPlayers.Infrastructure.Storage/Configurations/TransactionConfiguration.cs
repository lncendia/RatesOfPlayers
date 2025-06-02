using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatesOfPlayers.Domain.Players;
using RatesOfPlayers.Domain.Transactions;

namespace RatesOfPlayers.Infrastructure.Storage.Configurations;

/// <summary>
/// Конфигурация таблицы транзакций в базе данных.
/// </summary>
public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    /// <summary>
    /// Настраивает таблицу транзакций.
    /// </summary>
    /// <param name="builder">Строитель для настройки таблицы.</param>
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        // Указываем имя таблицы в БД
        builder.ToTable("Transactions");

        // Настраиваем первичный ключ
        builder.HasKey(t => t.Id);

        // Настраиваем свойства
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        // Связь один-ко-многим с игроком
        builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(t => t.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Индекс по дате ставки
        builder.HasIndex(b => b.Date);

        // Проверочные ограничения
        builder.ToTable(t => t.HasCheckConstraint(
            "CK_Transactions_Amount",
            "Amount > 0")); // Сумма не может быть нулевой
    }
}