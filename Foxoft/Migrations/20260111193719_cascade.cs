using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeaders_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeaders_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines",
                column: "BarcodeOperationHeaderId",
                principalTable: "TrBarcodeOperationHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeaders_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeaders_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines",
                column: "BarcodeOperationHeaderId",
                principalTable: "TrBarcodeOperationHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
