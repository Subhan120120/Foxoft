using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class isDefaultCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCustomer",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "DefaultWarehouse",
                table: "DcCurrAccs");

            migrationBuilder.AddColumn<bool>(
                name: "isDefaultCustomer",
                table: "DcCurrAccs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDefaultCustomer",
                table: "DcCurrAccs");

            migrationBuilder.AddColumn<string>(
                name: "DefaultCustomer",
                table: "DcCurrAccs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultWarehouse",
                table: "DcCurrAccs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
