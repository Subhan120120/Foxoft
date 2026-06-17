using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
