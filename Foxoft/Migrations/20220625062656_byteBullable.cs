using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class byteBullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "CustomerTypeCode",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                column: "CustomerTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                column: "CustomerTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-3",
                column: "CustomerTypeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                column: "CustomerTypeCode",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "CustomerTypeCode",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                column: "CustomerTypeCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                column: "CustomerTypeCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-3",
                column: "CustomerTypeCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-4",
                column: "CustomerTypeCode",
                value: (byte)0);
        }
    }
}
