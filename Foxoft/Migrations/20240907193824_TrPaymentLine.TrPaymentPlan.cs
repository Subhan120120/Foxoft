using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrPaymentLineTrPaymentPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentLines_PaymentLineId",
                table: "TrPaymentPlans");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentLines_PaymentLineId",
                table: "TrPaymentPlans",
                column: "PaymentLineId",
                principalTable: "TrPaymentLines",
                principalColumn: "PaymentLineId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentLines_PaymentLineId",
                table: "TrPaymentPlans");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentLines_PaymentLineId",
                table: "TrPaymentPlans",
                column: "PaymentLineId",
                principalTable: "TrPaymentLines",
                principalColumn: "PaymentLineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
