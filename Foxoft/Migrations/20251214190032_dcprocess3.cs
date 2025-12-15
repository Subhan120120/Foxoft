using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class dcprocess3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CN",
                column: "ProcessDir",
                value: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CN",
                column: "ProcessDir",
                value: (byte)2);
        }
    }
}
