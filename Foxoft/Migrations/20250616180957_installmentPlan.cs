using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class installmentPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_TrInstallments_InvoiceHeaderId",
                table: "TrInstallments");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInstallments_DcInstallmentPlan_InstallmentPlanCode",
                table: "TrInstallments");

            migrationBuilder.DropTable(
                name: "DcInstallmentPlan");

            migrationBuilder.DropIndex(
                name: "IX_TrInstallments_InvoiceHeaderId",
                table: "TrInstallments");

            migrationBuilder.RenameColumn(
                name: "InstallmentPlanCode",
                table: "TrInstallments",
                newName: "PaymentPlanCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrInstallments_InstallmentPlanCode",
                table: "TrInstallments",
                newName: "IX_TrInstallments_PaymentPlanCode");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 19,
                column: "ReportQuery",
                value: "\n\nselect * From ProductBalanceSerialNumber\n\n");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstallments_InvoiceHeaderId",
                table: "TrInstallments",
                column: "InvoiceHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInstallments_DcPaymentPlans_PaymentPlanCode",
                table: "TrInstallments",
                column: "PaymentPlanCode",
                principalTable: "DcPaymentPlans",
                principalColumn: "PaymentPlanCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
