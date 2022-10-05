using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addMigrat5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankId",
                table: "TrPaymentLines");

            migrationBuilder.DropColumn(
                name: "CashRegisterCode",
                table: "TrInvoiceLines");

            migrationBuilder.AddColumn<string>(
                name: "CashRegisterCode",
                table: "TrPaymentLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashRegisterCode",
                table: "TrPaymentLines");

            migrationBuilder.AddColumn<byte>(
                name: "BankId",
                table: "TrPaymentLines",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CashRegisterCode",
                table: "TrInvoiceLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
