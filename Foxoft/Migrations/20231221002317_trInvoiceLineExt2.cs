using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class trInvoiceLineExt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trInvoiceLineExt_TrInvoiceLines_PaymentLineId",
                table: "trInvoiceLineExt");

            migrationBuilder.RenameColumn(
                name: "PaymentLineId",
                table: "trInvoiceLineExt",
                newName: "InvoiceLineId");

            migrationBuilder.RenameIndex(
                name: "IX_trInvoiceLineExt_PaymentLineId",
                table: "trInvoiceLineExt",
                newName: "IX_trInvoiceLineExt_InvoiceLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_trInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "trInvoiceLineExt",
                column: "InvoiceLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "trInvoiceLineExt");

            migrationBuilder.RenameColumn(
                name: "InvoiceLineId",
                table: "trInvoiceLineExt",
                newName: "PaymentLineId");

            migrationBuilder.RenameIndex(
                name: "IX_trInvoiceLineExt_InvoiceLineId",
                table: "trInvoiceLineExt",
                newName: "IX_trInvoiceLineExt_PaymentLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_trInvoiceLineExt_TrInvoiceLines_PaymentLineId",
                table: "trInvoiceLineExt",
                column: "PaymentLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
