using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrInstallment_Currency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "TrInstallments",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "TrInstallments",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInstallments_DcCurrencies_CurrencyCode",
                table: "TrInstallments");

            migrationBuilder.DropIndex(
                name: "IX_TrInstallments_CurrencyCode",
                table: "TrInstallments");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrInstallments");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "TrInstallments",
                newName: "TotalAmount");
        }
    }
}
