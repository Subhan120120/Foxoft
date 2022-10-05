using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class indexies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_CurrAccCode",
                table: "TrInvoiceHeaders",
                newName: "IX_TrInvoiceHeaders_CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_DocumentNumber_ProcessCode_CurrAccCode",
                table: "TrInvoiceHeaders",
                columns: new[] { "DocumentNumber", "ProcessCode", "CurrAccCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_DocumentNumber_ProcessCode_CurrAccCode",
                table: "TrInvoiceHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceHeaders_CurrAccCode",
                table: "TrInvoiceHeaders",
                newName: "IX_CurrAccCode");
        }
    }
}
