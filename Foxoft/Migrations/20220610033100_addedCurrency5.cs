using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class addedCurrency5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "TrInvoiceLines",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_CurrencyCode",
                table: "TrInvoiceLines",
                column: "CurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcCurrencies_CurrencyCode",
                table: "TrInvoiceLines",
                column: "CurrencyCode",
                principalTable: "DcCurrencies",
                principalColumn: "CurrencyCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcCurrencies_CurrencyCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_CurrencyCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "TrInvoiceLines");

        }
    }
}
