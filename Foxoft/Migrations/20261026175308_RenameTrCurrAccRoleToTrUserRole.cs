using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class RenameTrCurrAccRoleToTrUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TrCurrAccRoles",
                newName: "TrUserRoles");

            migrationBuilder.RenameColumn(
                name: "CurrAccRoleId",
                table: "TrUserRoles",
                newName: "UserRoleId");

            migrationBuilder.RenameColumn(
                name: "CurrAccCode",
                table: "TrUserRoles",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_TrCurrAccRoles_RoleCode",
                table: "TrUserRoles",
                newName: "IX_TrUserRoles_RoleCode");

            migrationBuilder.DeleteData(
                table: "TrUserStores",
                keyColumn: "UserStoreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrUserStores",
                keyColumn: "UserStoreId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "InvoiceAiOcr", 2, "Qaimə AI OCR", (byte)1 },
                    { "ProductFeatureAi", 18, "Məhsul Özəllikləri AI", (byte)1 }
                });

            migrationBuilder.UpdateData(
                table: "TrUserRoles",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "UserName",
                value: "admin");

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 222, "ProductFeatureAi", "Admin" },
                    { 223, "InvoiceAiOcr", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InvoiceAiOcr");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductFeatureAi");

            migrationBuilder.UpdateData(
                table: "TrUserRoles",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "UserName",
                value: "C-000001");

            migrationBuilder.InsertData(
                table: "TrUserStores",
                columns: new[] { "UserStoreId", "StoreCode", "UserName" },
                values: new object[,]
                {
                    { 2, "MGZ01", "C-000001" },
                    { 3, "MGZ01", "CA-1" }
                });

            migrationBuilder.RenameIndex(
                name: "IX_TrUserRoles_RoleCode",
                table: "TrUserRoles",
                newName: "IX_TrCurrAccRoles_RoleCode");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "TrUserRoles",
                newName: "CurrAccCode");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "TrUserRoles",
                newName: "CurrAccRoleId");

            migrationBuilder.RenameTable(
                name: "TrUserRoles",
                newName: "TrCurrAccRoles");
        }
    }
}
