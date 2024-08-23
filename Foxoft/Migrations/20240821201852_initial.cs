using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "DcOffices");

            migrationBuilder.DropTable(
                name: "DcReportVariables");

            migrationBuilder.DropTable(
                name: "DcTerminals");

            migrationBuilder.DropTable(
                name: "DcVariables");

            migrationBuilder.DropTable(
                name: "DcWarehouses");

            migrationBuilder.DropTable(
                name: "SettingStores");

            migrationBuilder.DropTable(
                name: "SiteProducts");

            migrationBuilder.DropTable(
                name: "TrClaimReports");

            migrationBuilder.DropTable(
                name: "TrCurrAccRoles");

            migrationBuilder.DropTable(
                name: "TrFormReports");

            migrationBuilder.DropTable(
                name: "TrHierarchyFeatureTypes");

            migrationBuilder.DropTable(
                name: "TrInvoiceLineExts");

            migrationBuilder.DropTable(
                name: "TrPaymentLines");

            migrationBuilder.DropTable(
                name: "TrPaymentMethodDiscounts");

            migrationBuilder.DropTable(
                name: "TrPriceListLines");

            migrationBuilder.DropTable(
                name: "TrPrices");

            migrationBuilder.DropTable(
                name: "TrProcessPriceTypes");

            migrationBuilder.DropTable(
                name: "TrProductBarcodes");

            migrationBuilder.DropTable(
                name: "TrProductDiscounts");

            migrationBuilder.DropTable(
                name: "TrProductFeatures");

            migrationBuilder.DropTable(
                name: "TrProductHierarchies");

            migrationBuilder.DropTable(
                name: "TrReportSubQueryRelationColumns");

            migrationBuilder.DropTable(
                name: "TrRoleClaims");

            migrationBuilder.DropTable(
                name: "TrSessions");

            migrationBuilder.DropTable(
                name: "dcReportVariableTypes");

            migrationBuilder.DropTable(
                name: "DcForms");

            migrationBuilder.DropTable(
                name: "TrInvoiceLines");

            migrationBuilder.DropTable(
                name: "TrPaymentHeaders");

            migrationBuilder.DropTable(
                name: "DcPaymentMethods");

            migrationBuilder.DropTable(
                name: "TrPriceListHeaders");

            migrationBuilder.DropTable(
                name: "DcBarcodeTypes");

            migrationBuilder.DropTable(
                name: "DcDiscounts");

            migrationBuilder.DropTable(
                name: "DcFeatures");

            migrationBuilder.DropTable(
                name: "TrReportSubQueries");

            migrationBuilder.DropTable(
                name: "DcClaims");

            migrationBuilder.DropTable(
                name: "DcRoles");

            migrationBuilder.DropTable(
                name: "DcSerialNumbers");

            migrationBuilder.DropTable(
                name: "DcUnitOfMeasures");

            migrationBuilder.DropTable(
                name: "TrInvoiceHeaders");

            migrationBuilder.DropTable(
                name: "DcPriceTypes");

            migrationBuilder.DropTable(
                name: "DcFeatureTypes");

            migrationBuilder.DropTable(
                name: "DcReports");

            migrationBuilder.DropTable(
                name: "DcClaimTypes");

            migrationBuilder.DropTable(
                name: "DcProducts");

            migrationBuilder.DropTable(
                name: "DcCurrAccs");

            migrationBuilder.DropTable(
                name: "DcProcesses");

            migrationBuilder.DropTable(
                name: "DcReportTypes");

            migrationBuilder.DropTable(
                name: "DcHierarchies");

            migrationBuilder.DropTable(
                name: "DcProductTypes");

            migrationBuilder.DropTable(
                name: "DcCurrAccTypes");

            migrationBuilder.DropTable(
                name: "DcPaymentTypes");

            migrationBuilder.DropTable(
                name: "DcPersonalTypes");

            migrationBuilder.DropTable(
                name: "DcCurrencies");
        }
    }
}
