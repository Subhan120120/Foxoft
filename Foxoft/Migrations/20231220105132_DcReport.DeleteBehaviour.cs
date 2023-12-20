using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcReportDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcReportFilters_DcReports_ReportId",
                table: "DcReportFilters");

            migrationBuilder.DropForeignKey(
                name: "FK_TrClaimReport_DcReports_ReportId",
                table: "TrClaimReport");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFormReports_DcReports_ReportId",
                table: "TrFormReports");

            migrationBuilder.AddForeignKey(
                name: "FK_DcReportFilters_DcReports_ReportId",
                table: "DcReportFilters",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrClaimReport_DcReports_ReportId",
                table: "TrClaimReport",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFormReports_DcReports_ReportId",
                table: "TrFormReports",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcReportFilters_DcReports_ReportId",
                table: "DcReportFilters");

            migrationBuilder.DropForeignKey(
                name: "FK_TrClaimReport_DcReports_ReportId",
                table: "TrClaimReport");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFormReports_DcReports_ReportId",
                table: "TrFormReports");

            migrationBuilder.AddForeignKey(
                name: "FK_DcReportFilters_DcReports_ReportId",
                table: "DcReportFilters",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrClaimReport_DcReports_ReportId",
                table: "TrClaimReport",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFormReports_DcReports_ReportId",
                table: "TrFormReports",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
