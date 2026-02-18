using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class iniasdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosTerminalId",
                table: "TrInvoiceHeaders");

            migrationBuilder.AddColumn<int>(
                name: "TerminalId",
                table: "TrInvoiceHeaders",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "TrInvoiceHeaders");

            migrationBuilder.AddColumn<string>(
                name: "PosTerminalId",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
