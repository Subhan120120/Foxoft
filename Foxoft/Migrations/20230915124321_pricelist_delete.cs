using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class pricelist_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPriceListLines_TrPriceListHeaders_PriceListHeaderId",
                table: "TrPriceListLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPriceListLines_TrPriceListHeaders_PriceListHeaderId",
                table: "TrPriceListLines",
                column: "PriceListHeaderId",
                principalTable: "TrPriceListHeaders",
                principalColumn: "PriceListHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPriceListLines_TrPriceListHeaders_PriceListHeaderId",
                table: "TrPriceListLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPriceListLines_TrPriceListHeaders_PriceListHeaderId",
                table: "TrPriceListLines",
                column: "PriceListHeaderId",
                principalTable: "TrPriceListHeaders",
                principalColumn: "PriceListHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
