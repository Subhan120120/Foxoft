using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class sdgkdghl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentLines_PaymentLineId",
                table: "TrPaymentPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentPlans_PaymentLineId",
                table: "TrPaymentPlans");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "DcPaymentPlans");

            migrationBuilder.RenameColumn(
                name: "PaymentLineId",
                table: "TrPaymentPlans",
                newName: "PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentPlans_PaymentHeaderId",
                table: "TrPaymentPlans",
                column: "PaymentHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentPlans",
                column: "PaymentHeaderId",
                principalTable: "TrPaymentHeaders",
                principalColumn: "PaymentHeaderId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentPlans");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentPlans_PaymentHeaderId",
                table: "TrPaymentPlans");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "IS");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "IS");

            migrationBuilder.RenameColumn(
                name: "PaymentHeaderId",
                table: "TrPaymentPlans",
                newName: "PaymentLineId");

            migrationBuilder.AddColumn<decimal>(
                name: "Commission",
                table: "DcPaymentPlans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M03",
                column: "Commission",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M06",
                column: "Commission",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M09",
                column: "Commission",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M12",
                column: "Commission",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M18",
                column: "Commission",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M24",
                column: "Commission",
                value: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentPlans_PaymentLineId",
                table: "TrPaymentPlans",
                column: "PaymentLineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentPlans_TrPaymentLines_PaymentLineId",
                table: "TrPaymentPlans",
                column: "PaymentLineId",
                principalTable: "TrPaymentLines",
                principalColumn: "PaymentLineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
