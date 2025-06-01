using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class ParentUnitOfMeasure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AlterColumn<int>(
                name: "ParentUnitOfMeasureId",
                table: "DcUnitOfMeasures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                column: "ParentUnitOfMeasureId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                column: "ParentUnitOfMeasureId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3,
                column: "ParentUnitOfMeasureId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4,
                column: "ParentUnitOfMeasureId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentUnitOfMeasureId",
                table: "DcUnitOfMeasures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                column: "ParentUnitOfMeasureId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                column: "ParentUnitOfMeasureId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3,
                column: "ParentUnitOfMeasureId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4,
                column: "ParentUnitOfMeasureId",
                value: 0);

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
    }
}
