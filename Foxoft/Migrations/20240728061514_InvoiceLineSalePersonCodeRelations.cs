using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceLineSalePersonCodeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SalesPersonCode",
                table: "TrInvoiceLines",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_SalesPersonCode",
                table: "TrInvoiceLines",
                column: "SalesPersonCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcCurrAccs_SalesPersonCode",
                table: "TrInvoiceLines",
                column: "SalesPersonCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcCurrAccs_SalesPersonCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_SalesPersonCode",
                table: "TrInvoiceLines");

            migrationBuilder.AlterColumn<string>(
                name: "SalesPersonCode",
                table: "TrInvoiceLines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);
        }
    }
}
