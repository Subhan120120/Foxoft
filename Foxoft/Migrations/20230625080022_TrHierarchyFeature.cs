using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrHierarchyFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrHierarchyFeature",
                columns: table => new
                {
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrHierarchyFeature", x => new { x.HierarchyCode, x.FeatureTypeId });
                    table.ForeignKey(
                        name: "FK_TrHierarchyFeature_DcFeatureTypes_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "DcFeatureTypes",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrHierarchyFeature_DcHierarchies_HierarchyCode",
                        column: x => x.HierarchyCode,
                        principalTable: "DcHierarchies",
                        principalColumn: "HierarchyCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrHierarchyFeature_FeatureTypeId",
                table: "TrHierarchyFeature",
                column: "FeatureTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrHierarchyFeature");
        }
    }
}
