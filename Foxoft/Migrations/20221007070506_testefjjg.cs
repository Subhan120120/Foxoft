using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class testefjjg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_FromCashRegCode",
                table: "TrPaymentHeaders",
                column: "FromCashRegCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_ToCashRegCode",
                table: "TrPaymentHeaders",
                column: "ToCashRegCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_FromCashRegCode",
                table: "TrPaymentHeaders",
                column: "FromCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders",
                column: "ToCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_FromCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_FromCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_ToCashRegCode",
                table: "TrPaymentHeaders");
        }
    }
}
