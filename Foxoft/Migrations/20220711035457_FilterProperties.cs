using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class FilterProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilterString",
                table: "DcReportFilters",
                newName: "FilterValue");

            migrationBuilder.AddColumn<string>(
                name: "FilterOperator",
                table: "DcReportFilters",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilterProperty",
                table: "DcReportFilters",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilterOperator",
                table: "DcReportFilters");

            migrationBuilder.DropColumn(
                name: "FilterProperty",
                table: "DcReportFilters");

            migrationBuilder.RenameColumn(
                name: "FilterValue",
                table: "DcReportFilters",
                newName: "FilterString");
        }
    }
}
