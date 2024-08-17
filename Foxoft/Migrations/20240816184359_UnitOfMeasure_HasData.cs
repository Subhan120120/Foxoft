using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasure_HasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcUnitOfMeasures",
                columns: new[] { "UnitOfMeasureCode", "Level" },
                values: new object[,]
                {
                    { "Ədəd", (byte)1 },
                    { "Qutu", (byte)1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureCode",
                keyValue: "Ədəd");

            migrationBuilder.DeleteData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureCode",
                keyValue: "Qutu");
        }
    }
}
