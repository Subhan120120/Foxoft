using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcPaymentMethodCurrAcccode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M3");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M6");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M9");

            migrationBuilder.AddColumn<string>(
                name: "DefaultCurrAccCode",
                table: "DcPaymentMethods",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "DefaultCurrAccCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "DefaultCurrAccCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "DefaultCurrAccCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "DefaultCurrAccCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "DefaultCurrAccCode",
                value: null);

            migrationBuilder.InsertData(
                table: "DcPaymentPlans",
                columns: new[] { "PaymentPlanCode", "Commission", "DurationInMonths", "PaymentMethodId", "PaymentPlanDesc" },
                values: new object[,]
                {
                    { "M03", 0m, 3, 2, "3 AY" },
                    { "M06", 0m, 6, 2, "6 AY" },
                    { "M09", 0m, 9, 2, "9 AY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentMethods_DefaultCurrAccCode",
                table: "DcPaymentMethods",
                column: "DefaultCurrAccCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCurrAccCode",
                table: "DcPaymentMethods",
                column: "DefaultCurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_DcPaymentMethods_DefaultCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M03");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M06");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M09");

            migrationBuilder.DropColumn(
                name: "DefaultCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.InsertData(
                table: "DcPaymentPlans",
                columns: new[] { "PaymentPlanCode", "Commission", "DurationInMonths", "PaymentMethodId", "PaymentPlanDesc" },
                values: new object[,]
                {
                    { "M3", 0m, 3, 2, "3 AY" },
                    { "M6", 0m, 6, 2, "6 AY" },
                    { "M9", 0m, 9, 2, "9 AY" }
                });
        }
    }
}
