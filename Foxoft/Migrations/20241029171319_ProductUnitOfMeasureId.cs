using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ProductUnitOfMeasureId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.AddColumn<int>(
                name: "DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductUnitOfMeasureId",
                table: "TrInvoiceLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrProductUnitOfMeasure",
                columns: table => new
                {
                    ProductUnitOfMeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProductUnitOfMeasure", x => x.ProductUnitOfMeasureId);
                    table.ForeignKey(
                        name: "FK_TrProductUnitOfMeasure_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductUnitOfMeasure_DcUnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "DcUnitOfMeasures",
                        principalColumn: "UnitOfMeasureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "DcUnitOfMeasureUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_ProductUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "ProductUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductUnitOfMeasure_ProductCode",
                table: "TrProductUnitOfMeasure",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductUnitOfMeasure_UnitOfMeasureId",
                table: "TrProductUnitOfMeasure",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "DcUnitOfMeasureUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrProductUnitOfMeasure_ProductUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "ProductUnitOfMeasureId",
                principalTable: "TrProductUnitOfMeasure",
                principalColumn: "ProductUnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrProductUnitOfMeasure_ProductUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropTable(
                name: "TrProductUnitOfMeasure");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_ProductUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "ProductUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
