using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fyley.Components.Dossiers.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dossiers");

            migrationBuilder.CreateTable(
                name: "Dossiers",
                schema: "Dossiers",
                columns: table => new
                {
                    DossierId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Version = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.DossierId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "Dossiers",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dossiers",
                schema: "Dossiers");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "Dossiers");
        }
    }
}
