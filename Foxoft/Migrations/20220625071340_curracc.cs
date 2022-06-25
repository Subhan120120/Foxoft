using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class curracc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "VendorTypeCode",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                table: "DcCurrAccs",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "DataLanguageCode",
                table: "DcCurrAccs",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<double>(
                name: "CustomerPosDiscountRate",
                table: "DcCurrAccs",
                type: "float",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                column: "VendorTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                column: "VendorTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-3",
                column: "VendorTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                column: "VendorTypeCode",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "VendorTypeCode",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                table: "DcCurrAccs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "DataLanguageCode",
                table: "DcCurrAccs",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<double>(
                name: "CustomerPosDiscountRate",
                table: "DcCurrAccs",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValueSql: "0");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                column: "VendorTypeCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                column: "VendorTypeCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-3",
                column: "VendorTypeCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                column: "VendorTypeCode",
                value: (byte)0);
        }
    }
}
