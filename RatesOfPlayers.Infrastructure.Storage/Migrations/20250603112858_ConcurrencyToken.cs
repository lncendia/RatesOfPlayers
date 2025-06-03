using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RatesOfPlayers.Infrastructure.Storage.Migrations
{
    /// <inheritdoc />
    public partial class ConcurrencyToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Transactions",
                type: "INTEGER",
                rowVersion: true,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Players",
                type: "INTEGER",
                rowVersion: true,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Bets",
                type: "INTEGER",
                rowVersion: true,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Bets");
        }
    }
}
