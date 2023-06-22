using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class Hierarchies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hierarchies",
                columns: table => new
                {
                    HierarchyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HierarchyCode01 = table.Column<int>(type: "int", nullable: false),
                    HierarchyDesc01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyCode02 = table.Column<int>(type: "int", nullable: false),
                    HierarchyDesc02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyCode03 = table.Column<int>(type: "int", nullable: false),
                    HierarchyDesc03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyCode04 = table.Column<int>(type: "int", nullable: false),
                    HierarchyDesc04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyCode05 = table.Column<int>(type: "int", nullable: false),
                    HierarchyDesc05 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hierarchies", x => x.HierarchyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hierarchies");
        }
    }
}
