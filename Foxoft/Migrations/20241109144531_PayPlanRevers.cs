using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class PayPlanRevers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "DcPaymentPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);


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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
