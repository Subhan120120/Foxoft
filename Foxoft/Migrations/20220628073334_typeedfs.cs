using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class typeedfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)3,
                column: "CurrAccTypeDesc",
                value: "Personal");

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)4,
                column: "CurrAccTypeDesc",
                value: "Mağaza");

            migrationBuilder.InsertData(
                table: "DcCurrencies",
                columns: new[] { "CurrencyCode", "CurrencyDesc", "ExchangeRate" },
                values: new object[] { "EUR", "€ EURO", 1.798f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "EUR");

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)3,
                column: "CurrAccTypeDesc",
                value: "Mağaza");

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)4,
                column: "CurrAccTypeDesc",
                value: "Personal");
        }
    }
}
