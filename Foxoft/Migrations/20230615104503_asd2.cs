using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures");

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures");

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
