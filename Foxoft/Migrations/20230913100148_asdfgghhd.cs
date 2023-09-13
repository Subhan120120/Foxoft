using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfgghhd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "PL",
                column: "ProcessDir",
                value: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "PL",
                column: "ProcessDir",
                value: (byte)2);
        }
    }
}
