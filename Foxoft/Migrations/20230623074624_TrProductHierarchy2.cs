using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrProductHierarchy2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcHierarchies",
                columns: table => new
                {
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HierarchyDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcHierarchies", x => x.HierarchyCode);
                });

            migrationBuilder.CreateTable(
                name: "TrProductHierarchies",
                columns: table => new
                {
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProductHierarchies", x => new { x.ProductCode, x.HierarchyCode });
                    table.ForeignKey(
                        name: "FK_TrProductHierarchies_DcHierarchies_HierarchyCode",
                        column: x => x.HierarchyCode,
                        principalTable: "DcHierarchies",
                        principalColumn: "HierarchyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductHierarchies_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrProductHierarchies_HierarchyCode",
                table: "TrProductHierarchies",
                column: "HierarchyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrProductHierarchies");

            migrationBuilder.DropTable(
                name: "DcHierarchies");
        }
    }
}
