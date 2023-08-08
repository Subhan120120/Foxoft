using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfggsj345678900124 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "CashRegPaymentTypeCode",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_CashRegPaymentTypeCode",
                table: "DcCurrAccs",
                column: "CashRegPaymentTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_DcPaymentTypes_CashRegPaymentTypeCode",
                table: "DcCurrAccs",
                column: "CashRegPaymentTypeCode",
                principalTable: "DcPaymentTypes",
                principalColumn: "PaymentTypeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_DcPaymentTypes_CashRegPaymentTypeCode",
                table: "DcCurrAccs");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAccs_CashRegPaymentTypeCode",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "CashRegPaymentTypeCode",
                table: "DcCurrAccs");
        }
    }
}
