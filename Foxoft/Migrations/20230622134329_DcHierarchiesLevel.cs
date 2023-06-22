using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcHierarchiesLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HierarchyCode01",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyCode02",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyCode03",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyCode04",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyCode05",
                table: "DcHierarchies");

            migrationBuilder.RenameColumn(
                name: "HierarchyDesc05",
                table: "DcHierarchies",
                newName: "HierarchyLevelDesc05");

            migrationBuilder.RenameColumn(
                name: "HierarchyDesc04",
                table: "DcHierarchies",
                newName: "HierarchyLevelDesc04");

            migrationBuilder.RenameColumn(
                name: "HierarchyDesc03",
                table: "DcHierarchies",
                newName: "HierarchyLevelDesc03");

            migrationBuilder.RenameColumn(
                name: "HierarchyDesc02",
                table: "DcHierarchies",
                newName: "HierarchyLevelDesc02");

            migrationBuilder.RenameColumn(
                name: "HierarchyDesc01",
                table: "DcHierarchies",
                newName: "HierarchyLevelDesc01");

            migrationBuilder.AddColumn<int>(
                name: "HierarchyLevelCode01",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "HierarchyLevelCode02",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "HierarchyLevelCode03",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "HierarchyLevelCode04",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "HierarchyLevelCode05",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HierarchyLevelCode01",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyLevelCode02",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyLevelCode03",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyLevelCode04",
                table: "DcHierarchies");

            migrationBuilder.DropColumn(
                name: "HierarchyLevelCode05",
                table: "DcHierarchies");

            migrationBuilder.RenameColumn(
                name: "HierarchyLevelDesc05",
                table: "DcHierarchies",
                newName: "HierarchyDesc05");

            migrationBuilder.RenameColumn(
                name: "HierarchyLevelDesc04",
                table: "DcHierarchies",
                newName: "HierarchyDesc04");

            migrationBuilder.RenameColumn(
                name: "HierarchyLevelDesc03",
                table: "DcHierarchies",
                newName: "HierarchyDesc03");

            migrationBuilder.RenameColumn(
                name: "HierarchyLevelDesc02",
                table: "DcHierarchies",
                newName: "HierarchyDesc02");

            migrationBuilder.RenameColumn(
                name: "HierarchyLevelDesc01",
                table: "DcHierarchies",
                newName: "HierarchyDesc01");

            migrationBuilder.AddColumn<int>(
                name: "HierarchyCode01",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HierarchyCode02",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HierarchyCode03",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HierarchyCode04",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HierarchyCode05",
                table: "DcHierarchies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
