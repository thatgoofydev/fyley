using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fyley.Components.Dossiers.Infrastructure.Migrations
{
    public partial class Added_Dossiers : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dossiers",
                schema: "Dossiers");
        }
    }
}
