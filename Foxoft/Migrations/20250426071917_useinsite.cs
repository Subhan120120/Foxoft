using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class useinsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UseInSite",
                table: "SiteProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "EAN13",
                column: "DefaultBarcodeType",
                value: true);

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "Serbest",
                column: "DefaultBarcodeType",
                value: false);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccCreditLimit");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "StoreList");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "DcClaimCategories",
                keyColumn: "CategoryId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Parameters");

            migrationBuilder.DropColumn(
                name: "UseInSite",
                table: "SiteProducts");

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "EAN13",
                column: "DefaultBarcodeType",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "Serbest",
                column: "DefaultBarcodeType",
                value: null);

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 23,
                column: "ClaimCode",
                value: "HierarchyFeatureType");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 49,
                column: "ClaimCode",
                value: "CurrAccFeatureType");
        }
    }
}
