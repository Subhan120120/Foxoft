using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ProductUnitOfMeasureId3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "DcUnitOfMeasureUnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_DcUnitOfMeasureUnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "DcUnitOfMeasureUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
