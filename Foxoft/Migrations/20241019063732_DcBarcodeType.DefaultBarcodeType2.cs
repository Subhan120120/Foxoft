using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcBarcodeTypeDefaultBarcodeType2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "DefaultBarcodeType",
                table: "DcBarcodeTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "DefaultBarcodeType",
                table: "DcBarcodeTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "EAN13",
                column: "DefaultBarcodeType",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "Serbest",
                column: "DefaultBarcodeType",
                value: false);
        }
    }
}
