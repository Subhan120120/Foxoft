using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_TerminalId",
                table: "TrInvoiceHeaders",
                column: "TerminalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_DcTerminals_TerminalId",
                table: "TrInvoiceHeaders",
                column: "TerminalId",
                principalTable: "DcTerminals",
                principalColumn: "TerminalId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_DcTerminals_TerminalId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_TerminalId",
                table: "TrInvoiceHeaders");
        }
    }
}
