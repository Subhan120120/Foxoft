using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdgfgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trPaymentMethodDiscounts_DcDiscounts_DiscountId",
                table: "trPaymentMethodDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_trPaymentMethodDiscounts_DcPaymentMethods_PaymentMethodId",
                table: "trPaymentMethodDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trPaymentMethodDiscounts",
                table: "trPaymentMethodDiscounts");

            migrationBuilder.RenameTable(
                name: "trPaymentMethodDiscounts",
                newName: "TrPaymentMethodDiscounts");

            migrationBuilder.RenameIndex(
                name: "IX_trPaymentMethodDiscounts_PaymentMethodId",
                table: "TrPaymentMethodDiscounts",
                newName: "IX_TrPaymentMethodDiscounts_PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrPaymentMethodDiscounts",
                table: "TrPaymentMethodDiscounts",
                columns: new[] { "DiscountId", "PaymentMethodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentMethodDiscounts_DcDiscounts_DiscountId",
                table: "TrPaymentMethodDiscounts",
                column: "DiscountId",
                principalTable: "DcDiscounts",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentMethodDiscounts_DcPaymentMethods_PaymentMethodId",
                table: "TrPaymentMethodDiscounts",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentMethodDiscounts_DcDiscounts_DiscountId",
                table: "TrPaymentMethodDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentMethodDiscounts_DcPaymentMethods_PaymentMethodId",
                table: "TrPaymentMethodDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrPaymentMethodDiscounts",
                table: "TrPaymentMethodDiscounts");

            migrationBuilder.RenameTable(
                name: "TrPaymentMethodDiscounts",
                newName: "trPaymentMethodDiscounts");

            migrationBuilder.RenameIndex(
                name: "IX_TrPaymentMethodDiscounts_PaymentMethodId",
                table: "trPaymentMethodDiscounts",
                newName: "IX_trPaymentMethodDiscounts_PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trPaymentMethodDiscounts",
                table: "trPaymentMethodDiscounts",
                columns: new[] { "DiscountId", "PaymentMethodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_trPaymentMethodDiscounts_DcDiscounts_DiscountId",
                table: "trPaymentMethodDiscounts",
                column: "DiscountId",
                principalTable: "DcDiscounts",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trPaymentMethodDiscounts_DcPaymentMethods_PaymentMethodId",
                table: "trPaymentMethodDiscounts",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
