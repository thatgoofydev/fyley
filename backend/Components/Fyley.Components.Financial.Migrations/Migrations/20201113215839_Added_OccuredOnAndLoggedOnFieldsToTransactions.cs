using Microsoft.EntityFrameworkCore.Migrations;

namespace Fyley.Components.Financial.Migrations.Migrations
{
    public partial class Added_OccuredOnAndLoggedOnFieldsToTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoggedOn",
                schema: "Financial",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OccuredOn",
                schema: "Financial",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoggedOn",
                schema: "Financial",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "OccuredOn",
                schema: "Financial",
                table: "Transactions");
        }
    }
}
