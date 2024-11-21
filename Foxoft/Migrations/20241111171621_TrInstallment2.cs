using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrInstallment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentPlans_DcPaymentPlans_PaymentPlanCode",
                table: "TrPaymentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentPlans_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrPaymentPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrPaymentPlans",
                table: "TrPaymentPlans");

            migrationBuilder.RenameTable(
                name: "TrPaymentPlans",
                newName: "TrInstallments");

            migrationBuilder.RenameColumn(
                name: "PaymentPlanId",
                table: "TrInstallments",
                newName: "InstallmentId");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentPlans_PaymentPlanCode",
                table: "TrInstallments",
                newName: "IX_TrInstallments_PaymentPlanCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentPlans_InvoiceHeaderId",
                table: "TrInstallments",
                newName: "IX_TrInstallments_InvoiceHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrInstallments",
                table: "TrInstallments",
                column: "InstallmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInstallments_DcPaymentPlans_PaymentPlanCode",
                table: "TrInstallments",
                column: "PaymentPlanCode",
                principalTable: "DcPaymentPlans",
                principalColumn: "PaymentPlanCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInstallments_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInstallments",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInstallments_DcPaymentPlans_PaymentPlanCode",
                table: "TrInstallments");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInstallments_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInstallments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrInstallments",
                table: "TrInstallments");

            migrationBuilder.RenameTable(
                name: "TrInstallments",
                newName: "TrPaymentPlans");

            migrationBuilder.RenameColumn(
                name: "InstallmentId",
                table: "TrPaymentPlans",
                newName: "PaymentPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_TrInstallments_PaymentPlanCode",
                table: "TrPaymentPlans",
                newName: "IX_TrPaymentPlans_PaymentPlanCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrInstallments_InvoiceHeaderId",
                table: "TrPaymentPlans",
                newName: "IX_TrPaymentPlans_InvoiceHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrPaymentPlans",
                table: "TrPaymentPlans",
                column: "PaymentPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentPlans_DcPaymentPlans_PaymentPlanCode",
                table: "TrPaymentPlans",
                column: "PaymentPlanCode",
                principalTable: "DcPaymentPlans",
                principalColumn: "PaymentPlanCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentPlans_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrPaymentPlans",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
