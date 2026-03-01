using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class loyaltyServis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PosAllowPaymentDifferenceOfInvoice");

            migrationBuilder.AddColumn<Guid>(
                name: "LoyaltyCardId",
                table: "TrInvoiceHeaders",
                type: "uniqueidentifier",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "AllowPaymentDifference");

            migrationBuilder.DropColumn(
                name: "LoyaltyCardId",
                table: "TrInvoiceHeaders");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "PosAllowPaymentDifferenceOfInvoice", 2, "Faktura ilə ödəniş arasında fərqə icazə", (byte)1 });
        }
    }
}
