using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_DocumentNumber_ProcessCode_CurrAccCode",
                table: "TrInvoiceHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceHeaderId",
                table: "TrInvoiceLines",
                newName: "IX_TrInvoiceLines_InvoiceHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceLines_InvoiceHeaderId",
                table: "TrInvoiceLines",
                newName: "IX_InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_DocumentNumber_ProcessCode_CurrAccCode",
                table: "TrInvoiceHeaders",
                columns: new[] { "DocumentNumber", "ProcessCode", "CurrAccCode" });
        }
    }
}
