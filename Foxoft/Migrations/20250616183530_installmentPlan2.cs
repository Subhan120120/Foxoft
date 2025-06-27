using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class installmentPlan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInstallments_DcCurrencies_CurrencyCode",
                table: "TrInstallments");

            migrationBuilder.DropIndex(
                name: "IX_TrInstallments_CurrencyCode",
                table: "TrInstallments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TrInstallments");

            migrationBuilder.DropColumn(
                name: "AmountLoc",
                table: "TrInstallments");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrInstallments");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "TrInstallments");

            migrationBuilder.AddColumn<string>(
                name: "DcCurrencyCurrencyCode",
                table: "TrInstallments",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrInstallments_DcCurrencyCurrencyCode",
                table: "TrInstallments",
                column: "DcCurrencyCurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInstallments_DcCurrencies_DcCurrencyCurrencyCode",
                table: "TrInstallments",
                column: "DcCurrencyCurrencyCode",
                principalTable: "DcCurrencies",
                principalColumn: "CurrencyCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInstallments_DcCurrencies_DcCurrencyCurrencyCode",
                table: "TrInstallments");

            migrationBuilder.DropIndex(
                name: "IX_TrInstallments_DcCurrencyCurrencyCode",
                table: "TrInstallments");

            migrationBuilder.DropColumn(
                name: "DcCurrencyCurrencyCode",
                table: "TrInstallments");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "TrInstallments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLoc",
                table: "TrInstallments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "TrInstallments",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "ExchangeRate",
                table: "TrInstallments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_TrInstallments_CurrencyCode",
                table: "TrInstallments",
                column: "CurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInstallments_DcCurrencies_CurrencyCode",
                table: "TrInstallments",
                column: "CurrencyCode",
                principalTable: "DcCurrencies",
                principalColumn: "CurrencyCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
