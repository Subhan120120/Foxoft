using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdasdaasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_FromCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_FromCashRegCode",
                table: "TrPaymentHeaders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_FromCashRegCode",
                table: "TrPaymentHeaders",
                column: "FromCashRegCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_FromCashRegCode",
                table: "TrPaymentHeaders",
                column: "FromCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
