using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addedCurrency4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentLines",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_CurrencyCode",
                table: "TrPaymentLines",
                column: "CurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcCurrencies_CurrencyCode",
                table: "TrPaymentLines",
                column: "CurrencyCode",
                principalTable: "DcCurrencies",
                principalColumn: "CurrencyCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcCurrencies_CurrencyCode",
                table: "TrPaymentLines");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentLines_CurrencyCode",
                table: "TrPaymentLines");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrPaymentLines");

        }
    }
}
