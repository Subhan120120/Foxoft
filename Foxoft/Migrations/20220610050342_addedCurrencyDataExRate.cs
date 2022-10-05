using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addedCurrencyDataExRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZE",
                column: "ExchangeRate",
                value: 1f);

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "ExchangeRate",
                value: 1.703f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZE",
                column: "ExchangeRate",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "ExchangeRate",
                value: 0f);
        }
    }
}
