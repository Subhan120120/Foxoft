using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class processDir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProcessDesc",
                table: "DcProcesses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "ProcessDir",
                table: "DcProcesses",
                type: "tinyint",
                maxLength: 150,
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CI",
                column: "ProcessDir",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CO",
                column: "ProcessDir",
                value: (byte)2);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "EX",
                column: "ProcessDir",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "PA",
                column: "ProcessDir",
                value: (byte)2);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "PE",
                column: "ProcessDir",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "RP",
                column: "ProcessDir",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "RS",
                column: "ProcessDir",
                value: (byte)2);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "SB",
                column: "ProcessDir",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "WS",
                column: "ProcessDir",
                value: (byte)2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessDir",
                table: "DcProcesses");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessDesc",
                table: "DcProcesses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
