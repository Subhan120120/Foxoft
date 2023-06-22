using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcHierarchiesLevel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HierarchyLevelDesc01",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyLevelDesc02",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyLevelDesc03",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyLevelDesc04",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyLevelDesc05",
                table: "DcHierarchies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HierarchyLevelDesc01",
                table: "DcHierarchies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HierarchyLevelDesc02",
                table: "DcHierarchies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HierarchyLevelDesc03",
                table: "DcHierarchies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HierarchyLevelDesc04",
                table: "DcHierarchies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HierarchyLevelDesc05",
                table: "DcHierarchies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
