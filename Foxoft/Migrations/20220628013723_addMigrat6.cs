using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addMigrat6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CashRegisterCode",
                table: "TrPaymentLines",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_CashRegisterCode",
                table: "TrPaymentLines",
                column: "CashRegisterCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcCurrAccs_CashRegisterCode",
                table: "TrPaymentLines",
                column: "CashRegisterCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcCurrAccs_CashRegisterCode",
                table: "TrPaymentLines");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentLines_CashRegisterCode",
                table: "TrPaymentLines");

            migrationBuilder.AlterColumn<string>(
                name: "CashRegisterCode",
                table: "TrPaymentLines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");
        }
    }
}
