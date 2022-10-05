using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class NetAmountLoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountLoc",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetAmountLoc",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountLoc",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "NetAmountLoc",
                table: "TrInvoiceLines");

        }
    }
}
