using Microsoft.EntityFrameworkCore.Migrations;

namespace Fyley.Components.Financial.Migrations.Migrations
{
    public partial class Added_DifferenceAccountReferenceOrTransactionAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Payor_Value",
                schema: "Financial",
                table: "Transactions",
                newName: "Payor_TransactionAccount_Number_Value");

            migrationBuilder.RenameColumn(
                name: "Payor_Type",
                schema: "Financial",
                table: "Transactions",
                newName: "Payor_TransactionAccount_Number_Type");

            migrationBuilder.RenameColumn(
                name: "Payee_Value",
                schema: "Financial",
                table: "Transactions",
                newName: "Payee_TransactionAccount_Number_Value");

            migrationBuilder.RenameColumn(
                name: "Payee_Type",
                schema: "Financial",
                table: "Transactions",
                newName: "Payee_TransactionAccount_Number_Type");

            migrationBuilder.AddColumn<string>(
                name: "Payee_AccountReference",
                schema: "Financial",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payor_AccountReference",
                schema: "Financial",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payee_TransactionAccount_Name",
                schema: "Financial",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payor_TransactionAccount_Name",
                schema: "Financial",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payee_AccountReference",
                schema: "Financial",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Payor_AccountReference",
                schema: "Financial",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Payee_TransactionAccount_Name",
                schema: "Financial",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Payor_TransactionAccount_Name",
                schema: "Financial",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Payor_TransactionAccount_Number_Value",
                schema: "Financial",
                table: "Transactions",
                newName: "Payor_Value");

            migrationBuilder.RenameColumn(
                name: "Payor_TransactionAccount_Number_Type",
                schema: "Financial",
                table: "Transactions",
                newName: "Payor_Type");

            migrationBuilder.RenameColumn(
                name: "Payee_TransactionAccount_Number_Value",
                schema: "Financial",
                table: "Transactions",
                newName: "Payee_Value");

            migrationBuilder.RenameColumn(
                name: "Payee_TransactionAccount_Number_Type",
                schema: "Financial",
                table: "Transactions",
                newName: "Payee_Type");
        }
    }
}
