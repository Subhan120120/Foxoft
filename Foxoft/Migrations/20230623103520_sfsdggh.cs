using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sfsdggh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TopHierarchyCode",
                table: "DcHierarchies",
                newName: "HierarchyParentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HierarchyParentCode",
                table: "DcHierarchies",
                newName: "TopHierarchyCode");
        }
    }
}
