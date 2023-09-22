using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdgfgh2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductDiscount_DcDiscounts_DiscountId",
                table: "TrProductDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductDiscount_DcProducts_ProductCode",
                table: "TrProductDiscount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductDiscount",
                table: "TrProductDiscount");

            migrationBuilder.RenameTable(
                name: "TrProductDiscount",
                newName: "TrProductDiscounts");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductDiscount_DiscountId",
                table: "TrProductDiscounts",
                newName: "IX_TrProductDiscounts_DiscountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductDiscounts",
                table: "TrProductDiscounts",
                columns: new[] { "ProductCode", "DiscountId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductDiscounts_DcDiscounts_DiscountId",
                table: "TrProductDiscounts",
                column: "DiscountId",
                principalTable: "DcDiscounts",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductDiscounts_DcProducts_ProductCode",
                table: "TrProductDiscounts",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductDiscounts_DcDiscounts_DiscountId",
                table: "TrProductDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductDiscounts_DcProducts_ProductCode",
                table: "TrProductDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductDiscounts",
                table: "TrProductDiscounts");

            migrationBuilder.RenameTable(
                name: "TrProductDiscounts",
                newName: "TrProductDiscount");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductDiscounts_DiscountId",
                table: "TrProductDiscount",
                newName: "IX_TrProductDiscount_DiscountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductDiscount",
                table: "TrProductDiscount",
                columns: new[] { "ProductCode", "DiscountId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductDiscount_DcDiscounts_DiscountId",
                table: "TrProductDiscount",
                column: "DiscountId",
                principalTable: "DcDiscounts",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductDiscount_DcProducts_ProductCode",
                table: "TrProductDiscount",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
