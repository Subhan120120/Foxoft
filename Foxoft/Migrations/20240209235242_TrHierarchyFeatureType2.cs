using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrHierarchyFeatureType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeatures_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeatures_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrHierarchyFeatures",
                table: "TrHierarchyFeatures");

            migrationBuilder.RenameTable(
                name: "TrHierarchyFeatures",
                newName: "TrHierarchyFeatureTypes");

            migrationBuilder.RenameIndex(
                name: "IX_TrHierarchyFeatures_FeatureTypeId",
                table: "TrHierarchyFeatureTypes",
                newName: "IX_TrHierarchyFeatureTypes_FeatureTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrHierarchyFeatureTypes",
                table: "TrHierarchyFeatureTypes",
                columns: new[] { "HierarchyCode", "FeatureTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrHierarchyFeatureTypes_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeatureTypes",
                column: "FeatureTypeId",
                principalTable: "DcFeatureTypes",
                principalColumn: "FeatureTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrHierarchyFeatureTypes_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeatureTypes",
                column: "HierarchyCode",
                principalTable: "DcHierarchies",
                principalColumn: "HierarchyCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeatureTypes_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeatureTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeatureTypes_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeatureTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrHierarchyFeatureTypes",
                table: "TrHierarchyFeatureTypes");

            migrationBuilder.RenameTable(
                name: "TrHierarchyFeatureTypes",
                newName: "TrHierarchyFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_TrHierarchyFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeatures",
                newName: "IX_TrHierarchyFeatures_FeatureTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrHierarchyFeatures",
                table: "TrHierarchyFeatures",
                columns: new[] { "HierarchyCode", "FeatureTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrHierarchyFeatures_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeatures",
                column: "FeatureTypeId",
                principalTable: "DcFeatureTypes",
                principalColumn: "FeatureTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrHierarchyFeatures_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeatures",
                column: "HierarchyCode",
                principalTable: "DcHierarchies",
                principalColumn: "HierarchyCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
