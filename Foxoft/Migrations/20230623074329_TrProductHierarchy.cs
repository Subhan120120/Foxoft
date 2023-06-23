using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class TrProductHierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcHierarchies");

            migrationBuilder.DropTable(
                name: "DcHierarchyNames");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcHierarchies",
                columns: table => new
                {
                    HierarchyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HierarchyLevelCode01 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelCode02 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelCode03 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelCode04 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelCode05 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcHierarchies", x => x.HierarchyId);
                });

            migrationBuilder.CreateTable(
                name: "DcHierarchyNames",
                columns: table => new
                {
                    HierarchyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HierarchyLevelCode01 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelCode02 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelCode03 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelCode04 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelCode05 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelDesc01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevelDesc02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevelDesc03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevelDesc04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevelDesc05 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcHierarchyNames", x => x.HierarchyId);
                });
        }
    }
}
