using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class IsBasic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBasic",
                table: "DcUnitOfMeasures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                column: "IsBasic",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                column: "IsBasic",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3,
                column: "IsBasic",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4,
                column: "IsBasic",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBasic",
                table: "DcUnitOfMeasures");
        }
    }
}
