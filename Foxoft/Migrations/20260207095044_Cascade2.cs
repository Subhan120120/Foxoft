using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class Cascade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrLoyaltyTxns_TrPaymentLines_PaymentLineId",
                table: "TrLoyaltyTxns");

            migrationBuilder.AddForeignKey(
                name: "FK_TrLoyaltyTxns_TrPaymentLines_PaymentLineId",
                table: "TrLoyaltyTxns",
                column: "PaymentLineId",
                principalTable: "TrPaymentLines",
                principalColumn: "PaymentLineId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrLoyaltyTxns_TrPaymentLines_PaymentLineId",
                table: "TrLoyaltyTxns");

            migrationBuilder.AddForeignKey(
                name: "FK_TrLoyaltyTxns_TrPaymentLines_PaymentLineId",
                table: "TrLoyaltyTxns",
                column: "PaymentLineId",
                principalTable: "TrPaymentLines",
                principalColumn: "PaymentLineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
