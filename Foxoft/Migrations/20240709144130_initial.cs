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
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductVersion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "DcBarcodeTypes",
                columns: table => new
                {
                    BarcodeTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BarcodeTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcBarcodeTypes", x => x.BarcodeTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcClaimTypes",
                columns: table => new
                {
                    ClaimTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ClaimTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcClaimTypes", x => x.ClaimTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccTypes",
                columns: table => new
                {
                    CurrAccTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrAccTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccTypes", x => x.CurrAccTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrencies",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CurrencyDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrencies", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "DcDiscounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcDiscounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "DcFeatureTypes",
                columns: table => new
                {
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Filterable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatureTypes", x => x.FeatureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DcForms",
                columns: table => new
                {
                    FormCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcForms", x => x.FormCode);
                });

            migrationBuilder.CreateTable(
                name: "DcHierarchies",
                columns: table => new
                {
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HierarchyDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HierarchyLevel = table.Column<int>(type: "int", nullable: false),
                    HierarchyParentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcHierarchies", x => x.HierarchyCode);
                });

            migrationBuilder.CreateTable(
                name: "DcOffices",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    OfficeDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyCode = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcOffices", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcPaymentTypes",
                columns: table => new
                {
                    PaymentTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentTypes", x => x.PaymentTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcPriceTypes",
                columns: table => new
                {
                    PriceTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PriceTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPriceTypes", x => x.PriceTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcProductTypes",
                columns: table => new
                {
                    ProductTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    ProductTypeDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProductTypes", x => x.ProductTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcReportTypes",
                columns: table => new
                {
                    ReportTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ReportTypeDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReportTypes", x => x.ReportTypeId);
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
                name: "DcRoles",
                columns: table => new
                {
                    RoleCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcRoles", x => x.RoleCode);
                });

            migrationBuilder.CreateTable(
                name: "DcTerminals",
                columns: table => new
                {
                    TerminalId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TouchUIMode = table.Column<bool>(type: "bit", nullable: false),
                    TouchScaleFactor = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcTerminals", x => x.TerminalId);
                });

            migrationBuilder.CreateTable(
                name: "DcVariables",
                columns: table => new
                {
                    VariableCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    VariableDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LastNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcVariables", x => x.VariableCode);
                });

            migrationBuilder.CreateTable(
                name: "DcWarehouses",
                columns: table => new
                {
                    WarehouseCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WarehouseDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    WarehouseTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    OfficeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PermitNegativeStock = table.Column<bool>(type: "bit", nullable: false),
                    WarnNegativeStock = table.Column<bool>(type: "bit", nullable: false),
                    ControlStockLevel = table.Column<bool>(type: "bit", nullable: false),
                    WarnStockLevelRate = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcWarehouses", x => x.WarehouseCode);
                });

            migrationBuilder.CreateTable(
                name: "DcClaims",
                columns: table => new
                {
                    ClaimCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimTypeId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcClaims", x => x.ClaimCode);
                    table.ForeignKey(
                        name: "FK_DcClaims_DcClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "DcClaimTypes",
                        principalColumn: "ClaimTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GridViewLayout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetPrint = table.Column<bool>(type: "bit", nullable: false),
                    PrinterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrinterCopyNum = table.Column<int>(type: "int", nullable: false),
                    PrintDesignPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalCurrencyCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TwilioInstanceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwilioToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsePriceList = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    AutoSave = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppSettings_DcCurrencies_LocalCurrencyCode",
                        column: x => x.LocalCurrencyCode,
                        principalTable: "DcCurrencies",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcProcesses",
                columns: table => new
                {
                    ProcessCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ProcessDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProcessDir = table.Column<byte>(type: "tinyint", maxLength: 150, nullable: false),
                    CustomCurrencyCode = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProcesses", x => x.ProcessCode);
                    table.ForeignKey(
                        name: "FK_DcProcesses_DcCurrencies_CustomCurrencyCode",
                        column: x => x.CustomCurrencyCode,
                        principalTable: "DcCurrencies",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcFeatures",
                columns: table => new
                {
                    FeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    FeatureDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatures", x => new { x.FeatureCode, x.FeatureTypeId });
                    table.ForeignKey(
                        name: "FK_DcFeatures_DcFeatureTypes_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "DcFeatureTypes",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "DcCurrAccs",
                columns: table => new
                {
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CurrAccDesc = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CurrAccTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    NewPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TaxNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DataLanguageCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CreditLimit = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    IsVIP = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CustomerTypeCode = table.Column<byte>(type: "tinyint", nullable: true),
                    VendorTypeCode = table.Column<byte>(type: "tinyint", nullable: true),
                    CustomerPosDiscountRate = table.Column<double>(type: "float", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BonusCardNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNum = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'1901-01-01'"),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashRegPaymentTypeCode = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccs", x => x.CurrAccCode);
                    table.ForeignKey(
                        name: "FK_DcCurrAccs_DcCurrAccTypes_CurrAccTypeCode",
                        column: x => x.CurrAccTypeCode,
                        principalTable: "DcCurrAccTypes",
                        principalColumn: "CurrAccTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcCurrAccs_DcPaymentTypes_CashRegPaymentTypeCode",
                        column: x => x.CashRegPaymentTypeCode,
                        principalTable: "DcPaymentTypes",
                        principalColumn: "PaymentTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPriceListHeaders",
                columns: table => new
                {
                    PriceListHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PriceTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DueTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OfficeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsTexIncluded = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPriceListHeaders", x => x.PriceListHeaderId);
                    table.ForeignKey(
                        name: "FK_TrPriceListHeaders_DcPriceTypes_PriceTypeCode",
                        column: x => x.PriceTypeCode,
                        principalTable: "DcPriceTypes",
                        principalColumn: "PriceTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcProducts",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductCode2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductDesc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductFeature = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ProductTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsePos = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    PromotionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PromotionCode2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxRate = table.Column<double>(type: "float", nullable: false, defaultValueSql: "0"),
                    PosDiscount = table.Column<double>(type: "float", nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    WholesalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0"),
                    UseInternet = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    ImagePath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProducts", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_DcProducts_DcHierarchies_HierarchyCode",
                        column: x => x.HierarchyCode,
                        principalTable: "DcHierarchies",
                        principalColumn: "HierarchyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                        column: x => x.ProductTypeCode,
                        principalTable: "DcProductTypes",
                        principalColumn: "ProductTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcReports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportQuery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ReportLayout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportFilter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_DcReports_DcReportTypes_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalTable: "DcReportTypes",
                        principalColumn: "ReportTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrRoleClaims",
                columns: table => new
                {
                    RoleClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrRoleClaims", x => x.RoleClaimId);
                    table.ForeignKey(
                        name: "FK_TrRoleClaims_DcClaims_ClaimCode",
                        column: x => x.ClaimCode,
                        principalTable: "DcClaims",
                        principalColumn: "ClaimCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrRoleClaims_DcRoles_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "DcRoles",
                        principalColumn: "RoleCode",
                        onDelete: ReferentialAction.Restrict);
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
                name: "DcPaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    PaymentMethodDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultCashRegCode = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentMethods", x => x.PaymentMethodId);
                    table.ForeignKey(
                        name: "FK_DcPaymentMethods_DcCurrAccs_DefaultCashRegCode",
                        column: x => x.DefaultCashRegCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcPaymentMethods_DcPaymentTypes_PaymentTypeCode",
                        column: x => x.PaymentTypeCode,
                        principalTable: "DcPaymentTypes",
                        principalColumn: "PaymentTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SettingStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DesignFileFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrinterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingStores_DcCurrAccs_StoreCode",
                        column: x => x.StoreCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrCurrAccRoles",
                columns: table => new
                {
                    CurrAccRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    RoleCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrCurrAccRoles", x => x.CurrAccRoleId);
                    table.ForeignKey(
                        name: "FK_TrCurrAccRoles_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrCurrAccRoles_DcRoles_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "DcRoles",
                        principalColumn: "RoleCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceHeaders",
                columns: table => new
                {
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProcessCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsReturn = table.Column<bool>(type: "bit", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    OfficeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WarehouseCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ToWarehouseCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CustomsDocumentNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PosTerminalId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsSent = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    PrintCount = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    FiscalPrintedState = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "0"),
                    IsSalesViaInternet = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsMainTF = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceHeaders", x => x.InvoiceHeaderId);
                    table.ForeignKey(
                        name: "FK_TrInvoiceHeaders_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInvoiceHeaders_DcProcesses_ProcessCode",
                        column: x => x.ProcessCode,
                        principalTable: "DcProcesses",
                        principalColumn: "ProcessCode",
                        onDelete: ReferentialAction.Restrict);
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
                name: "SiteProducts",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteProducts", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_SiteProducts_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrPriceListLines",
                columns: table => new
                {
                    PriceListLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceListHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    LineDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPriceListLines", x => x.PriceListLineId);
                    table.ForeignKey(
                        name: "FK_TrPriceListLines_DcCurrencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "DcCurrencies",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPriceListLines_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPriceListLines_TrPriceListHeaders_PriceListHeaderId",
                        column: x => x.PriceListHeaderId,
                        principalTable: "TrPriceListHeaders",
                        principalColumn: "PriceListHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrPrices",
                columns: table => new
                {
                    PriceCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
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
                name: "TrProductBarcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    BarcodeTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false, defaultValueSql: "1"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProductBarcodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrProductBarcodes_DcBarcodeTypes_BarcodeTypeCode",
                        column: x => x.BarcodeTypeCode,
                        principalTable: "DcBarcodeTypes",
                        principalColumn: "BarcodeTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductBarcodes_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrProductDiscounts",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProductDiscounts", x => new { x.ProductCode, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_TrProductDiscounts_DcDiscounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "DcDiscounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductDiscounts_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrProductFeatures",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    FeatureTypeId = table.Column<int>(type: "int", nullable: false),
                    FeatureCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityColumn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrProductFeatures", x => new { x.ProductCode, x.FeatureTypeId, x.FeatureCode });
                    table.ForeignKey(
                        name: "FK_TrProductFeatures_DcFeatureTypes_FeatureTypeId",
                        column: x => x.FeatureTypeId,
                        principalTable: "DcFeatureTypes",
                        principalColumn: "FeatureTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductFeatures_DcFeatures_FeatureCode_FeatureTypeId",
                        columns: x => new { x.FeatureCode, x.FeatureTypeId },
                        principalTable: "DcFeatures",
                        principalColumns: new[] { "FeatureCode", "FeatureTypeId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrProductFeatures_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrProductHierarchies",
                columns: table => new
                {
                    HierarchyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", nullable: false)
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
                name: "TrFormReports",
                columns: table => new
                {
                    FormCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Shortcut = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrFormReports", x => new { x.FormCode, x.ReportId });
                    table.ForeignKey(
                        name: "FK_TrFormReports_DcForms_FormCode",
                        column: x => x.FormCode,
                        principalTable: "DcForms",
                        principalColumn: "FormCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrFormReports_DcReports_ReportId",
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentMethodDiscounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPaymentMethodDiscounts", x => new { x.DiscountId, x.PaymentMethodId });
                    table.ForeignKey(
                        name: "FK_TrPaymentMethodDiscounts_DcDiscounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "DcDiscounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentMethodDiscounts_DcPaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "DcPaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceLines",
                columns: table => new
                {
                    InvoiceLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    QtyIn = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    QtyOut = table.Column<int>(type: "int", nullable: false, defaultValueSql: "0"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ExchangeRate = table.Column<float>(type: "real", nullable: false, defaultValueSql: "1"),
                    PriceLoc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    AmountLoc = table.Column<decimal>(type: "money", nullable: false),
                    PosDiscount = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    NetAmount = table.Column<decimal>(type: "money", nullable: false),
                    NetAmountLoc = table.Column<decimal>(type: "money", nullable: false),
                    DiscountCampaign = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    VatRate = table.Column<float>(type: "real", nullable: false, defaultValueSql: "0"),
                    LineDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SalesPersonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceLines", x => x.InvoiceLineId);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLines_DcCurrencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "DcCurrencies",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentHeaders",
                columns: table => new
                {
                    PaymentHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    CurrAccCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ToCashRegCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FromCashRegCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OperationType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "0"),
                    OfficeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StoreCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PosterminalId = table.Column<short>(type: "smallint", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsSent = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    IsMainTF = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPaymentHeaders", x => x.PaymentHeaderId);
                    table.ForeignKey(
                        name: "FK_TrPaymentHeaders_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode");
                    table.ForeignKey(
                        name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                        column: x => x.StoreCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                        column: x => x.ToCashRegCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentHeaders_DcProcesses_ProcessCode",
                        column: x => x.ProcessCode,
                        principalTable: "DcProcesses",
                        principalColumn: "ProcessCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrReportSubQueryRelationColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubQueryId = table.Column<int>(type: "int", maxLength: 150, nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceLineExts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDiscounted = table.Column<decimal>(type: "money", nullable: false),
                    LineExpences = table.Column<decimal>(type: "money", nullable: true),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceLineExts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLineExts_TrInvoiceLines_InvoiceLineId",
                        column: x => x.InvoiceLineId,
                        principalTable: "TrInvoiceLines",
                        principalColumn: "InvoiceLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentLines",
                columns: table => new
                {
                    PaymentLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentTypeCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Payment = table.Column<decimal>(type: "money", nullable: false),
                    PaymentLoc = table.Column<decimal>(type: "money", nullable: false),
                    LineDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ExchangeRate = table.Column<float>(type: "real", nullable: false, defaultValueSql: "1"),
                    CashRegisterCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CreatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPaymentLines", x => x.PaymentLineId);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_DcCurrAccs_CashRegisterCode",
                        column: x => x.CashRegisterCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_DcCurrencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "DcCurrencies",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_DcPaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "DcPaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                        column: x => x.PaymentTypeCode,
                        principalTable: "DcPaymentTypes",
                        principalColumn: "PaymentTypeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                        column: x => x.PaymentHeaderId,
                        principalTable: "TrPaymentHeaders",
                        principalColumn: "PaymentHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "Id", "DueDate", "GetPrint", "GridViewLayout", "License", "LocalCurrencyCode", "PrintDesignPath", "PrinterCopyNum", "PrinterName", "TwilioInstanceId", "TwilioToken" },
                values: new object[] { 1, null, false, "<XtraSerializer version=\"1.0\" application=\"View\">\n	<property name=\"#LayoutVersion\" />\n	<property name=\"#LayoutScaleFactor\">@1,Width=1@1,Height=1</property>\n	<property name=\"Appearance\" isnull=\"true\" iskey=\"true\">\n		<property name=\"Row\" iskey=\"true\" value=\"Row\">\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\n				<property name=\"UseFont\">true</property>\n			</property>\n			<property name=\"Font\">Tahoma, 12pt</property>\n		</property>\n		<property name=\"FooterPanel\" iskey=\"true\" value=\"FooterPanel\">\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\n				<property name=\"UseFont\">true</property>\n			</property>\n			<property name=\"Font\">Tahoma, 12pt</property>\n		</property>\n	</property>\n	<property name=\"OptionsBehavior\" isnull=\"true\" iskey=\"true\">\n		<property name=\"Editable\">false</property>\n		<property name=\"ReadOnly\">true</property>\n	</property>\n	<property name=\"OptionsCustomization\" isnull=\"true\" iskey=\"true\">\n		<property name=\"AllowRowSizing\">true</property>\n	</property>\n	<property name=\"OptionsView\" isnull=\"true\" iskey=\"true\">\n		<property name=\"ColumnHeaderAutoHeight\">True</property>\n		<property name=\"ShowAutoFilterRow\">true</property>\n		<property name=\"ShowGroupPanel\">false</property>\n		<property name=\"ShowIndicator\">false</property>\n	</property>\n	<property name=\"OptionsFind\" isnull=\"true\" iskey=\"true\">\n		<property name=\"FindMode\">Always</property>\n		<property name=\"FindDelay\">100</property>\n	</property>\n	<property name=\"FixedLineWidth\">2</property>\n	<property name=\"IndicatorWidth\">-1</property>\n	<property name=\"ColumnPanelRowHeight\">-1</property>\n	<property name=\"RowSeparatorHeight\">0</property>\n	<property name=\"FooterPanelHeight\">-1</property>\n	<property name=\"HorzScrollVisibility\">Auto</property>\n	<property name=\"VertScrollVisibility\">Auto</property>\n	<property name=\"RowHeight\">-1</property>\n	<property name=\"GroupRowHeight\">-1</property>\n	<property name=\"GroupFormat\">{0}: [#image]{1} {2}</property>\n	<property name=\"ChildGridLevelName\" />\n	<property name=\"VertScrollTipFieldName\" />\n	<property name=\"PreviewFieldName\" />\n	<property name=\"GroupPanelText\" />\n	<property name=\"NewItemRowText\" />\n	<property name=\"LevelIndent\">-1</property>\n	<property name=\"PreviewIndent\">-1</property>\n	<property name=\"PreviewLineCount\">-1</property>\n	<property name=\"ScrollStyle\">LiveVertScroll, LiveHorzScroll</property>\n	<property name=\"FocusRectStyle\">CellFocus</property>\n	<property name=\"HorzScrollStep\">0</property>\n	<property name=\"ActiveFilterEnabled\">true</property>\n	<property name=\"ViewCaptionHeight\">-1</property>\n	<property name=\"Columns\" iskey=\"true\" value=\"0\" />\n	<property name=\"ViewCaption\" />\n	<property name=\"BorderStyle\">Default</property>\n	<property name=\"SynchronizeClones\">true</property>\n	<property name=\"DetailTabHeaderLocation\">Top</property>\n	<property name=\"Name\">gridView1</property>\n	<property name=\"DetailHeight\">350</property>\n	<property name=\"Tag\" isnull=\"true\" />\n	<property name=\"GroupSummary\" iskey=\"true\" value=\"0\" />\n	<property name=\"ActiveFilterString\" />\n	<property name=\"FormatRules\" iskey=\"true\" value=\"0\" />\n	<property name=\"FormatConditions\" iskey=\"true\" value=\"0\" />\n	<property name=\"GroupSummarySortInfoState\" />\n	<property name=\"FindFilterText\" />\n	<property name=\"FindPanelVisible\">true</property>\n</XtraSerializer>", null, null, null, 0, null, null, null });

            migrationBuilder.InsertData(
                table: "DcBarcodeTypes",
                columns: new[] { "BarcodeTypeCode", "BarcodeTypeDesc" },
                values: new object[,]
                {
                    { "EAN13", "EAN13" },
                    { "Serbest", "Sərbəst" }
                });

            migrationBuilder.InsertData(
                table: "DcClaimTypes",
                columns: new[] { "ClaimTypeId", "ClaimTypeDesc" },
                values: new object[,]
                {
                    { (byte)1, "Embaded" },
                    { (byte)2, "Report" },
                    { (byte)3, "Column" }
                });

            migrationBuilder.InsertData(
                table: "DcCurrAccTypes",
                columns: new[] { "CurrAccTypeCode", "CurrAccTypeDesc", "IsDisabled", "RowGuid" },
                values: new object[,]
                {
                    { (byte)1, "Müştəri", false, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (byte)2, "Tədarikçi", false, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (byte)3, "Personal", false, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (byte)4, "Mağaza", false, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (byte)5, "Kassa", false, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "DcCurrencies",
                columns: new[] { "CurrencyCode", "CurrencyDesc", "ExchangeRate" },
                values: new object[,]
                {
                    { "AZN", "₼ AZN", 1f },
                    { "EUR", "€ EURO", 1.67f },
                    { "USD", "$ DOLLAR", 1.7f }
                });

            migrationBuilder.InsertData(
                table: "DcForms",
                columns: new[] { "FormCode", "FormDesc" },
                values: new object[,]
                {
                    { "CurrAccs", "CurrAccs" },
                    { "Products", "Products" }
                });

            migrationBuilder.InsertData(
                table: "DcHierarchies",
                columns: new[] { "HierarchyCode", "HierarchyDesc", "HierarchyLevel", "HierarchyParentCode", "Order", "Slug" },
                values: new object[] { "Root", "Root", 0, null, 0, null });

            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[] { "ofs01", 0m, false, "Mərkəz Ofisi", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "DcPaymentTypes",
                columns: new[] { "PaymentTypeCode", "PaymentTypeDesc" },
                values: new object[,]
                {
                    { (byte)1, "Nağd" },
                    { (byte)2, "Nağdsız" }
                });

            migrationBuilder.InsertData(
                table: "DcPriceTypes",
                columns: new[] { "PriceTypeCode", "PriceTypeDesc" },
                values: new object[] { "STD", "Standart" });

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "CustomCurrencyCode", "ProcessDesc", "ProcessDir" },
                values: new object[,]
                {
                    { "CI", null, "Sayım Artırma", (byte)1 },
                    { "CO", null, "Sayım Azaltma", (byte)2 },
                    { "CT", null, "Pul Transferi", (byte)2 },
                    { "EX", null, "Xərc", (byte)1 },
                    { "IT", null, "Mal Transferi", (byte)2 },
                    { "PA", null, "Ödəmə", (byte)2 },
                    { "PE", null, "Dovr", (byte)1 },
                    { "PL", null, "Qiymət Cədvəli", (byte)0 },
                    { "RP", null, "Alış", (byte)1 },
                    { "RPO", null, "Alış Sifarişi", (byte)1 },
                    { "RS", null, "Satış", (byte)2 },
                    { "RSO", null, "Satış Sifarişi", (byte)2 },
                    { "SB", null, "Toptan Alış", (byte)1 },
                    { "SBO", null, "Toptan Alış Sifarişi", (byte)1 },
                    { "TF", null, "Transfer", (byte)2 },
                    { "WS", null, "Toptan Satış", (byte)2 },
                    { "WSO", null, "Toptan Satış Sifarişi", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "DcProductTypes",
                columns: new[] { "ProductTypeCode", "ProductTypeDesc" },
                values: new object[,]
                {
                    { (byte)1, "Məhsul" },
                    { (byte)2, "Xərc" },
                    { (byte)3, "Servis" }
                });

            migrationBuilder.InsertData(
                table: "DcReportTypes",
                columns: new[] { "ReportTypeId", "IsDisabled", "ReportTypeDesc", "RowGuid" },
                values: new object[,]
                {
                    { (byte)0, false, "Embedded", new Guid("00000000-0000-0000-0000-000000000000") },
                    { (byte)1, false, "Grid", new Guid("00000000-0000-0000-0000-000000000000") },
                    { (byte)2, false, "Detail", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "DcRoles",
                columns: new[] { "RoleCode", "RoleDesc" },
                values: new object[,]
                {
                    { "Admin", "Administrator" },
                    { "MGZ", "Mağaza İstifadəçisi" }
                });

            migrationBuilder.InsertData(
                table: "DcTerminals",
                columns: new[] { "TerminalId", "RowGuid", "TerminalDesc", "TouchScaleFactor", "TouchUIMode" },
                values: new object[,]
                {
                    { 1, null, "Notebook", 1, false },
                    { 2, null, "Telefon", 2, true }
                });

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[,]
                {
                    { "20", null, "Barkod" },
                    { "C", null, "Cari" },
                    { "CI", null, "Sayım Artırma" },
                    { "CO", null, "Sayım Azaltma" },
                    { "CT", null, "Pul transferi" },
                    { "EX", null, "Xərclər" },
                    { "IT", null, "Mal Transferi" },
                    { "P", null, "Məhsul" },
                    { "PA", null, "Ödəmə" },
                    { "RP", null, "Pərakəndə Alış" },
                    { "RPO", null, "Pərakəndə Alış Sifarişi" },
                    { "RS", null, "Pərakəndə Satış" },
                    { "RSO", null, "Pərakəndə Satış Sifarişi" },
                    { "SB", null, "Toptan Alış" },
                    { "SBO", null, "Toptan Alış Sifarişi" },
                    { "WS", null, "Toptan Satış" },
                    { "WSO", null, "Topdan Satış Sifarişi" }
                });

            migrationBuilder.InsertData(
                table: "DcWarehouses",
                columns: new[] { "WarehouseCode", "ControlStockLevel", "IsDefault", "IsDisabled", "OfficeCode", "PermitNegativeStock", "RowGuid", "StoreCode", "WarehouseDesc", "WarehouseTypeCode", "WarnNegativeStock", "WarnStockLevelRate" },
                values: new object[] { "depo-01", false, true, false, "ofs01", false, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", "Mərkəz deposu", (byte)0, false, false });

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
                columns: new[] { "ClaimCode", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "ButunHesabatlar", "Butun Hesabatlar", (byte)2 },
                    { "CashRegs", "Kassalar", (byte)1 },
                    { "CashTransfer", "Pul Transferi", (byte)1 },
                    { "Column_ProductCost", "Son Alış Qiyməti", (byte)1 },
                    { "CountIn", "Sayım Artırma", (byte)1 },
                    { "CountOut", "Sayım Azaltma", (byte)1 },
                    { "CurrAccs", "Cari Hesablar", (byte)1 },
                    { "DiscountList", "Endirim Siyahısı", (byte)1 },
                    { "Expense", "Xərc", (byte)1 },
                    { "HierarchyFeatureType", "Özəlliyi İyerarxiyaya Bağlama", (byte)1 },
                    { "InventoryTransfer", "Mal Transferi", (byte)1 },
                    { "PaymentDetail", "Ödəmə", (byte)1 },
                    { "PosDiscount", "POS Endirimi", (byte)1 },
                    { "PriceList", "Qiymət Cədvəli", (byte)1 },
                    { "ProductFeatureType", "Məhsul Özəlliyi", (byte)1 },
                    { "Products", "Məhsullar", (byte)1 },
                    { "ReportZet", "Gün Sonu Hesabatı", (byte)1 },
                    { "RetailPurchaseInvoice", "Alış Fakturası", (byte)1 },
                    { "RetailPurchaseReturn", "Alışın Qaytarılması", (byte)1 },
                    { "RetailSaleInvoice", "Satış Fakturası", (byte)1 },
                    { "RetailSaleReturn", "Satışın Qaytarılması", (byte)1 },
                    { "Session", "Özəlliyi İyerarxiyaya Bağlama", (byte)1 },
                    { "WholesaleInvoice", "Topdan Satışın Qaytarılması", (byte)1 },
                    { "WholesaleReturn", "Topdan Satışın Qaytarılması", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CashRegPaymentTypeCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "DataLanguageCode", "FatherName", "FirstName", "IdentityNum", "IsDefault", "LastName", "NewPassword", "OfficeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "Theme", "VendorTypeCode" },
                values: new object[,]
                {
                    { "C-000001", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", (byte)3, null, null, null, null, null, false, null, "123", "ofs01", "0519678909", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "C-000002", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mudir", (byte)3, null, null, null, null, null, false, "Mudir", "123", "ofs01", "0519678909", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "C-000003", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operator", (byte)3, null, null, null, null, null, false, "Operator", "123", "ofs01", "0773628800", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "C-000004", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Satici", (byte)3, null, null, null, null, null, false, "Satici", "123", "ofs01", "0553628804", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "C-000005", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ümumi Müştəri", (byte)1, null, null, null, null, null, true, null, "123", "ofs01", null, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "kassa01", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nağd Kassa", (byte)5, null, null, null, null, null, true, null, "456", "ofs01", null, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "mgz01", null, null, null, null, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Merkez Mağaza", (byte)4, null, null, null, null, null, false, null, "456", "ofs01", "0773628800", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "DcPaymentMethods",
                columns: new[] { "PaymentMethodId", "DefaultCashRegCode", "PaymentMethodDesc", "PaymentTypeCode" },
                values: new object[,]
                {
                    { 1, null, "Nağd", (byte)1 },
                    { 2, null, "Çatdırılma zamanı nağd ödə", (byte)1 },
                    { 3, null, "Saytda nağd ödə", (byte)2 },
                    { 4, null, "Bir Kart", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "CreatedDate", "HierarchyCode", "ImagePath", "ProductCode2", "ProductDesc", "ProductFeature", "ProductTypeCode", "PromotionCode", "PromotionCode2" },
                values: new object[,]
                {
                    { "xerc01", new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Yol Xərci", null, (byte)2, null, null },
                    { "xerc02", new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "İşıq Pulu", null, (byte)2, null, null }
                });

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "CreatedDate", "HierarchyCode", "ImagePath", "ProductCode2", "ProductDesc", "ProductFeature", "ProductTypeCode", "PromotionCode", "PromotionCode2", "RetailPrice" },
                values: new object[,]
                {
                    { "test01", new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Test Məhsul 01", null, (byte)1, null, null, 4.5m },
                    { "test02", new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Test Məhsul 01", null, (byte)1, null, null, 2.5m }
                });

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[,]
                {
                    { 1, null, "", "Report_Embedded_ProductList", "\n\n\n\n\n\n--declare @StartDate date = dateadd(DAY, 1, getdate())\n--declare @StartTime time =  '00:00:00.000'\n\nselect * from (\n\nSelect pro.ProductCode\n		, pro.HierarchyCode\n		, [M?hsulun Genis Adi]= isnull(pro.HierarchyCode + ' ','')  + ProductDesc \n			+ isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') + isnull(' ' + Feature06,'') + isnull(' ' +Feature07,'')\n			+ isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') + isnull(' ' + Feature11,'')\n			+ isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \n			+ isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')\n			+ isnull(' ' + Feature23,'') + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') \n			+ isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \n		, ProductDesc\n		, Balance = isnull(ProductBalance.[depo-01],0)\n		, WholesalePrice\n		, HierarchyDesc\n		, ProductTypeCode\n		--, ProductId	\n		, ProductCost = dbo.GetProductCost(pro.ProductCode)\n		, CalcClosingStockFifo.FIFO_CORG\n		\nfrom DcProducts pro\n\nleft join DcHierarchies on pro.HierarchyCode = DcHierarchies.HierarchyCode\n--left join SiteProducts on SiteProducts.ProductCode = pro.ProductCode\nleft join ProductFeatures ON pro.ProductCode = ProductFeatures.ProductCode \nleft join ProductBalance on ProductBalance.ProductCode = pro.ProductCode\nleft join CalcClosingStockFifo on CalcClosingStockFifo.ProductCode = pro.ProductCode\n\n	--where ProductTypeCode = 1\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\n	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))\n	--and il.ProductCode = '5503'\n\n) as tablo \n	order by \ntablo.HierarchyCode \n, tablo.ProductDesc \n\n\n\n\n", (byte)0 },
                    { 2, null, "", "Report_Embedded_CurrAccList", "\n\nselect DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, Balance =ISNULL(SUM(CAST(Amount as money)),0)\n, PhoneNum\n, IsVIP\n, CurrAccTypeCode\nfrom \nDcCurrAccs \nleft join \n(\n	select CurrAccCode\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\n	from TrInvoiceLines il\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\n	where 1=1\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n\n	UNION ALL \n	\n	select CurrAccCode\n	, Amount = PaymentLoc -- 200 usd\n	from TrPaymentLines pl\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\n	where 1=1 \n	--and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\nwhere 1 = 1 \n	--and DcCurrAccs.IsVIP = 1 \n	--and balance.CurrAccCode = '1403'\ngroup by DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, PhoneNum\n, IsVIP\n, CurrAccTypeCode\norder by CurrAccDesc", (byte)0 },
                    { 3, null, "", "Report_Embedded_CashRegList", "\n\n\n\nselect DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\n, PhoneNum\n, IsVIP\n, CurrAccTypeCode\nfrom \nDcCurrAccs \nleft join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode\nwhere CurrAccTypeCode = 5 and IsDisabled = 0 and PaymentTypeCode = 1 \n	--and DcCurrAccs.IsVIP = 1 \n	--and balance.CurrAccCode = '1403'\ngroup by DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, PhoneNum\n, IsVIP\n, CurrAccTypeCode\norder by CurrAccDesc\n\n\n\n\n\n\n", (byte)0 },
                    { 4, null, "", "Report_Embedded_InvoiceReport", "\r\n--Declare @invoiceHeader nvarchar(50) = 'dd6927e4-d33c-4dc7-929c-1410c299e0a9'\r\n\r\n	select \r\n * from (\r\n	select  InvoiceLineId\r\n			,	[Marka] = isnull(' ' +  Feature02Desc,'')\r\n		  , [Ceki] = isnull(' ' + Feature04Desc,'')\r\n		  , [Reng] = isnull(' ' + Feature05Desc,'')\r\n		  , [Məhsul Tipi] = isnull(' ' + Feature06Desc,'')\r\n		  , [Soyutma Tipi] = isnull(' ' + Feature07Desc,'')\r\n		  , [BTU] = isnull(' ' + Feature09Desc,'')\r\n		  , [Ekran Ölçüsü] = isnull(' ' + Feature10Desc,'')\r\n		  , [Ekran İcazəsi] = isnull(' ' + Feature11Desc,'')\r\n		  , [Motorun Növü] = isnull(' ' + Feature12Desc,'')\r\n		  , [Həcmi] = isnull(' ' + Feature13Desc,'')\r\n		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + Feature14Desc,'')\r\n		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + Feature15Desc,'')\r\n		  , [Istehsalçı Ölkə] = isnull(' ' + Feature16Desc,'')\r\n		  , [Məhsuldarlıq] = isnull(' ' + Feature17Desc,'')\r\n		  , [Güc] = isnull(' ' + Feature18Desc,'')\r\n		  , [Tərtib Edən İstifadəçi] =( select CurrAccDesc from DcCurrAccs where CurrAccCode = TrInvoiceHeaders.CreatedUserName)\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, DcProducts.ProductCode\r\n	, ProductDesc\r\n	, QtyIn = QtyIn\r\n	, QtyOut = QtyOut\r\n	, Price\r\n	, TrInvoiceLines.PosDiscount\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, ProcessDesc\r\n	, TrInvoiceLines.CurrencyCode\r\n	, DcProducts.HierarchyCode\r\n	, HierarchyDesc\r\n	, IsReturn\r\n	, CustomsDocumentNumber\r\n	, PrintCount\r\n	, NetAmount\r\n	, LineDescription\r\n	, PriceLoc\r\n	, TrInvoiceLines.ExchangeRate\r\n	, NetAmountLoc = (QtyIn-QtyOut) * PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100\r\n	, DocumentNumber\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, DcCurrAccs.CurrAccCode\r\n	, DcCurrAccs.CurrAccDesc\r\n	, FirstName\r\n	, PhoneNum\r\n	, HeaderCreatedDate = TrInvoiceHeaders.CreatedDate\r\n	, LineCreatedDate = TrInvoiceLines.CreatedDate\r\n	, TrInvoiceHeaders.CreatedUserName\r\n	, CurrAccBalance = ISNULL((select sum((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n							 	from TrInvoiceLines il\r\n							 	left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n							 	where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode\r\n							 	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n							 	(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))														\r\n							 ), 0)\r\n							 + \r\n							 ISNULL((select sum(PaymentLoc) -- 200 usd\r\n							 	from TrPaymentLines pl\r\n							 	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							 	where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode\r\n							 		and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n							 		(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n							 ), 0)\r\n	, BalanceCode = 'M' + Convert(nvarchar, Format((select SUM(QtyIn - QtyOut) ProductBalance\r\n						from TrInvoiceLines il \r\n						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n						where il.ProductCode = TrInvoiceLines.ProductCode and WarehouseCode = TrInvoiceHeaders.WarehouseCode),'000'))\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, TrInvoiceHeaders.ToWarehouseCode\r\n	, [Depodan] = wareIn.WarehouseDesc\r\n	, [Depoya] = wareOut.WarehouseDesc\r\n	, Description\r\n	, TrInvoiceHeaders.StoreCode\r\n	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl \r\n							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)\r\n	, ProductCost\r\n	from TrInvoiceLines\r\n\r\n	join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n	left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\n	left join DcHierarchies on DcHierarchies.HierarchyCode = DcProducts.HierarchyCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = TrInvoiceLines.CurrencyCode\r\n	left join DcWarehouses wareIn on wareIn.WarehouseCode = TrInvoiceHeaders.WarehouseCode\r\n	left join DcWarehouses wareOut on wareOut.WarehouseCode = TrInvoiceHeaders.ToWarehouseCode\r\n	left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader\r\n\r\n\r\n) AS PivotTable2\r\n\r\n	order by LineCreatedDate\r\n\r\n\r\n", (byte)0 },
                    { 5, null, "", "Report_Embedded_Barcode", "\n\n\nSELECT   t2.number + 1 RepeatNumber\n	, DcProducts.ProductDesc\n	, DcProducts.WholesalePrice\n	, pb.*\nFROM    TrProductBarcodes pb\nJOIN DcProducts on DcProducts.ProductCode = pb.ProductCode\nJOIN    master.dbo.spt_values t2 ON t2.type = 'P' AND t2.number < pb.Qty\n", (byte)0 },
                    { 11, null, "", "Xərclər", "\n\n\n\n\n\n\n\nselect Price\n, ProductDesc\n, CurrencyCode\n, NetAmountLoc\n, DocumentDate \n, LineDescription\n, StoreCode\nfrom TrInvoiceLines\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\nwhere ProcessCode = 'EX'", (byte)1 },
                    { 12, null, "", "Pulun Hərəkəti", "\n\n\n\nselect  PaymentLineId\n, TrPaymentHeaders.PaymentHeaderId\n, TrPaymentHeaders.InvoiceHeaderId\n, InvoiceNumber = tph.DocumentNumber\n, DcPaymentTypes.PaymentTypeCode\n, PaymentTypeDesc\n, PaymentLoc\n, Payment\n, CurrencyCode\n, LineDescription\n, TrPaymentHeaders.DocumentNumber\n, TrPaymentHeaders.DocumentDate\n, TrPaymentHeaders.DocumentTime\n, TrPaymentHeaders.OperationDate\n, TrPaymentHeaders.OperationTime\n, OperationType\n, TrPaymentHeaders.CurrAccCode\n, CashRegisterCode\n, FirstName\n, DcCurrAccs.CurrAccDesc\n, TrPaymentHeaders.StoreCode\n, tpl.CreatedDate\n, tpl.CreatedUserName\n, [Cari Hesab Balansı] = (	(select sum ((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\n	from TrInvoiceLines il\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\n	where DcCurrAccs.CurrAccCode = ih.CurrAccCode\n	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\n	(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\n		+ \n(select Sum(PaymentLoc) -- 200 usd\n	from TrPaymentLines pl\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\n	where DcCurrAccs.CurrAccCode = ph.CurrAccCode \n			and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\n			(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\n		)\n\n from TrPaymentLines tpl\nleft join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\nleft join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId\nleft Join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\nleft join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode\norder by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc\n\n\n\n", (byte)1 },
                    { 13, null, "", "Cari Hesab ilə Əməliyatlar", "\n\n\nselect 	CurrAccDesc\n	--, ProductDesc\n	, NetAmountLoc\n	, PaymentLoc\n	, [Ara Toplam] = sum(Summary) OVER (ORDER BY DocumentDate, DocumentTime )\n	, ProcessDesc\n	, DocumentNumber\n	, CurrAccCode\n	, DocumentDate\n	, DocumentTime\n	, InvoiceHeaderId\n	, PaymentHeaderId\n	, LineDescription\n	, IsReturn\n	, StoreCode\n	--, LineId\nfrom (\n	select FirstName\n	, CurrAccDesc\n	--, ProductDesc\n	, TrInvoiceHeaders.InvoiceHeaderId\n	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)\n	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\n	, PaymentLoc= 0\n	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\n	, ProcessDesc = ProcessDesc\n	, DocumentNumber\n	, TrInvoiceHeaders.StoreCode\n	, TrInvoiceHeaders.CurrAccCode\n	, TrInvoiceHeaders.DocumentDate\n	, TrInvoiceHeaders.DocumentTime\n	, LineDescription = TrInvoiceHeaders.Description\n	, TrInvoiceHeaders.ProcessCode\n	, IsReturn\n	--, LineId = InvoiceLineId\n	from TrInvoiceLines \n	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\n	left join DcProcesses on DcProcesses.ProcessCode = TrInvoiceHeaders.ProcessCode\n	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode\n	group by FirstName\n			, CurrAccDesc\n			, ProcessDesc\n			, DocumentNumber\n			, TrInvoiceHeaders.InvoiceHeaderId\n			, TrInvoiceHeaders.CurrAccCode\n			, TrInvoiceHeaders.DocumentDate	\n			, TrInvoiceHeaders.DocumentTime\n			, TrInvoiceHeaders.Description\n			, TrInvoiceHeaders.StoreCode\n	, TrInvoiceHeaders.ProcessCode\n	, IsReturn\n	\n	UNION ALL \n	\n	select FirstName\n	--, ProductCode = ''\n	, CurrAccDesc = CurrAccDesc\n	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\n	, TrPaymentHeaders.PaymentHeaderId\n	, NetAmountLoc = 0\n	, PaymentLoc\n	, Summary = PaymentLoc\n	, ProcessDesc = N'Ödəniş'\n	, DocumentNumber\n	, TrPaymentHeaders.StoreCode\n	, TrPaymentHeaders.CurrAccCode\n	, DocumentDate = TrPaymentHeaders.OperationDate\n	, DocumentTime = TrPaymentHeaders.OperationTime\n	, LineDescription\n	, ProcessCode = 'PA'\n	, IsReturn = CAST(0 as bit)\n	--, LineId = PaymentLineId\n	from TrPaymentLines\n	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\n	left join DcCurrAccs  on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode	\n\n) as CurrAccExtra where 1=1 {CurrAccCode}\n\norder by DocumentDate, DocumentTime", (byte)1 },
                    { 14, null, "", "Məhsulun Hərəkəti", "\n\n\n\n\nselect  InvoiceLineId\n, TrInvoiceHeaders.InvoiceHeaderId\n, TrInvoiceLines.ProductCode\n, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')\n		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \n		  + isnull(' ' + Feature29,'') \n\n\n, ProductDesc\n, QtyIn\n, QtyOut\n, Price\n, PriceLoc\n, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))\n, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))\n, Amount\n, NetAmountLoc\n, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines \n		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId\n		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)\n, LineDescription\n, SalesPersonCode\n, CurrencyCode\n, ExchangeRate\n, TrInvoiceHeaders.ProcessCode\n, ProcessDesc\n, DocumentNumber\n, IsReturn\n, ProductCost\n, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)\n, DocumentDate\n, DocumentTime\n, OperationDate\n, OperationTime\n, Description\n, TrInvoiceLines.PosDiscount\n, TrInvoiceHeaders.CurrAccCode\n, DcCurrAccs .CurrAccDesc\n, DcCurrAccTypes.CurrAccTypeDesc\n, DcCurrAccs.CurrAccTypeCode\n, TrInvoiceHeaders.OfficeCode\n, TrInvoiceHeaders.StoreCode\n, WarehouseCode\n, CustomsDocumentNumber\n, PosTerminalId\n, IsSuspended\n, IsCompleted\n, PrintCount\n, IsSalesViaInternet\n, IsLocked\n, DcProducts.ProductTypeCode\n, ProductTypeDesc\n, UsePos\n, PromotionCode\n, TaxRate\n, RetailPrice\n, PurchasePrice\n, WholesalePrice\n, TrInvoiceLines.CreatedDate\n, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il where il.ProductCode = TrInvoiceLines .ProductCode)\n, TrInvoiceHeaders.CreatedUserName\n, ImagePath\n--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  \n\nfrom TrInvoiceLines \nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\n\n\norder by DocumentDate, DocumentTime\n\n\n", (byte)1 },
                    { 15, null, "", "Gəlir", "\n\n\nSELECT Maya = (-1)*(case when Dvijok.ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0) else 0 end)\n, Menfeet = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0)) else 0 end)\n, [Net Menfeet] = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), ProductCost),0)) else 0 end) - Xərc\n, *\nFROM (\nselect  InvoiceLineId\n, TrInvoiceHeaders.InvoiceHeaderId\n, TrInvoiceLines.ProductCode\n, ProductDesc\n, Qty = (QtyIn-QtyOut)*(-1)\n, Price\n, PriceLoc\n, Amount\n, TrInvoiceLines.PosDiscount\n, QtyIn\n, QtyOut\n, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end\n, Satis = (-1)*(case when TrInvoiceHeaders.ProcessCode = 'RS' then (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100)) else 0 end)\n, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end\n, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end\n, ProductCost\n, SonQiymet = (select top 1 toplam = il.PriceLoc * (1 - (il.PosDiscount / 100))  \n					from TrInvoiceLines il\n					join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\n					where il.ProductCode = TrInvoiceLines.ProductCode\n					and (ih.ProcessCode = 'RP' or ih.ProcessCode = 'CI')\n					and ih.IsReturn = 0\n					and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\n						 (CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\n					ORDER BY ih.DocumentDate desc\n					, il.CreatedDate desc )	\n\n, LineDescription\n, SalesPersonCode\n, CurrencyCode\n, ExchangeRate\n, TrInvoiceHeaders.ProcessCode\n, ProcessDesc\n, InvoiceNumber = DocumentNumber\n, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)  / NULLIF(ProductCost,0) * 100,2)\n, DocumentDate\n, DocumentTime\n, OperationDate\n, OperationTime\n, Description\n, TrInvoiceHeaders.CurrAccCode\n, DcCurrAccs.CurrAccDesc\n, DcCurrAccTypes.CurrAccTypeDesc\n, DcCurrAccs.CurrAccTypeCode\n, TrInvoiceHeaders.OfficeCode\n, TrInvoiceHeaders.StoreCode\n, WarehouseCode\n, CustomsDocumentNumber\n, PosTerminalId\n, IsSuspended\n, IsCompleted\n, IsSalesViaInternet\n, IsLocked\n, DcProducts.ProductTypeCode\n, ProductTypeDesc\n, UsePos\n, PromotionCode\n, TaxRate\n, RetailPrice\n, PurchasePrice\n, WholesalePrice\n, TrInvoiceLines.CreatedDate\n\nfrom TrInvoiceLines \nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	\n\nwhere TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'RS', 'EX')\n--and DocumentNumber = 'RS-000012'\n) Dvijok\norder by Dvijok.DocumentDate\n\n\n\n\n\n\n\n", (byte)1 },
                    { 16, null, "", "Son Gələn Mallar", "\n\n\nselect \n [Topdan Sat. Qiy.] =  Round(WholesalePrice, 0)\n, [Maya Dəyəri.] =  Round(ProductCost, 0)\n, [%] =CONVERT(int, Round((1 - (PivotTable.ProductCost / NULLIF(PivotTable.WholesalePrice,0))) * 100, 0)) \n, *\nfrom (\n	select prdcts.ProductCode\n	, LastUpdatedDate\n	, UseInternet\n	, ProductDesc \n	, HierarchyCode \n	, FeatureCode\n	, FeatureTypeId\n	, WholesalePrice\n	, ProductCost = (select top 1  PriceLoc * (1 - (PosDiscount / 100))	\n								from TrInvoiceLines il\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\n								where il.ProductCode = prdcts.ProductCode\n								and ih.ProcessCode IN ('RP', 'CI') \n								and ih.IsReturn = 0\n								order by ih.DocumentDate desc\n										, ih.CreatedDate desc\n								)\n	, [Son Alış Günü] = (select top 1  il.LastUpdatedDate	\n								from TrInvoiceLines il\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\n								where il.ProductCode = prdcts.ProductCode\n								and ih.ProcessCode IN ('RP') \n								and ih.IsReturn = 0\n								order by ih.DocumentDate desc\n										, ih.CreatedDate desc\n								)\n	, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il \n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\n								where il.ProductCode = prdcts.ProductCode\n								and ih.WarehouseCode = 'depo-01')\n	from DcProducts prdcts\n	left join TrProductFeatures on TrProductFeatures.ProductCode = prdcts.ProductCode\n\n	where ProductTypeCode = 1\n	) pro\nPIVOT (Max(FeatureCode) FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25]) \n) AS PivotTable \norder by PivotTable.[Son Alış Günü] \n\n\n\n", (byte)1 },
                    { 17, null, "", "Depoların Qalığı", "\n\nselect DcProducts.ProductCode\n	, DcProducts.ProductDesc\n	, TrInvoiceHeaders.WarehouseCode\n	, Balance = sum(QtyIn - QtyOut)\n	, ProductCost = (select top 1 PriceLoc * (100 - PosDiscount)/100\n					from TrInvoiceLines \n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \n					{StartDate}\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\n					)\n	, Toplam = sum(QtyIn - QtyOut) * (select top 1 PriceLoc * (100 - PosDiscount)/100\n					from TrInvoiceLines \n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \n					{StartDate}\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\n					)\nfrom TrInvoiceLines\nLEFT JOIN TrInvoiceHeaders \n	ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\nLEFT JOIN DcProducts \n	on DcProducts.ProductCode = TrInvoiceLines.ProductCode\nwhere DcProducts.ProductTypeCode = 1\n{StartDate}\nGroup by DcProducts.ProductCode\n	, DcProducts.ProductDesc\n	, TrInvoiceHeaders.WarehouseCode\n\n", (byte)1 },
                    { 18, null, "", "Məhsul Kartı", "	--declare @StartDate date = dateadd(DAY, 1, getdate())\n	--declare @StartTime time =  '00:00:00.000'\n\nselect DcProducts.ProductCode\n, [Məhsulun Geniş Adı] = isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc \n		  + isnull(' ' + Feature01,'') + isnull(' ' + Feature02,'') + isnull(' ' + Feature03,'') + isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19,'') + isnull(' ' + Feature20,'')\n, ProductDesc\n, WholesalePrice\n, DcHierarchies.HierarchyCode\n, HierarchyDesc\n, ProductTypeCode\n, [01] = isnull(' ' + Feature01Desc,'')\n, [02] = isnull(' ' + Feature02Desc,'')\n, [03] = isnull(' ' + Feature03Desc,'')\n, [04] = isnull(' ' + Feature04Desc,'')\n, [05] = isnull(' ' + Feature05Desc,'')\n, [06] = isnull(' ' + Feature06Desc,'')\n, [07] = isnull(' ' + Feature07Desc,'')\n, [09] = isnull(' ' + Feature09Desc,'')\n, [10] = isnull(' ' + Feature10Desc,'')\n, [11] = isnull(' ' + Feature11Desc,'')\n, [12] = isnull(' ' + Feature12Desc,'')\n, [13] = isnull(' ' + Feature13Desc,'')\n, [14] = isnull(' ' + Feature14Desc,'')\n, [15] = isnull(' ' + Feature15Desc,'')\n, [16] = isnull(' ' + Feature16Desc,'')\n, [17] = isnull(' ' + Feature17Desc,'')\n, [18] = isnull(' ' + Feature18Desc,'')\n, [19] = isnull(' ' + Feature22Desc,'')\n, [20] = isnull(' ' + Feature23Desc,'')\n\nfrom DcProducts\n\nleft join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\n\nwhere ProductTypeCode = 1\n			\norder by isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc\n", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "DcReportVariables",
                columns: new[] { "VariableId", "ReportId", "Representative", "VariableOperator", "VariableProperty", "VariableTypeId", "VariableValue", "VariableValueType" },
                values: new object[,]
                {
                    { 1, 13, "{CurrAccCode}", "=", "CurrAccCode", (byte)2, "c-0000001", "System.String" },
                    { 2, 17, "{StartDate}", "<=", "DocumentDate", (byte)2, "08.01.2030", "System.DateTime" }
                });

            migrationBuilder.InsertData(
                table: "SettingStores",
                columns: new[] { "Id", "DesignFileFolder", "ImageFolder", "PrinterName", "StoreCode" },
                values: new object[] { 1, "C:\\Foxoft\\Foxoft Design Files", "C:\\Foxoft\\Foxoft Images", null, "mgz01" });

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

            migrationBuilder.InsertData(
                table: "TrCurrAccRoles",
                columns: new[] { "CurrAccRoleId", "CurrAccCode", "RoleCode" },
                values: new object[] { 1, "C-000001", "Admin" });

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
                    { 7, "CurrAccs", "Admin" },
                    { 8, "DiscountList", "Admin" },
                    { 9, "Expense", "Admin" },
                    { 10, "InventoryTransfer", "Admin" },
                    { 11, "PaymentDetail", "Admin" },
                    { 12, "PosDiscount", "Admin" },
                    { 13, "PriceList", "Admin" },
                    { 14, "Products", "Admin" },
                    { 15, "ReportZet", "Admin" },
                    { 16, "RetailPurchaseInvoice", "Admin" },
                    { 17, "RetailSaleInvoice", "Admin" },
                    { 18, "WholesaleInvoice", "Admin" },
                    { 19, "RetailPurchaseReturn", "Admin" },
                    { 20, "RetailSaleReturn", "Admin" },
                    { 21, "WholeSaleReturn", "Admin" },
                    { 22, "ProductFeatureType", "Admin" },
                    { 23, "HierarchyFeatureType", "Admin" },
                    { 24, "Session", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSettings_LocalCurrencyCode",
                table: "AppSettings",
                column: "LocalCurrencyCode",
                unique: true,
                filter: "[LocalCurrencyCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DcClaims_ClaimTypeId",
                table: "DcClaims",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_CashRegPaymentTypeCode",
                table: "DcCurrAccs",
                column: "CashRegPaymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAccs_CurrAccTypeCode",
                table: "DcCurrAccs",
                column: "CurrAccTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcFeatures_FeatureTypeId",
                table: "DcFeatures",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentMethods_DefaultCashRegCode",
                table: "DcPaymentMethods",
                column: "DefaultCashRegCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentMethods_PaymentTypeCode",
                table: "DcPaymentMethods",
                column: "PaymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcProcesses_CustomCurrencyCode",
                table: "DcProcesses",
                column: "CustomCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_HierarchyCode",
                table: "DcProducts",
                column: "HierarchyCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcProducts_ProductTypeCode",
                table: "DcProducts",
                column: "ProductTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcReports_ReportTypeId",
                table: "DcReports",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportVariables_ReportId",
                table: "DcReportVariables",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportVariables_VariableTypeId",
                table: "DcReportVariables",
                column: "VariableTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingStores_StoreCode",
                table: "SettingStores",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrClaimReports_ClaimCode",
                table: "TrClaimReports",
                column: "ClaimCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrClaimReports_ReportId",
                table: "TrClaimReports",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccRoles_CurrAccCode",
                table: "TrCurrAccRoles",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccRoles_RoleCode",
                table: "TrCurrAccRoles",
                column: "RoleCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrFormReports_ReportId",
                table: "TrFormReports",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrHierarchyFeatureTypes_FeatureTypeId",
                table: "TrHierarchyFeatureTypes",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_CurrAccCode",
                table: "TrInvoiceHeaders",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_DocumentNumber_ProcessCode_CurrAccCode",
                table: "TrInvoiceHeaders",
                columns: new[] { "DocumentNumber", "ProcessCode", "CurrAccCode" });

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeaders_ProcessCode",
                table: "TrInvoiceHeaders",
                column: "ProcessCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLineExts_InvoiceLineId",
                table: "TrInvoiceLineExts",
                column: "InvoiceLineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_CurrencyCode",
                table: "TrInvoiceLines",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_InvoiceHeaderId_ProductCode",
                table: "TrInvoiceLines",
                columns: new[] { "InvoiceHeaderId", "ProductCode" });

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLines_ProductCode",
                table: "TrInvoiceLines",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_CurrAccCode",
                table: "TrPaymentHeaders",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_InvoiceHeaderId",
                table: "TrPaymentHeaders",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_ProcessCode",
                table: "TrPaymentHeaders",
                column: "ProcessCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_StoreCode",
                table: "TrPaymentHeaders",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_ToCashRegCode",
                table: "TrPaymentHeaders",
                column: "ToCashRegCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_CashRegisterCode",
                table: "TrPaymentLines",
                column: "CashRegisterCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_CurrencyCode",
                table: "TrPaymentLines",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_PaymentHeaderId",
                table: "TrPaymentLines",
                column: "PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_PaymentMethodId",
                table: "TrPaymentLines",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_PaymentTypeCode",
                table: "TrPaymentLines",
                column: "PaymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentMethodDiscounts_PaymentMethodId",
                table: "TrPaymentMethodDiscounts",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPriceListHeaders_PriceTypeCode",
                table: "TrPriceListHeaders",
                column: "PriceTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPriceListLines_CurrencyCode",
                table: "TrPriceListLines",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPriceListLines_PriceListHeaderId",
                table: "TrPriceListLines",
                column: "PriceListHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPriceListLines_ProductCode",
                table: "TrPriceListLines",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPrices_ProductCode",
                table: "TrPrices",
                column: "ProductCode");

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
                name: "IX_TrProductBarcodes_Barcode",
                table: "TrProductBarcodes",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrProductBarcodes_BarcodeTypeCode",
                table: "TrProductBarcodes",
                column: "BarcodeTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductBarcodes_ProductCode",
                table: "TrProductBarcodes",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductDiscounts_DiscountId",
                table: "TrProductDiscounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductFeatures_FeatureCode_FeatureTypeId",
                table: "TrProductFeatures",
                columns: new[] { "FeatureCode", "FeatureTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrProductFeatures_FeatureTypeId",
                table: "TrProductFeatures",
                column: "FeatureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrProductHierarchies_HierarchyCode",
                table: "TrProductHierarchies",
                column: "HierarchyCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportSubQueries_ReportId",
                table: "TrReportSubQueries",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportSubQueryRelationColumns_SubQueryId",
                table: "TrReportSubQueryRelationColumns",
                column: "SubQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrRoleClaims_ClaimCode",
                table: "TrRoleClaims",
                column: "ClaimCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrRoleClaims_RoleCode",
                table: "TrRoleClaims",
                column: "RoleCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrSessions_CurrAccCode",
                table: "TrSessions",
                column: "CurrAccCode",
                unique: true);
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
                name: "DcProducts");

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
                name: "DcHierarchies");

            migrationBuilder.DropTable(
                name: "DcProductTypes");

            migrationBuilder.DropTable(
                name: "DcCurrAccs");

            migrationBuilder.DropTable(
                name: "DcProcesses");

            migrationBuilder.DropTable(
                name: "DcReportTypes");

            migrationBuilder.DropTable(
                name: "DcCurrAccTypes");

            migrationBuilder.DropTable(
                name: "DcPaymentTypes");

            migrationBuilder.DropTable(
                name: "DcCurrencies");
        }
    }
}
