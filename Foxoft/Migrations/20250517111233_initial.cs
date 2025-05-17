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

            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims");

            migrationBuilder.Sql("delete from TrRoleClaims where ClaimCode = 'DiscountList'");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DiscountList");

            migrationBuilder.Sql("delete from TrRoleClaims where ClaimCode = 'HierarchyFeatureType'");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "HierarchyFeatureType");

            migrationBuilder.Sql("delete from TrRoleClaims where ClaimCode = 'InstallmentsaleInvoice'");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentsaleInvoice");

            migrationBuilder.Sql("delete from TrRoleClaims where ClaimCode = 'InstallmentsaleReturn'");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentsaleReturn");

            migrationBuilder.Sql("delete from TrRoleClaims where ClaimCode = 'ReportZet'");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ReportZet");

            migrationBuilder.RenameColumn(
                name: "DefaultCurrAccCode",
                table: "DcPaymentMethods",
                newName: "RedirectedCurrAccCode");

            migrationBuilder.RenameIndex(
                name: "IX_DcPaymentMethods_DefaultCurrAccCode",
                table: "DcPaymentMethods",
                newName: "IX_DcPaymentMethods_RedirectedCurrAccCode");

            migrationBuilder.AddColumn<byte>(
                name: "PaymentKindId",
                table: "TrPaymentHeaders",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkerCode",
                table: "TrInvoiceLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountLoc",
                table: "TrInstallments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentDate",
                table: "TrInstallments",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<bool>(
                name: "UseInSite",
                table: "SiteProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReportCategoryId",
                table: "DcReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "DcProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "DcPaymentMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRedirected",
                table: "DcPaymentMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DcClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("update DcClaims set CategoryId = 1 where CategoryId = 0");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DcClaims",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceEditGraceDays",
                table: "AppSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentEditGraceDays",
                table: "AppSettings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DcClaimCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryLevel = table.Column<int>(type: "int", nullable: false),
                    CategoryParentId = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "DcContactType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    ContactTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumberFormat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DefaultValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccFeatureTypes",
                columns: table => new
                {
                    CurrAccFeatureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Filterable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccFeatureTypes", x => x.CurrAccFeatureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcPaymentKinds",
                columns: table => new
                {
                    PaymentKindId = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentKindDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentKinds", x => x.PaymentKindId);
                });

            migrationBuilder.CreateTable(
                name: "DcReportCategories",
                columns: table => new
                {
                    ReportCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportCategories", x => x.ReportCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TrReportCustomizations",
                columns: table => new
                {
                    ReportCustomizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCustomizationDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    ReportDesignFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrReportCustomizations", x => x.ReportCustomizationId);
                    table.ForeignKey(
                        name: "FK_TrReportCustomizations_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrReportCustomizations_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcCurrAccContactDetails_DcContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "DcContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcCurrAccContactDetails_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccFeatures",
                columns: table => new
                {
                    CurrAccFeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrAccFeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    FeatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccFeatures", x => new { x.CurrAccFeatureCode, x.CurrAccFeatureTypeId });
                    table.ForeignKey(
                        name: "FK_DcCurrAccFeatures_DcCurrAccFeatureTypes_CurrAccFeatureTypeId",
                        column: x => x.CurrAccFeatureTypeId,
                        principalTable: "DcCurrAccFeatureTypes",
                        principalColumn: "CurrAccFeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCurrAccFeatures",
                columns: table => new
                {
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CurrAccFeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    CurrAccFeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCurrAccFeatures", x => new { x.CurrAccCode, x.CurrAccFeatureTypeId, x.CurrAccFeatureCode });
                    table.ForeignKey(
                        name: "FK_TrCurrAccFeatures_DcCurrAccFeatureTypes_CurrAccFeatureTypeId",
                        column: x => x.CurrAccFeatureTypeId,
                        principalTable: "DcCurrAccFeatureTypes",
                        principalColumn: "CurrAccFeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrCurrAccFeatures_DcCurrAccFeatures_CurrAccFeatureCode_CurrAccFeatureTypeId",
                        columns: x => new { x.CurrAccFeatureCode, x.CurrAccFeatureTypeId },
                        principalTable: "DcCurrAccFeatures",
                        principalColumns: new[] { "CurrAccFeatureCode", "CurrAccFeatureTypeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrCurrAccFeatures_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "EAN13",
                column: "DefaultBarcodeType",
                value: true);

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "Serbest",
                column: "DefaultBarcodeType",
                value: false);

            migrationBuilder.InsertData(
                table: "DcClaimCategories",
                columns: new[] { "CategoryId", "CategoryDesc", "CategoryLevel", "CategoryParentId", "Order" },
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
                    { 21, "Ödəniş", 0, null, 0 },
                    { 22, "Mağaza", 0, null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "DcClaimTypes",
                keyColumn: "ClaimTypeId",
                keyValue: (byte)1,
                column: "ClaimTypeDesc",
                value: "Embedded");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ButunHesabatlar",
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CashRegs",
                column: "CategoryId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CashTransfer",
                column: "CategoryId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Column_ProductCost",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 18, "Maya Dəyəri" });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CountIn",
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CountOut",
                column: "CategoryId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccClaim",
                column: "CategoryId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccs",
                column: "CategoryId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceIS",
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceRP",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 3, "Pərakəndə Alış Fakturası Silmə" });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceRS",
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceWS",
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineIS",
                column: "CategoryId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineRP",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 3, "Pərakəndə Alış Fakturası Sətiri Silmə" });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineRS",
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineWS",
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Expense",
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ExpenseOfInvoice",
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InventoryTransfer",
                column: "CategoryId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PaymentDetail",
                column: "CategoryId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PosDiscount",
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PriceList",
                column: "CategoryId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductFeatureType",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 18, "Məhsul Özəllik Tipləri" });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Products",
                column: "CategoryId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseInvoice",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 3, "Pərakəndə Alış Fakturası" });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseReturn",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 3, "Pərakəndə Alışın Qaytarılması" });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleInvoice",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 5, "Pərakəndə Satış Fakturası" });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleReturn",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 5, "Pərakəndə Satışın Qaytarılması" });

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Session",
                column: "CategoryId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WaybillIn",
                column: "CategoryId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WaybillOut",
                column: "CategoryId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleInvoice",
                column: "CategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleReturn",
                column: "CategoryId",
                value: 6);

            migrationBuilder.InsertData(
                table: "DcContactType",
                columns: new[] { "Id", "ContactTypeDesc", "DefaultValue", "PhoneNumberFormat" },
                values: new object[,]
                {
                    { (byte)1, "Telefon", null, null },
                    { (byte)2, "Adres", null, null },
                    { (byte)3, "Email", null, null },
                    { (byte)4, "Sosial Media", null, null }
                });

            migrationBuilder.UpdateData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "CurrAccs",
                column: "FormDesc",
                value: "Cari Hesablar");

            migrationBuilder.UpdateData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "Products",
                column: "FormDesc",
                value: "Məhsullar");

            migrationBuilder.InsertData(
                table: "DcForms",
                columns: new[] { "FormCode", "FormDesc" },
                values: new object[] { "CashRegisters", "Kassalar" });

            migrationBuilder.InsertData(
                table: "DcPaymentKinds",
                columns: new[] { "PaymentKindId", "PaymentKindDesc" },
                values: new object[,]
                {
                    { (byte)0, "Unknown" },
                    { (byte)1, "Payment" },
                    { (byte)2, "Invoice" },
                    { (byte)3, "Installment" }
                });

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)4,
                column: "PaymentTypeDesc",
                value: "Bonus");

            migrationBuilder.InsertData(
                table: "DcPaymentTypes",
                columns: new[] { "PaymentTypeCode", "PaymentTypeDesc" },
                values: new object[] { (byte)5, "Komissiya" });


            migrationBuilder.InsertData(
                table: "DcReportCategories",
                columns: new[] { "ReportCategoryId", "ReportCategoryDesc" },
                values: new object[,]
                {
                    { 1, "Satış və Müştəri Hesabatları" },
                    { 2, "Satınalma və Təchizatçı Hesabatları" },
                    { 3, "Məhsul və Stok Hesabatları" },
                    { 4, "İstehsal Hesabatları" },
                    { 5, "Maliyyə Hesabatları" },
                    { 6, "Kadr və İnsan Resursları Hesabatları" },
                    { 7, "Mənfəət/Zərər və Rentabellik Hesabatları" }
                });

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                columns: new[] { "Level", "UnitOfMeasureDesc" },
                values: new object[] { (byte)0, "ədəd" });

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                columns: new[] { "Level", "UnitOfMeasureDesc" },
                values: new object[] { (byte)0, "kq" });


            migrationBuilder.Sql("delete from DcUnitOfMeasures where UnitOfMeasureId = 4");

            migrationBuilder.InsertData(
                table: "DcUnitOfMeasures",
                columns: new[] { "UnitOfMeasureId", "ConversionRate", "Level", "ParentUnitOfMeasureId", "UnitOfMeasureDesc" },
                values: new object[,]
                {
                    { 3, 0m, (byte)0, 0, "metr" },
                    { 4, 0m, (byte)0, 0, "litr" }
                });


            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "CurrAccCreditLimit", 19, "Cari Hesab Kredit Limiti", (byte)1 },
                    { "CurrAccFeatureType", 19, "Cari Hesab Özəlliyi", (byte)1 },
                    { "DeleteInvoiceIP", 7, "Kredit Alış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceIPO", 7, "Kredit Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceISO", 8, "Kredit Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceRPO", 3, "Pərakəndə Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceRSO", 5, "Pərakəndə Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceWP", 4, "Topdan Alış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceWPO", 4, "Topdan Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceWSO", 6, "Topdan Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteLineIP", 7, "Kredit Alış Sətiri Silmə", (byte)1 },
                    { "DeleteLineIPO", 7, "Kredit Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineISO", 8, "Kredit Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineRPO", 3, "Pərakəndə Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineRSO", 5, "Pərakəndə Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineWP", 4, "Topdan Alış Fakturası Sətiri Silmə", (byte)1 },
                    { "DeleteLineWPO", 4, "Topdan Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineWSO", 6, "Topdan Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "EditLockedInvoice", 2, "Kilidli Fakturanı Dəyiş", (byte)1 },
                    { "EditLockedPayment", 2, "Kilidli Ödənişi Dəyiş", (byte)1 },
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
                    { "InventoryTransferReturnCustom", 14, "Məhsul Transferi Xüsusi Qaytarması", (byte)1 },
                    { "Parameters", 15, "Parametrlər", (byte)1 },
                    { "ProductDiscountList", 18, "Endirim Siyahısı", (byte)1 },
                    { "RetailPurchaseReturnCustom", 3, "Pərakəndə Alış Xüsusi Geri Qaytarması", (byte)1 },
                    { "RetailSaleReturnCustom", 5, "Pərakəndə Satış Xüsusi Geri Qaytarması", (byte)1 },
                    { "StoreList", 22, "Mağaza Siyahısı", (byte)1 },
                    { "WholePurchaseInvoice", 4, "Topdan Alış Fakturası", (byte)1 },
                    { "WholePurchaseOrder", 4, "Topdan Alış Sifarişi", (byte)1 },
                    { "WholePurchaseReturn", 4, "Topdan Alışın Qaytarılması", (byte)1 },
                    { "WholePurchaseReturnCustom", 4, "Topdan Alış Xüsusi Geri Qaytarması", (byte)1 },
                    { "WholesaleOrder", 6, "Topdan Satış Sifarişi", (byte)1 },
                    { "WholesaleReturnCustom", 6, "Topdan Satış Xüsusi Geri Qaytarması", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 339, "DeleteLineEX", "Admin" },
                    { 340, "InstallmentSaleReturn", "Admin" },
                    { 341, "RetailPurchaseReturnCustom", "Admin" },
                    { 342, "RetailsaleReturnCustom", "Admin" },
                    { 343, "WholesaleReturnCustom", "Admin" },
                    { 344, "InstallmentSaleReturnCustom", "Admin" },
                    { 345, "Installments", "Admin" },
                    { 346, "InstallmentCommissionChange", "Admin" },
                    { 347, "EditLockedInvoice", "Admin" },
                    { 348, "EditLockedPayment", "Admin" },
                    { 349, "CurrAccCreditLimit", "Admin" },
                    { 350, "Parameters", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_PaymentKindId",
                table: "TrPaymentHeaders",
                column: "PaymentKindId");

            migrationBuilder.CreateIndex(
                name: "IX_DcReports_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DcClaims_CategoryId",
                table: "DcClaims",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccContactDetails_ContactTypeId",
                table: "DcCurrAccContactDetails",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccContactDetails_CurrAccCode",
                table: "DcCurrAccContactDetails",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccFeatures_CurrAccFeatureTypeId",
                table: "DcCurrAccFeatures",
                column: "CurrAccFeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccFeatures_CurrAccFeatureCode_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                columns: new[] { "CurrAccFeatureCode", "CurrAccFeatureTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccFeatures_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                column: "CurrAccFeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportCustomizations_CurrAccCode",
                table: "TrReportCustomizations",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportCustomizations_ReportId",
                table: "TrReportCustomizations",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcClaims_DcClaimCategories_CategoryId",
                table: "DcClaims",
                column: "CategoryId",
                principalTable: "DcClaimCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                column: "RedirectedCurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcReports_DcReportCategories_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId",
                principalTable: "DcReportCategories",
                principalColumn: "ReportCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKindId",
                table: "TrPaymentHeaders",
                column: "PaymentKindId",
                principalTable: "DcPaymentKinds",
                principalColumn: "PaymentKindId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims",
                column: "RoleCode",
                principalTable: "DcRoles",
                principalColumn: "RoleCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcClaims_DcClaimCategories_CategoryId",
                table: "DcClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_RedirectedCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_DcReports_DcReportCategories_ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKindId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims");

            migrationBuilder.DropTable(
                name: "DcClaimCategories");

            migrationBuilder.DropTable(
                name: "DcCurrAccContactDetails");

            migrationBuilder.DropTable(
                name: "DcPaymentKinds");

            migrationBuilder.DropTable(
                name: "DcReportCategories");

            migrationBuilder.DropTable(
                name: "TrCurrAccFeatures");

            migrationBuilder.DropTable(
                name: "TrReportCustomizations");

            migrationBuilder.DropTable(
                name: "DcContactType");

            migrationBuilder.DropTable(
                name: "DcCurrAccFeatures");

            migrationBuilder.DropTable(
                name: "DcCurrAccFeatureTypes");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_PaymentKindId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_DcReports_ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropIndex(
                name: "IX_DcClaims_CategoryId",
                table: "DcClaims");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccFeatureType");

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
                keyValue: "DeleteInvoiceEX");

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
                keyValue: "DeleteInvoiceIT");

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
                keyValue: "DeleteLineIT");

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
                keyValue: "InstallmentSaleInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InventoryTransferReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductDiscountList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "StoreList");

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
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000006");

            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "CashRegisters");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "B03");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "B06");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "B09");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "B12");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "B18");

            migrationBuilder.DeleteData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "B24");

            migrationBuilder.DeleteData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 4);

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
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccCreditLimit");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineEX");

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
                keyValue: "InstallmentCommissionChange");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Installments");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Parameters");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleReturnCustom");

            migrationBuilder.DropColumn(
                name: "PaymentKindId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "WorkerCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "AmountLoc",
                table: "TrInstallments");

            migrationBuilder.DropColumn(
                name: "DocumentDate",
                table: "TrInstallments");

            migrationBuilder.DropColumn(
                name: "UseInSite",
                table: "SiteProducts");

            migrationBuilder.DropColumn(
                name: "ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "DcPaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsRedirected",
                table: "DcPaymentMethods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DcClaims");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DcClaims");

            migrationBuilder.DropColumn(
                name: "InvoiceEditGraceDays",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "PaymentEditGraceDays",
                table: "AppSettings");

            migrationBuilder.RenameColumn(
                name: "RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                newName: "DefaultCurrAccCode");

            migrationBuilder.RenameIndex(
                name: "IX_DcPaymentMethods_RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                newName: "IX_DcPaymentMethods_DefaultCurrAccCode");

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "EAN13",
                column: "DefaultBarcodeType",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcBarcodeTypes",
                keyColumn: "BarcodeTypeCode",
                keyValue: "Serbest",
                column: "DefaultBarcodeType",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcClaimTypes",
                keyColumn: "ClaimTypeId",
                keyValue: (byte)1,
                column: "ClaimTypeDesc",
                value: "Embaded");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Column_ProductCost",
                column: "ClaimDesc",
                value: "Son Alış Qiyməti");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceRP",
                column: "ClaimDesc",
                value: "Alış Fakturası Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteLineRP",
                column: "ClaimDesc",
                value: "Alış Fakturası Sətiri Silmə");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductFeatureType",
                column: "ClaimDesc",
                value: "Məhsul Özəlliyi");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseInvoice",
                column: "ClaimDesc",
                value: "Alış Fakturası");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseReturn",
                column: "ClaimDesc",
                value: "Alışın Qaytarılması");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleInvoice",
                column: "ClaimDesc",
                value: "Satış Fakturası");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleReturn",
                column: "ClaimDesc",
                value: "Satışın Qaytarılması");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "DiscountList", "Endirim Siyahısı", (byte)1 },
                    { "HierarchyFeatureType", "Özəlliyi İyerarxiyaya Bağlama", (byte)1 },
                    { "InstallmentsaleInvoice", "Kredit Satışı", (byte)1 },
                    { "InstallmentsaleReturn", "Kredit Satışı", (byte)1 },
                    { "ReportZet", "Gün Sonu Hesabatı", (byte)1 }
                });

            migrationBuilder.UpdateData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "CurrAccs",
                column: "FormDesc",
                value: "CurrAccs");

            migrationBuilder.UpdateData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "Products",
                column: "FormDesc",
                value: "Products");

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "DefaultCurrAccCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)4,
                column: "PaymentTypeDesc",
                value: "Komissiya");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "ReportQuery",
                value: "\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, Balance =ISNULL(SUM(CAST(Amount as money)),0)\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\nfrom \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where 1=1 \r\n	--and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\nwhere 1 = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\norder by CurrAccDesc");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\nselect CashRegisterCode\r\n, CurrAccDesc\r\n, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\nfrom \r\nDcCurrAccs \r\nleft join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode\r\nwhere CurrAccTypeCode = 5 and IsDisabled = 0 and PaymentTypeCode = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\norder by CurrAccDesc\r\n\r\n\r\n\r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 12,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\nselect  PaymentLineId\r\n, TrPaymentHeaders.PaymentHeaderId\r\n, TrPaymentHeaders.InvoiceHeaderId\r\n, InvoiceNumber = tph.DocumentNumber\r\n, DcPaymentTypes.PaymentTypeCode\r\n, PaymentTypeDesc\r\n, PaymentLoc\r\n, Payment\r\n, CurrencyCode\r\n, LineDescription\r\n, TrPaymentHeaders.DocumentNumber\r\n, TrPaymentHeaders.DocumentDate\r\n, TrPaymentHeaders.DocumentTime\r\n, TrPaymentHeaders.OperationDate\r\n, TrPaymentHeaders.OperationTime\r\n, OperationType\r\n, TrPaymentHeaders.CurrAccCode\r\n, CashRegisterCode\r\n, FirstName\r\n, DcCurrAccs.CurrAccDesc\r\n, TrPaymentHeaders.StoreCode\r\n, tpl.CreatedDate\r\n, tpl.CreatedUserName\r\n, [Cari Hesab Balansı] = (	(select sum ((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where DcCurrAccs.CurrAccCode = ih.CurrAccCode\r\n	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		+ \r\n(select Sum(PaymentLoc) -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where DcCurrAccs.CurrAccCode = ph.CurrAccCode \r\n			and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n			(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		)\r\n\r\n from TrPaymentLines tpl\r\nleft join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\nleft join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId\r\nleft Join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode\r\norder by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc\r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 1,
                columns: new[] { "Level", "UnitOfMeasureDesc" },
                values: new object[] { (byte)1, "Ədəd" });

            migrationBuilder.UpdateData(
                table: "DcUnitOfMeasures",
                keyColumn: "UnitOfMeasureId",
                keyValue: 2,
                columns: new[] { "Level", "UnitOfMeasureDesc" },
                values: new object[] { (byte)1, "Qutu" });

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 8,
                column: "ClaimCode",
                value: "DiscountList");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 23,
                column: "ClaimCode",
                value: "HierarchyFeatureType");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 29,
                column: "ClaimCode",
                value: "InstallmentsaleInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 34,
                column: "ClaimCode",
                value: "DeleteLineRP");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 35,
                column: "ClaimCode",
                value: "DeleteLineRS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 36,
                column: "ClaimCode",
                value: "DeleteLineWS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 37,
                column: "ClaimCode",
                value: "DeleteLineIS");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 38,
                column: "ClaimCode",
                value: "InstallmentsaleReturn");

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[] { 15, "ReportZet", "Admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCurrAccCode",
                table: "DcPaymentMethods",
                column: "DefaultCurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims",
                column: "RoleCode",
                principalTable: "DcRoles",
                principalColumn: "RoleCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
