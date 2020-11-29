using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fyley.Components.Financial.Migrations.Migrations
{
    public partial class Added_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Financial",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AccountNumber_Type = table.Column<int>(nullable: true),
                    AccountNumber_Value = table.Column<string>(nullable: true),
                    Version = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Financial");
        }
    }
}
