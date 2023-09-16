using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class PriceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceListTypeDesc",
                table: "DcPriceListTypes",
                newName: "PriceTypeDesc");

            migrationBuilder.RenameColumn(
                name: "PriceListTypeCode",
                table: "DcPriceListTypes",
                newName: "PriceTypeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceTypeDesc",
                table: "DcPriceListTypes",
                newName: "PriceListTypeDesc");

            migrationBuilder.RenameColumn(
                name: "PriceTypeCode",
                table: "DcPriceListTypes",
                newName: "PriceListTypeCode");
        }
    }
}
