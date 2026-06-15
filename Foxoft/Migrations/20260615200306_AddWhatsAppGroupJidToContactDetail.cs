using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddWhatsAppGroupJidToContactDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhatsAppGroupJid",
                table: "DcCurrAccContactDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SettingStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DesignFileFolder", "ImageFolder" },
                values: new object[] { "C:\\Foxoft\\CompanyCode\\Design Files", "C:\\Foxoft\\CompanyCode\\Image Files" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhatsAppGroupJid",
                table: "DcCurrAccContactDetails");

            migrationBuilder.UpdateData(
                table: "SettingStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DesignFileFolder", "ImageFolder" },
                values: new object[] { "C:\\Foxoft\\Foxoft Design Files", "C:\\Foxoft\\Foxoft Images" });
        }
    }
}
