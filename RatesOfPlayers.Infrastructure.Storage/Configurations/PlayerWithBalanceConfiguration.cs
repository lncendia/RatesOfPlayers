using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RatesOfPlayers.Domain.Players;

namespace RatesOfPlayers.Infrastructure.Storage.Configurations;

/// <summary>
/// Конфигурация сущности PlayerWithBalance в базе данных
/// </summary>
/// <remarks>
/// Настраивает маппинг на SQL-представление и определяет транзакционное поведение
/// </remarks>
public class PlayerWithBalanceConfiguration : IEntityTypeConfiguration<PlayerWithBalance>
{
    /// <summary>
    /// Настраивает маппинг сущности на представление базы данных
    /// </summary>
    /// <param name="builder">Строитель для конфигурации сущности</param>
    public void Configure(EntityTypeBuilder<PlayerWithBalance> builder)
    {
        // Указываем имя представления в БД
        builder.ToView("PlayerBalanceView")
            .HasKey(p => p.Id); // Ключ для представления
    }
}