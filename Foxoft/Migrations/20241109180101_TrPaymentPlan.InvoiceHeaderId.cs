using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrPaymentPlanInvoiceHeaderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentPlans");

            migrationBuilder.RenameColumn(
                name: "PaymentHeaderId",
                table: "TrPaymentPlans",
                newName: "InvoiceHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentPlans_PaymentHeaderId",
                table: "TrPaymentPlans",
                newName: "IX_TrPaymentPlans_InvoiceHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentPlans_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrPaymentPlans",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentPlans_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrPaymentPlans");

            migrationBuilder.RenameColumn(
                name: "InvoiceHeaderId",
                table: "TrPaymentPlans",
                newName: "PaymentHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentPlans_InvoiceHeaderId",
                table: "TrPaymentPlans",
                newName: "IX_TrPaymentPlans_PaymentHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentPlans",
                column: "PaymentHeaderId",
                principalTable: "TrPaymentHeaders",
                principalColumn: "PaymentHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
