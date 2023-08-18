using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdffghjhk4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeature_DcFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_TrHierarchyFeature_DcHierarchies_HierarchyCode",
                table: "TrHierarchyFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrHierarchyFeature",
                table: "TrHierarchyFeature");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DcHierarchies");

            migrationBuilder.RenameTable(
                name: "TrHierarchyFeature",
                newName: "TrHierarchyFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_TrHierarchyFeature_FeatureTypeId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "TrHierarchyFeature");

            migrationBuilder.RenameIndex(
                name: "IX_TrHierarchyFeatures_FeatureTypeId",
                table: "TrHierarchyFeature",
                newName: "IX_TrHierarchyFeature_FeatureTypeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrHierarchyFeature",
                table: "TrHierarchyFeature",
                columns: new[] { "HierarchyCode", "FeatureTypeId" });

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
    }
}
