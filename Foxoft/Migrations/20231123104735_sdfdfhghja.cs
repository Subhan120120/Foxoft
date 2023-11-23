using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdfdfhghja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_TrProductBarcodes_Barcode",
                table: "TrProductBarcodes");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductBarcodes_Barcode",
                table: "TrProductBarcodes",
                column: "Barcode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrProductBarcodes_Barcode",
                table: "TrProductBarcodes");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TrProductBarcodes_Barcode",
                table: "TrProductBarcodes",
                column: "Barcode");
        }
    }
}
