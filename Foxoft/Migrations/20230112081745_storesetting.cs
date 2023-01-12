using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class storesetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SettingStoreId",
                table: "DcCurrAccs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalCurrencyCode",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SettingStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DesignFileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFolder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingStores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SettingStores",
                columns: new[] { "Id", "DesignFileFolder", "ImageFolder", "StoreCode" },
                values: new object[] { 1, "C:\\Foxoft\\Foxoft Design Files", "C:\\Foxoft\\Foxoft Images", "mgz01" });

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_SettingStoreId",
                table: "DcCurrAccs",
                column: "SettingStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_SettingStores_SettingStoreId",
                table: "DcCurrAccs",
                column: "SettingStoreId",
                principalTable: "SettingStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_SettingStores_SettingStoreId",
                table: "DcCurrAccs");

            migrationBuilder.DropTable(
                name: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAccs_SettingStoreId",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "SettingStoreId",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "LocalCurrencyCode",
                table: "AppSettings");
        }
    }
}
