using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asddgfgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcBarcodeType",
                columns: table => new
                {
                    BarcodeTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BarcodeTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcBarcodeType", x => x.BarcodeTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "TrProductBarcode",
                columns: table => new
                {
                    Barcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    BarcodeTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProductBarcode", x => x.Barcode);
                    table.ForeignKey(
                        name: "FK_TrProductBarcode_DcBarcodeType_BarcodeTypeCode",
                        column: x => x.BarcodeTypeCode,
                        principalTable: "DcBarcodeType",
                        principalColumn: "BarcodeTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductBarcode_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcBarcodeType",
                columns: new[] { "BarcodeTypeCode", "BarcodeTypeDesc" },
                values: new object[] { "Serbest", "Sərbəst" });

            migrationBuilder.InsertData(
                table: "DcBarcodeType",
                columns: new[] { "BarcodeTypeCode", "BarcodeTypeDesc" },
                values: new object[] { "EAN13", "EAN13" });

            migrationBuilder.CreateIndex(
                name: "IX_TrProductBarcode_BarcodeTypeCode",
                table: "TrProductBarcode",
                column: "BarcodeTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductBarcode_ProductCode",
                table: "TrProductBarcode",
                column: "ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrProductBarcode");

            migrationBuilder.DropTable(
                name: "DcBarcodeType");
        }
    }
}
