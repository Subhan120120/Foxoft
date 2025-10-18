using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class settingstore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores");


            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores",
                column: "StoreCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 59);

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 51,
                column: "ClaimCode",
                value: "ChangePriceRP");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 52,
                column: "ClaimCode",
                value: "ChangePriceWP");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 53,
                column: "ClaimCode",
                value: "ChangePriceRS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 54,
                column: "ClaimCode",
                value: "ChangePriceWS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 55,
                column: "ClaimCode",
                value: "ChangePriceIP");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 56,
                column: "ClaimCode",
                value: "ChangePriceIS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 57,
                column: "ClaimCode",
                value: "ChangePriceCI");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 58,
                column: "ClaimCode",
                value: "ChangePriceCO");

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
    }
}
