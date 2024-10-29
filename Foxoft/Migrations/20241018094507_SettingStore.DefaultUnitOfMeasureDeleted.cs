using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class SettingStoreDefaultUnitOfMeasureDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores",
                type: "nvarchar(25)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultUnitOfMeasure",
                table: "SettingStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultUnitOfMeasure",
                table: "DcProducts",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01",
                column: "DefaultUnitOfMeasure",
                value: "Ədəd");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02",
                column: "DefaultUnitOfMeasure",
                value: "Ədəd");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "DefaultUnitOfMeasure",
                value: "Ədəd");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "DefaultUnitOfMeasure",
                value: "Ədəd");

            migrationBuilder.UpdateData(
                table: "SettingStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DcUnitOfMeasureUnitOfMeasureCode", "DefaultUnitOfMeasure" },
                values: new object[] { null, "Ədəd" });

            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores",
                column: "DcUnitOfMeasureUnitOfMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_DefaultUnitOfMeasure",
                table: "DcProducts",
                column: "DefaultUnitOfMeasure");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasures_DefaultUnitOfMeasure",
                table: "DcProducts",
                column: "DefaultUnitOfMeasure",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasures_DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores",
                column: "DcUnitOfMeasureUnitOfMeasureCode",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
