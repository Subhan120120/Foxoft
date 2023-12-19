using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class dcterminal_defaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RowGuid",
                table: "DcTerminals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                table: "DcTerminals",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 1,
                column: "RowGuid",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 2,
                column: "RowGuid",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RowGuid",
                table: "DcTerminals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                table: "DcTerminals",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 1,
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 2,
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
