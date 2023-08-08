using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfggsj34567890 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodCode",
                table: "TrPaymentLines");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodCode",
                table: "TrPaymentLines",
                newName: "PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentLines_PaymentMethodCode",
                table: "TrPaymentLines",
                newName: "IX_TrPaymentLines_PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodId",
                table: "TrPaymentLines",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodId",
                table: "TrPaymentLines");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "TrPaymentLines",
                newName: "PaymentMethodCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentLines_PaymentMethodId",
                table: "TrPaymentLines",
                newName: "IX_TrPaymentLines_PaymentMethodCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodCode",
                table: "TrPaymentLines",
                column: "PaymentMethodCode",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
