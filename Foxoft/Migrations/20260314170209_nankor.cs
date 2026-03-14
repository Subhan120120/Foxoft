using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class nankor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "EditLockedPayment",
                column: "CategoryId",
                value: 21);

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "DeletePayment", 21, "Ödənişi Silmək", (byte)1 },
                    { "MakePayment", 21, "Ödəniş Etmək", (byte)1 },
                    { "Payment", 21, "Ödəmə", (byte)1 },
                    { "ReceivePayment", 21, "Ödəniş Qəbul Etmək", (byte)1 }
                });

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 11,
                column: "ClaimCode",
                value: "Payment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeletePayment");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "MakePayment");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Payment");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ReceivePayment");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "EditLockedPayment",
                column: "CategoryId",
                value: 2);

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "PaymentDetail", 21, "Ödəmə", (byte)1 });

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 11,
                column: "ClaimCode",
                value: "PaymentDetail");
        }
    }
}
