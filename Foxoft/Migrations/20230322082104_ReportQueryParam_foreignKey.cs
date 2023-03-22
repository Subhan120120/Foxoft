using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class ReportQueryParam_foreignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_DcReportQueries_DcReportQueryQueryId",
                table: "DcQueryParams");

            migrationBuilder.DropIndex(
                name: "IX_DcQueryParams_DcReportQueryQueryId",
                table: "DcQueryParams");

            migrationBuilder.DropColumn(
                name: "DcReportQueryQueryId",
                table: "DcQueryParams");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportQueries_ReportId",
                table: "DcReportQueries",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_QueryId",
                table: "DcQueryParams",
                column: "QueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_DcReportQueries_QueryId",
                table: "DcQueryParams",
                column: "QueryId",
                principalTable: "DcReportQueries",
                principalColumn: "QueryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcReportQueries_DcReports_ReportId",
                table: "DcReportQueries",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_DcReportQueries_QueryId",
                table: "DcQueryParams");

            migrationBuilder.DropForeignKey(
                name: "FK_DcReportQueries_DcReports_ReportId",
                table: "DcReportQueries");

            migrationBuilder.DropIndex(
                name: "IX_DcReportQueries_ReportId",
                table: "DcReportQueries");

            migrationBuilder.DropIndex(
                name: "IX_DcQueryParams_QueryId",
                table: "DcQueryParams");

            migrationBuilder.AddColumn<int>(
                name: "DcReportQueryQueryId",
                table: "DcQueryParams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_DcReportQueryQueryId",
                table: "DcQueryParams",
                column: "DcReportQueryQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_DcReportQueries_DcReportQueryQueryId",
                table: "DcQueryParams",
                column: "DcReportQueryQueryId",
                principalTable: "DcReportQueries",
                principalColumn: "QueryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
