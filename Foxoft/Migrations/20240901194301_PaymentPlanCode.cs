using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class PaymentPlanCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcPaymentPlan",
                columns: table => new
                {
                    PaymentPlanCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentPlanDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentPlan", x => x.PaymentPlanCode);
                    table.ForeignKey(
                        name: "FK_DcPaymentPlan_DcPaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "DcPaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcPaymentPlan",
                columns: new[] { "PaymentPlanCode", "DurationInMonths", "InterestRate", "PaymentMethodId", "PaymentPlanDesc" },
                values: new object[,]
                {
                    { "M12", 12, 0m, 2, "12 AY" },
                    { "M18", 18, 0m, 2, "18 AY" },
                    { "M24", 24, 0m, 2, "24 AY" },
                    { "M3", 3, 0m, 2, "3 AY" },
                    { "M6", 6, 0m, 2, "6 AY" },
                    { "M9", 9, 0m, 2, "9 AY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentPlan_PaymentMethodId",
                table: "DcPaymentPlan",
                column: "PaymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcPaymentPlan");
        }
    }
}
