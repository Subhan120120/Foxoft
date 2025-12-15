using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class dcprocess2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CN",
                column: "ProcessDir",
                value: (byte)2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CN",
                column: "ProcessDir",
                value: (byte)0);
        }
    }
}
