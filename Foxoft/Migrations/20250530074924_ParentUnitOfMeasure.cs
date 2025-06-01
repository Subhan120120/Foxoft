using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ParentUnitOfMeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "DefaultUnitOfMeasureId",
                value: 0);
        }
    }
}
