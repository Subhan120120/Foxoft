using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class SiteProductDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteProducts_DcProducts_ProductCode",
                table: "SiteProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteProducts_DcProducts_ProductCode",
                table: "SiteProducts",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteProducts_DcProducts_ProductCode",
                table: "SiteProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteProducts_DcProducts_ProductCode",
                table: "SiteProducts",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
