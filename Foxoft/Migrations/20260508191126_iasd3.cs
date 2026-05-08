using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class iasd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceiverCurrAccCode",
                table: "TrWhatsAppMessageLogs",
                newName: "CurrAccCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrAccCode",
                table: "TrWhatsAppMessageLogs",
                newName: "ReceiverCurrAccCode");
        }
    }
}
