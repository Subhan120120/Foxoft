using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dtest2asas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_ProductCode",
                table: "TrInvoiceLines",
                newName: "IX_TrInvoiceLines_ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceLines_ProductCode",
                table: "TrInvoiceLines",
                newName: "IX_ProductCode");
        }
    }
}
