using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcUnitOfMeasure7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasure_DefaultUnitOfMeasureId",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasure_DefaultUnitOfMeasureId",
                table: "SettingStores");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasure_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcUnitOfMeasure",
                table: "DcUnitOfMeasure");

            migrationBuilder.RenameTable(
                name: "DcUnitOfMeasure",
                newName: "DcUnitOfMeasures");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "SettingStores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "DcProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcUnitOfMeasures",
                table: "DcUnitOfMeasures",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "DcProducts",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "SettingStores",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "SettingStores");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcUnitOfMeasures",
                table: "DcUnitOfMeasures");

            migrationBuilder.RenameTable(
                name: "DcUnitOfMeasures",
                newName: "DcUnitOfMeasure");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "SettingStores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "DcProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcUnitOfMeasure",
                table: "DcUnitOfMeasure",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasure_DefaultUnitOfMeasureId",
                table: "DcProducts",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasure_DefaultUnitOfMeasureId",
                table: "SettingStores",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasure_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId",
                principalTable: "DcUnitOfMeasure",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
