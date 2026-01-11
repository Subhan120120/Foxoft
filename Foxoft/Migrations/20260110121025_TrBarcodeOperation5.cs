using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrBarcodeOperation5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLine_DcBarcodeTypes_BarcodeTypeCode",
                table: "TrBarcodeOperationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLine_DcProducts_ProductCode",
                table: "TrBarcodeOperationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLine_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrBarcodeOperationLine",
                table: "TrBarcodeOperationLine");

            migrationBuilder.RenameTable(
                name: "TrBarcodeOperationLine",
                newName: "TrBarcodeOperationLines");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLine_ProductCode",
                table: "TrBarcodeOperationLines",
                newName: "IX_TrBarcodeOperationLines_ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLine_BarcodeTypeCode",
                table: "TrBarcodeOperationLines",
                newName: "IX_TrBarcodeOperationLines_BarcodeTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLine_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines",
                newName: "IX_TrBarcodeOperationLines_BarcodeOperationHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrBarcodeOperationLines",
                table: "TrBarcodeOperationLines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLines_DcBarcodeTypes_BarcodeTypeCode",
                table: "TrBarcodeOperationLines",
                column: "BarcodeTypeCode",
                principalTable: "DcBarcodeTypes",
                principalColumn: "BarcodeTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLines_DcProducts_ProductCode",
                table: "TrBarcodeOperationLines",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines",
                column: "BarcodeOperationHeaderId",
                principalTable: "TrBarcodeOperationHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLines_DcBarcodeTypes_BarcodeTypeCode",
                table: "TrBarcodeOperationLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLines_DcProducts_ProductCode",
                table: "TrBarcodeOperationLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrBarcodeOperationLines",
                table: "TrBarcodeOperationLines");

            migrationBuilder.RenameTable(
                name: "TrBarcodeOperationLines",
                newName: "TrBarcodeOperationLine");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLines_ProductCode",
                table: "TrBarcodeOperationLine",
                newName: "IX_TrBarcodeOperationLine_ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLines_BarcodeTypeCode",
                table: "TrBarcodeOperationLine",
                newName: "IX_TrBarcodeOperationLine_BarcodeTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLines_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLine",
                newName: "IX_TrBarcodeOperationLine_BarcodeOperationHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrBarcodeOperationLine",
                table: "TrBarcodeOperationLine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLine_DcBarcodeTypes_BarcodeTypeCode",
                table: "TrBarcodeOperationLine",
                column: "BarcodeTypeCode",
                principalTable: "DcBarcodeTypes",
                principalColumn: "BarcodeTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLine_DcProducts_ProductCode",
                table: "TrBarcodeOperationLine",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLine_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLine",
                column: "BarcodeOperationHeaderId",
                principalTable: "TrBarcodeOperationHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
