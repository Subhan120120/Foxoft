using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfggsj34567890012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultCashRegCode",
                table: "DcPaymentMethods",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentMethods_DefaultCashRegCode",
                table: "DcPaymentMethods",
                column: "DefaultCashRegCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCashRegCode",
                table: "DcPaymentMethods",
                column: "DefaultCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCashRegCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_DcPaymentMethods_DefaultCashRegCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropColumn(
                name: "DefaultCashRegCode",
                table: "DcPaymentMethods");
        }
    }
}
