using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdasiasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProductDcFeatures_DcProducts_ProductCode",
                table: "DcProductDcFeatures");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProductDcFeatures_DcProducts_ProductCode",
                table: "DcProductDcFeatures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProductDcFeatures_DcProducts_ProductCode",
                table: "DcProductDcFeatures");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProductDcFeatures_DcProducts_ProductCode",
                table: "DcProductDcFeatures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
