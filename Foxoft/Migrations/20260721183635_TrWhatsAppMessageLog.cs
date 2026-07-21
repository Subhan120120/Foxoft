using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrWhatsAppMessageLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFilePath",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "TrWhatsAppMessageLogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.AddColumn<string>(
                name: "ImageFilePath",
                table: "TrWhatsAppMessageLogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
