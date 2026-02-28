using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class terminalPrinterName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrinterName",
                table: "DcTerminals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 1,
                column: "PrinterName",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 2,
                column: "PrinterName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrinterName",
                table: "DcTerminals");
        }
    }
}
