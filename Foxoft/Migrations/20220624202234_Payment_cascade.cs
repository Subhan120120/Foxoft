using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class Payment_cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines",
                column: "PaymentHeaderId",
                principalTable: "TrPaymentHeaders",
                principalColumn: "PaymentHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines",
                column: "PaymentHeaderId",
                principalTable: "TrPaymentHeaders",
                principalColumn: "PaymentHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
