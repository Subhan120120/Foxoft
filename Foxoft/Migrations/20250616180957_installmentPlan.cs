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
            migrationBuilder.DropForeignKey(
                name: "FK_TrInstallments_DcPaymentPlans_PaymentPlanCode",
                table: "TrInstallments");

            migrationBuilder.DropIndex(
                name: "IX_TrInstallments_InvoiceHeaderId",
                table: "TrInstallments");

            migrationBuilder.RenameColumn(
                name: "PaymentPlanCode",
                table: "TrInstallments",
                newName: "InstallmentPlanCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrInstallments_PaymentPlanCode",
                table: "TrInstallments",
                newName: "IX_TrInstallments_InstallmentPlanCode");

            migrationBuilder.CreateTable(
                name: "DcInstallmentPlan",
                columns: table => new
                {
                    InstallmentPlanCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InstallmentPlanDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    CommissionRate = table.Column<float>(type: "real", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcInstallmentPlan", x => x.InstallmentPlanCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrInstallments_InvoiceHeaderId",
                table: "TrInstallments",
                column: "InvoiceHeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInstallments_DcInstallmentPlan_InstallmentPlanCode",
                table: "TrInstallments",
                column: "InstallmentPlanCode",
                principalTable: "DcInstallmentPlan",
                principalColumn: "InstallmentPlanCode",
                onDelete: ReferentialAction.Restrict);
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
