using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class autoSendMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcSmsProviderSettings");

            migrationBuilder.DropColumn(
                name: "AutoSendIntervalSeconds",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AutoSendMaxRetries",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AutoSendUnsentMessages",
                table: "AppSettings");
        }
    }
}
