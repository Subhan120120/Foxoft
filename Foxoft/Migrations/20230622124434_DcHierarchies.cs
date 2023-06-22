using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcHierarchies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hierarchies",
                table: "Hierarchies");

            migrationBuilder.RenameTable(
                name: "Hierarchies",
                newName: "DcHierarchies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcHierarchies",
                table: "DcHierarchies",
                column: "HierarchyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcHierarchies",
                table: "DcHierarchies");

            migrationBuilder.RenameTable(
                name: "DcHierarchies",
                newName: "Hierarchies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hierarchies",
                table: "Hierarchies",
                column: "HierarchyId");
        }
    }
}
