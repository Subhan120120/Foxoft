using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class claimtype_hassdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcClaimTypes",
                columns: new[] { "ClaimTypeCode", "ClaimTypeDesc" },
                values: new object[] { (byte)1, "Embaded" });

            migrationBuilder.InsertData(
                table: "DcClaimTypes",
                columns: new[] { "ClaimTypeCode", "ClaimTypeDesc" },
                values: new object[] { (byte)2, "Report" });

            migrationBuilder.InsertData(
                table: "DcClaimTypes",
                columns: new[] { "ClaimTypeCode", "ClaimTypeDesc" },
                values: new object[] { (byte)3, "Column" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaimTypes",
                keyColumn: "ClaimTypeCode",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "DcClaimTypes",
                keyColumn: "ClaimTypeCode",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "DcClaimTypes",
                keyColumn: "ClaimTypeCode",
                keyValue: (byte)3);
        }
    }
}
