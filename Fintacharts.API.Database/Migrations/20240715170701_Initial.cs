using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fintacharts.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Kind = table.Column<string>(type: "text", nullable: true),
                    Exchange = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TickSize = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    AskPrice = table.Column<double>(type: "double precision", nullable: false),
                    AskTimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BidPrice = table.Column<double>(type: "double precision", nullable: false),
                    BidTimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastPrice = table.Column<double>(type: "double precision", nullable: false),
                    LastTimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
