using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class trestfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcReportCategory",
                columns: table => new
                {
                    ReportCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportCategory", x => x.ReportCategoryId);
                });

            migrationBuilder.InsertData(
                table: "DcReportCategory",
                columns: new[] { "ReportCategoryId", "ReportCategoryDesc" },
                values: new object[,]
                {
                    { 1, "Satış və Müştəri Hesabatları" },
                    { 2, "Satınalma və Təchizatçı Hesabatları" },
                    { 3, "Məhsul və Stok Hesabatları" },
                    { 4, "İstehsal Hesabatları" },
                    { 5, "Maliyyə Hesabatları" },
                    { 6, "Kadr və İnsan Resursları Hesabatları" },
                    { 7, "Mənfəət/Zərər və Rentabellik Hesabatları" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcReports_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcReports_DcReportCategory_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId",
                principalTable: "DcReportCategory",
                principalColumn: "ReportCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcReports_DcReportCategory_ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropTable(
                name: "DcReportCategory");

            migrationBuilder.DropIndex(
                name: "IX_DcReports_ReportCategoryId",
                table: "DcReports");
        }
    }
}
