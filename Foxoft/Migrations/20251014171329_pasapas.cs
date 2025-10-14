using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class pasapas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "ChangePriceCI", 10, "Sayım Artırma Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceCO", 11, "Sayım Azaltma Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceIP", 7, "Kredit Alış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceIS", 8, "Kredit Alış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceRP", 3, "Pərakəndə Alış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceRS", 5, "Pərakəndə Satış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceWP", 4, "Topdan Alış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceWS", 6, "Topdan Satış Qiymət Dəyişmə", (byte)1 }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceCI");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceCO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceIP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceIS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceRP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceRS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceWP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceWS");
        }
    }
}
