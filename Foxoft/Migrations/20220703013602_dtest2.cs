using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dtest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
