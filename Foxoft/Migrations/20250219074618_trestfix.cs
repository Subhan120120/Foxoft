using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class trestfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcReportCategories",
                columns: table => new
                {
                    ReportCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    ReportCategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportCategories", x => x.ReportCategoryId);
                });

            migrationBuilder.InsertData(
                table: "DcReportCategories",
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
                name: "FK_DcReports_DcReportCategories_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId",
                principalTable: "DcReportCategories",
                principalColumn: "ReportCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
