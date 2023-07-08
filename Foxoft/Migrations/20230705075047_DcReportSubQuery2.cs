using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcReportSubQuery2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_DcReportQueries_QueryId",
                table: "DcQueryParams");

            migrationBuilder.DropForeignKey(
                name: "FK_DcReportQueries_DcReports_ReportId",
                table: "DcReportQueries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcReportQueries",
                table: "DcReportQueries");

            migrationBuilder.RenameTable(
                name: "DcReportQueries",
                newName: "DcReportSubQueries");

            migrationBuilder.RenameIndex(
                name: "IX_DcReportQueries_ReportId",
                table: "DcReportSubQueries",
                newName: "IX_DcReportSubQueries_ReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcReportSubQueries",
                table: "DcReportSubQueries",
                column: "SubQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_DcReportSubQueries_QueryId",
                table: "DcQueryParams",
                column: "QueryId",
                principalTable: "DcReportSubQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcReportSubQueries_DcReports_ReportId",
                table: "DcReportSubQueries",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_DcReportSubQueries_QueryId",
                table: "DcQueryParams");

            migrationBuilder.DropForeignKey(
                name: "FK_DcReportSubQueries_DcReports_ReportId",
                table: "DcReportSubQueries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcReportSubQueries",
                table: "DcReportSubQueries");

            migrationBuilder.RenameTable(
                name: "DcReportSubQueries",
                newName: "DcReportQueries");

            migrationBuilder.RenameIndex(
                name: "IX_DcReportSubQueries_ReportId",
                table: "DcReportQueries",
                newName: "IX_DcReportQueries_ReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcReportQueries",
                table: "DcReportQueries",
                column: "SubQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_DcReportQueries_QueryId",
                table: "DcQueryParams",
                column: "QueryId",
                principalTable: "DcReportQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcReportQueries_DcReports_ReportId",
                table: "DcReportQueries",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
