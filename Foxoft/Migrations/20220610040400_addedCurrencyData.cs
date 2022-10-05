using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addedCurrencyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DcCurrencies");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "DcCurrencies");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "DcCurrencies");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserName",
                table: "DcCurrencies");

            migrationBuilder.InsertData(
                table: "DcCurrencies",
                columns: new[] { "CurrencyCode", "CurrencyDesc", "ExchangeRate" },
                values: new object[] { "AZE", "Azərbaycan Manatı", 0f });

            migrationBuilder.InsertData(
                table: "DcCurrencies",
                columns: new[] { "CurrencyCode", "CurrencyDesc", "ExchangeRate" },
                values: new object[] { "USD", "Amerikan Dolları", 0f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "AZE");

            migrationBuilder.DeleteData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DcCurrencies",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "DcCurrencies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcCurrencies",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcCurrencies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

        }
    }
}
