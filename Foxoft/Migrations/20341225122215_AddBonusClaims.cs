using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddBonusClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "BonusEarn", 19, "Bonus Kartı Qazandırma", (byte)1 },
                    { "BonusPayment", 21, "Bonus Kartı ilə Ödəniş", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 312, "BonusEarn", "Admin" },
                    { 313, "BonusPayment", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "BonusEarn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "BonusPayment");
        }
    }
}