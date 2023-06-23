using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcHierarchyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcHierarchyNames",
                columns: table => new
                {
                    HierarchyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HierarchyLevelCode01 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelDesc01 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevelCode02 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelDesc02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevelCode03 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelDesc03 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevelCode04 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelDesc04 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HierarchyLevelCode05 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    HierarchyLevelDesc05 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcHierarchyNames", x => x.HierarchyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcHierarchyNames");
        }
    }
}
