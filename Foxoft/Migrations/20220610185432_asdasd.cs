using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZE",
                column: "CurrencyDesc",
                value: "₼");

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "CurrencyDesc",
                value: "$");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZE",
                column: "CurrencyDesc",
                value: "Azərbaycan Manatı");

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "CurrencyDesc",
                value: "Amerikan Dolları");
        }
    }
}
