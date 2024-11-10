using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class PayPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentPlans_DcPaymentMethods_PaymentMethodId",
                table: "DcPaymentPlans");

            migrationBuilder.DropIndex(
                name: "IX_DcPaymentPlans_PaymentMethodId",
                table: "DcPaymentPlans");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "DcPaymentPlans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "DcPaymentPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M03",
                column: "PaymentMethodId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M06",
                column: "PaymentMethodId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M09",
                column: "PaymentMethodId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M12",
                column: "PaymentMethodId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M18",
                column: "PaymentMethodId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M24",
                column: "PaymentMethodId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentPlans_PaymentMethodId",
                table: "DcPaymentPlans",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentPlans_DcPaymentMethods_PaymentMethodId",
                table: "DcPaymentPlans",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
