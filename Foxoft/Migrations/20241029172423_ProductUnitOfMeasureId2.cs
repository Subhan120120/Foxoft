using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ProductUnitOfMeasureId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrProductUnitOfMeasure_ProductUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductUnitOfMeasure_DcProducts_ProductCode",
                table: "TrProductUnitOfMeasure");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductUnitOfMeasure_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrProductUnitOfMeasure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductUnitOfMeasure",
                table: "TrProductUnitOfMeasure");

            migrationBuilder.RenameTable(
                name: "TrProductUnitOfMeasure",
                newName: "TrProductUnitOfMeasures");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductUnitOfMeasure_UnitOfMeasureId",
                table: "TrProductUnitOfMeasures",
                newName: "IX_TrProductUnitOfMeasures_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductUnitOfMeasure_ProductCode",
                table: "TrProductUnitOfMeasures",
                newName: "IX_TrProductUnitOfMeasures_ProductCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductUnitOfMeasures",
                table: "TrProductUnitOfMeasures",
                column: "ProductUnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrProductUnitOfMeasures_ProductUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "ProductUnitOfMeasureId",
                principalTable: "TrProductUnitOfMeasures",
                principalColumn: "ProductUnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductUnitOfMeasures_DcProducts_ProductCode",
                table: "TrProductUnitOfMeasures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductUnitOfMeasures_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrProductUnitOfMeasures",
                column: "UnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrProductUnitOfMeasures_ProductUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductUnitOfMeasures_DcProducts_ProductCode",
                table: "TrProductUnitOfMeasures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductUnitOfMeasures_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrProductUnitOfMeasures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductUnitOfMeasures",
                table: "TrProductUnitOfMeasures");

            migrationBuilder.RenameTable(
                name: "TrProductUnitOfMeasures",
                newName: "TrProductUnitOfMeasure");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductUnitOfMeasures_UnitOfMeasureId",
                table: "TrProductUnitOfMeasure",
                newName: "IX_TrProductUnitOfMeasure_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductUnitOfMeasures_ProductCode",
                table: "TrProductUnitOfMeasure",
                newName: "IX_TrProductUnitOfMeasure_ProductCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductUnitOfMeasure",
                table: "TrProductUnitOfMeasure",
                column: "ProductUnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrProductUnitOfMeasure_ProductUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "ProductUnitOfMeasureId",
                principalTable: "TrProductUnitOfMeasure",
                principalColumn: "ProductUnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductUnitOfMeasure_DcProducts_ProductCode",
                table: "TrProductUnitOfMeasure",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductUnitOfMeasure_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrProductUnitOfMeasure",
                column: "UnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
