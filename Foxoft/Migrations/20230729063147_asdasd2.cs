using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdasd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureCode",
                table: "TrProductFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.DropIndex(
                name: "IX_TrProductFeatures_FeatureCode",
                table: "TrProductFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcFeatures",
                table: "DcFeatures");

            migrationBuilder.AlterColumn<string>(
                name: "HierarchyDesc",
                table: "DcHierarchies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureTypeId", "FeatureCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcFeatures",
                table: "DcFeatures",
                columns: new[] { "FeatureCode", "FeatureTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrProductFeatures_FeatureCode_FeatureTypeId",
                table: "TrProductFeatures",
                columns: new[] { "FeatureCode", "FeatureTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureCode_FeatureTypeId",
                table: "TrProductFeatures",
                columns: new[] { "FeatureCode", "FeatureTypeId" },
                principalTable: "DcFeatures",
                principalColumns: new[] { "FeatureCode", "FeatureTypeId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureCode_FeatureTypeId",
                table: "TrProductFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures");

            migrationBuilder.DropIndex(
                name: "IX_TrProductFeatures_FeatureCode_FeatureTypeId",
                table: "TrProductFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcFeatures",
                table: "DcFeatures");

            migrationBuilder.AlterColumn<string>(
                name: "HierarchyDesc",
                table: "DcHierarchies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrProductFeatures",
                table: "TrProductFeatures",
                columns: new[] { "ProductCode", "FeatureTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcFeatures",
                table: "DcFeatures",
                column: "FeatureCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductFeatures_FeatureCode",
                table: "TrProductFeatures",
                column: "FeatureCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductFeatures_DcFeatures_FeatureCode",
                table: "TrProductFeatures",
                column: "FeatureCode",
                principalTable: "DcFeatures",
                principalColumn: "FeatureCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
