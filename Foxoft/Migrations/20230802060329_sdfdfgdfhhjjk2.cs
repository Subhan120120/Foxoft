using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdfdfgdfhhjjk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "TrHierarchyFeature");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "DcHierarchies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "DcHierarchies");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "TrHierarchyFeature",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
