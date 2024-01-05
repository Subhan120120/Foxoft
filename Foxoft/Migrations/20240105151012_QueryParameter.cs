using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class QueryParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentColumnName",
                table: "DcQueryParams",
                newName: "ParameterValue");

            migrationBuilder.RenameColumn(
                name: "ColumnName",
                table: "DcQueryParams",
                newName: "ParameterType");

            migrationBuilder.AddColumn<string>(
                name: "ParameterName",
                table: "DcQueryParams",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParameterName",
                table: "DcQueryParams");

            migrationBuilder.RenameColumn(
                name: "ParameterValue",
                table: "DcQueryParams",
                newName: "ParentColumnName");

            migrationBuilder.RenameColumn(
                name: "ParameterType",
                table: "DcQueryParams",
                newName: "ColumnName");
        }
    }
}
