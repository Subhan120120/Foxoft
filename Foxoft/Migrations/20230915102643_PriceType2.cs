using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class PriceType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPriceListHeaders_DcPriceListTypes_PriceTypeCode",
                table: "TrPriceListHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcPriceListTypes",
                table: "DcPriceListTypes");

            migrationBuilder.RenameTable(
                name: "DcPriceListTypes",
                newName: "DcPriceTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcPriceTypes",
                table: "DcPriceTypes",
                column: "PriceTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPriceListHeaders_DcPriceTypes_PriceTypeCode",
                table: "TrPriceListHeaders",
                column: "PriceTypeCode",
                principalTable: "DcPriceTypes",
                principalColumn: "PriceTypeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPriceListHeaders_DcPriceTypes_PriceTypeCode",
                table: "TrPriceListHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcPriceTypes",
                table: "DcPriceTypes");

            migrationBuilder.RenameTable(
                name: "DcPriceTypes",
                newName: "DcPriceListTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcPriceListTypes",
                table: "DcPriceListTypes",
                column: "PriceTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPriceListHeaders_DcPriceListTypes_PriceTypeCode",
                table: "TrPriceListHeaders",
                column: "PriceTypeCode",
                principalTable: "DcPriceListTypes",
                principalColumn: "PriceTypeCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
