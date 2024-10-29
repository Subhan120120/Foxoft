using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ConversionRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ConversionRate",
                table: "DcUnitOfMeasure",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                column: "ConversionRate",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasure",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                column: "ConversionRate",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversionRate",
                table: "DcUnitOfMeasure");
        }
    }
}
