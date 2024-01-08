using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcReportVariable_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VariableOperatorType",
                table: "DcReportVariables");

            migrationBuilder.AddColumn<string>(
                name: "VariableOperator",
                table: "DcReportVariables",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VariableValueType",
                table: "DcReportVariables",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VariableOperator",
                table: "DcReportVariables");

            migrationBuilder.DropColumn(
                name: "VariableValueType",
                table: "DcReportVariables");

            migrationBuilder.AddColumn<string>(
                name: "VariableOperatorType",
                table: "DcReportVariables",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
