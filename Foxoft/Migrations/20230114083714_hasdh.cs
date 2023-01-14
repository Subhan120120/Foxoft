using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class hasdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01",
                column: "IsDefault",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01",
                column: "IsDefault",
                value: false);
        }
    }
}
