using Microsoft.EntityFrameworkCore.Migrations;

namespace Fyley.Services.Account.Infrastructure.Migrations.Migrations
{
    public partial class Added_IsArchived : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                schema: "Accounts",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                schema: "Accounts",
                table: "Accounts");
        }
    }
}
