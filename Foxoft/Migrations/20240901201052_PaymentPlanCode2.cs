using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class PaymentPlanCode2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCashRegCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcPaymentTypes_PaymentTypeCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentPlan_DcPaymentMethods_PaymentMethodId",
                table: "DcPaymentPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodId",
                table: "TrPaymentLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentMethodDiscounts_DcPaymentMethods_PaymentMethodId",
                table: "TrPaymentMethodDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcPaymentMethods",
                table: "DcPaymentMethods");

            migrationBuilder.RenameTable(
                name: "DcPaymentMethods",
                newName: "DcPaymentMethod");

            migrationBuilder.RenameIndex(
                name: "IX_DcPaymentMethods_PaymentTypeCode",
                table: "DcPaymentMethod",
                newName: "IX_DcPaymentMethod_PaymentTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_DcPaymentMethods_DefaultCashRegCode",
                table: "DcPaymentMethod",
                newName: "IX_DcPaymentMethod_DefaultCashRegCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcPaymentMethod",
                table: "DcPaymentMethod",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethod_DcCurrAccs_DefaultCashRegCode",
                table: "DcPaymentMethod",
                column: "DefaultCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethod_DcPaymentTypes_PaymentTypeCode",
                table: "DcPaymentMethod",
                column: "PaymentTypeCode",
                principalTable: "DcPaymentTypes",
                principalColumn: "PaymentTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentPlan_DcPaymentMethod_PaymentMethodId",
                table: "DcPaymentPlan",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethod",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethod_PaymentMethodId",
                table: "TrPaymentLines",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethod",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentMethodDiscounts_DcPaymentMethod_PaymentMethodId",
                table: "TrPaymentMethodDiscounts",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethod",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethod_DcCurrAccs_DefaultCashRegCode",
                table: "DcPaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethod_DcPaymentTypes_PaymentTypeCode",
                table: "DcPaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentPlan_DcPaymentMethod_PaymentMethodId",
                table: "DcPaymentPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethod_PaymentMethodId",
                table: "TrPaymentLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentMethodDiscounts_DcPaymentMethod_PaymentMethodId",
                table: "TrPaymentMethodDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcPaymentMethod",
                table: "DcPaymentMethod");

            migrationBuilder.RenameTable(
                name: "DcPaymentMethod",
                newName: "DcPaymentMethods");

            migrationBuilder.RenameIndex(
                name: "IX_DcPaymentMethod_PaymentTypeCode",
                table: "DcPaymentMethods",
                newName: "IX_DcPaymentMethods_PaymentTypeCode");

            migrationBuilder.RenameIndex(
                name: "IX_DcPaymentMethod_DefaultCashRegCode",
                table: "DcPaymentMethods",
                newName: "IX_DcPaymentMethods_DefaultCashRegCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcPaymentMethods",
                table: "DcPaymentMethods",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCashRegCode",
                table: "DcPaymentMethods",
                column: "DefaultCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcPaymentTypes_PaymentTypeCode",
                table: "DcPaymentMethods",
                column: "PaymentTypeCode",
                principalTable: "DcPaymentTypes",
                principalColumn: "PaymentTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentPlan_DcPaymentMethods_PaymentMethodId",
                table: "DcPaymentPlan",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodId",
                table: "TrPaymentLines",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentMethodDiscounts_DcPaymentMethods_PaymentMethodId",
                table: "TrPaymentMethodDiscounts",
                column: "PaymentMethodId",
                principalTable: "DcPaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
