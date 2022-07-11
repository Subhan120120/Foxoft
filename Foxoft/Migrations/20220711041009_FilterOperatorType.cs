using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class FilterOperatorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilterOperator",
                table: "DcReportFilters",
                newName: "FilterOperatorType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilterOperatorType",
                table: "DcReportFilters",
                newName: "FilterOperator");
        }
    }
}
