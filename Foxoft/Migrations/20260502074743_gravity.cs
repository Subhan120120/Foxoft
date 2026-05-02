using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class gravity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "WhatsAppProvider",
                table: "AppSettings",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.CreateTable(
                name: "DcWhatsAppProviderSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InstanceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcWhatsAppProviderSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DcWhatsAppProviderSettings",
                columns: new[] { "Id", "ApiKey", "InstanceName", "ServerUrl" },
                values: new object[] { 1, "2fdqo0JtF6dnG23N7JbnZ9wMoVMRvRkh", "tokla", "https://evolution.tokla.az" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcWhatsAppProviderSettings");

            migrationBuilder.DropColumn(
                name: "WhatsAppProvider",
                table: "AppSettings");
        }
    }
}
