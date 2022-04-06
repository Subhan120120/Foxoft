using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdasda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_InvoiceHeaderId",
                table: "TrPaymentHeaders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_InvoiceHeaderId",
                table: "TrPaymentHeaders",
                column: "InvoiceHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrPaymentHeaders",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
