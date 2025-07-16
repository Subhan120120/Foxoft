using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrReportSubQueries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrReportSubQueries_DcReports_ReportId",
                table: "TrReportSubQueries");

            migrationBuilder.AddForeignKey(
                name: "FK_TrReportSubQueries_DcReports_ReportId",
                table: "TrReportSubQueries",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrReportSubQueries_DcReports_ReportId",
                table: "TrReportSubQueries");

            migrationBuilder.AddForeignKey(
                name: "FK_TrReportSubQueries_DcReports_ReportId",
                table: "TrReportSubQueries",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
