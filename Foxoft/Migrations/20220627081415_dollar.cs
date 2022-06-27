using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dollar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZN",
                column: "CurrencyDesc",
                value: "AZN ₼");

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "CurrencyDesc",
                value: "DOLLAR $");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZN",
                column: "CurrencyDesc",
                value: "₼ AZN");

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "CurrencyDesc",
                value: "$ Dollar");
        }
    }
}
