using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class asdi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "TrWhatsAppMessageLogs");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "TrWhatsAppMessageLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "TrWhatsAppMessageLogs",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "TrWhatsAppMessageLogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
