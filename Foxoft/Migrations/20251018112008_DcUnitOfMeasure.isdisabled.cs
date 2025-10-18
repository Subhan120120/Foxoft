using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcUnitOfMeasureisdisabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "DcUnitOfMeasures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3,
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4,
                column: "IsDisabled",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "DcUnitOfMeasures");
        }
    }
}
