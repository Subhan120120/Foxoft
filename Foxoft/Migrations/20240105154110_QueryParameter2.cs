using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class QueryParameter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_TrReportSubQueries_TrReportSubQuerySubQueryId",
                table: "DcQueryParams");

            migrationBuilder.DropIndex(
                name: "IX_DcQueryParams_TrReportSubQuerySubQueryId",
                table: "DcQueryParams");

            migrationBuilder.DropColumn(
                name: "TrReportSubQuerySubQueryId",
                table: "DcQueryParams");

            migrationBuilder.RenameColumn(
                name: "QueryId",
                table: "DcQueryParams",
                newName: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_ReportId",
                table: "DcQueryParams",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_DcReports_ReportId",
                table: "DcQueryParams",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_DcReports_ReportId",
                table: "DcQueryParams");

            migrationBuilder.DropIndex(
                name: "IX_DcQueryParams_ReportId",
                table: "DcQueryParams");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "DcQueryParams",
                newName: "QueryId");

            migrationBuilder.AddColumn<int>(
                name: "TrReportSubQuerySubQueryId",
                table: "DcQueryParams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_TrReportSubQuerySubQueryId",
                table: "DcQueryParams",
                column: "TrReportSubQuerySubQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_TrReportSubQueries_TrReportSubQuerySubQueryId",
                table: "DcQueryParams",
                column: "TrReportSubQuerySubQueryId",
                principalTable: "TrReportSubQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
