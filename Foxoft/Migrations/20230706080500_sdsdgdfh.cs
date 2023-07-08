using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class sdsdgdfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_DcReportSubQueries_QueryId",
                table: "DcQueryParams");

            migrationBuilder.DropIndex(
                name: "IX_DcQueryParams_QueryId",
                table: "DcQueryParams");

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

            migrationBuilder.AddColumn<int>(
                name: "DcReportSubQuerySubQueryId",
                table: "DcQueryParams",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FeatureDesc",
                table: "DcFeatures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_DcReportSubQuerySubQueryId",
                table: "DcQueryParams",
                column: "DcReportSubQuerySubQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_DcReportSubQueries_DcReportSubQuerySubQueryId",
                table: "DcQueryParams",
                column: "DcReportSubQuerySubQueryId",
                principalTable: "DcReportSubQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_DcReportSubQueries_DcReportSubQuerySubQueryId",
                table: "DcQueryParams");

            migrationBuilder.DropIndex(
                name: "IX_DcQueryParams_DcReportSubQuerySubQueryId",
                table: "DcQueryParams");

            migrationBuilder.DropColumn(
                name: "DcReportSubQuerySubQueryId",
                table: "DcQueryParams");

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

            migrationBuilder.AlterColumn<string>(
                name: "FeatureDesc",
                table: "DcFeatures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_QueryId",
                table: "DcQueryParams",
                column: "QueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_DcReportSubQueries_QueryId",
                table: "DcQueryParams",
                column: "QueryId",
                principalTable: "DcReportSubQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
