using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addedCurrency2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcCurrencies");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrPaymentLines");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrInvoiceLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "TrInvoiceLines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                defaultValueSql: "space(0)");

            migrationBuilder.CreateTable(
                name: "DcCurrencies",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CurrencyDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeRate = table.Column<float>(type: "real", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrencies", x => x.CurrencyCode);
                });

        }
    }
}
