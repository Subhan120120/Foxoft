using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificationSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    NotificationTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NotificationTypeDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DefaultSeverity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AllowPopup = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.NotificationTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NotificationTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EntityKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Active"),
                    LastRaisedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "sysdatetime()"),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_DcCurrAccs_StoreCode",
                        column: x => x.StoreCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_NotificationType_NotificationTypeCode",
                        column: x => x.NotificationTypeCode,
                        principalTable: "NotificationType",
                        principalColumn: "NotificationTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationRecipientRule",
                columns: table => new
                {
                    NotificationRecipientRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRecipientRule", x => x.NotificationRecipientRuleId);
                    table.ForeignKey(
                        name: "FK_NotificationRecipientRule_DcCurrAccs_StoreCode",
                        column: x => x.StoreCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationRecipientRule_DcRoles_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "DcRoles",
                        principalColumn: "RoleCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationRecipientRule_NotificationType_NotificationTypeCode",
                        column: x => x.NotificationTypeCode,
                        principalTable: "NotificationType",
                        principalColumn: "NotificationTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationRule",
                columns: table => new
                {
                    NotificationRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NotificationTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ThrottleMinutes = table.Column<int>(type: "int", nullable: false, defaultValue: 60),
                    ChannelCodes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PopupMinSeverity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRule", x => x.NotificationRuleId);
                    table.ForeignKey(
                        name: "FK_NotificationRule_DcCurrAccs_StoreCode",
                        column: x => x.StoreCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationRule_NotificationType_NotificationTypeCode",
                        column: x => x.NotificationTypeCode,
                        principalTable: "NotificationType",
                        principalColumn: "NotificationTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplate",
                columns: table => new
                {
                    NotificationTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationTypeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TitleTemplate = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BodyTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplate", x => x.NotificationTemplateId);
                    table.ForeignKey(
                        name: "FK_NotificationTemplate_NotificationType_NotificationTypeCode",
                        column: x => x.NotificationTypeCode,
                        principalTable: "NotificationType",
                        principalColumn: "NotificationTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationChannelOutbox",
                columns: table => new
                {
                    OutboxId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    ChannelCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Receiver = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pending"),
                    TryCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastTryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "sysdatetime()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationChannelOutbox", x => x.OutboxId);
                    table.ForeignKey(
                        name: "FK_NotificationChannelOutbox_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationRecipient",
                columns: table => new
                {
                    NotificationRecipientId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Unread"),
                    ReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DismissedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SnoozedUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPopupShownDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRecipient", x => x.NotificationRecipientId);
                    table.ForeignKey(
                        name: "FK_NotificationRecipient_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationRecipient_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationAudit",
                columns: table => new
                {
                    NotificationAuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<long>(type: "bigint", nullable: true),
                    NotificationRecipientId = table.Column<long>(type: "bigint", nullable: true),
                    ActionType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ActorCurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ChannelCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "sysdatetime()"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationAudit", x => x.NotificationAuditId);
                    table.ForeignKey(
                        name: "FK_NotificationAudit_DcCurrAccs_ActorCurrAccCode",
                        column: x => x.ActorCurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationAudit_NotificationRecipient_NotificationRecipientId",
                        column: x => x.NotificationRecipientId,
                        principalTable: "NotificationRecipient",
                        principalColumn: "NotificationRecipientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationAudit_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "NotificationCenter", 15, "Bildiriş Mərkəzi", (byte)1 },
                    { "NotificationRules", 15, "Bildiriş Qaydaları", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "DcRoles",
                columns: new[] { "RoleCode", "RoleDesc" },
                values: new object[,]
                {
                    { "PurchaseManager", "Satınalma meneceri" },
                    { "StoreManager", "Mağaza müdiri" },
                    { "WarehouseUser", "Anbarçı" }
                });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "NotificationTypeCode", "CategoryCode", "NotificationTypeDesc", "DefaultSeverity", "AllowPopup", "IsEnabled", "DisplayOrder" },
                values: new object[,]
                {
                    { "ProductStockWarning", "Stock", "Product Stock Warning Level", "Warning", false, true, 10 },
                    { "ProductOutOfStock", "Stock", "Product Out Of Stock", "Critical", true, true, 20 },
                    { "NegativeStock", "Stock", "Negative Stock", "Critical", true, true, 30 },
                    { "OverStock", "Stock", "Over Stock", "Warning", false, true, 40 },
                    { "ExpiredProduct", "Stock", "Expired Product", "High", true, true, 50 },
                    { "ProductExpireSoon", "Stock", "Product Expire Soon", "Warning", false, true, 60 },
                    { "SerialImeiMissing", "Stock", "Serial/Imei Missing", "Warning", false, true, 70 },
                    { "StockTransferPending", "Stock", "Stock Transfer Pending", "Info", false, true, 80 },
                    { "StockTransferRejected", "Stock", "Stock Transfer Rejected", "High", true, true, 90 },
                    { "InventoryDifference", "Stock", "Inventory Difference", "High", true, true, 100 },
                    { "SaleBelowMinimumPrice", "Sale", "Sale Below Minimum Price", "High", true, true, 110 },
                    { "DiscountApprovalRequired", "Sale", "Discount Approval Required", "Warning", false, true, 120 },
                    { "InvoiceNotPosted", "Sale", "Invoice Not Posted", "Warning", false, true, 130 },
                    { "CustomerCreditLimitExceeded", "Sale", "Customer Credit Limit Exceeded", "High", true, true, 140 },
                    { "LargeSaleCreated", "Sale", "Large Sale Created", "Info", false, true, 150 },
                    { "ReturnCreated", "Sale", "Return Created", "Info", false, true, 160 },
                    { "PurchaseOrderPending", "Purchase", "Purchase Order Pending", "Info", false, true, 170 },
                    { "SupplierDebtDue", "Purchase", "Supplier Debt Due", "Warning", false, true, 180 },
                    { "PurchasePriceChanged", "Purchase", "Purchase Price Changed", "Info", false, true, 190 },
                    { "SupplierInvoiceMissing", "Purchase", "Supplier Invoice Missing", "Warning", false, true, 200 },
                    { "CashBalanceWarning", "Payment", "Cash Balance Warning", "Warning", false, true, 210 },
                    { "PaymentNotConfirmed", "Payment", "Payment Not Confirmed", "Warning", false, true, 220 },
                    { "BankPaymentImported", "Payment", "Bank Payment Imported", "Info", false, true, 230 },
                    { "CashboxClosingMissing", "Payment", "Cashbox Closing Missing", "High", true, true, 240 },
                    { "PaymentDifference", "Payment", "Payment Difference", "High", true, true, 250 },
                    { "InstallmentDueSoon", "Installment", "Installment Due Soon", "Warning", false, true, 260 },
                    { "InstallmentOverdue", "Installment", "Installment Overdue", "High", true, true, 270 },
                    { "InstallmentPaid", "Installment", "Installment Paid", "Info", false, true, 280 },
                    { "CreditClosed", "Installment", "Credit Closed", "Info", false, true, 290 },
                    { "CustomerDebtIncreased", "Installment", "Customer Debt Increased", "Warning", false, true, 300 },
                    { "CustomerBirthday", "Customer", "Customer Birthday", "Info", false, true, 310 },
                    { "CustomerInactive", "Customer", "Customer Inactive", "Info", false, true, 320 },
                    { "VipCustomerSale", "Customer", "VIP Customer Sale", "Info", false, true, 330 },
                    { "NewCustomerCreated", "Customer", "New Customer Created", "Info", false, true, 340 },
                    { "BackupFailed", "System", "Backup Failed", "Critical", true, true, 350 },
                    { "IntegrationFailed", "System", "Integration Failed", "High", true, true, 360 },
                    { "SyncFailed", "System", "Sync Failed", "High", true, true, 370 },
                    { "LicenseExpireSoon", "System", "License Expire Soon", "Warning", false, true, 380 },
                    { "UserLoginFailedManyTimes", "System", "User Login Failed Many Times", "Critical", true, true, 390 }
                });

            migrationBuilder.InsertData(
                table: "NotificationRecipientRule",
                columns: new[] { "NotificationRecipientRuleId", "IsEnabled", "NotificationTypeCode", "RoleCode", "StoreCode" },
                values: new object[,]
                {
                    { 1, true, "ProductStockWarning", "Admin", null },
                    { 2, true, "ProductOutOfStock", "Admin", null },
                    { 3, true, "NegativeStock", "Admin", null },
                    { 4, true, "OverStock", "Admin", null },
                    { 5, true, "ExpiredProduct", "Admin", null },
                    { 6, true, "ProductExpireSoon", "Admin", null },
                    { 7, true, "SerialImeiMissing", "Admin", null },
                    { 8, true, "StockTransferPending", "Admin", null },
                    { 9, true, "StockTransferRejected", "Admin", null },
                    { 10, true, "InventoryDifference", "Admin", null },
                    { 11, true, "SaleBelowMinimumPrice", "Admin", null },
                    { 12, true, "DiscountApprovalRequired", "Admin", null },
                    { 13, true, "InvoiceNotPosted", "Admin", null },
                    { 14, true, "CustomerCreditLimitExceeded", "Admin", null },
                    { 15, true, "LargeSaleCreated", "Admin", null },
                    { 16, true, "ReturnCreated", "Admin", null },
                    { 17, true, "PurchaseOrderPending", "Admin", null },
                    { 18, true, "SupplierDebtDue", "Admin", null },
                    { 19, true, "PurchasePriceChanged", "Admin", null },
                    { 20, true, "SupplierInvoiceMissing", "Admin", null },
                    { 21, true, "CashBalanceWarning", "Admin", null },
                    { 22, true, "PaymentNotConfirmed", "Admin", null },
                    { 23, true, "BankPaymentImported", "Admin", null },
                    { 24, true, "CashboxClosingMissing", "Admin", null },
                    { 25, true, "PaymentDifference", "Admin", null },
                    { 26, true, "InstallmentDueSoon", "Admin", null },
                    { 27, true, "InstallmentOverdue", "Admin", null },
                    { 28, true, "InstallmentPaid", "Admin", null },
                    { 29, true, "CreditClosed", "Admin", null },
                    { 30, true, "CustomerDebtIncreased", "Admin", null },
                    { 31, true, "CustomerBirthday", "Admin", null },
                    { 32, true, "CustomerInactive", "Admin", null },
                    { 33, true, "VipCustomerSale", "Admin", null },
                    { 34, true, "NewCustomerCreated", "Admin", null },
                    { 35, true, "BackupFailed", "Admin", null },
                    { 36, true, "IntegrationFailed", "Admin", null },
                    { 37, true, "SyncFailed", "Admin", null },
                    { 38, true, "LicenseExpireSoon", "Admin", null },
                    { 39, true, "UserLoginFailedManyTimes", "Admin", null },
                    { 1001, true, "ProductStockWarning", "PurchaseManager", null },
                    { 1002, true, "ProductOutOfStock", "PurchaseManager", null },
                    { 1003, true, "NegativeStock", "WarehouseUser", null },
                    { 1004, true, "StockTransferPending", "WarehouseUser", null },
                    { 1005, true, "StockTransferRejected", "WarehouseUser", null },
                    { 1006, true, "InventoryDifference", "WarehouseUser", null },
                    { 1101, true, "ProductStockWarning", "StoreManager", "MGZ01" },
                    { 1102, true, "ProductOutOfStock", "StoreManager", "MGZ01" },
                    { 1103, true, "ProductStockWarning", "WarehouseUser", "MGZ01" },
                    { 1104, true, "ProductOutOfStock", "WarehouseUser", "MGZ01" }
                });

            migrationBuilder.InsertData(
                table: "NotificationRule",
                columns: new[] { "NotificationRuleId", "ChannelCodes", "IsEnabled", "NotificationTypeCode", "PopupMinSeverity", "RuleName", "StoreCode", "ThrottleMinutes" },
                values: new object[,]
                {
                    { 1, "InApp", true, "ProductStockWarning", "High", "Product Stock Warning Level", null, 60 },
                    { 2, "InApp,Popup", true, "ProductOutOfStock", "High", "Product Out Of Stock", null, 60 },
                    { 3, "InApp,Popup", true, "NegativeStock", "High", "Negative Stock", null, 60 },
                    { 4, "InApp", true, "OverStock", "High", "Over Stock", null, 60 },
                    { 5, "InApp,Popup", true, "ExpiredProduct", "High", "Expired Product", null, 60 },
                    { 6, "InApp", true, "ProductExpireSoon", "High", "Product Expire Soon", null, 60 },
                    { 7, "InApp", true, "SerialImeiMissing", "High", "Serial/Imei Missing", null, 60 },
                    { 8, "InApp", true, "StockTransferPending", "High", "Stock Transfer Pending", null, 60 },
                    { 9, "InApp,Popup", true, "StockTransferRejected", "High", "Stock Transfer Rejected", null, 60 },
                    { 10, "InApp,Popup", true, "InventoryDifference", "High", "Inventory Difference", null, 60 },
                    { 11, "InApp,Popup", true, "SaleBelowMinimumPrice", "High", "Sale Below Minimum Price", null, 60 },
                    { 12, "InApp", true, "DiscountApprovalRequired", "High", "Discount Approval Required", null, 60 },
                    { 13, "InApp", true, "InvoiceNotPosted", "High", "Invoice Not Posted", null, 60 },
                    { 14, "InApp,Popup", true, "CustomerCreditLimitExceeded", "High", "Customer Credit Limit Exceeded", null, 60 },
                    { 15, "InApp", true, "LargeSaleCreated", "High", "Large Sale Created", null, 60 },
                    { 16, "InApp", true, "ReturnCreated", "High", "Return Created", null, 60 },
                    { 17, "InApp", true, "PurchaseOrderPending", "High", "Purchase Order Pending", null, 60 },
                    { 18, "InApp", true, "SupplierDebtDue", "High", "Supplier Debt Due", null, 60 },
                    { 19, "InApp", true, "PurchasePriceChanged", "High", "Purchase Price Changed", null, 60 },
                    { 20, "InApp", true, "SupplierInvoiceMissing", "High", "Supplier Invoice Missing", null, 60 },
                    { 21, "InApp", true, "CashBalanceWarning", "High", "Cash Balance Warning", null, 60 },
                    { 22, "InApp", true, "PaymentNotConfirmed", "High", "Payment Not Confirmed", null, 60 },
                    { 23, "InApp", true, "BankPaymentImported", "High", "Bank Payment Imported", null, 60 },
                    { 24, "InApp,Popup", true, "CashboxClosingMissing", "High", "Cashbox Closing Missing", null, 60 },
                    { 25, "InApp,Popup", true, "PaymentDifference", "High", "Payment Difference", null, 60 },
                    { 26, "InApp", true, "InstallmentDueSoon", "High", "Installment Due Soon", null, 60 },
                    { 27, "InApp,Popup", true, "InstallmentOverdue", "High", "Installment Overdue", null, 60 },
                    { 28, "InApp", true, "InstallmentPaid", "High", "Installment Paid", null, 60 },
                    { 29, "InApp", true, "CreditClosed", "High", "Credit Closed", null, 60 },
                    { 30, "InApp", true, "CustomerDebtIncreased", "High", "Customer Debt Increased", null, 60 },
                    { 31, "InApp", true, "CustomerBirthday", "High", "Customer Birthday", null, 1440 },
                    { 32, "InApp", true, "CustomerInactive", "High", "Customer Inactive", null, 60 },
                    { 33, "InApp", true, "VipCustomerSale", "High", "VIP Customer Sale", null, 60 },
                    { 34, "InApp", true, "NewCustomerCreated", "High", "New Customer Created", null, 60 },
                    { 35, "InApp,Popup", true, "BackupFailed", "High", "Backup Failed", null, 60 },
                    { 36, "InApp,Popup", true, "IntegrationFailed", "High", "Integration Failed", null, 60 },
                    { 37, "InApp,Popup", true, "SyncFailed", "High", "Sync Failed", null, 60 },
                    { 38, "InApp", true, "LicenseExpireSoon", "High", "License Expire Soon", null, 60 },
                    { 39, "InApp,Popup", true, "UserLoginFailedManyTimes", "High", "User Login Failed Many Times", null, 60 }
                });

            migrationBuilder.InsertData(
                table: "NotificationTemplate",
                columns: new[] { "NotificationTemplateId", "BodyTemplate", "IsEnabled", "LanguageCode", "NotificationTypeCode", "TitleTemplate" },
                values: new object[,]
                {
                    { 1, "{ProductDesc} məhsulunun {WarehouseDesc} anbarında qalığı xəbərdarlıq limitindən aşağı düşüb.\n\nMəhsul kodu: {ProductCode}\nMövcud qalıq: {AvailableQty}\nMinimum limit: {WarningQty}", true, "az", "ProductStockWarning", "Məhsul qalığı azalıb" },
                    { 2, "{ProductDesc} məhsulunun {WarehouseDesc} anbarında satışa yararlı qalığı 0-dır.\n\nMəhsul kodu: {ProductCode}\nAnbar: {WarehouseDesc}", true, "az", "ProductOutOfStock", "Məhsul anbarda bitib" },
                    { 3, "{ProductDesc} məhsulunun {WarehouseDesc} anbarında qalığı mənfiyə düşüb.\n\nMəhsul kodu: {ProductCode}\nMövcud qalıq: {AvailableQty}", true, "az", "NegativeStock", "Məhsul qalığı mənfidir" }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 209, "NotificationCenter", "Admin" },
                    { 210, "NotificationRules", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotificationKey",
                table: "Notification",
                column: "NotificationKey",
                unique: true,
                filter: "[Status] = N'Active'");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotificationTypeCode_Status_StoreCode",
                table: "Notification",
                columns: new[] { "NotificationTypeCode", "Status", "StoreCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_StoreCode",
                table: "Notification",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAudit_ActorCurrAccCode",
                table: "NotificationAudit",
                column: "ActorCurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAudit_NotificationId_ActionDate",
                table: "NotificationAudit",
                columns: new[] { "NotificationId", "ActionDate" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAudit_NotificationRecipientId",
                table: "NotificationAudit",
                column: "NotificationRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationChannelOutbox_NotificationId",
                table: "NotificationChannelOutbox",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationChannelOutbox_Status_CreatedDate",
                table: "NotificationChannelOutbox",
                columns: new[] { "Status", "CreatedDate" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecipient_CurrAccCode_Status",
                table: "NotificationRecipient",
                columns: new[] { "CurrAccCode", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecipient_NotificationId_CurrAccCode",
                table: "NotificationRecipient",
                columns: new[] { "NotificationId", "CurrAccCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecipientRule_NotificationTypeCode_RoleCode_StoreCode",
                table: "NotificationRecipientRule",
                columns: new[] { "NotificationTypeCode", "RoleCode", "StoreCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecipientRule_RoleCode",
                table: "NotificationRecipientRule",
                column: "RoleCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRecipientRule_StoreCode",
                table: "NotificationRecipientRule",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRule_NotificationTypeCode_StoreCode",
                table: "NotificationRule",
                columns: new[] { "NotificationTypeCode", "StoreCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRule_StoreCode",
                table: "NotificationRule",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTemplate_NotificationTypeCode_LanguageCode",
                table: "NotificationTemplate",
                columns: new[] { "NotificationTypeCode", "LanguageCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationType_CategoryCode",
                table: "NotificationType",
                column: "CategoryCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationAudit");

            migrationBuilder.DropTable(
                name: "NotificationChannelOutbox");

            migrationBuilder.DropTable(
                name: "NotificationRecipientRule");

            migrationBuilder.DropTable(
                name: "NotificationRule");

            migrationBuilder.DropTable(
                name: "NotificationTemplate");

            migrationBuilder.DropTable(
                name: "NotificationRecipient");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "NotificationType");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "PurchaseManager");

            migrationBuilder.DeleteData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "StoreManager");

            migrationBuilder.DeleteData(
                table: "DcRoles",
                keyColumn: "RoleCode",
                keyValue: "WarehouseUser");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "NotificationRules");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "NotificationCenter");
        }
    }
}
