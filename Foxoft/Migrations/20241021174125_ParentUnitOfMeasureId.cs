using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ParentUnitOfMeasureId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentUnitOfMeasureId",
                table: "DcUnitOfMeasure",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                column: "ParentUnitOfMeasureId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                column: "ParentUnitOfMeasureId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentUnitOfMeasureId",
                table: "DcUnitOfMeasure");
        }
    }
}
