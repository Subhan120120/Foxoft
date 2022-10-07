using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class moneytrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromCashRegCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCashRegCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "ToCashRegCode",
                table: "TrPaymentHeaders");
        }
    }
}
