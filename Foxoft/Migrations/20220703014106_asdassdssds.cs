using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdassdssds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_InvoiceHeaderId",
                table: "TrInvoiceLines");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_InvoiceHeaderId_ProductCode",
                table: "TrInvoiceLines",
                columns: new[] { "InvoiceHeaderId", "ProductCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_InvoiceHeaderId_ProductCode",
                table: "TrInvoiceLines");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_InvoiceHeaderId",
                table: "TrInvoiceLines",
                column: "InvoiceHeaderId");
        }
    }
}
