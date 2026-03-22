using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrProductBarcodes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrBarcodeOperationLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValueSql: "1");

            migrationBuilder.CreateTable(
                name: "DcCampaigns",
                columns: table => new
                {
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CampaignDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CampaignTypeCode = table.Column<int>(type: "int", maxLength: 20, nullable: false, defaultValue: 1),
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
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                name: "TrCampaignPaymentMethods",
                columns: table => new
                {
                    CampaignPaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCampaignPaymentMethods", x => x.CampaignPaymentMethodId);
                    table.ForeignKey(
                        name: "FK_TrCampaignPaymentMethods_DcCampaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "DcCampaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrCampaignPaymentMethods_DcPaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "DcPaymentMethods",
                        principalColumn: "PaymentMethodId",
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
                    CampaignTypeCode = table.Column<int>(type: "int", maxLength: 20, nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrInvoiceCampaignLogs_TrInvoiceLines_InvoiceLineId",
                        column: x => x.InvoiceLineId,
                        principalTable: "TrInvoiceLines",
                        principalColumn: "InvoiceLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[] { "CP", null, "Kampaniya" });

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
                name: "IX_TrCampaignPaymentMethods_CampaignId_PaymentMethodId",
                table: "TrCampaignPaymentMethods",
                columns: new[] { "CampaignId", "PaymentMethodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrCampaignPaymentMethods_PaymentMethodId",
                table: "TrCampaignPaymentMethods",
                column: "PaymentMethodId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrCampaignCategories");

            migrationBuilder.DropTable(
                name: "TrCampaignCustomers");

            migrationBuilder.DropTable(
                name: "TrCampaignPaymentMethods");

            migrationBuilder.DropTable(
                name: "TrCampaignProducts");

            migrationBuilder.DropTable(
                name: "TrCampaignStores");

            migrationBuilder.DropTable(
                name: "TrCampaignWarehouses");

            migrationBuilder.DropTable(
                name: "TrInvoiceCampaignHeaders");

            migrationBuilder.DropTable(
                name: "TrInvoiceCampaignLogs");

            migrationBuilder.DropTable(
                name: "DcCampaigns");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CP");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrProductBarcodes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 1m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "TrBarcodeOperationLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 1m);
        }
    }
}
