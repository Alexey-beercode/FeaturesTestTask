using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeaturesTestTask.MarketDataService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "futures-data",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp", nullable: false),
                    QuarterPrice = table.Column<decimal>(type: "numeric(18,8)", precision: 18, scale: 8, nullable: false),
                    BiQuarterPrice = table.Column<decimal>(type: "numeric(18,8)", precision: 18, scale: 8, nullable: false),
                    PriceDifference = table.Column<decimal>(type: "numeric(18,8)", precision: 18, scale: 8, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_futures-data", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "idx_futures_data_timestamp",
                table: "futures-data",
                column: "Timestamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "futures-data");
        }
    }
}
