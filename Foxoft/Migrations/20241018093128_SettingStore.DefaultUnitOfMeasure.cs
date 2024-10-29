using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class SettingStoreDefaultUnitOfMeasure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasures_DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores");

            migrationBuilder.DropColumn(
                name: "DcUnitOfMeasureUnitOfMeasureCode",
                table: "SettingStores");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasure",
                table: "SettingStores");

            migrationBuilder.AlterColumn<string>(
                name: "UnitOfMeasure",
                table: "TrInvoiceLines",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UnitOfMeasureCode",
                table: "DcUnitOfMeasures",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "DefaultUnitOfMeasure",
                table: "DcProducts",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01",
                column: "DefaultUnitOfMeasure",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02",
                column: "DefaultUnitOfMeasure",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "DefaultUnitOfMeasure",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "DefaultUnitOfMeasure",
                value: null);
        }
    }
}
