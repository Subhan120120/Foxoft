using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrBarcodeOperation4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trBarcodeOperations_DcBarcodeTypes_BarcodeTypeCode",
                table: "trBarcodeOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_trBarcodeOperations_DcProducts_ProductCode",
                table: "trBarcodeOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_trBarcodeOperations_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "trBarcodeOperations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trBarcodeOperations",
                table: "trBarcodeOperations");

            migrationBuilder.RenameTable(
                name: "trBarcodeOperations",
                newName: "TrBarcodeOperationLine");

            migrationBuilder.RenameIndex(
                name: "IX_trBarcodeOperations_ProductCode",
                table: "TrBarcodeOperationLine",
                newName: "IX_TrBarcodeOperationLine_ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_trBarcodeOperations_BarcodeTypeCode",
                table: "TrBarcodeOperationLine",
                newName: "IX_TrBarcodeOperationLine_BarcodeTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_trBarcodeOperations_BarcodeOperationHeaderId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "trBarcodeOperations");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLine_ProductCode",
                table: "trBarcodeOperations",
                newName: "IX_trBarcodeOperations_ProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLine_BarcodeTypeCode",
                table: "trBarcodeOperations",
                newName: "IX_trBarcodeOperations_BarcodeTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrBarcodeOperationLine_BarcodeOperationHeaderId",
                table: "trBarcodeOperations",
                newName: "IX_trBarcodeOperations_BarcodeOperationHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trBarcodeOperations",
                table: "trBarcodeOperations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_trBarcodeOperations_DcBarcodeTypes_BarcodeTypeCode",
                table: "trBarcodeOperations",
                column: "BarcodeTypeCode",
                principalTable: "DcBarcodeTypes",
                principalColumn: "BarcodeTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trBarcodeOperations_DcProducts_ProductCode",
                table: "trBarcodeOperations",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trBarcodeOperations_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "trBarcodeOperations",
                column: "BarcodeOperationHeaderId",
                principalTable: "TrBarcodeOperationHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
