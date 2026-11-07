using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesBonusModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "LineSource",
                table: "TrPayrollLines",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "DcSalesBonusPlans",
                columns: table => new
                {
                    SalesBonusPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CalcMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    TriggerType = table.Column<byte>(type: "tinyint", nullable: false),
                    TierMode = table.Column<byte>(type: "tinyint", nullable: false),
                    PeriodType = table.Column<byte>(type: "tinyint", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    FixedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TargetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TargetMinAchievementPercent = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    MinBaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxBonusAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProcessCodes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcSalesBonusPlans", x => x.SalesBonusPlanId);
                });

            migrationBuilder.CreateTable(
                name: "DcSalesBonusPlanCategories",
                columns: table => new
                {
                    SalesBonusPlanCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesBonusPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RateOverride = table.Column<decimal>(type: "decimal(9,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcSalesBonusPlanCategories", x => x.SalesBonusPlanCategoryId);
                    table.ForeignKey(
                        name: "FK_DcSalesBonusPlanCategories_DcHierarchies_HierarchyCode",
                        column: x => x.HierarchyCode,
                        principalTable: "DcHierarchies",
                        principalColumn: "HierarchyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcSalesBonusPlanCategories_DcSalesBonusPlans_SalesBonusPlanId",
                        column: x => x.SalesBonusPlanId,
                        principalTable: "DcSalesBonusPlans",
                        principalColumn: "SalesBonusPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcSalesBonusPlanProducts",
                columns: table => new
                {
                    SalesBonusPlanProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesBonusPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RateOverride = table.Column<decimal>(type: "decimal(9,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcSalesBonusPlanProducts", x => x.SalesBonusPlanProductId);
                    table.ForeignKey(
                        name: "FK_DcSalesBonusPlanProducts_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcSalesBonusPlanProducts_DcSalesBonusPlans_SalesBonusPlanId",
                        column: x => x.SalesBonusPlanId,
                        principalTable: "DcSalesBonusPlans",
                        principalColumn: "SalesBonusPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcSalesBonusPlanTiers",
                columns: table => new
                {
                    SalesBonusPlanTierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesBonusPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    FixedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcSalesBonusPlanTiers", x => x.SalesBonusPlanTierId);
                    table.ForeignKey(
                        name: "FK_DcSalesBonusPlanTiers_DcSalesBonusPlans_SalesBonusPlanId",
                        column: x => x.SalesBonusPlanId,
                        principalTable: "DcSalesBonusPlans",
                        principalColumn: "SalesBonusPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrSalesBonusAssignments",
                columns: table => new
                {
                    SalesBonusAssignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesBonusPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesPersonCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    TargetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrSalesBonusAssignments", x => x.SalesBonusAssignmentId);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusAssignments_DcCurrAccs_SalesPersonCode",
                        column: x => x.SalesPersonCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusAssignments_DcSalesBonusPlans_SalesBonusPlanId",
                        column: x => x.SalesBonusPlanId,
                        principalTable: "DcSalesBonusPlans",
                        principalColumn: "SalesBonusPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrSalesBonusTxns",
                columns: table => new
                {
                    SalesBonusTxnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesBonusPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesBonusAssignmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesPersonCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TxnType = table.Column<byte>(type: "tinyint", nullable: false),
                    CalcMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    TriggerType = table.Column<byte>(type: "tinyint", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false),
                    PeriodYear = table.Column<int>(type: "int", nullable: false),
                    PeriodNo = table.Column<int>(type: "int", nullable: false),
                    BaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(9,4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceDocumentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PaymentHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentDocumentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RelatedTxnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PayrollHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CalcDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrSalesBonusTxns", x => x.SalesBonusTxnId);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusTxns_DcCurrAccs_SalesPersonCode",
                        column: x => x.SalesPersonCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusTxns_DcSalesBonusPlans_SalesBonusPlanId",
                        column: x => x.SalesBonusPlanId,
                        principalTable: "DcSalesBonusPlans",
                        principalColumn: "SalesBonusPlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusTxns_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusTxns_TrPaymentHeaders_PaymentHeaderId",
                        column: x => x.PaymentHeaderId,
                        principalTable: "TrPaymentHeaders",
                        principalColumn: "PaymentHeaderId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusTxns_TrPayrollHeaders_PayrollHeaderId",
                        column: x => x.PayrollHeaderId,
                        principalTable: "TrPayrollHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusTxns_TrSalesBonusAssignments_SalesBonusAssignmentId",
                        column: x => x.SalesBonusAssignmentId,
                        principalTable: "TrSalesBonusAssignments",
                        principalColumn: "SalesBonusAssignmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TrSalesBonusTxns_TrSalesBonusTxns_RelatedTxnId",
                        column: x => x.RelatedTxnId,
                        principalTable: "TrSalesBonusTxns",
                        principalColumn: "SalesBonusTxnId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "CategoryId", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "SalesBonusCalculate", 23, "Satıcı Bonusu Hesablama və Düzəliş", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 2224, "SalesBonusPlans", "Admin" },
                    { 2225, "SalesBonusAssignments", "Admin" },
                    { 2226, "SalesBonusTxns", "Admin" },
                    { 2227, "SalesBonusCalculate", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DcSalesBonusPlanCategories_HierarchyCode",
                table: "DcSalesBonusPlanCategories",
                column: "HierarchyCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcSalesBonusPlanCategories_SalesBonusPlanId_HierarchyCode",
                table: "DcSalesBonusPlanCategories",
                columns: new[] { "SalesBonusPlanId", "HierarchyCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcSalesBonusPlanProducts_ProductCode",
                table: "DcSalesBonusPlanProducts",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcSalesBonusPlanProducts_SalesBonusPlanId_ProductCode",
                table: "DcSalesBonusPlanProducts",
                columns: new[] { "SalesBonusPlanId", "ProductCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcSalesBonusPlans_PlanName",
                table: "DcSalesBonusPlans",
                column: "PlanName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DcSalesBonusPlanTiers_SalesBonusPlanId_FromValue",
                table: "DcSalesBonusPlanTiers",
                columns: new[] { "SalesBonusPlanId", "FromValue" });

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusAssignments_SalesBonusPlanId",
                table: "TrSalesBonusAssignments",
                column: "SalesBonusPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusAssignments_SalesPersonCode_StartDate",
                table: "TrSalesBonusAssignments",
                columns: new[] { "SalesPersonCode", "StartDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusTxns_InvoiceHeaderId",
                table: "TrSalesBonusTxns",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusTxns_PaymentHeaderId",
                table: "TrSalesBonusTxns",
                column: "PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusTxns_PayrollHeaderId",
                table: "TrSalesBonusTxns",
                column: "PayrollHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusTxns_RelatedTxnId",
                table: "TrSalesBonusTxns",
                column: "RelatedTxnId");

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusTxns_SalesBonusAssignmentId",
                table: "TrSalesBonusTxns",
                column: "SalesBonusAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusTxns_SalesBonusPlanId_SalesPersonCode_PeriodYear_PeriodNo",
                table: "TrSalesBonusTxns",
                columns: new[] { "SalesBonusPlanId", "SalesPersonCode", "PeriodYear", "PeriodNo" });

            migrationBuilder.CreateIndex(
                name: "IX_TrSalesBonusTxns_SalesPersonCode_DocumentDate",
                table: "TrSalesBonusTxns",
                columns: new[] { "SalesPersonCode", "DocumentDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcSalesBonusPlanCategories");

            migrationBuilder.DropTable(
                name: "DcSalesBonusPlanProducts");

            migrationBuilder.DropTable(
                name: "DcSalesBonusPlanTiers");

            migrationBuilder.DropTable(
                name: "TrSalesBonusTxns");

            migrationBuilder.DropTable(
                name: "TrSalesBonusAssignments");

            migrationBuilder.DropTable(
                name: "DcSalesBonusPlans");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "SalesBonusAssignments");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "SalesBonusCalculate");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "SalesBonusPlans");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "SalesBonusTxns");

            migrationBuilder.DropColumn(
                name: "LineSource",
                table: "TrPayrollLines");
        }
    }
}
