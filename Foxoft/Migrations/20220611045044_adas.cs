using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class adas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZE");

            migrationBuilder.InsertData(
                table: "DcCurrencies",
                columns: new[] { "CurrencyCode", "CurrencyDesc", "ExchangeRate" },
                values: new object[] { "AZN", "₼", 1f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZN");

            migrationBuilder.InsertData(
                table: "DcCurrencies",
                columns: new[] { "CurrencyCode", "CurrencyDesc", "ExchangeRate" },
                values: new object[] { "AZE", "₼", 1f });
        }
    }
}
