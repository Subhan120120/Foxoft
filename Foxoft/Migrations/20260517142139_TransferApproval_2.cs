using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class TransferApproval_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                table: "TrCurrAccRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_trInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "trInvoiceLineExt");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeType_BarcodeTypeCode",
                table: "TrProductBarcodes");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims");

            migrationBuilder.DropTable(
                name: "DcQueryParams");

            migrationBuilder.DropTable(
                name: "DcReportFilters");

            migrationBuilder.DropTable(
                name: "sysdiagrams");

            migrationBuilder.DropTable(
                name: "TrClaimReport");

            migrationBuilder.DropTable(
                name: "TrHierarchyFeatures");

            migrationBuilder.DropTable(
                name: "TrPrices");

            migrationBuilder.DropTable(
                name: "TrProductHierarchies");

            migrationBuilder.DropTable(
                name: "DcReportSubQueries");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trInvoiceLineExt",
                table: "trInvoiceLineExt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcBarcodeType",
                table: "DcBarcodeType");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Column_LastPurchasePrice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DiscountList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PaymentDetail");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ReportZet");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "SaleIsReturn");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "mgz01");

            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01");

            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PurchaseIsReturn");

            migrationBuilder.DropColumn(
                name: "PosterminalId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "PosTerminalId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "PrinterName",
                table: "SettingStores");

            migrationBuilder.DropColumn(
                name: "RowGuid",
                table: "DcCurrAccTypes");

            migrationBuilder.DropColumn(
                name: "DataLanguageCode",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "PrinterName",
                table: "AppSettings");

            migrationBuilder.RenameTable(
                name: "trInvoiceLineExt",
                newName: "TrInvoiceLineExts");

            migrationBuilder.RenameTable(
                name: "DcBarcodeType",
                newName: "DcBarcodeTypes");

            migrationBuilder.RenameColumn(
                name: "LastPurchasePrice",
                table: "TrInvoiceLines",
                newName: "ProductCost");

            migrationBuilder.RenameColumn(
                name: "TwilioToken",
                table: "AppSettings",
                newName: "WhatsappChromeProfileName");

            migrationBuilder.RenameColumn(
                name: "TwilioInstanceId",
                table: "AppSettings",
                newName: "POSFindProductBy");

            migrationBuilder.RenameColumn(
                name: "PrinterCopyNum",
                table: "AppSettings",
                newName: "PrintCount");

            migrationBuilder.RenameColumn(
                name: "GetPrint",
                table: "AppSettings",
                newName: "UseScales");

            migrationBuilder.RenameIndex(
                name: "IX_trInvoiceLineExt_InvoiceLineId",
                table: "TrInvoiceLineExts",
                newName: "IX_TrInvoiceLineExts_InvoiceLineId");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureCode",
                table: "TrProductFeatures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "FeatureTypeId",
                table: "TrProductFeatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrProductFeatures",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "TrProductDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrProductDiscounts",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrProductBarcodes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrProductBarcodes",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrPriceListLines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPriceListLines",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrPriceListHeaders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "TrPaymentMethodDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "TrPaymentMethodDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "CashRegisterCode",
                table: "TrPaymentLines",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "0");

            migrationBuilder.AddColumn<byte>(
                name: "PaymentKindId",
                table: "TrPaymentHeaders",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TerminalId",
                table: "TrPaymentHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SalesPersonCode",
                table: "TrInvoiceLines",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceLoc",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrInvoiceLines",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumberCode",
                table: "TrInvoiceLines",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "TrInvoiceLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkerCode",
                table: "TrInvoiceLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "TrInvoiceHeaders",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LoyaltyCardId",
                table: "TrInvoiceHeaders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TerminalId",
                table: "TrInvoiceHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TransferApprovalStatus",
                table: "TrInvoiceHeaders",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "TrFormReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "FormCode",
                table: "TrFormReports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "RoleCode",
                table: "TrCurrAccRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrCurrAccRoles",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseInSite",
                table: "SiteProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "SettingStores",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "SettingStores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SalesmanContinuity",
                table: "SettingStores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "DcWarehouses",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "CashRegisterCode",
                table: "DcTerminals",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrinterName",
                table: "DcTerminals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreCode",
                table: "DcTerminals",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReportCategoryId",
                table: "DcReports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceWarningLevel",
                table: "DcProducts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "DcProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IsDisabled",
                table: "DcPaymentMethods",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "IsRedirected",
                table: "DcPaymentMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FeatureTypeId",
                table: "DcFeatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "FeatureCode",
                table: "DcFeatures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "RowGuid",
                table: "DcCurrAccs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "DcCurrAccs",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyCode",
                table: "DcCurrAccs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "DcCurrAccs",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MaritalStatus",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PersonalTypeCode",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DcClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DcClaims",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "AutoPrint",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AutoSave",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "DefaultUnitOfMeasureId",
                table: "AppSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceEditGraceDays",
                table: "AppSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockReturnDocument",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<bool>(
                name: "NotifyBalanceWarningLevel",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<byte>(
                name: "OverpaymentMode",
                table: "AppSettings",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "POSMergeSameProducts",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "POSShowQuantityDialog",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "POSShowSalesmanCodeDialog",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentEditGraceDays",
                table: "AppSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TransferAutoApprove",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<bool>(
                name: "UseBarcode",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseCampaign",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UsePriceList",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<byte>(
                name: "WhatsAppProvider",
                table: "AppSettings",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<decimal>(
                name: "LineExpences",
                table: "TrInvoiceLineExts",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceDiscountedLoc",
                table: "TrInvoiceLineExts",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "DefaultBarcodeType",
                table: "DcBarcodeTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrInvoiceLineExts",
                table: "TrInvoiceLineExts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcBarcodeTypes",
                table: "DcBarcodeTypes",
                column: "BarcodeTypeCode");

            migrationBuilder.CreateTable(
                name: "DcCampaigns",
                columns: table => new
                {
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CampaignDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PromoCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiscountTypeCode = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    Priority = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    IsCombinable = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinInvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    MaxDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    ProcessCode = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "RS"),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CampaignPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsCashOnly = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsAutoApply = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCampaigns", x => x.CampaignId);
                });

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
                name: "DcCrmActivityTypes",
                columns: table => new
                {
                    ActivityTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ActivityTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCrmActivityTypes", x => x.ActivityTypeId);
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
                name: "DcDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ParentDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcDepartments_DcDepartments_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "DcDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcEmploymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcEmploymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcInstallmentPlan",
                columns: table => new
                {
                    InstallmentPlanCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InstallmentPlanDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<float>(type: "real", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcInstallmentPlan", x => x.InstallmentPlanCode);
                });

            migrationBuilder.CreateTable(
                name: "DcLoyaltyPrograms",
                columns: table => new
                {
                    LoyaltyProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EarnPercent = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    ExpireDays = table.Column<int>(type: "int", nullable: true),
                    MaxRedeemPercent = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcLoyaltyPrograms", x => x.LoyaltyProgramId);
                });

            migrationBuilder.CreateTable(
                name: "DcNotificationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DaysBefore = table.Column<int>(type: "int", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcNotificationSettings", x => x.Id);
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
                name: "DcPaymentPlans",
                columns: table => new
                {
                    PaymentPlanCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentPlanDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    DurationInMonths = table.Column<int>(type: "int", nullable: false),
                    CommissionRate = table.Column<float>(type: "real", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentPlans", x => x.PaymentPlanCode);
                    table.ForeignKey(
                        name: "FK_DcPaymentPlans_DcPaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "DcPaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcPayrollPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodYear = table.Column<int>(type: "int", nullable: false),
                    PeriodMonth = table.Column<int>(type: "int", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPayrollPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcPersonalTypes",
                columns: table => new
                {
                    PersonalTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    PersonalTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPersonalTypes", x => x.PersonalTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcProductScales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ScaleProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScaleProductNumber = table.Column<int>(type: "int", nullable: true),
                    UseInScale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProductScales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcProductScales_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcProductStaticPrices",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PriceTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProductStaticPrices", x => new { x.ProductCode, x.PriceTypeCode });
                    table.ForeignKey(
                        name: "FK_DcProductStaticPrices_DcPriceTypes_PriceTypeCode",
                        column: x => x.PriceTypeCode,
                        principalTable: "DcPriceTypes",
                        principalColumn: "PriceTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcProductStaticPrices_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
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
                name: "dcReportVariableTypes",
                columns: table => new
                {
                    VariableTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    VariableTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dcReportVariableTypes", x => x.VariableTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcSerialNumbers",
                columns: table => new
                {
                    SerialNumberCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcSerialNumbers", x => x.SerialNumberCode);
                    table.ForeignKey(
                        name: "FK_DcSerialNumbers_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcShortcuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ButtonName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortcutKeys = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ButtonDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcShortcuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcUILanguages",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LanguageDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcUILanguages", x => x.LanguageCode);
                });

            migrationBuilder.CreateTable(
                name: "DcUnitOfMeasures",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitOfMeasureDesc = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParentUnitOfMeasureId = table.Column<int>(type: "int", nullable: true),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false),
                    IsBasic = table.Column<bool>(type: "bit", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcUnitOfMeasures", x => x.UnitOfMeasureId);
                    table.ForeignKey(
                        name: "FK_DcUnitOfMeasures_DcUnitOfMeasures_ParentUnitOfMeasureId",
                        column: x => x.ParentUnitOfMeasureId,
                        principalTable: "DcUnitOfMeasures",
                        principalColumn: "UnitOfMeasureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcWhatsAppProviderSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InstanceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcWhatsAppProviderSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLockAudits",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MachineName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ActionAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLockAudits", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLocks",
                columns: table => new
                {
                    LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LockedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastHeartbeatAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ForceCloseReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientProcessId = table.Column<int>(type: "int", nullable: false),
                    ForceCloseRequestedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppInstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseRequestedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CloseRequestedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseRequestReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLocks", x => x.LockId);
                });

            migrationBuilder.CreateTable(
                name: "TrAttendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkedMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrAttendances_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrBarcodeOperationHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrBarcodeOperationHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrClaimReports",
                columns: table => new
                {
                    ClaimReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrClaimReports", x => x.ClaimReportId);
                    table.ForeignKey(
                        name: "FK_TrClaimReports_DcClaims_ClaimCode",
                        column: x => x.ClaimCode,
                        principalTable: "DcClaims",
                        principalColumn: "ClaimCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrClaimReports_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrCredits",
                columns: table => new
                {
                    CreditId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApiKeyHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCredits", x => x.CreditId);
                });

            migrationBuilder.CreateTable(
                name: "TrHierarchyFeatureTypes",
                columns: table => new
                {
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrHierarchyFeatureTypes", x => new { x.HierarchyCode, x.FeatureTypeId });
                    table.ForeignKey(
                        name: "FK_TrHierarchyFeatureTypes_DcFeatureTypes_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "DcFeatureTypes",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrHierarchyFeatureTypes_DcHierarchies_HierarchyCode",
                        column: x => x.HierarchyCode,
                        principalTable: "DcHierarchies",
                        principalColumn: "HierarchyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceCampaignHeaders",
                columns: table => new
                {
                    InvoiceCampaignHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromoCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceCampaignHeaders", x => x.InvoiceCampaignHeaderId);
                    table.ForeignKey(
                        name: "FK_TrInvoiceCampaignHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrProcessPriceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    PriceTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProcessPriceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrProcessPriceTypes_DcPriceTypes_PriceTypeCode",
                        column: x => x.PriceTypeCode,
                        principalTable: "DcPriceTypes",
                        principalColumn: "PriceTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProcessPriceTypes_DcProcesses_ProcessCode",
                        column: x => x.ProcessCode,
                        principalTable: "DcProcesses",
                        principalColumn: "ProcessCode",
                        onDelete: ReferentialAction.Restrict);
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
                name: "TrReportSubQueries",
                columns: table => new
                {
                    SubQueryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    SubQueryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubQueryText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrReportSubQueries", x => x.SubQueryId);
                    table.ForeignKey(
                        name: "FK_TrReportSubQueries_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PID = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrSessions_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrWhatsAppMessageLogs",
                columns: table => new
                {
                    WhatsAppMessageLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceiverPhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MessageType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrWhatsAppMessageLogs", x => x.WhatsAppMessageLogId);
                    table.ForeignKey(
                        name: "FK_TrWhatsAppMessageLogs_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrWhatsAppMessageLogs_DcCurrAccs_Sender",
                        column: x => x.Sender,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCampaignCategories",
                columns: table => new
                {
                    CampaignCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCampaignCategories", x => x.CampaignCategoryId);
                    table.ForeignKey(
                        name: "FK_TrCampaignCategories_DcCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "DcCampaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrCampaignCategories_DcHierarchies_HierarchyCode",
                        column: x => x.HierarchyCode,
                        principalTable: "DcHierarchies",
                        principalColumn: "HierarchyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCampaignCustomers",
                columns: table => new
                {
                    CampaignCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCampaignCustomers", x => x.CampaignCustomerId);
                    table.ForeignKey(
                        name: "FK_TrCampaignCustomers_DcCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "DcCampaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrCampaignCustomers_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCampaignProducts",
                columns: table => new
                {
                    CampaignProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCampaignProducts", x => x.CampaignProductId);
                    table.ForeignKey(
                        name: "FK_TrCampaignProducts_DcCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "DcCampaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrCampaignProducts_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCampaignStores",
                columns: table => new
                {
                    CampaignStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DcStoreCurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCampaignStores", x => x.CampaignStoreId);
                    table.ForeignKey(
                        name: "FK_TrCampaignStores_DcCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "DcCampaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrCampaignStores_DcCurrAccs_DcStoreCurrAccCode",
                        column: x => x.DcStoreCurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCampaignWarehouses",
                columns: table => new
                {
                    CampaignWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCampaignWarehouses", x => x.CampaignWarehouseId);
                    table.ForeignKey(
                        name: "FK_TrCampaignWarehouses_DcCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "DcCampaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrCampaignWarehouses_DcWarehouses_WarehouseCode",
                        column: x => x.WarehouseCode,
                        principalTable: "DcWarehouses",
                        principalColumn: "WarehouseCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceCampaignLogs",
                columns: table => new
                {
                    InvoiceCampaignLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CampaignDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PromoCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    IsCombinable = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    BaseAmount = table.Column<decimal>(type: "money", nullable: false),
                    BaseAmountLoc = table.Column<decimal>(type: "money", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "money", nullable: false),
                    DiscountAmountLoc = table.Column<decimal>(type: "money", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DcPaymentMethodPaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceCampaignLogs", x => x.InvoiceCampaignLogId);
                    table.ForeignKey(
                        name: "FK_TrInvoiceCampaignLogs_DcCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "DcCampaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInvoiceCampaignLogs_DcPaymentMethods_DcPaymentMethodPaymentMethodId",
                        column: x => x.DcPaymentMethodPaymentMethodId,
                        principalTable: "DcPaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInvoiceCampaignLogs_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInvoiceCampaignLogs_TrInvoiceLines_InvoiceLineId",
                        column: x => x.InvoiceLineId,
                        principalTable: "TrInvoiceLines",
                        principalColumn: "InvoiceLineId",
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
                name: "TrCrmActivities",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OfficeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ActivityTypeId = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Priority = table.Column<byte>(type: "tinyint", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "date", nullable: false),
                    NextPlanDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    AssignedCurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Result = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCrmActivities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_TrCrmActivities_DcCrmActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "DcCrmActivityTypes",
                        principalColumn: "ActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrCrmActivities_DcCurrAccs_CurrAccCode",
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
                name: "DcPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsManagerial = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DcPositions_DcDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DcDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrEmployeeContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EmploymentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrEmployeeContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrEmployeeContracts_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrEmployeeContracts_DcEmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "DcEmploymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInstallments",
                columns: table => new
                {
                    InstallmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstallmentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    InstallmentPlanCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInstallments", x => x.InstallmentId);
                    table.ForeignKey(
                        name: "FK_TrInstallments_DcInstallmentPlan_InstallmentPlanCode",
                        column: x => x.InstallmentPlanCode,
                        principalTable: "DcInstallmentPlan",
                        principalColumn: "InstallmentPlanCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInstallments_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcLoyaltyCards",
                columns: table => new
                {
                    LoyaltyCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LoyaltyProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcLoyaltyCards", x => x.LoyaltyCardId);
                    table.ForeignKey(
                        name: "FK_DcLoyaltyCards_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcLoyaltyCards_DcLoyaltyPrograms_LoyaltyProgramId",
                        column: x => x.LoyaltyProgramId,
                        principalTable: "DcLoyaltyPrograms",
                        principalColumn: "LoyaltyProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPayrollHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PayrollPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPayrollHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPayrollHeaders_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPayrollHeaders_DcPayrollPeriods_PayrollPeriodId",
                        column: x => x.PayrollPeriodId,
                        principalTable: "DcPayrollPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcReportVariables",
                columns: table => new
                {
                    VariableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    VariableTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    VariableProperty = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VariableValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VariableOperator = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VariableValueType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Representative = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportVariables", x => x.VariableId);
                    table.ForeignKey(
                        name: "FK_DcReportVariables_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DcReportVariables_dcReportVariableTypes_VariableTypeId",
                        column: x => x.VariableTypeId,
                        principalTable: "dcReportVariableTypes",
                        principalColumn: "VariableTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrBarcodeOperationLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarcodeOperationHeaderId = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    BarcodeTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 1m),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrBarcodeOperationLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrBarcodeOperationLines_DcBarcodeTypes_BarcodeTypeCode",
                        column: x => x.BarcodeTypeCode,
                        principalTable: "DcBarcodeTypes",
                        principalColumn: "BarcodeTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrBarcodeOperationLines_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrBarcodeOperationLines_TrBarcodeOperationHeaders_BarcodeOperationHeaderId",
                        column: x => x.BarcodeOperationHeaderId,
                        principalTable: "TrBarcodeOperationHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrReportSubQueryRelationColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubQueryId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrReportSubQueryRelationColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrReportSubQueryRelationColumns_TrReportSubQueries_SubQueryId",
                        column: x => x.SubQueryId,
                        principalTable: "TrReportSubQueries",
                        principalColumn: "SubQueryId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "TrEmployeePositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrEmployeePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrEmployeePositions_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrEmployeePositions_DcPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "DcPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInstallmentGuarantors",
                columns: table => new
                {
                    InstallmentGuarantorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    InstallmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInstallmentGuarantors", x => x.InstallmentGuarantorId);
                    table.ForeignKey(
                        name: "FK_TrInstallmentGuarantors_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInstallmentGuarantors_TrInstallments_InstallmentId",
                        column: x => x.InstallmentId,
                        principalTable: "TrInstallments",
                        principalColumn: "InstallmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrLoyaltyTxns",
                columns: table => new
                {
                    LoyaltyTxnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoyaltyCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    TxnType = table.Column<byte>(type: "tinyint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RelatedLoyaltyTxnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrLoyaltyTxns", x => x.LoyaltyTxnId);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_DcLoyaltyCards_LoyaltyCardId",
                        column: x => x.LoyaltyCardId,
                        principalTable: "DcLoyaltyCards",
                        principalColumn: "LoyaltyCardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_TrLoyaltyTxns_RelatedLoyaltyTxnId",
                        column: x => x.RelatedLoyaltyTxnId,
                        principalTable: "TrLoyaltyTxns",
                        principalColumn: "LoyaltyTxnId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrLoyaltyTxns_TrPaymentLines_PaymentLineId",
                        column: x => x.PaymentLineId,
                        principalTable: "TrPaymentLines",
                        principalColumn: "PaymentLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrPayrollLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayrollHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayrollItemType = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPayrollLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrPayrollLines_TrPayrollHeaders_PayrollHeaderId",
                        column: x => x.PayrollHeaderId,
                        principalTable: "TrPayrollHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AutoPrint", "DefaultUnitOfMeasureId", "InvoiceEditGraceDays", "OverpaymentMode", "POSMergeSameProducts", "POSShowQuantityDialog", "POSShowSalesmanCodeDialog", "PaymentEditGraceDays", "TransferAutoApprove", "UseBarcode", "UseCampaign" },
                values: new object[] { false, 1, null, (byte)0, false, false, false, null, true, false, false });

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
                    { 7, "Taksit Alış", 1, 2, 0 },
                    { 8, "Taksit Satış", 1, 2, 0 },
                    { 9, "Xərc", 1, 2, 0 },
                    { 10, "Sayım", 1, 2, 0 },
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
                keyValue: "CountIn",
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CountOut",
                column: "CategoryId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccs",
                column: "CategoryId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Expense",
                column: "CategoryId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InventoryTransfer",
                column: "CategoryId",
                value: 14);

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
                keyValue: "RetailSaleInvoice",
                columns: new[] { "CategoryId", "ClaimDesc" },
                values: new object[] { 5, "Pərakəndə Satış Fakturası" });

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

            migrationBuilder.InsertData(
                table: "DcCrmActivityTypes",
                columns: new[] { "ActivityTypeId", "ActivityTypeDesc", "IsDisabled" },
                values: new object[,]
                {
                    { (byte)1, "Zəng", false },
                    { (byte)2, "Görüş", false },
                    { (byte)3, "Tapşırıq", false },
                    { (byte)4, "Email", false },
                    { (byte)5, "Ziyarət", false }
                });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000001",
                columns: new[] { "CompanyCode", "Gender", "LanguageCode", "MaritalStatus", "PersonalTypeCode", "RowGuid" },
                values: new object[] { null, (byte)0, null, (byte)0, null, null });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000002",
                columns: new[] { "CompanyCode", "Gender", "LanguageCode", "MaritalStatus", "PersonalTypeCode", "PhoneNum", "RowGuid" },
                values: new object[] { null, (byte)0, null, (byte)0, null, "", null });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000003",
                columns: new[] { "CompanyCode", "Gender", "LanguageCode", "MaritalStatus", "PersonalTypeCode", "PhoneNum", "RowGuid" },
                values: new object[] { null, (byte)0, null, (byte)0, null, "", null });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000004",
                columns: new[] { "CompanyCode", "Gender", "LanguageCode", "MaritalStatus", "PersonalTypeCode", "PhoneNum", "RowGuid" },
                values: new object[] { null, (byte)0, null, (byte)0, null, "", null });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000005",
                columns: new[] { "CompanyCode", "Gender", "LanguageCode", "MaritalStatus", "PersonalTypeCode", "RowGuid" },
                values: new object[] { null, (byte)0, null, (byte)0, null, null });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CashRegPaymentTypeCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "FatherName", "FirstName", "Gender", "IdentityNum", "LanguageCode", "LastName", "MaritalStatus", "NewPassword", "OfficeCode", "PersonalTypeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "Theme", "VendorTypeCode" },
                values: new object[] { "MGZ01", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Merkez Mağaza", (byte)4, null, null, null, (byte)0, null, null, null, (byte)0, "456", "ofs01", null, "", null, "MGZ01", null, null, null });

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
                values: new object[,]
                {
                    { "CashRegisters", "Kassalar" },
                    { "ERP", "ERP" },
                    { "InstallmentSale", "Taksit Satış" },
                    { "PaymentDetails", "Ödəniş" }
                });

            migrationBuilder.InsertData(
                table: "DcNotificationSettings",
                columns: new[] { "Id", "DaysBefore", "IsEnabled", "MessageTemplate", "NotificationType" },
                values: new object[,]
                {
                    { 1, 2, false, "Hörmətli müştəri! {StoreDesc} mağazasından götürdüyünüz məhsulun aylıq ödənişinə {day} gün qalıb. Əlaqə nömrəsi: {StorePhone}", "InstallmentReminder" },
                    { 2, null, false, "{StoreDesc} mağazasından götürdüyünüz məhsulun ödənişinin bu gün vaxtıdır. Xahiş edirik, ödənişinizi vaxtında ödəyəsiniz. Əlaqə nömrəsi: {StorePhone}", "InstallmentDueDay" },
                    { 3, null, false, "Yeni cihazınız xeyirli olsun. Bizi seçdiyiniz üçün təşəkkür edirik.", "ProductPurchase" },
                    { 4, null, false, "Hörmətli müştəri, sizin kreditiniz tam bağlandı. Bizi seçdiyiniz üçün təşəkkürlər! {StorePhone}", "CreditClosed" },
                    { 5, null, false, "{StoreDesc} mağazasından götürdüyünüz məhsulun {paid} AZN aylıq krediti ödəndi. Qalıq borcunuz {debit} AZN-dir.", "CreditPayment" },
                    { 6, null, false, "Dəyərli müştərimiz, sizi ad günü münasibətilə {StoreDesc} adından təbrik edirik.", "Birthday" }
                });

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
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                columns: new[] { "IsDefault", "IsRedirected", "RedirectedCurrAccCode" },
                values: new object[] { false, false, null });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                columns: new[] { "IsDefault", "IsRedirected", "PaymentMethodDesc", "PaymentTypeCode", "RedirectedCurrAccCode" },
                values: new object[] { false, true, "Bir Kart", (byte)2, "C-000006" });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                columns: new[] { "IsDefault", "IsRedirected", "PaymentMethodDesc", "PaymentTypeCode", "RedirectedCurrAccCode" },
                values: new object[] { false, false, "Çatdırılma zamanı nağd ödə", (byte)1, null });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                columns: new[] { "IsDefault", "IsRedirected", "PaymentMethodDesc", "RedirectedCurrAccCode" },
                values: new object[] { false, false, "Saytda nağd ödə", null });

            migrationBuilder.InsertData(
                table: "DcPaymentPlans",
                columns: new[] { "PaymentPlanCode", "CommissionRate", "DurationInMonths", "IsDefault", "PaymentMethodId", "PaymentPlanDesc" },
                values: new object[,]
                {
                    { "B03", 0f, 3, false, 3, "3 AY" },
                    { "B06", 0f, 6, false, 3, "6 AY" },
                    { "B09", 0f, 9, false, 3, "9 AY" },
                    { "B12", 0f, 12, false, 3, "12 AY" },
                    { "B18", 0f, 18, false, 3, "18 AY" },
                    { "B24", 0f, 24, false, 3, "24 AY" },
                    { "M03", 0f, 3, false, 2, "3 AY" },
                    { "M06", 0f, 6, false, 2, "6 AY" },
                    { "M09", 0f, 9, false, 2, "9 AY" },
                    { "M12", 0f, 12, false, 2, "12 AY" },
                    { "M18", 0f, 18, false, 2, "18 AY" },
                    { "M24", 0f, 24, false, 2, "24 AY" }
                });

            migrationBuilder.InsertData(
                table: "DcPaymentTypes",
                columns: new[] { "PaymentTypeCode", "PaymentTypeDesc" },
                values: new object[,]
                {
                    { (byte)3, "Bonus" },
                    { (byte)4, "Komissiya" }
                });

            migrationBuilder.InsertData(
                table: "DcPersonalTypes",
                columns: new[] { "PersonalTypeCode", "IsDisabled", "PersonalTypeDesc" },
                values: new object[] { (byte)1, false, "Satıcı" });

            migrationBuilder.InsertData(
                table: "DcPriceTypes",
                columns: new[] { "PriceTypeCode", "PriceTypeDesc" },
                values: new object[] { "STD", "Standart" });

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "CustomCurrencyCode", "ProcessDesc", "ProcessDir" },
                values: new object[,]
                {
                    { "CN", null, "Sayım", (byte)0 },
                    { "EI", null, "Faktura Xərci", (byte)1 },
                    { "IS", null, "Taksit Satışı", (byte)2 },
                    { "RPO", null, "Alış Sifarişi", (byte)1 },
                    { "RSO", null, "Satış Sifarişi", (byte)2 },
                    { "SBO", null, "Toptan Alış Sifarişi", (byte)1 },
                    { "WI", null, "Təhvil Alma", (byte)1 },
                    { "WO", null, "Təhvil Vermə", (byte)2 },
                    { "WSO", null, "Toptan Satış Sifarişi", (byte)2 }
                });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                columns: new[] { "BalanceWarningLevel", "DefaultUnitOfMeasureId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                columns: new[] { "BalanceWarningLevel", "DefaultUnitOfMeasureId" },
                values: new object[] { null, 1 });

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
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 1,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { null, "\r\n\r\n\r\n\r\n\r\n\r\n--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n--declare @StartTime time =  '00:00:00.000'\r\n\r\nselect * from (\r\n\r\nSelect pro.ProductCode\r\n		, pro.HierarchyCode\r\n		, [Məhsulun Genis Adi]= isnull(pro.HierarchyCode + ' ','')  + ProductDesc \r\n			+ isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') + isnull(' ' + Feature06,'') + isnull(' ' +Feature07,'')\r\n			+ isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') + isnull(' ' + Feature11,'')\r\n			+ isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n			+ isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')\r\n			+ isnull(' ' + Feature23,'') + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') \r\n			+ isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		, ProductDesc\r\n		, Balance = CAST(isnull(ProductBalance.[depo-01],0) AS INT)\r\n		, WholesalePrice\r\n		, HierarchyDesc\r\n		, ProductTypeCode\r\n		--, ProductId	\r\n		, ProductCost = dbo.GetProductCost(pro.ProductCode, null)\r\n		--, CalcClosingStockFifo.FIFO_CORG\r\n		, IsDisabled\r\n		\r\nfrom DcProducts pro\r\n\r\nleft join DcHierarchies on pro.HierarchyCode = DcHierarchies.HierarchyCode\r\n--left join SiteProducts on SiteProducts.ProductCode = pro.ProductCode\r\nleft join ProductFeatures ON pro.ProductCode = ProductFeatures.ProductCode \r\nleft join ProductBalance on ProductBalance.ProductCode = pro.ProductCode\r\nleft join CalcClosingStockFifo on CalcClosingStockFifo.ProductCode = pro.ProductCode\r\n\r\n	--where ProductTypeCode = 1\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))\r\n	--and il.ProductCode = '5503'\r\n\r\n) as tablo \r\n	order by \r\ntablo.HierarchyCode \r\n, tablo.ProductDesc \r\n\r\n\r\n\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 2,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { null, "\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, Balance =ISNULL(SUM(CAST(Amount as money)),0)\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\n, PersonalTypeCode\r\n, IsDisabled\r\nfrom \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where 1=1 AND pl.PaymentTypeCode != 4\r\n	--and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\nwhere 1 = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\n, IsDisabled\r\n, PersonalTypeCode\r\norder by CurrAccDesc" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 3,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { null, "\r\n\r\n	select CashRegisterCode = DcCurrAccs.CurrAccCode\r\n	, [Kassa Adı] = CurrAccDesc\r\n	, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	, StoreCode\r\n	from \r\n	DcCurrAccs \r\n	left join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode and PaymentTypeCode = 1\r\n	where CurrAccTypeCode = 5 and IsDisabled = 0\r\n		--and DcCurrAccs.IsVIP = 1 \r\n		--and balance.CurrAccCode = '1403'\r\n	group by DcCurrAccs.CurrAccCode\r\n	, CurrAccDesc\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	, CashRegisterCode \r\n	, StoreCode\r\n	order by CurrAccDesc" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 4,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { null, "\r\n\r\n--Declare @invoiceHeader nvarchar(50) = 'dd6927e4-d33c-4dc7-929c-1410c299e0a9'\r\n\r\n	select  TrInvoiceLines.InvoiceLineId\r\n			,	[Marka] = isnull(' ' +  Feature02Desc,'')\r\n		  , [Ceki] = isnull(' ' + Feature04Desc,'')\r\n		  , [Reng] = isnull(' ' + Feature05Desc,'')\r\n		  , [Məhsul Tipi] = isnull(' ' + Feature06Desc,'')\r\n		  , [Soyutma Tipi] = isnull(' ' + Feature07Desc,'')\r\n		  , [BTU] = isnull(' ' + Feature09Desc,'')\r\n		  , [Ekran Ölçüsü] = isnull(' ' + Feature10Desc,'')\r\n		  , [Ekran İcazəsi] = isnull(' ' + Feature11Desc,'')\r\n		  , [Motorun Növü] = isnull(' ' + Feature12Desc,'')\r\n		  , [Həcmi] = isnull(' ' + Feature13Desc,'')\r\n		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + Feature14Desc,'')\r\n		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + Feature15Desc,'')\r\n		  , [Istehsalçı Ölkə] = isnull(' ' + Feature16Desc,'')\r\n		  , [Məhsuldarlıq] = isnull(' ' + Feature17Desc,'')\r\n		  , [Güc] = isnull(' ' + Feature18Desc,'')\r\n		  , [Tərtib Edən İstifadəçi] =( select CurrAccDesc from DcCurrAccs where CurrAccCode = TrInvoiceHeaders.CreatedUserName)\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, DcProducts.ProductCode\r\n	, ProductDesc\r\n	, QtyIn = QtyIn\r\n	, QtyOut = QtyOut\r\n	, Price\r\n	, TrInvoiceLines.PosDiscount\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, ProcessDesc = IIF(IsReturn = 1, ProcessDesc + ' - Geri Qaytarma', ProcessDesc)\r\n	, TrInvoiceLines.CurrencyCode\r\n	, DcProducts.HierarchyCode\r\n	, HierarchyDesc\r\n	, IsReturn\r\n	, CustomsDocumentNumber\r\n	, PrintCount\r\n	, NetAmount\r\n	, LineDescription\r\n	, PriceLoc\r\n	, PriceDiscounted\r\n	, PriceDiscountedLoc\r\n	, TrInvoiceLines.ExchangeRate\r\n	, NetAmountLoc = (QtyIn-QtyOut) * PriceDiscountedLoc\r\n	, DocumentNumber\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, DcCurrAccs.CurrAccCode\r\n	, DcCurrAccs.CurrAccDesc\r\n	, DcCurrAccs.FirstName\r\n	, DcCurrAccs.PhoneNum\r\n	, HeaderCreatedDate = TrInvoiceHeaders.CreatedDate\r\n	, LineCreatedDate = TrInvoiceLines.CreatedDate\r\n	, TrInvoiceHeaders.CreatedUserName\r\n	, CurrAccBalance = dbo.CurrAccBalance(TrInvoiceHeaders.CurrAccCode, CAST(DocumentDate as Datetime) + CAST(DocumentTime as Datetime))\r\n	, BalanceCode = 'M' + Convert(nvarchar, Format((select SUM(QtyIn - QtyOut) ProductBalance\r\n						from TrInvoiceLines il \r\n						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n						where il.ProductCode = TrInvoiceLines.ProductCode and WarehouseCode = TrInvoiceHeaders.WarehouseCode\r\n						and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )),'000')) \r\n						\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, TrInvoiceHeaders.ToWarehouseCode\r\n	, [Depodan] = wareIn.WarehouseDesc\r\n	, [Depoya] = wareOut.WarehouseDesc\r\n	, Description\r\n	, TrInvoiceHeaders.StoreCode\r\n	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl \r\n							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)\r\n	, ProductCost\r\n	, StorePhoneNum = store.PhoneNum\r\n	, StoreAddress = store.Address\r\n	from TrInvoiceLines\r\n	left join TrInvoiceLineExts on TrInvoiceLineExts.InvoiceLineId = TrInvoiceLines.InvoiceLineId\r\n	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n	left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\n	left join DcHierarchies on DcHierarchies.HierarchyCode = DcProducts.HierarchyCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = TrInvoiceLines.CurrencyCode\r\n	left join DcWarehouses wareIn on wareIn.WarehouseCode = TrInvoiceHeaders.WarehouseCode\r\n	left join DcWarehouses wareOut on wareOut.WarehouseCode = TrInvoiceHeaders.ToWarehouseCode\r\n	left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n	left join DcCurrAccs store on store.CurrAccCode = TrInvoiceHeaders.StoreCode\r\n\r\n	where TrInvoiceHeaders.InvoiceHeaderId = @InvoiceHeaderId\r\n\r\n\r\n	order by TrInvoiceLines.CreatedDate\r\n\r\n\r\n\r\n\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 5,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { null, "\r\n\r\n\r\nSELECT   t2.number + 1 RepeatNumber\r\n	, DcProducts.ProductDesc\r\n	, DcProducts.WholesalePrice\r\n	, DcProducts.RetailPrice\r\n	, pb.*\r\nFROM    TrProductBarcodes pb\r\nJOIN DcProducts on DcProducts.ProductCode = pb.ProductCode\r\nJOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < pb.Qty\r\n" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 11,
                column: "ReportCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 12,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { 5, "\r\n\r\n\r\n\r\nselect  PaymentLineId\r\n, TrPaymentHeaders.PaymentHeaderId\r\n, TrPaymentHeaders.InvoiceHeaderId\r\n, InvoiceNumber = tph.DocumentNumber\r\n, DcPaymentTypes.PaymentTypeCode\r\n, PaymentTypeDesc\r\n, PaymentLoc\r\n, Payment\r\n, CurrencyCode\r\n, LineDescription\r\n, TrPaymentHeaders.DocumentNumber\r\n, TrPaymentHeaders.DocumentDate\r\n, TrPaymentHeaders.DocumentTime\r\n, TrPaymentHeaders.OperationDate\r\n, TrPaymentHeaders.OperationTime\r\n, PaymentKindId\r\n, TrPaymentHeaders.CurrAccCode\r\n, CashRegisterCode\r\n, FirstName\r\n, DcCurrAccs.CurrAccDesc\r\n, TrPaymentHeaders.StoreCode\r\n, tpl.CreatedDate\r\n, tpl.CreatedUserName\r\n, [Cari Hesab Balansı] = (	(select sum ((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where DcCurrAccs.CurrAccCode = ih.CurrAccCode\r\n	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		+ \r\n(select Sum(PaymentLoc) -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where DcCurrAccs.CurrAccCode = ph.CurrAccCode \r\n			and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n			(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		)\r\n\r\n from TrPaymentLines tpl\r\nleft join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\nleft join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId\r\nleft Join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode\r\norder by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc\r\n\r\n\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 13,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { 1, "\r\n\r\n\r\n\r\n\r\n\r\nselect 	CurrAccDesc\r\n	--, ProductDesc\r\n	, NetAmountLoc\r\n	, PaymentLoc\r\n	, [Ara Toplam] = sum(Summary) OVER (ORDER BY DocumentDate, DocumentTime )\r\n	, ProcessDesc\r\n	, DocumentNumber\r\n	, CurrAccCode\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, InvoiceHeaderId\r\n	, PaymentHeaderId\r\n	, LineDescription\r\n	, IsReturn\r\n	, StoreCode\r\n	--, LineId\r\nfrom (\r\n	select FirstName\r\n	, CurrAccDesc\r\n	--, ProductDesc\r\n	, ih.InvoiceHeaderId\r\n	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, PaymentLoc= 0\r\n	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, ProcessDesc = ProcessDesc\r\n	, DocumentNumber\r\n	, ih.StoreCode\r\n	, ih.CurrAccCode\r\n	, ih.DocumentDate\r\n	, ih.DocumentTime\r\n	, LineDescription = ih.Description\r\n	, ih.ProcessCode\r\n	, IsReturn\r\n	--, LineId = InvoiceLineId\r\n	from TrInvoiceLines \r\n	left join TrInvoiceHeaders ih on TrInvoiceLines.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	left join DcCurrAccs on ih.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = ih.ProcessCode\r\n	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\n	where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )\r\n	group by FirstName\r\n			, CurrAccDesc\r\n			, ProcessDesc\r\n			, DocumentNumber\r\n			, ih.InvoiceHeaderId\r\n			, ih.CurrAccCode\r\n			, ih.DocumentDate	\r\n			, ih.DocumentTime\r\n			, ih.Description\r\n			, ih.StoreCode\r\n			, ih.ProcessCode\r\n			, IsReturn\r\n	\r\n	UNION ALL \r\n	\r\n	select FirstName\r\n	--, ProductCode = ''\r\n	, CurrAccDesc = CurrAccDesc\r\n	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, TrPaymentHeaders.PaymentHeaderId\r\n	, NetAmountLoc = 0\r\n	, PaymentLoc\r\n	, Summary = PaymentLoc\r\n	, ProcessDesc = N'Ödəniş'\r\n	, DocumentNumber\r\n	, TrPaymentHeaders.StoreCode\r\n	, TrPaymentHeaders.CurrAccCode\r\n	, DocumentDate = TrPaymentHeaders.OperationDate\r\n	, DocumentTime = TrPaymentHeaders.OperationTime\r\n	, LineDescription\r\n	, ProcessCode = 'PA'\r\n	, IsReturn = CAST(0 as bit)\r\n	--, LineId = PaymentLineId\r\n	from TrPaymentLines\r\n	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\n	left join DcCurrAccs  on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode	\r\n\r\n) as CurrAccExtra where 1=1 {CurrAccCode}\r\n\r\norder by DocumentDate, DocumentTime" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 14,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { 3, "\r\n\r\n\r\n\r\n\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')\r\n		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		  + isnull(' ' + Feature29,'') \r\n\r\n\r\n, ProductDesc\r\n, QtyIn\r\n, QtyOut\r\n, Price\r\n, PriceLoc\r\n, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))\r\n, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))\r\n, Amount\r\n, NetAmountLoc\r\n, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines \r\n		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId\r\n		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc = IIF(IsReturn = 1, ProcessDesc + ' - Geri Qaytarma', ProcessDesc)\r\n, DocumentNumber\r\n, IsReturn\r\n, ProductCost\r\n, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceLines.PosDiscount\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs .CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, PrintCount\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il \r\n					left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n					where il.ProductCode = TrInvoiceLines.ProductCode\r\n					and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT'))\r\n, TrInvoiceHeaders.CreatedUserName\r\n, ImagePath\r\n--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  \r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n\r\norder by DocumentDate, DocumentTime\r\n\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 15,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { 7, "\r\n\r\nSELECT \r\n Menfeet = Satis - Maya\r\n, [Net Menfeet] = Satis - Maya - Xərc\r\n, *\r\nFROM  (\r\nselect  TrInvoiceLines.InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, ProductDesc\r\n, Price\r\n, PriceLoc\r\n, Amount\r\n, NetAmountLoc\r\n, TrInvoiceLines.PosDiscount\r\n, QtyIn\r\n, QtyOut\r\n, Satis = case when TrInvoiceHeaders.ProcessCode IN ('WS', 'RS', 'IS') then NetAmountLoc else 0 end\r\n, Maya = CASE WHEN TrInvoiceHeaders.ProcessCode IN ('WS', 'RS', 'IS') THEN (QtyOut - QtyIn) * COALESCE(ProductCost, 0) ELSE 0 END\r\n, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end\r\n, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end\r\n, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end\r\n, IsReturn\r\n, ProductCost\r\n--, SonQiymet = dbo.GetProductCost(TrInvoiceLines.ProductCode, CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, InvoiceNumber = DocumentNumber\r\n--, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)  / NULLIF(ProductCost,0) * 100,2)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs.CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, TrInvoiceLines.CreatedUserName\r\n, TrInvoiceLineExts.PriceDiscountedLoc\r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join TrInvoiceLineExts on TrInvoiceLineExts.InvoiceLineId = TrInvoiceLines.InvoiceLineId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	\r\n\r\nwhere TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'WS', 'RS', 'IS', 'EX')\r\n--and DocumentNumber = 'RS-000012'\r\n) Dvijok\r\norder by Dvijok.DocumentDate\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 16,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { 3, "\r\n\r\n\r\nselect \r\n [Topdan Sat. Qiy.] =  Round(WholesalePrice, 0)\r\n, [Maya Dəyəri.] =  Round(ProductCost, 0)\r\n, [%] =CONVERT(int, Round((1 - (PivotTable.ProductCost / NULLIF(PivotTable.WholesalePrice,0))) * 100, 0)) \r\n, *\r\nfrom (\r\n	select prdcts.ProductCode\r\n	, LastUpdatedDate\r\n	, UseInternet\r\n	, ProductDesc \r\n	, HierarchyCode \r\n	, FeatureCode\r\n	, FeatureTypeId\r\n	, WholesalePrice\r\n	, ProductCost = (select top 1  PriceLoc * (1 - (PosDiscount / 100))	\r\n								from TrInvoiceLines il\r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.ProcessCode IN ('RP', 'CI') \r\n								and ih.IsReturn = 0\r\n								order by ih.DocumentDate desc\r\n										, ih.CreatedDate desc\r\n								)\r\n	, [Son Alış Günü] = (select top 1  il.LastUpdatedDate	\r\n								from TrInvoiceLines il\r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.ProcessCode IN ('RP') \r\n								and ih.IsReturn = 0\r\n								order by ih.DocumentDate desc\r\n										, ih.CreatedDate desc\r\n								)\r\n	, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il \r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.WarehouseCode = 'depo-01'\r\n								and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT'))\r\n	from DcProducts prdcts\r\n	left join TrProductFeatures on TrProductFeatures.ProductCode = prdcts.ProductCode\r\n\r\n	where ProductTypeCode = 1\r\n	) pro\r\nPIVOT (Max(FeatureCode) FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25]) \r\n) AS PivotTable \r\norder by PivotTable.[Son Alış Günü] \r\n\r\n\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 17,
                columns: new[] { "ReportCategoryId", "ReportQuery" },
                values: new object[] { 3, "\r\n\r\nselect DcProducts.ProductCode\r\n	, DcProducts.ProductDesc\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, Balance = sum(QtyIn - QtyOut)\r\n	, ProductCost = (select top 1 PriceLoc * (100 - PosDiscount)/100\r\n					from TrInvoiceLines \r\n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \r\n					{StartDate}\r\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\r\n					)\r\n	, Toplam = sum(QtyIn - QtyOut) * (select top 1 PriceLoc * (100 - PosDiscount)/100\r\n					from TrInvoiceLines \r\n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \r\n					{StartDate}\r\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\r\n					)\r\nfrom TrInvoiceLines\r\nLEFT JOIN TrInvoiceHeaders \r\n	ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nLEFT JOIN DcProducts \r\n	on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\nwhere DcProducts.ProductTypeCode = 1 --and TrInvoiceHeaders.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT')\r\n\r\n{StartDate}\r\nGroup by DcProducts.ProductCode\r\n	, DcProducts.ProductDesc\r\n	, TrInvoiceHeaders.WarehouseCode\r\n\r\n" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 18,
                column: "ReportCategoryId",
                value: 3);

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportCategoryId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[,]
                {
                    { 6, null, null, "", "Report_Embedded_InstallmentSale", "\r\n\r\n\r\n;WITH InstallmentPaymentSum AS (\r\n    SELECT\r\n        ph.InvoiceHeaderId,\r\n        ph.CurrAccCode,\r\n        SUM(pl.PaymentLoc) AS InstallmentPaymentSum\r\n    FROM TrPaymentLines pl\r\n    JOIN TrPaymentHeaders ph ON pl.PaymentHeaderId = ph.PaymentHeaderId\r\n    JOIN TrInstallments i ON ph.InvoiceHeaderId = i.InvoiceHeaderId\r\n    WHERE ph.PaymentKindId = 3\r\n    GROUP BY ph.InvoiceHeaderId, ph.CurrAccCode\r\n),\r\nDownPaymentSum AS (\r\n    SELECT\r\n        i.InvoiceHeaderId,\r\n        SUM(pl.PaymentLoc) AS DownPaymentSum\r\n    FROM TrInstallments i\r\n    JOIN TrInvoiceHeaders ih ON ih.InvoiceHeaderId = i.InvoiceHeaderId\r\n    JOIN TrPaymentHeaders ph ON ih.InvoiceHeaderId = ph.InvoiceHeaderId\r\n                             AND ih.CurrAccCode     = ph.CurrAccCode\r\n    JOIN TrPaymentLines pl   ON ph.PaymentHeaderId  = pl.PaymentHeaderId\r\n    WHERE ph.PaymentKindId != 3\r\n    GROUP BY i.InvoiceHeaderId\r\n),\r\nInstallmentData AS (\r\n    SELECT\r\n        i.InstallmentId,\r\n        i.InvoiceHeaderId,\r\n        i.InstallmentDate,\r\n        SUM(il.NetAmountLoc) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountLoc,\r\n        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0) AS AmountWithComLoc,\r\n        (SUM(il.NetAmountLoc) + i.Commission) + COALESCE(SUM(ril.NetAmountLoc), 0)\r\n          - COALESCE(dps.DownPaymentSum, 0) AS InstallmentAmount,\r\n        ih.DocumentNumber,\r\n        ca.CurrAccDesc,\r\n        ca.PhoneNum,\r\n        ip.DurationInMonths,\r\n        COALESCE(psum.InstallmentPaymentSum, 0) AS InstallmentPaid,\r\n        COALESCE(dps.DownPaymentSum, 0) AS DownPayment\r\n    FROM TrInstallments i\r\n    JOIN TrInvoiceHeaders ih    ON i.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    LEFT JOIN TrInvoiceLines il ON il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n    JOIN DcCurrAccs ca          ON ih.CurrAccCode = ca.CurrAccCode\r\n    JOIN DcInstallmentPlan ip   ON i.InstallmentPlanCode = ip.InstallmentPlanCode\r\n    LEFT JOIN InstallmentPaymentSum psum ON i.InvoiceHeaderId = psum.InvoiceHeaderId\r\n                                         AND ih.CurrAccCode     = psum.CurrAccCode\r\n    LEFT JOIN DownPaymentSum dps ON i.InvoiceHeaderId = dps.InvoiceHeaderId\r\n    LEFT JOIN TrInvoiceHeaders rih ON rih.RelatedInvoiceId = i.InvoiceHeaderId \r\n                                  AND rih.IsReturn = 1\r\n    LEFT JOIN TrInvoiceLines ril   ON ril.InvoiceHeaderId  = rih.InvoiceHeaderId\r\n                                   AND ril.RelatedLineId   = il.InvoiceLineId\r\n    GROUP BY\r\n        i.InstallmentId, \r\n        i.InvoiceHeaderId, \r\n        i.InstallmentDate,\r\n        ih.DocumentNumber, \r\n        ca.CurrAccDesc, \r\n        ca.PhoneNum,\r\n        ip.DurationInMonths, \r\n        i.Commission, \r\n        psum.InstallmentPaymentSum, \r\n        dps.DownPaymentSum\r\n)\r\nSELECT\r\n    id.InstallmentId,\r\n    id.InvoiceHeaderId,\r\n    id.DocumentNumber,\r\n    id.CurrAccDesc,\r\n    id.PhoneNum,\r\n    id.InstallmentDate,\r\n    id.InstallmentAmount,\r\n    id.DurationInMonths,\r\n    id.InstallmentPaid,\r\n\r\n    CASE\r\n        WHEN COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0) < 0 THEN 0\r\n        ELSE COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0)\r\n    END AS RemainingAmount,\r\n\r\n    CASE\r\n        WHEN COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0) <= 0\r\n            THEN 1\r\n        ELSE 0\r\n    END AS InstallmentStatus,\r\n\r\n    mp.MonthlyPayment,\r\n    pm.PassedMonth,\r\n    p2.PaidMonth,\r\n\r\n    CASE\r\n        WHEN pm.PassedMonth * mp.MonthlyPayment - COALESCE(id.InstallmentPaid, 0) < 0 THEN 0\r\n        ELSE pm.PassedMonth * mp.MonthlyPayment - COALESCE(id.InstallmentPaid, 0)\r\n    END AS DueAmount,\r\n\r\n    dd.DueDate,\r\n    od.OverDueDays\r\n\r\nFROM InstallmentData id\r\nOUTER APPLY (\r\n    SELECT MonthlyPayment =\r\n        CASE\r\n            WHEN NULLIF(id.DurationInMonths, 0) IS NULL \r\n              OR COALESCE(id.InstallmentAmount, 0) = 0 THEN 0.0\r\n            ELSE COALESCE(id.InstallmentAmount, 0) * 1.0 / NULLIF(id.DurationInMonths, 0)\r\n        END\r\n) mp\r\nOUTER APPLY (\r\n    SELECT RawPassed =\r\n        DATEDIFF(MONTH, id.InstallmentDate, CAST(GETDATE() AS date))\r\n) rp\r\nOUTER APPLY (\r\n    SELECT PassedMonth =\r\n        CASE\r\n            WHEN rp.RawPassed < 0 THEN 0\r\n            WHEN rp.RawPassed > COALESCE(id.DurationInMonths, 0) THEN COALESCE(id.DurationInMonths, 0)\r\n            ELSE rp.RawPassed\r\n        END\r\n) pm\r\nOUTER APPLY (\r\n    SELECT PaidMonth =\r\n        CASE\r\n            WHEN mp.MonthlyPayment <= 0 THEN 0\r\n            ELSE\r\n                CASE\r\n                    WHEN FLOOR(COALESCE(id.InstallmentPaid, 0) * 1.0 / mp.MonthlyPayment) > COALESCE(id.DurationInMonths, 0)\r\n                        THEN COALESCE(id.DurationInMonths, 0)\r\n                    ELSE FLOOR(COALESCE(id.InstallmentPaid, 0) * 1.0 / mp.MonthlyPayment)\r\n                END\r\n        END\r\n) p2\r\nOUTER APPLY (\r\n    SELECT DueDate =\r\n        CASE\r\n            WHEN COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0) <= 0 THEN NULL\r\n            ELSE DATEADD(MONTH, p2.PaidMonth + 1, id.InstallmentDate)\r\n        END\r\n) dd\r\nOUTER APPLY (\r\n    SELECT OverDueDays =\r\n        CASE\r\n            WHEN COALESCE(id.InstallmentAmount, 0) - COALESCE(id.InstallmentPaid, 0) <= 0 \r\n              OR dd.DueDate IS NULL THEN 0\r\n            WHEN CAST(GETDATE() AS date) <= CAST(dd.DueDate AS date) THEN 0\r\n            ELSE DATEDIFF(DAY, CAST(dd.DueDate AS date), CAST(GETDATE() AS date))\r\n        END\r\n) od;", (byte)0 },
                    { 7, null, null, "", "Report_Embedded_StoreList", "\r\n\r\n	select StoreCode = DcCurrAccs.CurrAccCode\r\n	, [Mağaza Adı] = CurrAccDesc\r\n	, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	from \r\n	DcCurrAccs \r\n	left join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode and PaymentTypeCode = 1\r\n	where CurrAccTypeCode = 4 and IsDisabled = 0\r\n		--and DcCurrAccs.IsVIP = 1 \r\n		--and balance.CurrAccCode = '1403'\r\n	group by DcCurrAccs.CurrAccCode\r\n	, CurrAccDesc\r\n	, PhoneNum\r\n	, IsVIP\r\n	, CurrAccTypeCode\r\n	, CashRegisterCode \r\n	order by CurrAccDesc", (byte)0 },
                    { 8, null, null, "", "Report_Embedded_BarcodeOperation", "\r\nSELECT   t2.number + 1 RepeatNumber\r\n	, DcProducts.ProductDesc\r\n	, DcProducts.WholesalePrice\r\n	, DcProducts.RetailPrice\r\n	, TrBarcodeOperationLines.*\r\nFROM TrBarcodeOperationLines\r\nJOIN DcProducts on DcProducts.ProductCode = TrBarcodeOperationLines.ProductCode\r\nJOIN TrBarcodeOperationHeaders on TrBarcodeOperationHeaders.Id = TrBarcodeOperationLines.BarcodeOperationHeaderId\r\nJOIN master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < TrBarcodeOperationLines.Qty\r\n", (byte)0 },
                    { 9, null, null, "", "Report_Embedded_PaymentReport", "\r\n\r\nselect ph.*\r\n	, ProcessDesc\r\n	, pl.PaymentLineId\r\n	, pl.PaymentTypeCode\r\n	, pl.Payment\r\n	, pl.PaymentLoc\r\n	, pl.CurrencyCode\r\n	, pl.ExchangeRate\r\n	, pl.LineDescription\r\n	, pl.CashRegisterCode\r\n	, pl.PaymentMethodId\r\n	, cari.CurrAccDesc\r\n	, cari.PhoneNum\r\n	, CashRegisterDesc = kassa.CurrAccDesc\r\n	, DcPaymentTypes.PaymentTypeDesc\r\n	, CurrAccBalance = dbo.CurrAccBalance(ph.CurrAccCode, CAST(ph.DocumentDate as Datetime) + CAST(ph.DocumentTime as Datetime))\r\n	\r\n	, StorePhoneNum = store.PhoneNum\r\n	, StoreAddress = store.Address\r\n\r\n	from TrPaymentLines pl \r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n	left join DcPaymentTypes on DcPaymentTypes.PaymentTypeCode = pl.PaymentTypeCode\r\n	left join DcCurrAccs cari on cari.CurrAccCode = ph.CurrAccCode\r\n	left join DcCurrAccs kassa on kassa.CurrAccCode = pl.CashRegisterCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = ph.ProcessCode\r\n	left join DcCurrAccs store on store.CurrAccCode = ph.StoreCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = pl.CurrencyCode\r\n\r\n	where ph.ProcessCode = 'PA' AND ph.PaymentHeaderId = @PaymentHeaderId\r\n	order by DocumentDate\r\n\r\n", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "DcShortcuts",
                columns: new[] { "Id", "ButtonDescription", "ButtonName", "FormName", "ShortcutKeys" },
                values: new object[,]
                {
                    { 1, "Məhsul Axtar", "btn_ProductSearch", "UcRetailSale", "F2" },
                    { 2, "Nağd Ödəmə", "btn_Cash", "UcRetailSale", "F3" },
                    { 3, "Nağdsız Ödəmə", "btn_Cashless", "UcRetailSale", "" },
                    { 4, "Bonus Ödəmə", "btn_CustomerBonus", "UcRetailSale", "" },
                    { 5, "Sətir Endirimi", "btn_LineDiscount", "UcRetailSale", "" },
                    { 6, "Çeki Ləğv Et", "btn_CancelInvoice", "UcRetailSale", "" },
                    { 7, "Sətri Sil", "btn_DeleteLine", "UcRetailSale", "" },
                    { 8, "Satıcı", "btn_SalesPerson", "UcRetailSale", "" },
                    { 9, "Qaimə Endirimi", "btn_InvoiceDiscount", "UcRetailSale", "" },
                    { 10, "Yeni Faktura", "btn_NewInvoice", "UcRetailSale", "" },
                    { 11, "Səbətə At", "btn_AddBasket", "UcRetailSale", "" },
                    { 12, "Natamam Fakturalar", "btn_UncomplatedInvoices", "UcRetailSale", "" },
                    { 13, "Bonus Kart", "btn_LoyaltyCard", "UcRetailSale", "" },
                    { 14, "Çap", "btn_Print", "UcRetailSale", "" },
                    { 15, "Çap Görünüş", "btn_PrintPreview", "UcRetailSale", "" },
                    { 16, "Gün Sonu", "btn_ReportZ", "UcRetailSale", "" },
                    { 17, "Kampaniya Tətbiq Et", "btn_CampaignApply", "UcRetailSale", "" },
                    { 18, "Kampaniyanı Sil", "btn_CampaignDelete", "UcRetailSale", "" },
                    { 19, "Kampaniya Log", "btn_CampaignLog", "UcRetailSale", "" },
                    { 20, "Promo Kod", "btn_PromoCode", "UcRetailSale", "" },
                    { 21, "Saxla", "bBI_Save", "FormInvoice", "" },
                    { 22, "Saxla və Yeni", "bBI_SaveAndNew", "FormInvoice", "" },
                    { 23, "Saxla və Bağla", "bBI_SaveAndQuit", "FormInvoice", "F12" },
                    { 24, "Ödəniş", "bBI_Payment", "FormInvoice", "" },
                    { 25, "Yeni", "bBI_New", "FormInvoice", "Ctrl+N" },
                    { 26, "Çap Görünüşü", "bBI_reportPreview", "FormInvoice", "" },
                    { 27, "Fakturanı Sil", "bBI_DeleteInvoice", "FormInvoice", "" },
                    { 28, "Ödənişi Sil", "bBI_PaymentDelete", "FormInvoice", "" },
                    { 29, "Fakturanı Kopyala", "bBI_CopyInvoice", "FormInvoice", "" },
                    { 30, "WhatsApp Göndər", "bBI_Whatsapp", "FormInvoice", "" },
                    { 31, "Fakturanı Dəyiş", "BBI_EditInvoice", "FormInvoice", "" },
                    { 32, "Excelə İxrac", "BBI_exportXLSX", "FormInvoice", "" },
                    { 33, "Exceldən Al", "BBI_ImportExcel", "FormInvoice", "" },
                    { 34, "Sürətli Çap", "BBI_ReportPrintFast", "FormInvoice", "" },
                    { 35, "Faktura Endirimi", "BBI_InvoiceDiscount", "FormInvoice", "" },
                    { 36, "Satıcı", "BBI_Salesman", "FormInvoice", "" },
                    { 37, "Eyni Məhsulları Birləşdir", "BBI_SumSameProducts", "FormInvoice", "" },
                    { 38, "Bonus Kart", "BBI_LoyaltyCardInput", "FormInvoice", "" },
                    { 39, "Kampaniya Tətbiq Et", "bBI_CampaignApply", "FormInvoice", "" },
                    { 40, "Kampaniya Log", "bBI_CampaignLog", "FormInvoice", "" },
                    { 41, "Promo Kod", "BBI_PromoCodeCampaign", "FormInvoice", "" },
                    { 42, "Kampaniyanı Sil", "bBI_CampaignDelete", "FormInvoice", "" },
                    { 43, "Şəkillər", "BBI_picture", "FormInvoice", "" },
                    { 44, "Xərclər", "BBI_InvoiceExpenses", "FormInvoice", "" },
                    { 45, "Stok Sayım", "BBI_CountingStock", "FormInvoice", "" }
                });

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 1,
                columns: new[] { "CashRegisterCode", "PrinterName", "StoreCode" },
                values: new object[] { "KASSA01", null, "MGZ01" });

            migrationBuilder.UpdateData(
                table: "DcTerminals",
                keyColumn: "TerminalId",
                keyValue: 2,
                columns: new[] { "CashRegisterCode", "PrinterName", "StoreCode" },
                values: new object[] { "KASSA01", null, "MGZ01" });

            migrationBuilder.InsertData(
                table: "DcUILanguages",
                columns: new[] { "LanguageCode", "LanguageDesc" },
                values: new object[,]
                {
                    { "az", "Azərbaycanca" },
                    { "en", "English" },
                    { "ru", "Русский" },
                    { "tr", "Türkçe" }
                });

            migrationBuilder.InsertData(
                table: "DcUnitOfMeasures",
                columns: new[] { "UnitOfMeasureId", "ConversionRate", "IsBasic", "IsDisabled", "Level", "ParentUnitOfMeasureId", "UnitOfMeasureDesc" },
                values: new object[,]
                {
                    { 1, 1m, false, false, (byte)0, null, "ədəd" },
                    { 2, 1m, false, false, (byte)0, null, "kq" },
                    { 3, 1m, false, false, (byte)0, null, "metr" },
                    { 4, 1m, false, false, (byte)0, null, "litr" }
                });

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[,]
                {
                    { "CN", null, "Sayım" },
                    { "CP", null, "Kampaniya" },
                    { "EI", null, "Xərclər" },
                    { "IS", null, "Taksit Satışı" },
                    { "RPO", null, "Pərakəndə Alış Sifarişi" },
                    { "RSO", null, "Pərakəndə Satış Sifarişi" },
                    { "SBO", null, "Toptan Alış Sifarişi" },
                    { "WI", null, "Təhvil Alma" },
                    { "WO", null, "Təhvil Vermə" },
                    { "WSO", null, "Topdan Satış Sifarişi" }
                });

            migrationBuilder.InsertData(
                table: "DcWhatsAppProviderSettings",
                columns: new[] { "Id", "ApiKey", "InstanceName", "ServerUrl" },
                values: new object[] { 1, "2fdqo0JtF6dnG23N7JbnZ9wMoVMRvRkh", "tokla", "https://evolution.tokla.az" });

            migrationBuilder.UpdateData(
                table: "SettingStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DefaultUnitOfMeasureId", "SalesmanContinuity" },
                values: new object[] { 1, false });

            migrationBuilder.InsertData(
                table: "TrClaimReports",
                columns: new[] { "ClaimReportId", "ClaimCode", "ReportId" },
                values: new object[,]
                {
                    { 1, "ButunHesabatlar", 1 },
                    { 2, "ButunHesabatlar", 2 },
                    { 3, "ButunHesabatlar", 3 },
                    { 4, "ButunHesabatlar", 4 },
                    { 5, "ButunHesabatlar", 5 },
                    { 11, "ButunHesabatlar", 11 },
                    { 12, "ButunHesabatlar", 12 },
                    { 13, "ButunHesabatlar", 13 },
                    { 14, "ButunHesabatlar", 14 },
                    { 15, "ButunHesabatlar", 15 },
                    { 16, "ButunHesabatlar", 16 },
                    { 17, "ButunHesabatlar", 17 },
                    { 18, "ButunHesabatlar", 18 }
                });

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 4,
                column: "ClaimCode",
                value: "Column_ProductCost");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 8,
                column: "ClaimCode",
                value: "ProductDiscountList");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 11,
                column: "ClaimCode",
                value: "LoyaltyCards");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 16,
                column: "ClaimCode",
                value: "RetailPurchaseInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 17,
                column: "ClaimCode",
                value: "RetailSaleInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 18,
                column: "ClaimCode",
                value: "WholesaleInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 19,
                column: "ClaimCode",
                value: "RetailPurchaseReturn");

            migrationBuilder.InsertData(
                table: "dcReportVariableTypes",
                columns: new[] { "VariableTypeId", "VariableTypeDesc" },
                values: new object[,]
                {
                    { (byte)1, "Parameter" },
                    { (byte)2, "Filter" }
                });

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "AllowPaymentDifference", 2, "Faktura ilə ödəniş arasında fərqə icazə", (byte)1 },
                    { "BarcodeOperations", 18, "Barkod Əməliyatları", (byte)1 },
                    { "CampaignList", 18, "Endirim Kampaniyası Siyahısı", (byte)1 },
                    { "ChangeExchangeRate", 2, "Məzənnə Kursu Dəyişmə", (byte)1 },
                    { "ChangePriceCI", 10, "Sayım Artırma Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceCN", 10, "Sayım Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceCO", 10, "Sayım Azaltma Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceEX", 9, "Xərc Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceIP", 7, "Taksit Alış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceIS", 8, "Taksit Alış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceRP", 3, "Pərakəndə Alış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceRS", 5, "Pərakəndə Satış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceWP", 4, "Topdan Alış Qiymət Dəyişmə", (byte)1 },
                    { "ChangePriceWS", 6, "Topdan Satış Qiymət Dəyişmə", (byte)1 },
                    { "Column_ProductCost", 18, "Maya Dəyəri", (byte)1 },
                    { "Count", 10, "Sayım", (byte)1 },
                    { "CreditList", 15, "Kredit Əməliyyatları", (byte)1 },
                    { "CurrAccClaim", 15, "Cari hesab yetkisi", (byte)1 },
                    { "CurrAccCreditLimit", 19, "Cari Hesab Taksit Limiti", (byte)1 },
                    { "CurrAccFeatureType", 19, "Cari Hesab Özəlliyi", (byte)1 },
                    { "CurrAccsDisabled", 19, "Qeyri-Aktiv Cari Hesablar", (byte)1 },
                    { "CurrencyList", 15, "Valyuta Siyahısı", (byte)1 },
                    { "DeleteInvoiceCI", 10, "Sayım Artırma Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceCN", 10, "Sayım Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceCO", 10, "Sayım Azaltma Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceEX", 9, "Xərc Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceIP", 7, "Taksit Alış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceIPO", 7, "Taksit Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceIS", 8, "Taksit Satış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceISO", 8, "Taksit Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceIT", 14, "Transfer Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceRP", 3, "Pərakəndə Alış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceRPO", 3, "Pərakəndə Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceRS", 5, "Pərakəndə Satış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceRSO", 5, "Pərakəndə Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceWP", 4, "Topdan Alış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceWPO", 4, "Topdan Alış Sifarişi Silmə", (byte)1 },
                    { "DeleteInvoiceWS", 6, "Topdan Satış Fakturası Silmə", (byte)1 },
                    { "DeleteInvoiceWSO", 6, "Topdan Satış Sifarişi Silmə", (byte)1 },
                    { "DeleteLineCI", 10, "Sayım Artırma Sətiri Silmə", (byte)1 },
                    { "DeleteLineCN", 10, "Sayım Sətiri Silmə", (byte)1 },
                    { "DeleteLineCO", 10, "Sayım Azaltma Sətiri Silmə", (byte)1 },
                    { "DeleteLineEX", 9, "Xərc Sətiri Silmə", (byte)1 },
                    { "DeleteLineIP", 7, "Taksit Alış Sətiri Silmə", (byte)1 },
                    { "DeleteLineIPO", 7, "Taksit Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineIS", 8, "Taksit Satış Sətiri Silmə", (byte)1 },
                    { "DeleteLineISO", 8, "Taksit Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineIT", 14, "Məhsul Transfer Sətiri Silmə", (byte)1 },
                    { "DeleteLineRP", 3, "Pərakəndə Alış Fakturası Sətiri Silmə", (byte)1 },
                    { "DeleteLineRPO", 3, "Pərakəndə Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineRS", 5, "Pərakəndə Satış Sətiri Silmə", (byte)1 },
                    { "DeleteLineRSO", 5, "Pərakəndə Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineWP", 4, "Topdan Alış Fakturası Sətiri Silmə", (byte)1 },
                    { "DeleteLineWPO", 4, "Topdan Alış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeleteLineWS", 6, "Topdan Satış Sətiri Silmə", (byte)1 },
                    { "DeleteLineWSO", 6, "Topdan Satış Sifarişi Sətiri Silmə", (byte)1 },
                    { "DeletePayment", 21, "Ödənişi Silmək", (byte)1 },
                    { "EditLockedInvoice", 2, "Kilidli Fakturanı Dəyiş", (byte)1 },
                    { "EditLockedPayment", 21, "Kilidli Ödənişi Dəyiş", (byte)1 },
                    { "ExpenseOfInvoice", 2, "Faktura Xərci", (byte)1 },
                    { "InstallmentCommissionChange", 8, "Taksitin Kamissiyasını Dəyişmə", (byte)1 },
                    { "InstallmentPurchaseInvoice", 7, "Taksit Alışı", (byte)1 },
                    { "InstallmentPurchaseOrder", 7, "Taksit Alış Sifarişi", (byte)1 },
                    { "InstallmentPurchaseReturn", 7, "Taksit Alış Qaytarması", (byte)1 },
                    { "InstallmentPurchaseReturnCustom", 7, "Taksit Alış Xüsusi Geri Qaytarması", (byte)1 },
                    { "InstallmentSaleInvoice", 8, "Taksit Satışı", (byte)1 },
                    { "InstallmentSaleOrder", 8, "Taksit Satış Sifarişi", (byte)1 },
                    { "InstallmentSaleReturn", 8, "Taksit Satış Qaytarması", (byte)1 },
                    { "InstallmentSaleReturnCustom", 8, "Taksit Satış Xüsusi Geri Qaytarması", (byte)1 },
                    { "InstallmentSales", 8, "Taksit Satışlar", (byte)1 },
                    { "InventoryTransferReturnCustom", 14, "Məhsul Transferi Xüsusi Qaytarması", (byte)1 },
                    { "LoyaltyCards", 19, "Bonus Kartlar", (byte)1 },
                    { "MakePayment", 21, "Ödəniş Etmək", (byte)1 },
                    { "NotificationSettings", 15, "Bildiriş Tənzimləmələri", (byte)1 },
                    { "Parameters", 15, "Parametrlər", (byte)1 },
                    { "PaymentMethodList", 15, "Ödəniş Üsulları Siyahısı", (byte)1 },
                    { "PaymentPlanList", 15, "Ödəniş Planları Siyahısı", (byte)1 },
                    { "PayrollList", 9, "Əməkhaqqı Siyahısı", (byte)1 },
                    { "PosNewInvoice", 2, "POS Yeni Faktura", (byte)1 },
                    { "ProductDiscountList", 18, "Endirim Siyahısı", (byte)1 },
                    { "ProductFeatureType", 18, "Məhsul Özəllik Tipləri", (byte)1 },
                    { "ProductsDisabled", 18, "Qeyri-Aktiv Məhsullar", (byte)1 },
                    { "ReceivePayment", 21, "Ödəniş Qəbul Etmək", (byte)1 },
                    { "RetailPurchaseOrder", 3, "Pərakəndə Alış Sifarişi", (byte)1 },
                    { "RetailPurchaseReturn", 3, "Pərakəndə Alışın Qaytarılması", (byte)1 },
                    { "RetailPurchaseReturnCustom", 3, "Pərakəndə Alış Xüsusi Geri Qaytarması", (byte)1 },
                    { "RetailSaleOrder", 5, "Pərakəndə Satış Sifarişi", (byte)1 },
                    { "RetailSaleReturn", 5, "Pərakəndə Satışın Qaytarılması", (byte)1 },
                    { "RetailSaleReturnCustom", 5, "Pərakəndə Satış Xüsusi Geri Qaytarması", (byte)1 },
                    { "Session", 15, "Sessiya", (byte)1 },
                    { "StoreList", 22, "Mağaza Siyahısı", (byte)1 },
                    { "TerminalList", 22, "Terminal Siyahısı", (byte)1 },
                    { "TransferApproval", 14, "Transfer Təsdiqi", (byte)1 },
                    { "WarehouseList", 22, "Depoların Siyahısı", (byte)1 },
                    { "WaybillIn", 12, "Təhvil Alma", (byte)1 },
                    { "WaybillOut", 13, "Təhvil Vermə", (byte)1 },
                    { "WhatsAppMessageLog", 15, "WhatsApp Mesaj Jurnalı", (byte)1 },
                    { "WholePurchaseInvoice", 4, "Topdan Alış Fakturası", (byte)1 },
                    { "WholePurchaseOrder", 4, "Topdan Alış Sifarişi", (byte)1 },
                    { "WholePurchaseReturn", 4, "Topdan Alışın Qaytarılması", (byte)1 },
                    { "WholePurchaseReturnCustom", 4, "Topdan Alış Xüsusi Geri Qaytarması", (byte)1 },
                    { "WholesaleInvoice", 6, "Topdan Satış Fakturası", (byte)1 },
                    { "WholesaleOrder", 6, "Topdan Satış Sifarişi", (byte)1 },
                    { "WholesaleReturn", 6, "Topdan Satışın Qaytarılması", (byte)1 },
                    { "WholesaleReturnCustom", 6, "Topdan Satış Xüsusi Geri Qaytarması", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CashRegPaymentTypeCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "FatherName", "FirstName", "Gender", "IdentityNum", "IsDefault", "LanguageCode", "LastName", "MaritalStatus", "NewPassword", "OfficeCode", "PersonalTypeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "Theme", "VendorTypeCode" },
                values: new object[,]
                {
                    { "C-000006", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birbank", (byte)1, null, null, null, (byte)0, null, true, null, null, (byte)0, "", "ofs01", null, null, null, "MGZ01", null, null, null },
                    { "KASSA01", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nağd Kassa", (byte)5, null, null, null, (byte)0, null, true, null, null, (byte)0, "456", "ofs01", null, null, null, "MGZ01", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "BalanceWarningLevel", "CreatedDate", "DefaultUnitOfMeasureId", "HierarchyCode", "ImagePath", "ProductCode2", "ProductDesc", "ProductFeature", "ProductTypeCode", "PromotionCode", "PromotionCode2" },
                values: new object[,]
                {
                    { "01", null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, null, "Ümumi Xərc", null, (byte)2, null, null },
                    { "02", null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, null, "Yer Pulu", null, (byte)2, null, null }
                });

            migrationBuilder.InsertData(
                table: "DcReportVariables",
                columns: new[] { "VariableId", "ReportId", "Representative", "VariableOperator", "VariableProperty", "VariableTypeId", "VariableValue", "VariableValueType" },
                values: new object[,]
                {
                    { 1, 4, "@InvoiceHeaderId", "", "InvoiceHeaderId", (byte)1, "", "System.Guid" },
                    { 2, 13, "{CurrAccCode}", "=", "CurrAccCode", (byte)2, "c-0000001", "System.String" },
                    { 3, 17, "{StartDate}", "<=", "DocumentDate", (byte)2, "08.01.2030", "System.DateTime" },
                    { 4, 9, "@PaymentHeaderId", "", "PaymentHeaderId", (byte)1, "", "System.Guid" }
                });

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportCategoryId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[,]
                {
                    { 19, 3, null, "", "Məhsul Qalığı", "\r\n\r\nselect * From ProductBalanceSerialNumber\r\n\r\n", (byte)1 },
                    { 20, 1, null, "", "Alacaqlar", "\r\n\r\n\r\n\r\n--declare @EndDate date = dateadd(DAY, 1, getdate())\r\n--declare @EndTime time =  '00:00:00.000'\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, Amount = sum(isnull(Amount,0))\r\n, DcCurrAccs.CurrAccTypeCode\r\n, CurrAccTypeDesc\r\n	from \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n\r\n--	where 1=1\r\n--	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n	\r\n--	where 1=1 \r\n--	and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\njoin DcCurrAccTypes on DcCurrAccTypes.CurrAccTypeCode = DcCurrAccs.CurrAccTypeCode\r\nwhere 1 = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, DcCurrAccs.CurrAccTypeCode\r\n, CurrAccTypeDesc\r\n\r\nhaving   sum(Amount) < 0\r\norder by CurrAccDesc\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n", (byte)1 },
                    { 21, 2, null, "", "Verəcəklər", "\r\n\r\n\r\n--declare @EndDate date = dateadd(DAY, 1, getdate())\r\n--declare @EndTime time =  '00:00:00.000'\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, Amount = sum(Amount)\r\nfrom \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n\r\n--	where 1=1\r\n--	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n	\r\n--	where 1=1 \r\n--	and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\nwhere 1 = 1 \r\nand CurrAccTypeCode in (1,2,3)\r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n\r\nhaving   sum(Amount) > 0\r\n", (byte)1 },
                    { 22, 2, null, "", "Bonus Jurnalı", "\r\n\r\n\r\n\r\nSELECT\r\n      lt.LoyaltyTxnId\r\n    , lt.TxnType\r\n    , InvoiceDocumentNumber = ISNULL(ih.DocumentNumber, ph.DocumentNumber)\r\n    , NetAmountLoc = inv.NetAmountLoc\r\n    , PaymentLoc\r\n    , EarnAmount       = inv.NetAmountLoc * lp.EarnPercent / 100\r\n    , Amount\r\n    , lt.Note\r\n    , lt.InvoiceHeaderId\r\n    , lt.PaymentLineId\r\n    , lt.LoyaltyCardId\r\n    , lp.LoyaltyProgramId\r\n    , lp.EarnPercent\r\n\r\nFROM TrLoyaltyTxns lt\r\nJOIN DcLoyaltyCards lc\r\n    ON lc.LoyaltyCardId = lt.LoyaltyCardId\r\nJOIN DcLoyaltyPrograms lp\r\n    ON lp.LoyaltyProgramId = lc.LoyaltyProgramId\r\nLEFT JOIN TrInvoiceHeaders ih\r\n    ON ih.InvoiceHeaderId = lt.InvoiceHeaderId AND TxnType IN (1, 2)\r\nLEFT JOIN TrPaymentLines pl\r\n    ON pl.PaymentLineId = lt.PaymentLineId --and TxnType = 2\r\nLEFT JOIN TrPaymentHeaders ph\r\n    ON ph.PaymentHeaderId = pl.PaymentHeaderId\r\n\r\nOUTER APPLY\r\n(\r\n    SELECT SUM(il.NetAmountLoc) AS NetAmountLoc\r\n    FROM TrInvoiceLines il\r\n    WHERE il.InvoiceHeaderId = lt.InvoiceHeaderId AND TxnType IN (1, 2)\r\n) inv\r\n\r\n\r\n", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 20, "RetailSaleReturn", "Admin" },
                    { 21, "WholesaleReturn", "Admin" },
                    { 22, "ProductFeatureType", "Admin" },
                    { 23, "CurrAccFeatureType", "Admin" },
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
                    { 41, "RetailPurchaseReturnCustom", "Admin" },
                    { 42, "RetailsaleReturnCustom", "Admin" },
                    { 43, "WholesaleReturnCustom", "Admin" },
                    { 44, "InstallmentSaleReturnCustom", "Admin" },
                    { 45, "InstallmentSales", "Admin" },
                    { 46, "InstallmentCommissionChange", "Admin" },
                    { 47, "EditLockedInvoice", "Admin" },
                    { 48, "EditLockedPayment", "Admin" },
                    { 49, "CurrAccCreditLimit", "Admin" },
                    { 50, "Parameters", "Admin" },
                    { 51, "StoreList", "Admin" },
                    { 52, "StoreList", "Admin" },
                    { 53, "ChangePriceRP", "Admin" },
                    { 54, "ChangePriceWP", "Admin" },
                    { 55, "ChangePriceRS", "Admin" },
                    { 56, "ChangePriceWS", "Admin" },
                    { 57, "ChangePriceIP", "Admin" },
                    { 58, "ChangePriceIS", "Admin" },
                    { 59, "ChangePriceCI", "Admin" },
                    { 60, "ChangePriceCO", "Admin" },
                    { 61, "Count", "Admin" },
                    { 62, "MakePayment", "Admin" },
                    { 63, "ReceivePayment", "Admin" },
                    { 64, "DeletePayment", "Admin" },
                    { 65, "ChangeExchangeRate", "Admin" },
                    { 66, "CurrencyList", "Admin" },
                    { 67, "PaymentMethodList", "Admin" },
                    { 68, "PaymentPlanList", "Admin" },
                    { 69, "WhatsAppMessageLog", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_PaymentKindId",
                table: "TrPaymentHeaders",
                column: "PaymentKindId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_RelatedLineId",
                table: "TrInvoiceLines",
                column: "RelatedLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_SalesPersonCode",
                table: "TrInvoiceLines",
                column: "SalesPersonCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_SerialNumberCode",
                table: "TrInvoiceLines",
                column: "SerialNumberCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_LoyaltyCardId",
                table: "TrInvoiceHeaders",
                column: "LoyaltyCardId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_RelatedInvoiceId",
                table: "TrInvoiceHeaders",
                column: "RelatedInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_TerminalId",
                table: "TrInvoiceHeaders",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_DefaultUnitOfMeasureId",
                table: "SettingStores",
                column: "DefaultUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores",
                column: "StoreCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcWarehouses_StoreCode",
                table: "DcWarehouses",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcTerminals_CashRegisterCode",
                table: "DcTerminals",
                column: "CashRegisterCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcTerminals_StoreCode",
                table: "DcTerminals",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcReports_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_DefaultUnitOfMeasureId",
                table: "DcProducts",
                column: "DefaultUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentMethods_RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                column: "RedirectedCurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_LanguageCode",
                table: "DcCurrAccs",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_PersonalTypeCode",
                table: "DcCurrAccs",
                column: "PersonalTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_StoreCode",
                table: "DcCurrAccs",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcClaims_CategoryId",
                table: "DcClaims",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_DefaultUnitOfMeasureId",
                table: "AppSettings",
                column: "DefaultUnitOfMeasureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcCampaigns_CampaignCode",
                table: "DcCampaigns",
                column: "CampaignCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcCampaigns_IsActive_StartDate_EndDate",
                table: "DcCampaigns",
                columns: new[] { "IsActive", "StartDate", "EndDate" });

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
                name: "IX_DcDepartments_DepartmentCode",
                table: "DcDepartments",
                column: "DepartmentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcDepartments_ParentDepartmentId",
                table: "DcDepartments",
                column: "ParentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DcEmploymentTypes_TypeCode",
                table: "DcEmploymentTypes",
                column: "TypeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcLoyaltyCards_CardNumber",
                table: "DcLoyaltyCards",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcLoyaltyCards_CurrAccCode",
                table: "DcLoyaltyCards",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcLoyaltyCards_LoyaltyProgramId",
                table: "DcLoyaltyCards",
                column: "LoyaltyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_DcLoyaltyPrograms_Name",
                table: "DcLoyaltyPrograms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentPlans_PaymentMethodId",
                table: "DcPaymentPlans",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_DcPayrollPeriods_PeriodYear_PeriodMonth",
                table: "DcPayrollPeriods",
                columns: new[] { "PeriodYear", "PeriodMonth" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcPositions_DepartmentId",
                table: "DcPositions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DcPositions_PositionCode",
                table: "DcPositions",
                column: "PositionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcProductScales_ProductCode",
                table: "DcProductScales",
                column: "ProductCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcProductScales_ScaleProductNumber",
                table: "DcProductScales",
                column: "ScaleProductNumber",
                unique: true,
                filter: "[ScaleProductNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DcProductStaticPrices_PriceTypeCode",
                table: "DcProductStaticPrices",
                column: "PriceTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportVariables_ReportId",
                table: "DcReportVariables",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportVariables_VariableTypeId",
                table: "DcReportVariables",
                column: "VariableTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DcSerialNumbers_ProductCode",
                table: "DcSerialNumbers",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcShortcuts_FormName_ButtonName",
                table: "DcShortcuts",
                columns: new[] { "FormName", "ButtonName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcUnitOfMeasures_ParentUnitOfMeasureId",
                table: "DcUnitOfMeasures",
                column: "ParentUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLockAudits_DocumentType_DocumentId_ActionAtUtc",
                table: "DocumentLockAudits",
                columns: new[] { "DocumentType", "DocumentId", "ActionAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLocks_DocumentType_DocumentId",
                table: "DocumentLocks",
                columns: new[] { "DocumentType", "DocumentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentLocks_LastHeartbeatAtUtc",
                table: "DocumentLocks",
                column: "LastHeartbeatAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TrAttendances_CurrAccCode",
                table: "TrAttendances",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrBarcodeOperationLines_BarcodeOperationHeaderId",
                table: "TrBarcodeOperationLines",
                column: "BarcodeOperationHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrBarcodeOperationLines_BarcodeTypeCode",
                table: "TrBarcodeOperationLines",
                column: "BarcodeTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrBarcodeOperationLines_ProductCode",
                table: "TrBarcodeOperationLines",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignCategories_CampaignId_HierarchyCode",
                table: "TrCampaignCategories",
                columns: new[] { "CampaignId", "HierarchyCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignCategories_HierarchyCode",
                table: "TrCampaignCategories",
                column: "HierarchyCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignCustomers_CampaignId_CurrAccCode",
                table: "TrCampaignCustomers",
                columns: new[] { "CampaignId", "CurrAccCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignCustomers_CurrAccCode",
                table: "TrCampaignCustomers",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignProducts_CampaignId_ProductCode",
                table: "TrCampaignProducts",
                columns: new[] { "CampaignId", "ProductCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignProducts_ProductCode",
                table: "TrCampaignProducts",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignStores_CampaignId_StoreCode",
                table: "TrCampaignStores",
                columns: new[] { "CampaignId", "StoreCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignStores_DcStoreCurrAccCode",
                table: "TrCampaignStores",
                column: "DcStoreCurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignWarehouses_CampaignId_WarehouseCode",
                table: "TrCampaignWarehouses",
                columns: new[] { "CampaignId", "WarehouseCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignWarehouses_WarehouseCode",
                table: "TrCampaignWarehouses",
                column: "WarehouseCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrClaimReports_ClaimCode",
                table: "TrClaimReports",
                column: "ClaimCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrClaimReports_ReportId",
                table: "TrClaimReports",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCrmActivities_ActivityCode",
                table: "TrCrmActivities",
                column: "ActivityCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCrmActivities_ActivityTypeId",
                table: "TrCrmActivities",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCrmActivities_CurrAccCode_ActivityDate",
                table: "TrCrmActivities",
                columns: new[] { "CurrAccCode", "ActivityDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccFeatures_CurrAccFeatureCode_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                columns: new[] { "CurrAccFeatureCode", "CurrAccFeatureTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccFeatures_CurrAccFeatureTypeId",
                table: "TrCurrAccFeatures",
                column: "CurrAccFeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeeContracts_CurrAccCode",
                table: "TrEmployeeContracts",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeeContracts_EmploymentTypeId",
                table: "TrEmployeeContracts",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeePositions_CurrAccCode",
                table: "TrEmployeePositions",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrEmployeePositions_PositionId",
                table: "TrEmployeePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrHierarchyFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeatureTypes",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstallmentGuarantors_CurrAccCode",
                table: "TrInstallmentGuarantors",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstallmentGuarantors_InstallmentId",
                table: "TrInstallmentGuarantors",
                column: "InstallmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstallments_InstallmentPlanCode",
                table: "TrInstallments",
                column: "InstallmentPlanCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInstallments_InvoiceHeaderId",
                table: "TrInstallments",
                column: "InvoiceHeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceCampaignHeaders_InvoiceHeaderId",
                table: "TrInvoiceCampaignHeaders",
                column: "InvoiceHeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceCampaignLogs_CampaignId",
                table: "TrInvoiceCampaignLogs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceCampaignLogs_DcPaymentMethodPaymentMethodId",
                table: "TrInvoiceCampaignLogs",
                column: "DcPaymentMethodPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceCampaignLogs_InvoiceHeaderId",
                table: "TrInvoiceCampaignLogs",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceCampaignLogs_InvoiceLineId",
                table: "TrInvoiceCampaignLogs",
                column: "InvoiceLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_CurrAccCode",
                table: "TrLoyaltyTxns",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_InvoiceHeaderId",
                table: "TrLoyaltyTxns",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_LoyaltyCardId_DocumentDate",
                table: "TrLoyaltyTxns",
                columns: new[] { "LoyaltyCardId", "DocumentDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_PaymentLineId",
                table: "TrLoyaltyTxns",
                column: "PaymentLineId",
                unique: true,
                filter: "[PaymentLineId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrLoyaltyTxns_RelatedLoyaltyTxnId",
                table: "TrLoyaltyTxns",
                column: "RelatedLoyaltyTxnId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPayrollHeaders_CurrAccCode",
                table: "TrPayrollHeaders",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPayrollHeaders_PayrollPeriodId",
                table: "TrPayrollHeaders",
                column: "PayrollPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPayrollLines_PayrollHeaderId",
                table: "TrPayrollLines",
                column: "PayrollHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrProcessPriceTypes_PriceTypeCode",
                table: "TrProcessPriceTypes",
                column: "PriceTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProcessPriceTypes_ProcessCode_PriceTypeCode",
                table: "TrProcessPriceTypes",
                columns: new[] { "ProcessCode", "PriceTypeCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrReportCustomizations_CurrAccCode",
                table: "TrReportCustomizations",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportCustomizations_ReportId",
                table: "TrReportCustomizations",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportSubQueries_ReportId",
                table: "TrReportSubQueries",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportSubQueryRelationColumns_SubQueryId",
                table: "TrReportSubQueryRelationColumns",
                column: "SubQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrSessions_CurrAccCode",
                table: "TrSessions",
                column: "CurrAccCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrWhatsAppMessageLogs_CurrAccCode",
                table: "TrWhatsAppMessageLogs",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrWhatsAppMessageLogs_Sender",
                table: "TrWhatsAppMessageLogs",
                column: "Sender");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSettings_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "AppSettings",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcClaims_DcClaimCategories_CategoryId",
                table: "DcClaims",
                column: "CategoryId",
                principalTable: "DcClaimCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_DcCurrAccs_StoreCode",
                table: "DcCurrAccs",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_DcPersonalTypes_PersonalTypeCode",
                table: "DcCurrAccs",
                column: "PersonalTypeCode",
                principalTable: "DcPersonalTypes",
                principalColumn: "PersonalTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAccs_DcUILanguages_LanguageCode",
                table: "DcCurrAccs",
                column: "LanguageCode",
                principalTable: "DcUILanguages",
                principalColumn: "LanguageCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_RedirectedCurrAccCode",
                table: "DcPaymentMethods",
                column: "RedirectedCurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "DcProducts",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcReports_DcReportCategories_ReportCategoryId",
                table: "DcReports",
                column: "ReportCategoryId",
                principalTable: "DcReportCategories",
                principalColumn: "ReportCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcTerminals_DcCurrAccs_CashRegisterCode",
                table: "DcTerminals",
                column: "CashRegisterCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcTerminals_DcCurrAccs_StoreCode",
                table: "DcTerminals",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcWarehouses_DcCurrAccs_StoreCode",
                table: "DcWarehouses",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "SettingStores",
                column: "DefaultUnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                table: "TrCurrAccRoles",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_DcLoyaltyCards_LoyaltyCardId",
                table: "TrInvoiceHeaders",
                column: "LoyaltyCardId",
                principalTable: "DcLoyaltyCards",
                principalColumn: "LoyaltyCardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_DcTerminals_TerminalId",
                table: "TrInvoiceHeaders",
                column: "TerminalId",
                principalTable: "DcTerminals",
                principalColumn: "TerminalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_TrInvoiceHeaders_RelatedInvoiceId",
                table: "TrInvoiceHeaders",
                column: "RelatedInvoiceId",
                principalTable: "TrInvoiceHeaders",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLineExts_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceLineExts",
                column: "InvoiceLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcCurrAccs_SalesPersonCode",
                table: "TrInvoiceLines",
                column: "SalesPersonCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcSerialNumbers_SerialNumberCode",
                table: "TrInvoiceLines",
                column: "SerialNumberCode",
                principalTable: "DcSerialNumbers",
                principalColumn: "SerialNumberCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrInvoiceLines",
                column: "UnitOfMeasureId",
                principalTable: "DcUnitOfMeasures",
                principalColumn: "UnitOfMeasureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceLines_RelatedLineId",
                table: "TrInvoiceLines",
                column: "RelatedLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                table: "TrPaymentHeaders",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders",
                column: "ToCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKindId",
                table: "TrPaymentHeaders",
                column: "PaymentKindId",
                principalTable: "DcPaymentKinds",
                principalColumn: "PaymentKindId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeTypes_BarcodeTypeCode",
                table: "TrProductBarcodes",
                column: "BarcodeTypeCode",
                principalTable: "DcBarcodeTypes",
                principalColumn: "BarcodeTypeCode",
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
                name: "FK_AppSettings_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "AppSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_DcClaims_DcClaimCategories_CategoryId",
                table: "DcClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_DcCurrAccs_StoreCode",
                table: "DcCurrAccs");

            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_DcPersonalTypes_PersonalTypeCode",
                table: "DcCurrAccs");

            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAccs_DcUILanguages_LanguageCode",
                table: "DcCurrAccs");

            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentMethods_DcCurrAccs_RedirectedCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "DcProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DcReports_DcReportCategories_ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DcTerminals_DcCurrAccs_CashRegisterCode",
                table: "DcTerminals");

            migrationBuilder.DropForeignKey(
                name: "FK_DcTerminals_DcCurrAccs_StoreCode",
                table: "DcTerminals");

            migrationBuilder.DropForeignKey(
                name: "FK_DcWarehouses_DcCurrAccs_StoreCode",
                table: "DcWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores");

            migrationBuilder.DropForeignKey(
                name: "FK_SettingStores_DcUnitOfMeasures_DefaultUnitOfMeasureId",
                table: "SettingStores");

            migrationBuilder.DropForeignKey(
                name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                table: "TrCurrAccRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_DcLoyaltyCards_LoyaltyCardId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_DcTerminals_TerminalId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_TrInvoiceHeaders_RelatedInvoiceId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLineExts_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceLineExts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcCurrAccs_SalesPersonCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcSerialNumbers_SerialNumberCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcUnitOfMeasures_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_TrInvoiceLines_RelatedLineId",
                table: "TrInvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcPaymentKinds_PaymentKindId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeTypes_BarcodeTypeCode",
                table: "TrProductBarcodes");

            migrationBuilder.DropForeignKey(
                name: "FK_TrRoleClaims_DcRoles_RoleCode",
                table: "TrRoleClaims");

            migrationBuilder.DropTable(
                name: "DcClaimCategories");

            migrationBuilder.DropTable(
                name: "DcCurrAccContactDetails");

            migrationBuilder.DropTable(
                name: "DcNotificationSettings");

            migrationBuilder.DropTable(
                name: "DcPaymentKinds");

            migrationBuilder.DropTable(
                name: "DcPaymentPlans");

            migrationBuilder.DropTable(
                name: "DcPersonalTypes");

            migrationBuilder.DropTable(
                name: "DcProductScales");

            migrationBuilder.DropTable(
                name: "DcProductStaticPrices");

            migrationBuilder.DropTable(
                name: "DcReportCategories");

            migrationBuilder.DropTable(
                name: "DcReportVariables");

            migrationBuilder.DropTable(
                name: "DcSerialNumbers");

            migrationBuilder.DropTable(
                name: "DcShortcuts");

            migrationBuilder.DropTable(
                name: "DcUILanguages");

            migrationBuilder.DropTable(
                name: "DcUnitOfMeasures");

            migrationBuilder.DropTable(
                name: "DcWhatsAppProviderSettings");

            migrationBuilder.DropTable(
                name: "DocumentLockAudits");

            migrationBuilder.DropTable(
                name: "DocumentLocks");

            migrationBuilder.DropTable(
                name: "TrAttendances");

            migrationBuilder.DropTable(
                name: "TrBarcodeOperationLines");

            migrationBuilder.DropTable(
                name: "TrCampaignCategories");

            migrationBuilder.DropTable(
                name: "TrCampaignCustomers");

            migrationBuilder.DropTable(
                name: "TrCampaignProducts");

            migrationBuilder.DropTable(
                name: "TrCampaignStores");

            migrationBuilder.DropTable(
                name: "TrCampaignWarehouses");

            migrationBuilder.DropTable(
                name: "TrClaimReports");

            migrationBuilder.DropTable(
                name: "TrCredits");

            migrationBuilder.DropTable(
                name: "TrCrmActivities");

            migrationBuilder.DropTable(
                name: "TrCurrAccFeatures");

            migrationBuilder.DropTable(
                name: "TrEmployeeContracts");

            migrationBuilder.DropTable(
                name: "TrEmployeePositions");

            migrationBuilder.DropTable(
                name: "TrHierarchyFeatureTypes");

            migrationBuilder.DropTable(
                name: "TrInstallmentGuarantors");

            migrationBuilder.DropTable(
                name: "TrInvoiceCampaignHeaders");

            migrationBuilder.DropTable(
                name: "TrInvoiceCampaignLogs");

            migrationBuilder.DropTable(
                name: "TrLoyaltyTxns");

            migrationBuilder.DropTable(
                name: "TrPayrollLines");

            migrationBuilder.DropTable(
                name: "TrProcessPriceTypes");

            migrationBuilder.DropTable(
                name: "TrReportCustomizations");

            migrationBuilder.DropTable(
                name: "TrReportSubQueryRelationColumns");

            migrationBuilder.DropTable(
                name: "TrSessions");

            migrationBuilder.DropTable(
                name: "TrWhatsAppMessageLogs");

            migrationBuilder.DropTable(
                name: "DcContactType");

            migrationBuilder.DropTable(
                name: "dcReportVariableTypes");

            migrationBuilder.DropTable(
                name: "TrBarcodeOperationHeaders");

            migrationBuilder.DropTable(
                name: "DcCrmActivityTypes");

            migrationBuilder.DropTable(
                name: "DcCurrAccFeatures");

            migrationBuilder.DropTable(
                name: "DcEmploymentTypes");

            migrationBuilder.DropTable(
                name: "DcPositions");

            migrationBuilder.DropTable(
                name: "TrInstallments");

            migrationBuilder.DropTable(
                name: "DcCampaigns");

            migrationBuilder.DropTable(
                name: "DcLoyaltyCards");

            migrationBuilder.DropTable(
                name: "TrPayrollHeaders");

            migrationBuilder.DropTable(
                name: "TrReportSubQueries");

            migrationBuilder.DropTable(
                name: "DcCurrAccFeatureTypes");

            migrationBuilder.DropTable(
                name: "DcDepartments");

            migrationBuilder.DropTable(
                name: "DcInstallmentPlan");

            migrationBuilder.DropTable(
                name: "DcLoyaltyPrograms");

            migrationBuilder.DropTable(
                name: "DcPayrollPeriods");

            migrationBuilder.DropIndex(
                name: "IX_TrPaymentHeaders_PaymentKindId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_RelatedLineId",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_SalesPersonCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_SerialNumberCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLines_UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_LoyaltyCardId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_RelatedInvoiceId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeaders_TerminalId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_DefaultUnitOfMeasureId",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores");

            migrationBuilder.DropIndex(
                name: "IX_DcWarehouses_StoreCode",
                table: "DcWarehouses");

            migrationBuilder.DropIndex(
                name: "IX_DcTerminals_CashRegisterCode",
                table: "DcTerminals");

            migrationBuilder.DropIndex(
                name: "IX_DcTerminals_StoreCode",
                table: "DcTerminals");

            migrationBuilder.DropIndex(
                name: "IX_DcReports_ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropIndex(
                name: "IX_DcProducts_DefaultUnitOfMeasureId",
                table: "DcProducts");

            migrationBuilder.DropIndex(
                name: "IX_DcPaymentMethods_RedirectedCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAccs_LanguageCode",
                table: "DcCurrAccs");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAccs_PersonalTypeCode",
                table: "DcCurrAccs");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAccs_StoreCode",
                table: "DcCurrAccs");

            migrationBuilder.DropIndex(
                name: "IX_DcClaims_CategoryId",
                table: "DcClaims");

            migrationBuilder.DropIndex(
                name: "IX_AppSettings_DefaultUnitOfMeasureId",
                table: "AppSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrInvoiceLineExts",
                table: "TrInvoiceLineExts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcBarcodeTypes",
                table: "DcBarcodeTypes");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "AllowPaymentDifference");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "BarcodeOperations");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CampaignList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceCN");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceEX");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Column_ProductCost");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CreditList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccsDisabled");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceCI");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "DeleteInvoiceCN");

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
                keyValue: "DeleteLineCN");

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
                keyValue: "InstallmentSaleOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InventoryTransferReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "LoyaltyCards");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "NotificationSettings");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PayrollList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PosNewInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductDiscountList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductsDisabled");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleOrder");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "TerminalList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "TransferApproval");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WarehouseList");

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
                keyValue: "WholesaleInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleOrder");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000006");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "KASSA01");

            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "CashRegisters");

            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "ERP");

            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "InstallmentSale");

            migrationBuilder.DeleteData(
                table: "DcForms",
                keyColumn: "FormCode",
                keyValue: "PaymentDetails");

            migrationBuilder.DeleteData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "DcPriceTypes",
                keyColumn: "PriceTypeCode",
                keyValue: "STD");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CN");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "EI");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "IS");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "RPO");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "RSO");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "SBO");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "WI");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "WO");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "WSO");

            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "01");

            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "02");

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CN");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CP");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "EI");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "IS");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "RPO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "RSO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "SBO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "WI");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "WO");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "WSO");

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
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangeExchangeRate");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceCI");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceCO");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceIP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceIS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceRP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceRS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceWP");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ChangePriceWS");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Count");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccClaim");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccCreditLimit");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrAccFeatureType");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "CurrencyList");

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
                keyValue: "DeletePayment");

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
                keyValue: "ExpenseOfInvoice");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentCommissionChange");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "InstallmentSaleInvoice");

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
                keyValue: "InstallmentSales");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "MakePayment");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Parameters");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PaymentMethodList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "PaymentPlanList");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductFeatureType");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ReceivePayment");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseReturnCustom");

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
                keyValue: "StoreList");

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
                keyValue: "WhatsAppMessageLog");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleReturnCustom");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "MGZ01");

            migrationBuilder.DropColumn(
                name: "PaymentKindId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "TrPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "SerialNumberCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "WorkerCode",
                table: "TrInvoiceLines");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "LoyaltyCardId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "TransferApprovalStatus",
                table: "TrInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "UseInSite",
                table: "SiteProducts");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasureId",
                table: "SettingStores");

            migrationBuilder.DropColumn(
                name: "SalesmanContinuity",
                table: "SettingStores");

            migrationBuilder.DropColumn(
                name: "CashRegisterCode",
                table: "DcTerminals");

            migrationBuilder.DropColumn(
                name: "PrinterName",
                table: "DcTerminals");

            migrationBuilder.DropColumn(
                name: "StoreCode",
                table: "DcTerminals");

            migrationBuilder.DropColumn(
                name: "ReportCategoryId",
                table: "DcReports");

            migrationBuilder.DropColumn(
                name: "BalanceWarningLevel",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasureId",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "DcPaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "DcPaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsRedirected",
                table: "DcPaymentMethods");

            migrationBuilder.DropColumn(
                name: "RedirectedCurrAccCode",
                table: "DcPaymentMethods");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "PersonalTypeCode",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DcClaims");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DcClaims");

            migrationBuilder.DropColumn(
                name: "AutoPrint",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "AutoSave",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "DefaultUnitOfMeasureId",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "InvoiceEditGraceDays",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "LockReturnDocument",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "NotifyBalanceWarningLevel",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "OverpaymentMode",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "POSMergeSameProducts",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "POSShowQuantityDialog",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "POSShowSalesmanCodeDialog",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "PaymentEditGraceDays",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "TransferAutoApprove",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "UseBarcode",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "UseCampaign",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "UsePriceList",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "WhatsAppProvider",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "LineExpences",
                table: "TrInvoiceLineExts");

            migrationBuilder.DropColumn(
                name: "PriceDiscountedLoc",
                table: "TrInvoiceLineExts");

            migrationBuilder.DropColumn(
                name: "DefaultBarcodeType",
                table: "DcBarcodeTypes");

            migrationBuilder.RenameTable(
                name: "TrInvoiceLineExts",
                newName: "trInvoiceLineExt");

            migrationBuilder.RenameTable(
                name: "DcBarcodeTypes",
                newName: "DcBarcodeType");

            migrationBuilder.RenameColumn(
                name: "ProductCost",
                table: "TrInvoiceLines",
                newName: "LastPurchasePrice");

            migrationBuilder.RenameColumn(
                name: "WhatsappChromeProfileName",
                table: "AppSettings",
                newName: "TwilioToken");

            migrationBuilder.RenameColumn(
                name: "UseScales",
                table: "AppSettings",
                newName: "GetPrint");

            migrationBuilder.RenameColumn(
                name: "PrintCount",
                table: "AppSettings",
                newName: "PrinterCopyNum");

            migrationBuilder.RenameColumn(
                name: "POSFindProductBy",
                table: "AppSettings",
                newName: "TwilioInstanceId");

            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceLineExts_InvoiceLineId",
                table: "trInvoiceLineExt",
                newName: "IX_trInvoiceLineExt_InvoiceLineId");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureCode",
                table: "TrProductFeatures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<int>(
                name: "FeatureTypeId",
                table: "TrProductFeatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrProductFeatures",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "TrProductDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrProductDiscounts",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "TrProductBarcodes",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 1m);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrProductBarcodes",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrPriceListLines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPriceListLines",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrPriceListHeaders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "TrPaymentMethodDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountId",
                table: "TrPaymentMethodDiscounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "CashRegisterCode",
                table: "TrPaymentLines",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyCode",
                table: "TrPaymentHeaders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AddColumn<short>(
                name: "PosterminalId",
                table: "TrPaymentHeaders",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<string>(
                name: "SalesPersonCode",
                table: "TrInvoiceLines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QtyOut",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<int>(
                name: "QtyIn",
                table: "TrInvoiceLines",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceLoc",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrInvoiceLines",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "PosTerminalId",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportId",
                table: "TrFormReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "FormCode",
                table: "TrFormReports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "RoleCode",
                table: "TrCurrAccRoles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrCurrAccRoles",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "SettingStores",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "PrinterName",
                table: "SettingStores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "DcWarehouses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureTypeId",
                table: "DcFeatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "FeatureCode",
                table: "DcFeatures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RowGuid",
                table: "DcCurrAccTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RowGuid",
                table: "DcCurrAccs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "DcCurrAccs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<byte>(
                name: "CompanyCode",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataLanguageCode",
                table: "DcCurrAccs",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrinterName",
                table: "AppSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_trInvoiceLineExt",
                table: "trInvoiceLineExt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcBarcodeType",
                table: "DcBarcodeType",
                column: "BarcodeTypeCode");

            migrationBuilder.CreateTable(
                name: "DcReportFilters",
                columns: table => new
                {
                    FilterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    FilterOperatorType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilterProperty = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilterValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Representative = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportFilters", x => x.FilterId);
                    table.ForeignKey(
                        name: "FK_DcReportFilters_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcReportSubQueries",
                columns: table => new
                {
                    SubQueryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    SubQueryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubQueryText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportSubQueries", x => x.SubQueryId);
                    table.ForeignKey(
                        name: "FK_DcReportSubQueries_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sysdiagrams",
                columns: table => new
                {
                    diagram_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    definition = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    principal_id = table.Column<int>(type: "int", nullable: false),
                    version = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.sysdiagrams", x => x.diagram_id);
                });

            migrationBuilder.CreateTable(
                name: "TrClaimReport",
                columns: table => new
                {
                    ClaimReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrClaimReport", x => x.ClaimReportId);
                    table.ForeignKey(
                        name: "FK_TrClaimReport_DcClaims_ClaimCode",
                        column: x => x.ClaimCode,
                        principalTable: "DcClaims",
                        principalColumn: "ClaimCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrClaimReport_DcReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "DcReports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrHierarchyFeatures",
                columns: table => new
                {
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrHierarchyFeatures", x => new { x.HierarchyCode, x.FeatureTypeId });
                    table.ForeignKey(
                        name: "FK_TrHierarchyFeatures_DcFeatureTypes_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "DcFeatureTypes",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrHierarchyFeatures_DcHierarchies_HierarchyCode",
                        column: x => x.HierarchyCode,
                        principalTable: "DcHierarchies",
                        principalColumn: "HierarchyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPrices",
                columns: table => new
                {
                    PriceCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPrices", x => x.PriceCode);
                    table.ForeignKey(
                        name: "FK_TrPrices_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrProductHierarchies",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProductHierarchies", x => new { x.ProductCode, x.HierarchyCode });
                    table.ForeignKey(
                        name: "FK_TrProductHierarchies_DcHierarchies_HierarchyCode",
                        column: x => x.HierarchyCode,
                        principalTable: "DcHierarchies",
                        principalColumn: "HierarchyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductHierarchies_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcQueryParams",
                columns: table => new
                {
                    ParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DcReportSubQuerySubQueryId = table.Column<int>(type: "int", nullable: true),
                    ColumnName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentColumnName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QueryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcQueryParams", x => x.ParameterId);
                    table.ForeignKey(
                        name: "FK_DcQueryParams_DcReportSubQueries_DcReportSubQuerySubQueryId",
                        column: x => x.DcReportSubQuerySubQueryId,
                        principalTable: "DcReportSubQueries",
                        principalColumn: "SubQueryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrinterName",
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
                keyValue: "RetailPurchaseInvoice",
                column: "ClaimDesc",
                value: "Alış Fakturası");

            migrationBuilder.UpdateData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleInvoice",
                column: "ClaimDesc",
                value: "Satış Fakturası");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "Column_LastPurchasePrice", "Son Alış Qiyməti", (byte)1 },
                    { "DiscountList", "Endirim Siyahısı", (byte)1 },
                    { "PaymentDetail", "Ödəmə", (byte)1 },
                    { "PurchaseIsReturn", "Alışın Qaytarılması", (byte)1 },
                    { "ReportZet", "Gün Sonu Hesabatı", (byte)1 },
                    { "SaleIsReturn", "Satışın Qaytarılması", (byte)1 }
                });

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)1,
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)2,
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)3,
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)4,
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)5,
                column: "RowGuid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000001",
                columns: new[] { "CompanyCode", "DataLanguageCode", "RowGuid" },
                values: new object[] { (byte)0, null, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000002",
                columns: new[] { "CompanyCode", "DataLanguageCode", "PhoneNum", "RowGuid" },
                values: new object[] { (byte)0, null, "0519678909", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000003",
                columns: new[] { "CompanyCode", "DataLanguageCode", "PhoneNum", "RowGuid" },
                values: new object[] { (byte)0, null, "0773628800", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000004",
                columns: new[] { "CompanyCode", "DataLanguageCode", "PhoneNum", "RowGuid" },
                values: new object[] { (byte)0, null, "0553628804", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000005",
                columns: new[] { "CompanyCode", "DataLanguageCode", "RowGuid", "StoreCode" },
                values: new object[] { (byte)0, null, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01" });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CashRegPaymentTypeCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "DataLanguageCode", "FatherName", "FirstName", "IdentityNum", "IsDefault", "LastName", "NewPassword", "OfficeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "Theme", "VendorTypeCode" },
                values: new object[,]
                {
                    { "kassa01", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nağd Kassa", (byte)5, null, null, null, null, null, true, null, "456", "ofs01", null, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "mgz01", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Merkez Mağaza", (byte)4, null, null, null, null, null, false, null, "456", "ofs01", "0773628800", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null }
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
                keyValue: 2,
                columns: new[] { "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { "Çatdırılma zamanı nağd ödə", (byte)1 });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                columns: new[] { "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[] { "Saytda nağd ödə", (byte)2 });

            migrationBuilder.UpdateData(
                table: "DcPaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "PaymentMethodDesc",
                value: "Bir Kart");

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "CreatedDate", "HierarchyCode", "ImagePath", "ProductCode2", "ProductDesc", "ProductFeature", "ProductTypeCode", "PromotionCode", "PromotionCode2" },
                values: new object[,]
                {
                    { "xerc01", new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Yol Xərci", null, (byte)2, null, null },
                    { "xerc02", new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "İşıq Pulu", null, (byte)2, null, null }
                });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 1,
                column: "ReportQuery",
                value: "\r\n--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n--declare @StartTime time =  '00:00:00.000'\r\n\r\n\r\nselect DcProducts.ProductCode\r\n		, [Məhsulun Geniş Adı]= isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc \r\n			+ isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') + isnull(' ' + Feature06,'') + isnull(' ' +Feature07,'')\r\n			+ isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') + isnull(' ' + Feature11,'')\r\n			+ isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n			+ isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')\r\n			+ isnull(' ' + Feature23,'') + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') \r\n			+ isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		, ProductDesc\r\n		, Balance = isnull([depo-01], 0) + isnull([depo-02],0) + isnull([depo-03],0)\r\n		, WholesalePrice\r\n		, DcProducts.HierarchyCode\r\n		, HierarchyDesc\r\n		, ProductTypeCode\r\n		, ProductId\r\n		, LastPurchasePrice = CAST((select top 1 toplam = TrInvoiceLines.PriceLoc * (1 - (TrInvoiceLines.PosDiscount / 100))  \r\n							 from TrInvoiceLines \r\n							 join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n							 where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n								and TrInvoiceHeaders.ProcessCode IN ( 'RP','CI')\r\n								and TrInvoiceHeaders.IsReturn = 0\r\n							 ORDER BY TrInvoiceHeaders.DocumentDate desc\r\n								, DcHierarchies.HierarchyCode desc\r\n								, TrInvoiceLines.CreatedDate desc) as money)									 \r\n		\r\nfrom DcProducts\r\n\r\nleft join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode\r\nleft join SiteProducts on SiteProducts.ProductCode = DcProducts.ProductCode\r\nleft join ProductFeatures ON DcProducts.ProductCode = ProductFeatures.ProductCode \r\nleft join (select * from (\r\n					select ProductCode\r\n						, WarehouseCode\r\n						, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  \r\n					from TrInvoiceLines il\r\n					left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n					group by ProductCode\r\n						, WarehouseCode\r\n				) AS SourceTable  \r\n				PIVOT  \r\n				( AVG(Balance)\r\n				  FOR WarehouseCode IN ([depo-01], [depo-02], [depo-03])  \r\n				) AS PivotTable \r\n			 ) as depolar on depolar.ProductCode = DcProducts.ProductCode\r\n\r\n	--where ProductTypeCode = 1\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))\r\n	--and il.ProductCode = '5503'\r\n			\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "ReportQuery",
                value: "\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, Balance =ISNULL(SUM(CAST(Amount as money)),0)\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\nfrom \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where 1=1\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where 1=1 \r\n	--and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\nwhere 1 = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\norder by CurrAccDesc");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 3,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\nselect DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\nfrom \r\nDcCurrAccs \r\nleft join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode\r\nwhere CurrAccTypeCode = 5 and IsDisabled = 0 and PaymentTypeCode = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\norder by CurrAccDesc\r\n\r\n\r\n\r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "ReportQuery",
                value: "\r\n--Declare @invoiceHeader nvarchar(50) = 'dd6927e4-d33c-4dc7-929c-1410c299e0a9'\r\n\r\n	select \r\n * from (\r\n	select  InvoiceLineId\r\n			,	[Marka] = isnull(' ' +  Feature02Desc,'')\r\n		  , [Ceki] = isnull(' ' + Feature04Desc,'')\r\n		  , [Reng] = isnull(' ' + Feature05Desc,'')\r\n		  , [Məhsul Tipi] = isnull(' ' + Feature06Desc,'')\r\n		  , [Soyutma Tipi] = isnull(' ' + Feature07Desc,'')\r\n		  , [BTU] = isnull(' ' + Feature09Desc,'')\r\n		  , [Ekran Ölçüsü] = isnull(' ' + Feature10Desc,'')\r\n		  , [Ekran İcazəsi] = isnull(' ' + Feature11Desc,'')\r\n		  , [Motorun Növü] = isnull(' ' + Feature12Desc,'')\r\n		  , [Həcmi] = isnull(' ' + Feature13Desc,'')\r\n		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + Feature14Desc,'')\r\n		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + Feature15Desc,'')\r\n		  , [Istehsalçı Ölkə] = isnull(' ' + Feature16Desc,'')\r\n		  , [Məhsuldarlıq] = isnull(' ' + Feature17Desc,'')\r\n		  , [Güc] = isnull(' ' + Feature18Desc,'')\r\n		  , [Tərtib Edən İstifadəçi] =( select CurrAccDesc from DcCurrAccs where CurrAccCode = TrInvoiceHeaders.CreatedUserName)\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, DcProducts.ProductCode\r\n	, ProductDesc\r\n	, QtyIn = QtyIn\r\n	, QtyOut = QtyOut\r\n	, Price\r\n	, TrInvoiceLines.PosDiscount\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, ProcessDesc\r\n	, TrInvoiceLines.CurrencyCode\r\n	, DcProducts.HierarchyCode\r\n	, HierarchyDesc\r\n	, IsReturn\r\n	, CustomsDocumentNumber\r\n	, PrintCount\r\n	, NetAmount\r\n	, LineDescription\r\n	, PriceLoc\r\n	, TrInvoiceLines.ExchangeRate\r\n	, NetAmountLoc = (QtyIn-QtyOut) * PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100\r\n	, DocumentNumber\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, DcCurrAccs.CurrAccCode\r\n	, DcCurrAccs.CurrAccDesc\r\n	, FirstName\r\n	, PhoneNum\r\n	, HeaderCreatedDate = TrInvoiceHeaders.CreatedDate\r\n	, LineCreatedDate = TrInvoiceLines.CreatedDate\r\n	, TrInvoiceHeaders.CreatedUserName\r\n	, CurrAccBalance = ISNULL((select sum((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n							 	from TrInvoiceLines il\r\n							 	left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n							 	where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode\r\n							 	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n							 	(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))														\r\n							 ), 0)\r\n							 + \r\n							 ISNULL((select sum(PaymentLoc) -- 200 usd\r\n							 	from TrPaymentLines pl\r\n							 	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							 	where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode\r\n							 		and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n							 		(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n							 ), 0)\r\n	, BalanceCode = 'M' + Convert(nvarchar, Format((select SUM(QtyIn - QtyOut) ProductBalance\r\n						from TrInvoiceLines il \r\n						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n						where il.ProductCode = TrInvoiceLines.ProductCode and WarehouseCode = TrInvoiceHeaders.WarehouseCode),'000'))\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, TrInvoiceHeaders.ToWarehouseCode\r\n	, [Depodan] = wareIn.WarehouseDesc\r\n	, [Depoya] = wareOut.WarehouseDesc\r\n	, Description\r\n	, TrInvoiceHeaders.StoreCode\r\n	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl \r\n							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)\r\n	, LastPurchasePrice\r\n	from TrInvoiceLines\r\n\r\n	join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n	left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\n	left join DcHierarchies on DcHierarchies.HierarchyCode = DcProducts.HierarchyCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = TrInvoiceLines.CurrencyCode\r\n	left join DcWarehouses wareIn on wareIn.WarehouseCode = TrInvoiceHeaders.WarehouseCode\r\n	left join DcWarehouses wareOut on wareOut.WarehouseCode = TrInvoiceHeaders.ToWarehouseCode\r\n	left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader\r\n\r\n\r\n) AS PivotTable2\r\n\r\n	order by LineCreatedDate\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 5,
                column: "ReportQuery",
                value: "\r\n\r\n\r\nSELECT   t2.number + 1 RepeatNumber\r\n	, DcProducts.ProductDesc\r\n	, DcProducts.WholesalePrice\r\n	, pb.*\r\nFROM    TrProductBarcodes pb\r\nJOIN DcProducts on DcProducts.ProductCode = pb.ProductCode\r\nJOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < pb.Qty\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 12,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\nselect  PaymentLineId\r\n, TrPaymentHeaders.PaymentHeaderId\r\n, TrPaymentHeaders.InvoiceHeaderId\r\n, InvoiceNumber = tph.DocumentNumber\r\n, DcPaymentTypes.PaymentTypeCode\r\n, PaymentTypeDesc\r\n, PaymentLoc\r\n, Payment\r\n, CurrencyCode\r\n, LineDescription\r\n, TrPaymentHeaders.DocumentNumber\r\n, TrPaymentHeaders.DocumentDate\r\n, TrPaymentHeaders.DocumentTime\r\n, TrPaymentHeaders.OperationDate\r\n, TrPaymentHeaders.OperationTime\r\n, OperationType\r\n, TrPaymentHeaders.CurrAccCode\r\n, CashRegisterCode\r\n, FirstName\r\n, DcCurrAccs.CurrAccDesc\r\n, TrPaymentHeaders.StoreCode\r\n, tpl.CreatedDate\r\n, tpl.CreatedUserName\r\n, [Cari Hesab Balansı] = (	(select sum ((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where DcCurrAccs.CurrAccCode = ih.CurrAccCode\r\n	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		+ \r\n(select Sum(PaymentLoc) -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where DcCurrAccs.CurrAccCode = ph.CurrAccCode \r\n			and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n			(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		)\r\n\r\n from TrPaymentLines tpl\r\nleft join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\nleft join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId\r\nleft Join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode\r\norder by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc\r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 13,
                column: "ReportQuery",
                value: "\r\n\r\n\r\nselect 	CurrAccDesc\r\n	--, ProductDesc\r\n	, NetAmountLoc\r\n	, PaymentLoc\r\n	, [Ara Toplam] = sum(Summary) OVER (ORDER BY DocumentDate, DocumentTime )\r\n	, ProcessDesc\r\n	, DocumentNumber\r\n	, CurrAccCode\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, InvoiceHeaderId\r\n	, PaymentHeaderId\r\n	, LineDescription\r\n	, IsReturn\r\n	, StoreCode\r\n	--, LineId\r\nfrom (\r\n	select FirstName\r\n	, CurrAccDesc\r\n	--, ProductDesc\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, PaymentLoc= 0\r\n	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, ProcessDesc = ProcessDesc\r\n	, DocumentNumber\r\n	, TrInvoiceHeaders.StoreCode\r\n	, TrInvoiceHeaders.CurrAccCode\r\n	, TrInvoiceHeaders.DocumentDate\r\n	, TrInvoiceHeaders.DocumentTime\r\n	, LineDescription = TrInvoiceHeaders.Description\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, IsReturn\r\n	--, LineId = InvoiceLineId\r\n	from TrInvoiceLines \r\n	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = TrInvoiceHeaders.ProcessCode\r\n	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\n	group by FirstName\r\n			, CurrAccDesc\r\n			, ProcessDesc\r\n			, DocumentNumber\r\n			, TrInvoiceHeaders.InvoiceHeaderId\r\n			, TrInvoiceHeaders.CurrAccCode\r\n			, TrInvoiceHeaders.DocumentDate	\r\n			, TrInvoiceHeaders.DocumentTime\r\n			, TrInvoiceHeaders.Description\r\n			, TrInvoiceHeaders.StoreCode\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, IsReturn\r\n	\r\n	UNION ALL \r\n	\r\n	select FirstName\r\n	--, ProductCode = ''\r\n	, CurrAccDesc = CurrAccDesc\r\n	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, TrPaymentHeaders.PaymentHeaderId\r\n	, NetAmountLoc = 0\r\n	, PaymentLoc\r\n	, Summary = PaymentLoc\r\n	, ProcessDesc = N'Ödəniş'\r\n	, DocumentNumber\r\n	, TrPaymentHeaders.StoreCode\r\n	, TrPaymentHeaders.CurrAccCode\r\n	, DocumentDate = TrPaymentHeaders.OperationDate\r\n	, DocumentTime = TrPaymentHeaders.OperationTime\r\n	, LineDescription\r\n	, ProcessCode = 'PA'\r\n	, IsReturn = CAST(0 as bit)\r\n	--, LineId = PaymentLineId\r\n	from TrPaymentLines\r\n	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\n	left join DcCurrAccs  on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode	\r\n\r\n) as CurrAccExtra where 1=1 {CurrAccCode}\r\n\r\norder by DocumentDate, DocumentTime");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 14,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\n\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')\r\n		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		  + isnull(' ' + Feature29,'') \r\n\r\n\r\n, ProductDesc\r\n, QtyIn\r\n, QtyOut\r\n, Price\r\n, PriceLoc\r\n, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))\r\n, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))\r\n, Amount\r\n, NetAmountLoc\r\n, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines \r\n		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId\r\n		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, DocumentNumber\r\n, IsReturn\r\n, LastPurchasePrice\r\n, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - LastPurchasePrice)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceLines.PosDiscount\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs .CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, PrintCount\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, Barcode\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il where il.ProductCode = TrInvoiceLines .ProductCode)\r\n, TrInvoiceHeaders.CreatedUserName\r\n, ImagePath\r\n--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  \r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n\r\norder by DocumentDate, DocumentTime\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 15,
                column: "ReportQuery",
                value: "\r\n\r\n\r\nSELECT Maya = (-1)*(case when Dvijok.ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0) else 0 end)\r\n, Menfeet = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0)) else 0 end)\r\n, [Net Menfeet] = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0)) else 0 end) - Xərc\r\n, *\r\nFROM (\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, ProductDesc\r\n, Qty = (QtyIn-QtyOut)*(-1)\r\n, Price\r\n, PriceLoc\r\n, Amount\r\n, TrInvoiceLines.PosDiscount\r\n, QtyIn\r\n, QtyOut\r\n, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end\r\n, Satis = (-1)*(case when TrInvoiceHeaders.ProcessCode = 'RS' then (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100)) else 0 end)\r\n, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end\r\n, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end\r\n, LastPurchasePrice\r\n, SonQiymet = (select top 1 toplam = il.PriceLoc * (1 - (il.PosDiscount / 100))  \r\n					from TrInvoiceLines il\r\n					join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n					where il.ProductCode = TrInvoiceLines.ProductCode\r\n					and (ih.ProcessCode = 'RP' or ih.ProcessCode = 'CI')\r\n					and ih.IsReturn = 0\r\n					and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n						 (CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n					ORDER BY ih.DocumentDate desc\r\n					, il.CreatedDate desc )	\r\n\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, InvoiceNumber = DocumentNumber\r\n, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - LastPurchasePrice)  / NULLIF(LastPurchasePrice,0) * 100,2)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs.CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, Barcode\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	\r\n\r\nwhere TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'RS', 'EX')\r\n--and DocumentNumber = 'RS-000012'\r\n) Dvijok\r\norder by Dvijok.DocumentDate\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 16,
                column: "ReportQuery",
                value: "\r\n\r\n\r\nselect \r\n [Topdan Sat. Qiy.] =  Round(WholesalePrice, 0)\r\n, [Son Alış Qiy.] =  Round(LastPurchasePrice, 0)\r\n, [%] =CONVERT(int, Round((1 - (PivotTable.LastPurchasePrice / NULLIF(PivotTable.WholesalePrice,0))) * 100, 0)) \r\n, *\r\nfrom (\r\n	select prdcts.ProductCode\r\n	, LastUpdatedDate\r\n	, UseInternet\r\n	, ProductDesc \r\n	, HierarchyCode \r\n	, FeatureCode\r\n	, FeatureTypeId\r\n	, WholesalePrice\r\n	, LastPurchasePrice = (select top 1  PriceLoc * (1 - (PosDiscount / 100))	\r\n								from TrInvoiceLines il\r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.ProcessCode IN ('RP', 'CI') \r\n								and ih.IsReturn = 0\r\n								order by ih.DocumentDate desc\r\n										, ih.CreatedDate desc\r\n								)\r\n	, [Son Alış Günü] = (select top 1  il.LastUpdatedDate	\r\n								from TrInvoiceLines il\r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.ProcessCode IN ('RP') \r\n								and ih.IsReturn = 0\r\n								order by ih.DocumentDate desc\r\n										, ih.CreatedDate desc\r\n								)\r\n	, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il \r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.WarehouseCode = 'depo-01')\r\n	from DcProducts prdcts\r\n	left join TrProductFeatures on TrProductFeatures.ProductCode = prdcts.ProductCode\r\n\r\n	where ProductTypeCode = 1\r\n	) pro\r\nPIVOT (Max(FeatureCode) FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25]) \r\n) AS PivotTable \r\norder by PivotTable.[Son Alış Günü] \r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 17,
                column: "ReportQuery",
                value: "\r\n\r\nselect DcProducts.ProductCode\r\n	, DcProducts.ProductDesc\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, Balance = sum(QtyIn - QtyOut)\r\n	, LastPurchasePrice = (select top 1 PriceLoc * (100 - PosDiscount)/100\r\n					from TrInvoiceLines \r\n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \r\n					{StartDate}\r\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\r\n					)\r\n	, Toplam = sum(QtyIn - QtyOut) * (select top 1 PriceLoc * (100 - PosDiscount)/100\r\n					from TrInvoiceLines \r\n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \r\n					{StartDate}\r\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\r\n					)\r\nfrom TrInvoiceLines\r\nLEFT JOIN TrInvoiceHeaders \r\n	ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nLEFT JOIN DcProducts \r\n	on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\nwhere DcProducts.ProductTypeCode = 1\r\n{StartDate}\r\nGroup by DcProducts.ProductCode\r\n	, DcProducts.ProductDesc\r\n	, TrInvoiceHeaders.WarehouseCode\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcWarehouses",
                keyColumn: "WarehouseCode",
                keyValue: "depo-01",
                column: "StoreCode",
                value: "mgz01");

            migrationBuilder.UpdateData(
                table: "SettingStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PrinterName", "StoreCode" },
                values: new object[] { null, "mgz01" });

            migrationBuilder.InsertData(
                table: "TrClaimReport",
                columns: new[] { "ClaimReportId", "ClaimCode", "ReportId" },
                values: new object[,]
                {
                    { 1, "ButunHesabatlar", 1 },
                    { 2, "ButunHesabatlar", 2 },
                    { 3, "ButunHesabatlar", 3 },
                    { 4, "ButunHesabatlar", 4 },
                    { 5, "ButunHesabatlar", 5 },
                    { 11, "ButunHesabatlar", 11 },
                    { 12, "ButunHesabatlar", 12 },
                    { 13, "ButunHesabatlar", 13 },
                    { 14, "ButunHesabatlar", 14 },
                    { 15, "ButunHesabatlar", 15 },
                    { 16, "ButunHesabatlar", 16 },
                    { 17, "ButunHesabatlar", 17 },
                    { 18, "ButunHesabatlar", 18 }
                });

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 4,
                column: "ClaimCode",
                value: "Column_LastPurchasePrice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 8,
                column: "ClaimCode",
                value: "DiscountList");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 11,
                column: "ClaimCode",
                value: "PaymentDetail");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 16,
                column: "ClaimCode",
                value: "ReportZet");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 17,
                column: "ClaimCode",
                value: "RetailPurchaseInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 18,
                column: "ClaimCode",
                value: "RetailSaleInvoice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 19,
                column: "ClaimCode",
                value: "SaleIsReturn");

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[] { 15, "PurchaseIsReturn", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcQueryParams_DcReportSubQuerySubQueryId",
                table: "DcQueryParams",
                column: "DcReportSubQuerySubQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportFilters_ReportId",
                table: "DcReportFilters",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportSubQueries_ReportId",
                table: "DcReportSubQueries",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrClaimReport_ClaimCode",
                table: "TrClaimReport",
                column: "ClaimCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrClaimReport_ReportId",
                table: "TrClaimReport",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrHierarchyFeatures_FeatureTypeId",
                table: "TrHierarchyFeatures",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPrices_ProductCode",
                table: "TrPrices",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductHierarchies_HierarchyCode",
                table: "TrProductHierarchies",
                column: "HierarchyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingStores_DcCurrAccs_StoreCode",
                table: "SettingStores",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                table: "TrCurrAccRoles",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "trInvoiceLineExt",
                column: "InvoiceLineId",
                principalTable: "TrInvoiceLines",
                principalColumn: "InvoiceLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                table: "TrPaymentHeaders",
                column: "StoreCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders",
                column: "ToCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeType_BarcodeTypeCode",
                table: "TrProductBarcodes",
                column: "BarcodeTypeCode",
                principalTable: "DcBarcodeType",
                principalColumn: "BarcodeTypeCode",
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
