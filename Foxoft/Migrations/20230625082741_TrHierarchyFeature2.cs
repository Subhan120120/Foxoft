using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrHierarchyFeature2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeature_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeature_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeature");

            migrationBuilder.AddForeignKey(
                name: "FK_TrHierarchyFeature_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeature",
                column: "FeatureTypeId",
                principalTable: "DcFeatureTypes",
                principalColumn: "FeatureTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrHierarchyFeature_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeature",
                column: "HierarchyCode",
                principalTable: "DcHierarchies",
                principalColumn: "HierarchyCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeature_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeature_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeature");

            migrationBuilder.AddForeignKey(
                name: "FK_TrHierarchyFeature_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeature",
                column: "FeatureTypeId",
                principalTable: "DcFeatureTypes",
                principalColumn: "FeatureTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrHierarchyFeature_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeature",
                column: "HierarchyCode",
                principalTable: "DcHierarchies",
                principalColumn: "HierarchyCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
