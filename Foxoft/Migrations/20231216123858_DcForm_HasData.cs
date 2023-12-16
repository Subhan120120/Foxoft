using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class DcForm_HasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "CurrAccs");

            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "Products");

            migrationBuilder.DeleteData(
                table: "TrClaimReport",
                keyColumn: "ClaimReportId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrClaimReport",
                keyColumn: "ClaimReportId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrClaimReport",
                keyColumn: "ClaimReportId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrClaimReport",
                keyColumn: "ClaimReportId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrClaimReport",
                keyColumn: "ClaimReportId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrClaimReport",
                keyColumn: "ClaimReportId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrClaimReport",
                keyColumn: "ClaimReportId",
                keyValue: 18);

            migrationBuilder.InsertData(
                table: "TrClaimReport",
                columns: new[] { "ClaimReportId", "ClaimCode", "ReportId" },
                values: new object[,]
                {
                    { 6, "ButunHesabatlar", 6 },
                    { 7, "ButunHesabatlar", 7 },
                    { 8, "ButunHesabatlar", 8 },
                    { 9, "ButunHesabatlar", 9 },
                    { 10, "ButunHesabatlar", 10 }
                });
        }
    }
}
