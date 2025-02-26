using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class createdReportCustomization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcReports_DcReportCategory_ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcReportCategory",
                table: "DcReportCategory");

            migrationBuilder.RenameTable(
                name: "DcReportCategory",
                newName: "DcReportCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcReportCategories",
                table: "DcReportCategories",
                column: "ReportCategoryId");

            migrationBuilder.CreateTable(
                name: "TrReportCustomizations",
                columns: table => new
                {
                    ReportCustomizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    ReportFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrReportCustomizations", x => x.ReportCustomizationId);
                    table.ForeignKey(
                        name: "FK_TrReportCustomizations_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrReportCustomizations_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_TrReportCustomizations_CurrAccCode",
                table: "TrReportCustomizations",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportCustomizations_ReportId",
                table: "TrReportCustomizations",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcReports_DcReportCategories_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId",
                principalTable: "DcReportCategories",
                principalColumn: "ReportCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcReports_DcReportCategories_ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropTable(
                name: "TrReportCustomizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcReportCategories",
                table: "DcReportCategories");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceEX");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineEX");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 47);

            migrationBuilder.RenameTable(
                name: "DcReportCategories",
                newName: "DcReportCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcReportCategory",
                table: "DcReportCategory",
                column: "ReportCategoryId");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 34,
                column: "ClaimCode",
                value: "DeleteLineRP");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 35,
                column: "ClaimCode",
                value: "DeleteLineRS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 36,
                column: "ClaimCode",
                value: "DeleteLineWS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 37,
                column: "ClaimCode",
                value: "DeleteLineIS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 38,
                column: "ClaimCode",
                value: "InstallmentsaleReturn");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 39,
                column: "ClaimCode",
                value: "PurchaseReturnCustom");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 40,
                column: "ClaimCode",
                value: "RetailsaleReturnCustom");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 41,
                column: "ClaimCode",
                value: "WholesaleReturnCustom");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 42,
                column: "ClaimCode",
                value: "InstallmentsaleReturnCustom");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 43,
                column: "ClaimCode",
                value: "Installments");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 44,
                column: "ClaimCode",
                value: "EditLockedInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 45,
                column: "ClaimCode",
                value: "EditLockedPayment");

            migrationBuilder.AddForeignKey(
                name: "FK_DcReports_DcReportCategory_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId",
                principalTable: "DcReportCategory",
                principalColumn: "ReportCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
