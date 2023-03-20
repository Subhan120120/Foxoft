using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class reportTypeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DcReports_ReportTypeId",
                table: "DcReports",
                column: "ReportTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcReports_DcReportTypes_ReportTypeId",
                table: "DcReports",
                column: "ReportTypeId",
                principalTable: "DcReportTypes",
                principalColumn: "ReportTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcReports_DcReportTypes_ReportTypeId",
                table: "DcReports");

            migrationBuilder.DropIndex(
                name: "IX_DcReports_ReportTypeId",
                table: "DcReports");
        }
    }
}
