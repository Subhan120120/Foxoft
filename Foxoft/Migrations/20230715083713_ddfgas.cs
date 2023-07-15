using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class ddfgas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrFormReport_DcForms_FormCode",
                table: "TrFormReport");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFormReport_DcReports_ReportId",
                table: "TrFormReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrFormReport",
                table: "TrFormReport");

            migrationBuilder.RenameTable(
                name: "TrFormReport",
                newName: "TrFormReports");

            migrationBuilder.RenameIndex(
                name: "IX_TrFormReport_ReportId",
                table: "TrFormReports",
                newName: "IX_TrFormReports_ReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrFormReports",
                table: "TrFormReports",
                columns: new[] { "FormCode", "ReportId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrFormReports_DcForms_FormCode",
                table: "TrFormReports",
                column: "FormCode",
                principalTable: "DcForms",
                principalColumn: "FormCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFormReports_DcReports_ReportId",
                table: "TrFormReports",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrFormReports_DcForms_FormCode",
                table: "TrFormReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFormReports_DcReports_ReportId",
                table: "TrFormReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrFormReports",
                table: "TrFormReports");

            migrationBuilder.RenameTable(
                name: "TrFormReports",
                newName: "TrFormReport");

            migrationBuilder.RenameIndex(
                name: "IX_TrFormReports_ReportId",
                table: "TrFormReport",
                newName: "IX_TrFormReport_ReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrFormReport",
                table: "TrFormReport",
                columns: new[] { "FormCode", "ReportId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrFormReport_DcForms_FormCode",
                table: "TrFormReport",
                column: "FormCode",
                principalTable: "DcForms",
                principalColumn: "FormCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFormReport_DcReports_ReportId",
                table: "TrFormReport",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
