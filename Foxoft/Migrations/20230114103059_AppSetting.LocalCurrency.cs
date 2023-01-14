using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class AppSettingLocalCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocalCurrencyCode",
                table: "AppSettings",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_LocalCurrencyCode",
                table: "AppSettings",
                column: "LocalCurrencyCode",
                unique: true,
                filter: "[LocalCurrencyCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSettings_DcCurrencies_LocalCurrencyCode",
                table: "AppSettings",
                column: "LocalCurrencyCode",
                principalTable: "DcCurrencies",
                principalColumn: "CurrencyCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSettings_DcCurrencies_LocalCurrencyCode",
                table: "AppSettings");

            migrationBuilder.DropIndex(
                name: "IX_AppSettings_LocalCurrencyCode",
                table: "AppSettings");

            migrationBuilder.AlterColumn<string>(
                name: "LocalCurrencyCode",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);
        }
    }
}
