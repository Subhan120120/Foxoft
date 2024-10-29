using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class SettingStoreDefaultUnitOfMeasure3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultUnitOfMeasure",
                table: "SettingStores",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DefaultUnitOfMeasure",
                table: "DcProducts",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_DefaultUnitOfMeasure",
                table: "SettingStores",
                column: "DefaultUnitOfMeasure");

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
                name: "FK_SettingStores_DcUnitOfMeasures_DefaultUnitOfMeasure",
                table: "SettingStores",
                column: "DefaultUnitOfMeasure",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasures_DefaultUnitOfMeasure",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasures_DefaultUnitOfMeasure",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_DefaultUnitOfMeasure",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_DcProducts_DefaultUnitOfMeasure",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasure",
                table: "SettingStores");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasure",
                table: "DcProducts");
        }
    }
}
