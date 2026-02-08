using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class iniasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrLoyaltyTxns_TrPaymentHeaders_PaymentHeaderId",
                table: "TrLoyaltyTxns");

            migrationBuilder.DropIndex(
                name: "IX_TrLoyaltyTxns_PaymentHeaderId",
                table: "TrLoyaltyTxns");

            migrationBuilder.RenameColumn(
                name: "PaymentHeaderId",
                table: "TrLoyaltyTxns",
                newName: "PaymentLineId");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "LoyaltyCards",
                column: "CategoryId",
                value: 19);

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_PaymentLineId",
                table: "TrLoyaltyTxns",
                column: "PaymentLineId",
                unique: true,
                filter: "[PaymentLineId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TrLoyaltyTxns_TrPaymentLines_PaymentLineId",
                table: "TrLoyaltyTxns",
                column: "PaymentLineId",
                principalTable: "TrPaymentLines",
                principalColumn: "PaymentLineId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrLoyaltyTxns_TrPaymentLines_PaymentLineId",
                table: "TrLoyaltyTxns");

            migrationBuilder.DropIndex(
                name: "IX_TrLoyaltyTxns_PaymentLineId",
                table: "TrLoyaltyTxns");

            migrationBuilder.RenameColumn(
                name: "PaymentLineId",
                table: "TrLoyaltyTxns",
                newName: "PaymentHeaderId");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "LoyaltyCards",
                column: "CategoryId",
                value: 9);

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_PaymentHeaderId",
                table: "TrLoyaltyTxns",
                column: "PaymentHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrLoyaltyTxns_TrPaymentHeaders_PaymentHeaderId",
                table: "TrLoyaltyTxns",
                column: "PaymentHeaderId",
                principalTable: "TrPaymentHeaders",
                principalColumn: "PaymentHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
