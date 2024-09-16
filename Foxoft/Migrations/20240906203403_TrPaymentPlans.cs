using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TrPaymentPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Commission",
                table: "DcPaymentPlans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "TrPaymentPlans",
                columns: table => new
                {
                    PaymentPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentPlanCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPaymentPlans", x => x.PaymentPlanId);
                    table.ForeignKey(
                        name: "FK_TrPaymentPlans_DcPaymentPlans_PaymentPlanCode",
                        column: x => x.PaymentPlanCode,
                        principalTable: "DcPaymentPlans",
                        principalColumn: "PaymentPlanCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentPlans_TrPaymentLines_PaymentLineId",
                        column: x => x.PaymentLineId,
                        principalTable: "TrPaymentLines",
                        principalColumn: "PaymentLineId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M3",
                column: "Commission",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M6",
                column: "Commission",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M9",
                column: "Commission",
                value: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentPlans_PaymentLineId",
                table: "TrPaymentPlans",
                column: "PaymentLineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentPlans_PaymentPlanCode",
                table: "TrPaymentPlans",
                column: "PaymentPlanCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrPaymentPlans");

            migrationBuilder.DropColumn(
                name: "Commission",
                table: "DcPaymentPlans");
        }
    }
}
