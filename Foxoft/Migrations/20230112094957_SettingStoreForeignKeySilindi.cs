using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class SettingStoreForeignKeySilindi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_SettingStores_SettingStoreId",
                table: "DcCurrAccs");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAccs_SettingStoreId",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "SettingStoreId",
                table: "DcCurrAccs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SettingStoreId",
                table: "DcCurrAccs",
                type: "int",
                nullable: true);

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
    }
}
