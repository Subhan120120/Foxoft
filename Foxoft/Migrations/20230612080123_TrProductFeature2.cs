using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrProductFeature2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProductDcFeatures_DcFeatures_FeatureId",
                table: "DcProductDcFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_DcProductDcFeatures_DcProducts_ProductCode",
                table: "DcProductDcFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcProductDcFeatures",
                table: "DcProductDcFeatures");

            migrationBuilder.RenameTable(
                name: "DcProductDcFeatures",
                newName: "TrProductFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_DcProductDcFeatures_FeatureId",
                table: "TrProductFeatures",
                newName: "IX_TrProductFeatures_FeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureId",
                table: "TrProductFeatures",
                column: "FeatureId",
                principalTable: "DcFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_TrProductFeatures_DcFeatures_FeatureId",
                table: "TrProductFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcProducts_ProductCode",
                table: "TrProductFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.RenameTable(
                name: "TrProductFeatures",
                newName: "DcProductDcFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_TrProductFeatures_FeatureId",
                table: "DcProductDcFeatures",
                newName: "IX_DcProductDcFeatures_FeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcProductDcFeatures",
                table: "DcProductDcFeatures",
                columns: new[] { "ProductCode", "FeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DcProductDcFeatures_DcFeatures_FeatureId",
                table: "DcProductDcFeatures",
                column: "FeatureId",
                principalTable: "DcFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcProductDcFeatures_DcProducts_ProductCode",
                table: "DcProductDcFeatures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
