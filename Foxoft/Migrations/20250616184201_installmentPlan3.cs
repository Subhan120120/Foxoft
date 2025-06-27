using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class installmentPlan3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
