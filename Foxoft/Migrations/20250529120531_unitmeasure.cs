using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class unitmeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrProductUnitOfMeasures_ProductUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropTable(
                name: "TrProductUnitOfMeasures");

            migrationBuilder.RenameColumn(
                name: "ProductUnitOfMeasureId",
                table: "TrInvoiceLines",
                newName: "UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceLines_ProductUnitOfMeasureId",
                table: "TrInvoiceLines",
                newName: "IX_TrInvoiceLines_UnitOfMeasureId");

            migrationBuilder.AddColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "AppSettings",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "DefaultUnitOfMeasureId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_DefaultUnitOfMeasureId",
                table: "AppSettings",
                column: "DefaultUnitOfMeasureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSettings_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "AppSettings",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSettings_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "AppSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_AppSettings_DefaultUnitOfMeasureId",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasureId",
                table: "AppSettings");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasureId",
                table: "TrInvoiceLines",
                newName: "ProductUnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceLines_UnitOfMeasureId",
                table: "TrInvoiceLines",
                newName: "IX_TrInvoiceLines_ProductUnitOfMeasureId");

            migrationBuilder.CreateTable(
                name: "TrProductUnitOfMeasures",
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
                    table.PrimaryKey("PK_TrProductUnitOfMeasures", x => x.ProductUnitOfMeasureId);
                    table.ForeignKey(
                        name: "FK_TrProductUnitOfMeasures_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductUnitOfMeasures_DcUnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "DcUnitOfMeasures",
                        principalColumn: "UnitOfMeasureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrProductUnitOfMeasures_ProductCode",
                table: "TrProductUnitOfMeasures",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductUnitOfMeasures_UnitOfMeasureId",
                table: "TrProductUnitOfMeasures",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrProductUnitOfMeasures_ProductUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "ProductUnitOfMeasureId",
                principalTable: "TrProductUnitOfMeasures",
                principalColumn: "ProductUnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
