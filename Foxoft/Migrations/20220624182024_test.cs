using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceLines",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceLines",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
