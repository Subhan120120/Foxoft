using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcTerminal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 2);
        }
    }
}
