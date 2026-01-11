using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class sdffh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrBarcodeOperationHeader",
                table: "TrBarcodeOperationHeader");

            migrationBuilder.RenameTable(
                name: "TrBarcodeOperationHeader",
                newName: "TrBarcodeOperationHeaders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrBarcodeOperationHeaders",
                table: "TrBarcodeOperationHeaders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeaders_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines",
                column: "BarcodeOperationHeaderId",
                principalTable: "TrBarcodeOperationHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeaders_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrBarcodeOperationHeaders",
                table: "TrBarcodeOperationHeaders");

            migrationBuilder.RenameTable(
                name: "TrBarcodeOperationHeaders",
                newName: "TrBarcodeOperationHeader");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrBarcodeOperationHeader",
                table: "TrBarcodeOperationHeader",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeader_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines",
                column: "BarcodeOperationHeaderId",
                principalTable: "TrBarcodeOperationHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
