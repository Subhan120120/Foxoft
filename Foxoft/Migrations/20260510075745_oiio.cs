using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class oiio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcClaimCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CategoryDesc",
                value: "Taksit Alış");

            migrationBuilder.UpdateData(
                table: "DcClaimCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CategoryDesc",
                value: "Taksit Satış");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceIP",
                column: "ClaimDesc",
                value: "Taksit Alış Qiymət Dəyişmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceIS",
                column: "ClaimDesc",
                value: "Taksit Alış Qiymət Dəyişmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccCreditLimit",
                column: "ClaimDesc",
                value: "Cari Hesab Taksit Limiti");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIP",
                column: "ClaimDesc",
                value: "Taksit Alış Fakturası Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIPO",
                column: "ClaimDesc",
                value: "Taksit Alış Sifarişi Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIS",
                column: "ClaimDesc",
                value: "Taksit Satış Fakturası Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceISO",
                column: "ClaimDesc",
                value: "Taksit Satış Sifarişi Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIP",
                column: "ClaimDesc",
                value: "Taksit Alış Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIPO",
                column: "ClaimDesc",
                value: "Taksit Alış Sifarişi Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIS",
                column: "ClaimDesc",
                value: "Taksit Satış Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineISO",
                column: "ClaimDesc",
                value: "Taksit Satış Sifarişi Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentCommissionChange",
                column: "ClaimDesc",
                value: "Taksitin Kamissiyasını Dəyişmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseInvoice",
                column: "ClaimDesc",
                value: "Taksit Alışı");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseOrder",
                column: "ClaimDesc",
                value: "Taksit Alış Sifarişi");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseReturn",
                column: "ClaimDesc",
                value: "Taksit Alış Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseReturnCustom",
                column: "ClaimDesc",
                value: "Taksit Alış Xüsusi Geri Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleInvoice",
                column: "ClaimDesc",
                value: "Taksit Satışı");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleOrder",
                column: "ClaimDesc",
                value: "Taksit Satış Sifarişi");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleReturn",
                column: "ClaimDesc",
                value: "Taksit Satış Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleReturnCustom",
                column: "ClaimDesc",
                value: "Taksit Satış Xüsusi Geri Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSales",
                column: "ClaimDesc",
                value: "Taksit Satışlar");

            migrationBuilder.UpdateData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "InstallmentSale",
                column: "FormDesc",
                value: "Taksit Satış");

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "IS",
                column: "ProcessDesc",
                value: "Taksit Satışı");

            migrationBuilder.UpdateData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "IS",
                column: "VariableDesc",
                value: "Taksit Satışı");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcClaimCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CategoryDesc",
                value: "Kredit Alış");

            migrationBuilder.UpdateData(
                table: "DcClaimCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CategoryDesc",
                value: "Kredit Satış");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceIP",
                column: "ClaimDesc",
                value: "Kredit Alış Qiymət Dəyişmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceIS",
                column: "ClaimDesc",
                value: "Kredit Alış Qiymət Dəyişmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccCreditLimit",
                column: "ClaimDesc",
                value: "Cari Hesab Kredit Limiti");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIP",
                column: "ClaimDesc",
                value: "Kredit Alış Fakturası Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIPO",
                column: "ClaimDesc",
                value: "Kredit Alış Sifarişi Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIS",
                column: "ClaimDesc",
                value: "Kredit Satış Fakturası Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceISO",
                column: "ClaimDesc",
                value: "Kredit Satış Sifarişi Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIP",
                column: "ClaimDesc",
                value: "Kredit Alış Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIPO",
                column: "ClaimDesc",
                value: "Kredit Alış Sifarişi Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIS",
                column: "ClaimDesc",
                value: "Kredit Satış Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineISO",
                column: "ClaimDesc",
                value: "Kredit Satış Sifarişi Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentCommissionChange",
                column: "ClaimDesc",
                value: "Kreditin Kamissiyasını Dəyişmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseInvoice",
                column: "ClaimDesc",
                value: "Kredit Alışı");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseOrder",
                column: "ClaimDesc",
                value: "Kredit Alış Sifarişi");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseReturn",
                column: "ClaimDesc",
                value: "Kredit Alış Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseReturnCustom",
                column: "ClaimDesc",
                value: "Kredit Alış Xüsusi Geri Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleInvoice",
                column: "ClaimDesc",
                value: "Kredit Satışı");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleOrder",
                column: "ClaimDesc",
                value: "Kredit Satış Sifarişi");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleReturn",
                column: "ClaimDesc",
                value: "Kredit Satış Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleReturnCustom",
                column: "ClaimDesc",
                value: "Kredit Satış Xüsusi Geri Qaytarması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSales",
                column: "ClaimDesc",
                value: "Kreditlər");

            migrationBuilder.UpdateData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "InstallmentSale",
                column: "FormDesc",
                value: "Kredit Satış");

            migrationBuilder.UpdateData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "IS",
                column: "ProcessDesc",
                value: "Kredit Satışı");

            migrationBuilder.UpdateData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "IS",
                column: "VariableDesc",
                value: "Kredit Satışı");
        }
    }
}
