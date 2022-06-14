using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class PriceLoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "LocPrice",
                table: "TrInvoiceLines",
                newName: "PriceLoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceLoc",
                table: "TrInvoiceLines",
                newName: "LocPrice");
        }
    }
}
