using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcProcessCustomCurrencyCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomCurrencyCode",
                table: "DcProcesses",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcProcesses_CustomCurrencyCode",
                table: "DcProcesses",
                column: "CustomCurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProcesses_DcCurrencies_CustomCurrencyCode",
                table: "DcProcesses",
                column: "CustomCurrencyCode",
                principalTable: "DcCurrencies",
                principalColumn: "CurrencyCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProcesses_DcCurrencies_CustomCurrencyCode",
                table: "DcProcesses");

            migrationBuilder.DropIndex(
                name: "IX_DcProcesses_CustomCurrencyCode",
                table: "DcProcesses");

            migrationBuilder.DropColumn(
                name: "CustomCurrencyCode",
                table: "DcProcesses");
        }
    }
}
