using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asddfgfgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_SiteProduct_SiteProductId",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteProduct_DcProducts_ProductCode",
                table: "SiteProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteProduct",
                table: "SiteProduct");

            migrationBuilder.RenameTable(
                name: "SiteProduct",
                newName: "SiteProducts");

            migrationBuilder.RenameIndex(
                name: "IX_SiteProduct_ProductCode",
                table: "SiteProducts",
                newName: "IX_SiteProducts_ProductCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteProducts",
                table: "SiteProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_SiteProducts_SiteProductId",
                table: "DcProducts",
                column: "SiteProductId",
                principalTable: "SiteProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteProducts_DcProducts_ProductCode",
                table: "SiteProducts",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_SiteProducts_SiteProductId",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteProducts_DcProducts_ProductCode",
                table: "SiteProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteProducts",
                table: "SiteProducts");

            migrationBuilder.RenameTable(
                name: "SiteProducts",
                newName: "SiteProduct");

            migrationBuilder.RenameIndex(
                name: "IX_SiteProducts_ProductCode",
                table: "SiteProduct",
                newName: "IX_SiteProduct_ProductCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteProduct",
                table: "SiteProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_SiteProduct_SiteProductId",
                table: "DcProducts",
                column: "SiteProductId",
                principalTable: "SiteProduct",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteProduct_DcProducts_ProductCode",
                table: "SiteProduct",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
