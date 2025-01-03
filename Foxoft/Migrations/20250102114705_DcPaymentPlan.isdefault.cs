using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class DcPaymentPlanisdefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "DcPaymentPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "InstallmentsaleReturn", "Kredit Satışı", (byte)1 });

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M03",
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M06",
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M09",
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M12",
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M18",
                column: "IsDefault",
                value: false);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M24",
                column: "IsDefault",
                value: false);

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[] { 38, "InstallmentsaleReturn", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_DcSerialNumbers_DcProducts_ProductCode",
                table: "DcSerialNumbers",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcSerialNumbers_DcProducts_ProductCode",
                table: "DcSerialNumbers");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentsaleReturn");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "DcPaymentPlans");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleInvoice",
                column: "ClaimDesc",
                value: "Topdan Satışın Qaytarılması");

            migrationBuilder.AddForeignKey(
                name: "FK_DcSerialNumbers_DcProducts_ProductCode",
                table: "DcSerialNumbers",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
