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

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyColumnType: "nvarchar(450)",
                keyValue: "I00");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyColumnType: "nvarchar(450)",
                keyValue: "I03");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyColumnType: "nvarchar(450)",
                keyValue: "I06");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyColumnType: "nvarchar(450)",
                keyValue: "I09");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyColumnType: "nvarchar(450)",
                keyValue: "I12");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyColumnType: "nvarchar(450)",
                keyValue: "I18");

            migrationBuilder.DeleteData(
                table: "DcInstallmentPlan",
                keyColumn: "InstallmentPlanCode",
                keyColumnType: "nvarchar(450)",
                keyValue: "I24");
        }
    }
}
