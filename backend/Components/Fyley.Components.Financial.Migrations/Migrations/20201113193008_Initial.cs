using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fyley.Components.Financial.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Financial");

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "Financial",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    AggregateId = table.Column<string>(nullable: false),
                    AggregateVersion = table.Column<long>(nullable: false),
                    EventType = table.Column<string>(nullable: false),
                    EventJson = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "Financial",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(nullable: false),
                    Payor_Type = table.Column<int>(nullable: true),
                    Payor_Value = table.Column<string>(nullable: true),
                    Payee_Type = table.Column<int>(nullable: true),
                    Payee_Value = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    OptionalReference = table.Column<string>(nullable: true),
                    Version = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events",
                schema: "Financial");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "Financial");
        }
    }
}
