using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdfdfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcTerminals",
                table: "DcTerminals");

            migrationBuilder.DropColumn(
                name: "TerminalCode",
                table: "DcTerminals");

            migrationBuilder.AddColumn<int>(
                name: "TerminalId",
                table: "DcTerminals",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TouchScaleFactor",
                table: "DcTerminals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TouchUIMode",
                table: "DcTerminals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcTerminals",
                table: "DcTerminals",
                column: "TerminalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcTerminals",
                table: "DcTerminals");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "DcTerminals");

            migrationBuilder.DropColumn(
                name: "TouchScaleFactor",
                table: "DcTerminals");

            migrationBuilder.DropColumn(
                name: "TouchUIMode",
                table: "DcTerminals");

            migrationBuilder.AddColumn<string>(
                name: "TerminalCode",
                table: "DcTerminals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcTerminals",
                table: "DcTerminals",
                column: "TerminalCode");
        }
    }
}
