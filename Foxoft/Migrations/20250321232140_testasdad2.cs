using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class testasdad2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentsaleOrder");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 15);

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "InstallmentSaleOrder", 8, "Kredit Satış Sifarişi", (byte)1 },
                });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportName",
                value: "Report_Embedded_InstallmentSale");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 41,
                column: "ClaimCode",
                value: "RetailPurchaseReturnCustom");

            migrationBuilder.AddForeignKey(
                name: "FK_DcClaims_DcClaimCategories_CategoryId",
                table: "DcClaims",
                column: "CategoryId",
                principalTable: "DcClaimCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleReturnCustom");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "InstallmentsaleOrder", 8, "Kredit Satış Sifarişi", (byte)1 },
                    { "InstallmentsaleReturn", 8, "Kredit Satış Qaytarması", (byte)1 },
                    { "InstallmentsaleReturnCustom", 8, "Kredit Satış Xüsusi Geri Qaytarması", (byte)1 }
                });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportName",
                value: "Report_Embedded_Installmentsale");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 29,
                column: "ClaimCode",
                value: "InstallmentsaleInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 40,
                column: "ClaimCode",
                value: "InstallmentsaleReturn");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 41,
                column: "ClaimCode",
                value: "PurchaseReturnCustom");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 44,
                column: "ClaimCode",
                value: "InstallmentsaleReturnCustom");

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[] { 15, "ReportZet", "Admin" });
        }
    }
}
