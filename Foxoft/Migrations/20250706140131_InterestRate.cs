using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class InterestRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommissionRate",
                table: "DcInstallmentPlan",
                newName: "InterestRate");

            migrationBuilder.AlterColumn<float>(
                name: "InterestRate",
                table: "TrInstallments",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InterestRate",
                table: "DcInstallmentPlan",
                newName: "CommissionRate");

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                table: "TrInstallments",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
