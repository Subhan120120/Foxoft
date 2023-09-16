using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class PriceTypeCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPriceListHeaders_DcPriceListTypes_PriceListTypeCode",
                table: "TrPriceListHeaders");

            migrationBuilder.RenameColumn(
                name: "PriceListTypeCode",
                table: "TrPriceListHeaders",
                newName: "PriceTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrPriceListHeaders_PriceListTypeCode",
                table: "TrPriceListHeaders",
                newName: "IX_TrPriceListHeaders_PriceTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPriceListHeaders_DcPriceListTypes_PriceTypeCode",
                table: "TrPriceListHeaders",
                column: "PriceTypeCode",
                principalTable: "DcPriceListTypes",
                principalColumn: "PriceListTypeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPriceListHeaders_DcPriceListTypes_PriceTypeCode",
                table: "TrPriceListHeaders");

            migrationBuilder.RenameColumn(
                name: "PriceTypeCode",
                table: "TrPriceListHeaders",
                newName: "PriceListTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrPriceListHeaders_PriceTypeCode",
                table: "TrPriceListHeaders",
                newName: "IX_TrPriceListHeaders_PriceListTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPriceListHeaders_DcPriceListTypes_PriceListTypeCode",
                table: "TrPriceListHeaders",
                column: "PriceListTypeCode",
                principalTable: "DcPriceListTypes",
                principalColumn: "PriceListTypeCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
