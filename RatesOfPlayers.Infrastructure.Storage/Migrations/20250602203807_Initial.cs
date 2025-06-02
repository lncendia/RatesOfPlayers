using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RatesOfPlayers.Infrastructure.Storage.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                                 EXPLAIN QUERY PLAN SELECT 
                                   p.Id, 
                                   p.Name, 
                                   p.Status, 
                                   p.RegistrationDate, 
                                   IFNULL(
                                     (
                                       SELECT 
                                         SUM(b.Amount) 
                                       FROM 
                                         Bets b 
                                       WHERE 
                                         b.PlayerId = p.Id
                                     ), 
                                     0
                                   ) AS TotalBets, 
                                   (
                                     IFNULL(
                                       (
                                         SELECT 
                                           SUM(
                                             CASE WHEN t.Type = 1 THEN t.Amount WHEN t.Type = 2 THEN - t.Amount ELSE 0 END
                                           ) 
                                         FROM 
                                           Transactions t 
                                         WHERE 
                                           t.PlayerId = p.Id 
                                       ), 
                                       0
                                     ) + IFNULL(
                                       (
                                         SELECT 
                                           SUM(b.Prize - b.Amount) 
                                         FROM 
                                           Bets b 
                                         WHERE 
                                           b.PlayerId = p.Id
                                       ), 
                                       0
                                     )
                                   ) AS Balance 
                                 FROM 
                                   Players p;
                                 """);
            
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.CheckConstraint("CK_Players_Name_Length", "LENGTH(Name) >= 3");
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerId = table.Column<long>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Prize = table.Column<decimal>(type: "TEXT", nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                    table.CheckConstraint("CK_Bets_Amount", "Amount > 0");
                    table.CheckConstraint("CK_Bets_Prize", "Prize > 0 OR Prize IS NULL");
                    table.CheckConstraint("CK_Bets_Settlement_after_bet", "SettlementDate IS NULL OR SettlementDate >= Date");
                    table.ForeignKey(
                        name: "FK_Bets_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerId = table.Column<long>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.CheckConstraint("CK_Transactions_Amount", "Amount > 0");
                    table.ForeignKey(
                        name: "FK_Transactions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_Date",
                table: "Bets",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_PlayerId",
                table: "Bets",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Name",
                table: "Players",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_RegistrationDate",
                table: "Players",
                column: "RegistrationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Status",
                table: "Players",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Date",
                table: "Transactions",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PlayerId",
                table: "Transactions",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
