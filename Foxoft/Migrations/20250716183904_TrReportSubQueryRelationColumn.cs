using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrReportSubQueryRelationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrReportSubQueryRelationColumns_TrReportSubQueries_SubQueryId",
                table: "TrReportSubQueryRelationColumns");

            migrationBuilder.AddForeignKey(
                name: "FK_TrReportSubQueryRelationColumns_TrReportSubQueries_SubQueryId",
                table: "TrReportSubQueryRelationColumns",
                column: "SubQueryId",
                principalTable: "TrReportSubQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrReportSubQueryRelationColumns_TrReportSubQueries_SubQueryId",
                table: "TrReportSubQueryRelationColumns");

            migrationBuilder.AddForeignKey(
                name: "FK_TrReportSubQueryRelationColumns_TrReportSubQueries_SubQueryId",
                table: "TrReportSubQueryRelationColumns",
                column: "SubQueryId",
                principalTable: "TrReportSubQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
