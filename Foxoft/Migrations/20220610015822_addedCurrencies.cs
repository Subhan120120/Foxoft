using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addedCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValueSql: "0");

            migrationBuilder.CreateTable(
                name: "DcCurrencies",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeRate = table.Column<float>(type: "real", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrencies", x => x.CurrencyCode);
                });

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "ProcessDescription" },
                values: new object[] { "PE", "Dovr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcCurrencies");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "PE");

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "float",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValueSql: "0");

        }
    }
}
