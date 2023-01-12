using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class storeSetting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores",
                column: "StoreCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores");
        }
    }
}
