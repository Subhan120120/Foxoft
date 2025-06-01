using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ParentUnitOfMeasure3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DcUnitOfMeasures_ParentUnitOfMeasureId",
                table: "DcUnitOfMeasures",
                column: "ParentUnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcUnitOfMeasures_DcUnitOfMeasures_ParentUnitOfMeasureId",
                table: "DcUnitOfMeasures",
                column: "ParentUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcUnitOfMeasures_DcUnitOfMeasures_ParentUnitOfMeasureId",
                table: "DcUnitOfMeasures");

            migrationBuilder.DropIndex(
                name: "IX_DcUnitOfMeasures_ParentUnitOfMeasureId",
                table: "DcUnitOfMeasures");
        }
    }
}
