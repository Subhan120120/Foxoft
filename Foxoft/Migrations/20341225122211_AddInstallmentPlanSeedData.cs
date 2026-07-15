using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddInstallmentPlanSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcInstallmentPlan",
                columns: new[] { "InstallmentPlanCode", "DurationInMonths", "InstallmentPlanDesc", "InterestRate", "IsDefault" },
                values: new object[,]
                {
                    { "I00", 0, "Təyin edilməyib", 0f, false },
                    { "I03", 3, "3 AY", 0f, false },
                    { "I06", 6, "6 AY", 0f, false },
                    { "I09", 9, "9 AY", 0f, false },
                    { "I12", 12, "12 AY", 0f, true },
                    { "I18", 18, "18 AY", 0f, false },
                    { "I24", 24, "24 AY", 0f, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyValue: "I00");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyValue: "I03");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyValue: "I06");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyValue: "I09");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyValue: "I12");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyValue: "I18");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyValue: "I24");
        }
    }
}
