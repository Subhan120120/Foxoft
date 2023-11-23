using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asddgfghl4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductBarcode_DcBarcodeType_BarcodeTypeCode",
                table: "TrProductBarcode");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductBarcode_DcProducts_ProductCode",
                table: "TrProductBarcode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductBarcode",
                table: "TrProductBarcode");

            migrationBuilder.RenameTable(
                name: "TrProductBarcode",
                newName: "TrProductBarcodes");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductBarcode_ProductCode",
                table: "TrProductBarcodes",
                newName: "IX_TrProductBarcodes_ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductBarcode_BarcodeTypeCode",
                table: "TrProductBarcodes",
                newName: "IX_TrProductBarcodes_BarcodeTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductBarcodes",
                table: "TrProductBarcodes",
                column: "Barcode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeType_BarcodeTypeCode",
                table: "TrProductBarcodes",
                column: "BarcodeTypeCode",
                principalTable: "DcBarcodeType",
                principalColumn: "BarcodeTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductBarcodes_DcProducts_ProductCode",
                table: "TrProductBarcodes",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeType_BarcodeTypeCode",
                table: "TrProductBarcodes");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductBarcodes_DcProducts_ProductCode",
                table: "TrProductBarcodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductBarcodes",
                table: "TrProductBarcodes");

            migrationBuilder.RenameTable(
                name: "TrProductBarcodes",
                newName: "TrProductBarcode");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductBarcodes_ProductCode",
                table: "TrProductBarcode",
                newName: "IX_TrProductBarcode_ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductBarcodes_BarcodeTypeCode",
                table: "TrProductBarcode",
                newName: "IX_TrProductBarcode_BarcodeTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductBarcode",
                table: "TrProductBarcode",
                column: "Barcode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductBarcode_DcBarcodeType_BarcodeTypeCode",
                table: "TrProductBarcode",
                column: "BarcodeTypeCode",
                principalTable: "DcBarcodeType",
                principalColumn: "BarcodeTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductBarcode_DcProducts_ProductCode",
                table: "TrProductBarcode",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
