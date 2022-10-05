using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class full : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_DcCurrAccTypes_CurrAccTypeCode",
                table: "DcCurrAccs");

            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFeatures_DcFeatures_FeatureId",
                table: "TrFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                table: "TrPaymentLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPrices_DcProducts_ProductCode",
                table: "TrPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcClaims_ClaimCode",
                table: "TrRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_TrShipmentLines_TrShipmentHeaders_ShipmentHeaderId",
                table: "TrShipmentLines");

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_DcCurrAccTypes_CurrAccTypeCode",
                table: "DcCurrAccs",
                column: "CurrAccTypeCode",
                principalTable: "DcCurrAccTypes",
                principalColumn: "CurrAccTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                table: "DcProducts",
                column: "ProductTypeCode",
                principalTable: "DcProductTypes",
                principalColumn: "ProductTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFeatures_DcFeatures_FeatureId",
                table: "TrFeatures",
                column: "FeatureId",
                principalTable: "DcFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceLines",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                table: "TrPaymentLines",
                column: "PaymentTypeCode",
                principalTable: "DcPaymentTypes",
                principalColumn: "PaymentTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines",
                column: "PaymentHeaderId",
                principalTable: "TrPaymentHeaders",
                principalColumn: "PaymentHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPrices_DcProducts_ProductCode",
                table: "TrPrices",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrRoleClaims_DcClaims_ClaimCode",
                table: "TrRoleClaims",
                column: "ClaimCode",
                principalTable: "DcClaims",
                principalColumn: "ClaimCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims",
                column: "RoleCode",
                principalTable: "DcRoles",
                principalColumn: "RoleCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrShipmentLines_TrShipmentHeaders_ShipmentHeaderId",
                table: "TrShipmentLines",
                column: "ShipmentHeaderId",
                principalTable: "TrShipmentHeaders",
                principalColumn: "ShipmentHeaderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_DcCurrAccTypes_CurrAccTypeCode",
                table: "DcCurrAccs");

            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFeatures_DcFeatures_FeatureId",
                table: "TrFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                table: "TrPaymentLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPrices_DcProducts_ProductCode",
                table: "TrPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcClaims_ClaimCode",
                table: "TrRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_TrShipmentLines_TrShipmentHeaders_ShipmentHeaderId",
                table: "TrShipmentLines");

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_DcCurrAccTypes_CurrAccTypeCode",
                table: "DcCurrAccs",
                column: "CurrAccTypeCode",
                principalTable: "DcCurrAccTypes",
                principalColumn: "CurrAccTypeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                table: "DcProducts",
                column: "ProductTypeCode",
                principalTable: "DcProductTypes",
                principalColumn: "ProductTypeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFeatures_DcFeatures_FeatureId",
                table: "TrFeatures",
                column: "FeatureId",
                principalTable: "DcFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                table: "TrInvoiceLines",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                table: "TrPaymentLines",
                column: "PaymentTypeCode",
                principalTable: "DcPaymentTypes",
                principalColumn: "PaymentTypeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                table: "TrPaymentLines",
                column: "PaymentHeaderId",
                principalTable: "TrPaymentHeaders",
                principalColumn: "PaymentHeaderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPrices_DcProducts_ProductCode",
                table: "TrPrices",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrRoleClaims_DcClaims_ClaimCode",
                table: "TrRoleClaims",
                column: "ClaimCode",
                principalTable: "DcClaims",
                principalColumn: "ClaimCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims",
                column: "RoleCode",
                principalTable: "DcRoles",
                principalColumn: "RoleCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrShipmentLines_TrShipmentHeaders_ShipmentHeaderId",
                table: "TrShipmentLines",
                column: "ShipmentHeaderId",
                principalTable: "TrShipmentHeaders",
                principalColumn: "ShipmentHeaderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
