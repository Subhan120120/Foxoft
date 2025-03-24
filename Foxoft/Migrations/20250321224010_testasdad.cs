using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class testasdad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "DcClaimCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryLevel = table.Column<int>(type: "int", nullable: false),
                    CategoryParentCode = table.Column<int>(type: "int", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcClaimCategories", x => x.CategoryId);
                });

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DcClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DcClaimCategories",
                columns: new[] { "CategoryId", "CategoryDesc", "CategoryLevel", "CategoryParentCode", "Order" },
                values: new object[,]
                {
                    { 1, "Hesabatlar", 0, null, 0 },
                    { 2, "Fakturalar", 0, null, 0 },
                    { 3, "Pərakəndə Alış", 1, 2, 0 },
                    { 4, "Topdan Alış", 1, 2, 0 },
                    { 5, "Pərakəndə Satış", 1, 2, 0 },
                    { 6, "Topdan Satış", 1, 2, 0 },
                    { 7, "Kredit Alış", 1, 2, 0 },
                    { 8, "Kredit Satış", 1, 2, 0 },
                    { 9, "Xərc", 1, 2, 0 },
                    { 10, "Sayım Artırma", 1, 2, 0 },
                    { 11, "Sayım Azaltma", 1, 2, 0 },
                    { 12, "Təhvil Alma", 1, 2, 0 },
                    { 13, "Təhvil Vermə", 1, 2, 0 },
                    { 14, "Məhsul Transferi", 1, 2, 0 },
                    { 15, "Təhlükəsizlik", 0, null, 0 },
                    { 18, "Məhsul", 0, null, 0 },
                    { 19, "Cari Hesab", 0, null, 0 },
                    { 20, "Kassa", 0, null, 0 },
                    { 21, "Ödəniş", 0, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[] { "CurrAccs", 0, "Cari Hesablar", (byte)1 });


            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "ButunHesabatlar", 1, "Butun Hesabatlar", (byte)2 },
                    { "CashRegs", 21, "Kassalar", (byte)1 },
                    { "CashTransfer", 21, "Pul Transferi", (byte)1 },
                    { "Column_ProductCost", 18, "Maya Dəyəri", (byte)1 },
                    { "CountIn", 10, "Sayım Artırma", (byte)1 },
                    { "CountOut", 11, "Sayım Azaltma", (byte)1 },
                    { "CurrAccClaim", 15, "Cari hesab yetkisi", (byte)1 },
                    { "DeleteInvoiceCI", 10, "Sayım Artırma Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceCO", 11, "Sayım Azaltma Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceEX", 9, "Xərc Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceIP", 7, "Kredit Alış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceIPO", 7, "Kredit Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceIS", 8, "Kredit Satış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceISO", 8, "Kredit Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceRP", 3, "Pərakəndə Alış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceRPO", 3, "Pərakəndə Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceRS", 5, "Pərakəndə Satış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceRSO", 5, "Pərakəndə Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceWP", 4, "Topdan Alış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceWPO", 4, "Topdan Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceWS", 6, "Topdan Satış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceWSO", 6, "Topdan Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteLineCI", 10, "Sayım Artırma Sətiri Silmə", (byte)1 },
                    { "DeleteLineCO", 11, "Sayım Azaltma Sətiri Silmə", (byte)1 },
                    { "DeleteLineEX", 9, "Xərc Sətiri Silmə", (byte)1 },
                    { "DeleteLineIP", 7, "Kredit Alış Sətiri Silmə", (byte)1 },
                    { "DeleteLineIPO", 7, "Kredit Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineIS", 8, "Kredit Satış Sətiri Silmə", (byte)1 },
                    { "DeleteLineISO", 8, "Kredit Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineRP", 3, "Pərakəndə Alış Fakturası Sətiri Silmə", (byte)1 },
                    { "DeleteLineRPO", 3, "Pərakəndə Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineRS", 5, "Pərakəndə Satış Sətiri Silmə", (byte)1 },
                    { "DeleteLineRSO", 5, "Pərakəndə Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineWP", 4, "Topdan Alış Fakturası Sətiri Silmə", (byte)1 },
                    { "DeleteLineWPO", 4, "Topdan Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineWS", 6, "Topdan Satış Sətiri Silmə", (byte)1 },
                    { "DeleteLineWSO", 6, "Topdan Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "EditLockedInvoice", 2, "Kilidli Fakturanı Dəyiş", (byte)1 },
                    { "EditLockedPayment", 2, "Kilidli Ödənişi Dəyiş", (byte)1 },
                    { "Expense", 9, "Xərc", (byte)1 },
                    { "ExpenseOfInvoice", 2, "Faktura Xərci", (byte)1 },
                    { "HierarchyFeatureType", 18, "Özəlliyi İyerarxiyaya Bağlama", (byte)1 },
                    { "InstallmentCommissionChange", 8, "Kreditin Kamissiyasını Dəyişmə", (byte)1 },
                    { "InstallmentPurchaseInvoice", 7, "Kredit Alışı", (byte)1 },
                    { "InstallmentPurchaseOrder", 7, "Kredit Alış Sifarişi", (byte)1 },
                    { "InstallmentPurchaseReturn", 7, "Kredit Alış Qaytarması", (byte)1 },
                    { "InstallmentPurchaseReturnCustom", 7, "Kredit Alış Xüsusi Geri Qaytarması", (byte)1 },
                    { "Installments", 8, "Kreditlər", (byte)1 },
                    { "InstallmentSaleInvoice", 8, "Kredit Satışı", (byte)1 },
                    { "InstallmentSaleOrder", 8, "Kredit Satış Sifarişi", (byte)1 },
                    { "InstallmentSaleReturn", 8, "Kredit Satış Qaytarması", (byte)1 },
                    { "InstallmentSaleReturnCustom", 8, "Kredit Satış Xüsusi Geri Qaytarması", (byte)1 },
                    { "InventoryTransfer", 14, "Mal Transferi", (byte)1 },
                    { "PaymentDetail", 21, "Ödəmə", (byte)1 },
                    { "PosDiscount", 2, "POS Endirimi", (byte)1 },
                    { "PriceList", 18, "Qiymət Cədvəli", (byte)1 },
                    { "ProductDiscountList", 18, "Endirim Siyahısı", (byte)1 },
                    { "ProductFeatureType", 18, "Məhsul Özəlliyi", (byte)1 },
                    { "Products", 18, "Məhsullar", (byte)1 },
                    { "RetailPurchaseInvoice", 3, "Pərakəndə Alış Fakturası", (byte)1 },
                    { "RetailPurchaseOrder", 3, "Pərakəndə Alış Sifarişi", (byte)1 },
                    { "RetailPurchaseReturn", 3, "Pərakəndə Alışın Qaytarılması", (byte)1 },
                    { "RetailPurchaseReturnCustom", 3, "Pərakəndə Alış Xüsusi Geri Qaytarması", (byte)1 },
                    { "RetailSaleInvoice", 5, "Pərakəndə Satış Fakturası", (byte)1 },
                    { "RetailSaleOrder", 5, "Pərakəndə Satış Sifarişi", (byte)1 },
                    { "RetailSaleReturn", 5, "Pərakəndə Satışın Qaytarılması", (byte)1 },
                    { "RetailSaleReturnCustom", 5, "Pərakəndə Satış Xüsusi Geri Qaytarması", (byte)1 },
                    { "Session", 15, "Sessiya", (byte)1 },
                    { "WaybillIn", 12, "Təhvil Alma", (byte)1 },
                    { "WaybillOut", 13, "Təhvil Vermə", (byte)1 },
                    { "WholePurchaseInvoice", 4, "Topdan Alış Fakturası", (byte)1 },
                    { "WholePurchaseOrder", 4, "Topdan Alış Sifarişi", (byte)1 },
                    { "WholePurchaseReturn", 4, "Topdan Alışın Qaytarılması", (byte)1 },
                    { "WholePurchaseReturnCustom", 4, "Topdan Alış Xüsusi Geri Qaytarması", (byte)1 },
                    { "WholesaleInvoice", 6, "Topdan Satış Fakturası", (byte)1 },
                    { "WholesaleOrder", 6, "Topdan Satış Sifarişi", (byte)1 },
                    { "WholesaleReturn", 6, "Topdan Satışın Qaytarılması", (byte)1 },
                    { "WholesaleReturnCustom", 6, "Topdan Satış Xüsusi Geri Qaytarması", (byte)1 }
                });

            //migrationBuilder.InsertData(
            //    table: "TrClaimReports",
            //    columns: new[] { "ClaimReportId", "ClaimCode", "ReportId" },
            //    values: new object[,]
            //    {
            //        { 1, "ButunHesabatlar", 1 },
            //        { 2, "ButunHesabatlar", 2 },
            //        { 3, "ButunHesabatlar", 3 },
            //        { 4, "ButunHesabatlar", 4 },
            //        { 5, "ButunHesabatlar", 5 },
            //        { 11, "ButunHesabatlar", 11 },
            //        { 12, "ButunHesabatlar", 12 },
            //        { 13, "ButunHesabatlar", 13 },
            //        { 14, "ButunHesabatlar", 14 },
            //        { 15, "ButunHesabatlar", 15 },
            //        { 16, "ButunHesabatlar", 16 },
            //        { 17, "ButunHesabatlar", 17 },
            //        { 18, "ButunHesabatlar", 18 }
            //    });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 41, "RetailPurchaseReturnCustom", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[] { 7, "CurrAccs", "Admin" });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 1, "ButunHesabatlar", "Admin" },
                    { 2, "CashRegs", "Admin" },
                    { 3, "CashTransfer", "Admin" },
                    { 4, "Column_ProductCost", "Admin" },
                    { 5, "CountIn", "Admin" },
                    { 6, "CountOut", "Admin" },
                    { 8, "ProductDiscountList", "Admin" },
                    { 9, "Expense", "Admin" },
                    { 10, "InventoryTransfer", "Admin" },
                    { 11, "PaymentDetail", "Admin" },
                    { 12, "PosDiscount", "Admin" },
                    { 13, "PriceList", "Admin" },
                    { 14, "Products", "Admin" },
                    { 16, "RetailPurchaseInvoice", "Admin" },
                    { 17, "RetailSaleInvoice", "Admin" },
                    { 18, "WholesaleInvoice", "Admin" },
                    { 19, "RetailPurchaseReturn", "Admin" },
                    { 20, "RetailSaleReturn", "Admin" },
                    { 21, "WholesaleReturn", "Admin" },
                    { 22, "ProductFeatureType", "Admin" },
                    { 23, "HierarchyFeatureType", "Admin" },
                    { 24, "CurrAccClaim", "Admin" },
                    { 25, "Session", "Admin" },
                    { 26, "WaybillIn", "Admin" },
                    { 27, "WaybillOut", "Admin" },
                    { 28, "ExpenseOfInvoice", "Admin" },
                    { 29, "InstallmentSaleInvoice", "Admin" },
                    { 30, "DeleteInvoiceRP", "Admin" },
                    { 31, "DeleteInvoiceRS", "Admin" },
                    { 32, "DeleteInvoiceWS", "Admin" },
                    { 33, "DeleteInvoiceIS", "Admin" },
                    { 34, "DeleteInvoiceEX", "Admin" },
                    { 35, "DeleteLineRP", "Admin" },
                    { 36, "DeleteLineRS", "Admin" },
                    { 37, "DeleteLineWS", "Admin" },
                    { 38, "DeleteLineIS", "Admin" },
                    { 39, "DeleteLineEX", "Admin" },
                    { 40, "InstallmentSaleReturn", "Admin" },
                    { 42, "RetailsaleReturnCustom", "Admin" },
                    { 43, "WholesaleReturnCustom", "Admin" },
                    { 44, "InstallmentSaleReturnCustom", "Admin" },
                    { 45, "Installments", "Admin" },
                    { 46, "InstallmentCommissionChange", "Admin" },
                    { 47, "EditLockedInvoice", "Admin" },
                    { 48, "EditLockedPayment", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcClaims_CategoryId",
                table: "DcClaims",
                column: "CategoryId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_DcClaims_DcClaimCategories_CategoryId",
            //    table: "DcClaims",
            //    column: "CategoryId",
            //    principalTable: "DcClaimCategories",
            //    principalColumn: "CategoryId",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcClaims_DcClaimCategories_CategoryId",
                table: "DcClaims");

            migrationBuilder.DropTable(
                name: "DcClaimCategories");

            migrationBuilder.DropIndex(
                name: "IX_DcClaims_CategoryId",
                table: "DcClaims");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceCI");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceCO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIPO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceISO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceRPO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceRSO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceWP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceWPO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceWSO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineCI");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineCO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIPO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineISO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineRPO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineRSO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineWP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineWPO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineWSO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentPurchaseReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentsaleOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholePurchaseInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholePurchaseOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholePurchaseReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholePurchaseReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleOrder");

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrClaimReports",
                keyColumn: "ClaimReportId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ButunHesabatlar");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CashRegs");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CashTransfer");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Column_ProductCost");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CountIn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CountOut");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccClaim");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccs");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceEX");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceRP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceRS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceWS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineEX");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineRP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineRS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineWS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "EditLockedInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "EditLockedPayment");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Expense");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ExpenseOfInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "HierarchyFeatureType");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentCommissionChange");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Installments");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentsaleReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentsaleReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InventoryTransfer");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PaymentDetail");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PosDiscount");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PriceList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductDiscountList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductFeatureType");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Products");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Session");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WaybillIn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WaybillOut");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleReturnCustom");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DcClaims");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6,
                column: "ReportQuery",
                value: "WITH PaymentLinesSum AS (\r\n    SELECT\r\n        ph.InvoiceHeaderId,\r\n        ph.CurrAccCode,\r\n        SUM(pl.PaymentLoc) AS PaymentLinesSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.OperationDate > i.DocumentDate -- payments without downpayments\r\n    GROUP BY\r\n        ph.InvoiceHeaderId, ph.CurrAccCode\r\n),\r\nDownPaymentSum AS (\r\n    SELECT\r\n        i.InvoiceHeaderId,\r\n        SUM(pl.PaymentLoc) AS DownPaymentSum\r\n    FROM\r\n        TrPaymentLines pl\r\n    INNER JOIN\r\n        TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    INNER JOIN\r\n        TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE\r\n        ph.OperationDate <= i.DocumentDate -- only downpayments\r\n    GROUP BY\r\n        i.InvoiceHeaderId\r\n),\r\nInstallmentData AS (\r\n    SELECT\r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.DocumentDate,\r\n        i.Amount + COALESCE(ril.NetAmount, 0) AS Amount,\r\n        i.AmountLoc + COALESCE(ril.NetAmountLoc, 0) AS AmountLoc, \r\n        i.CurrencyCode,\r\n        i.ExchangeRate,\r\n        (i.AmountLoc + i.Commission) + COALESCE(ril.NetAmountLoc, 0) AS AmountWithComLoc,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        pp.DurationInMonths,\r\n        COALESCE(psum.PaymentLinesSum, 0) AS TotalPaid,\r\n        COALESCE(dps.DownPaymentSum, 0) AS DownPayment\r\n    FROM\r\n        TrInstallments i\r\n    INNER JOIN\r\n        TrInvoiceHeaders ih ON i.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    INNER JOIN\r\n        DcCurrAccs ca ON ih.CurrAccCode = ca.CurrAccCode\r\n    INNER JOIN\r\n        DcPaymentPlans pp ON i.PaymentPlanCode = pp.PaymentPlanCode\r\n    LEFT JOIN\r\n        PaymentLinesSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId AND ih.CurrAccCode = psum.CurrAccCode\r\n    LEFT JOIN\r\n        DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId\r\n    LEFT JOIN\r\n        TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId AND rih.IsReturn = 1 \r\n    LEFT JOIN\r\n        TrInvoiceLines ril ON ril.InvoiceHeaderId = rih.InvoiceHeaderId\r\n),\r\nCalculatedData AS (\r\n    SELECT\r\n        InstallmentId,\r\n        InvoiceHeaderId,\r\n        CurrAccDesc,\r\n        PhoneNum,\r\n        DocumentNumber,\r\n        DocumentDate,\r\n        Amount,\r\n        AmountWithComLoc,\r\n        CurrencyCode,\r\n        ExchangeRate,\r\n        DownPayment,\r\n        TotalPaid,\r\n		DurationInMonths,\r\n        AmountWithComLoc - TotalPaid AS RemainingBalance,\r\n        (AmountWithComLoc / NULLIF(DurationInMonths, 0)) AS MonthlyPayment,\r\n        FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) AS MonthsPaid,\r\n        DATEADD(MONTH, FLOOR(TotalPaid / (AmountWithComLoc / NULLIF(DurationInMonths, 0))) + 1, DocumentDate) AS OverdueDate\r\n    FROM\r\n        InstallmentData\r\n)\r\nSELECT\r\n    InstallmentId,\r\n    InvoiceHeaderId,\r\n    CurrAccDesc,\r\n    PhoneNum,\r\n    DocumentNumber,\r\n    DocumentDate,\r\n    Amount,\r\n    CurrencyCode,\r\n    ExchangeRate,\r\n    MonthlyPayment,\r\n    [Tutar Faizi ilə] = AmountWithComLoc,\r\n	[Ay] = DurationInMonths,\r\n    [İlkin Ödəniş] = DownPayment,  -- Showing Down Payment Separately\r\n    [Toplam Ödəniş] = TotalPaid,   -- Payments excluding downpayment\r\n    [Qalıq] = RemainingBalance,\r\n    [Aylıq Ödəniş] = MonthlyPayment,\r\n    [Ödənilməli məbləğ] = TotalPaid - (DATEDIFF(DAY, DocumentDate, GETDATE()) / 30) * MonthlyPayment,\r\n    [Gecikmə tarixi] = OverdueDate,\r\n    [Gecikmiş Günlər] = CASE \r\n        WHEN GETDATE() > OverdueDate THEN DATEDIFF(DAY, OverdueDate, GETDATE())\r\n        ELSE 0\r\n    END\r\nFROM\r\n    CalculatedData;\r\n");
        }
    }
}
