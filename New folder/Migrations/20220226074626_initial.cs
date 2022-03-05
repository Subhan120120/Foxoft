using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GridViewLayout = table.Column<string>(nullable: true),
                    GetPrint = table.Column<bool>(nullable: false),
                    PrinterName = table.Column<string>(nullable: true),
                    PrinterCopyNum = table.Column<int>(nullable: false),
                    PrintDesignPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcClaims",
                columns: table => new
                {
                    ClaimCode = table.Column<string>(nullable: false),
                    ClaimDesc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcClaims", x => x.ClaimCode);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccTypes",
                columns: table => new
                {
                    CurrAccTypeCode = table.Column<byte>(nullable: false),
                    CurrAccTypeDescription = table.Column<string>(maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    IsDisabled = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccTypes", x => x.CurrAccTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcOffices",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    OfficeDesc = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)"),
                    CompanyCode = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcOffices", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcPaymentTypes",
                columns: table => new
                {
                    PaymentTypeCode = table.Column<byte>(nullable: false),
                    PaymentTypeDesc = table.Column<string>(maxLength: 100, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentTypes", x => x.PaymentTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcProcesses",
                columns: table => new
                {
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false),
                    ProcessDescription = table.Column<string>(maxLength: 150, nullable: true, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProcesses", x => x.ProcessCode);
                });

            migrationBuilder.CreateTable(
                name: "DcProductTypes",
                columns: table => new
                {
                    ProductTypeCode = table.Column<byte>(nullable: false),
                    ProductTypeDesc = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProductTypes", x => x.ProductTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ReportName = table.Column<string>(nullable: true),
                    ReportQuery = table.Column<string>(nullable: true),
                    ReportLayout = table.Column<string>(nullable: true),
                    ReportFilter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DcRoles",
                columns: table => new
                {
                    RoleCode = table.Column<string>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    RoleDesc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcRoles", x => x.RoleCode);
                });

            migrationBuilder.CreateTable(
                name: "DcStores",
                columns: table => new
                {
                    StoreCode = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    StoreDesc = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)"),
                    CompanyCode = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcStores", x => x.StoreCode);
                });

            migrationBuilder.CreateTable(
                name: "DcTerminals",
                columns: table => new
                {
                    TerminalCode = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    TerminalDesc = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)"),
                    IsDisabled = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcTerminals", x => x.TerminalCode);
                });

            migrationBuilder.CreateTable(
                name: "DcVariables",
                columns: table => new
                {
                    VariableCode = table.Column<string>(maxLength: 5, nullable: false),
                    VariableDesc = table.Column<string>(maxLength: 150, nullable: true),
                    LastNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcVariables", x => x.VariableCode);
                });

            migrationBuilder.CreateTable(
                name: "DcWarehouses",
                columns: table => new
                {
                    WarehouseCode = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    WarehouseDesc = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)"),
                    WarehouseTypeCode = table.Column<byte>(nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: true, defaultValueSql: "space(0)"),
                    StoreCode = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "space(0)"),
                    PermitNegativeStock = table.Column<bool>(nullable: false),
                    WarnNegativeStock = table.Column<bool>(nullable: false),
                    ControlStockLevel = table.Column<bool>(nullable: false),
                    WarnStockLevelRate = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcWarehouses", x => x.WarehouseCode);
                });

            migrationBuilder.CreateTable(
                name: "sysdiagrams",
                columns: table => new
                {
                    diagram_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 128, nullable: false),
                    principal_id = table.Column<int>(nullable: false),
                    version = table.Column<int>(nullable: true),
                    definition = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.sysdiagrams", x => x.diagram_id);
                });

            migrationBuilder.CreateTable(
                name: "TrShipmentHeaders",
                columns: table => new
                {
                    ShipmentHeaderId = table.Column<Guid>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ShipTypeCode = table.Column<byte>(nullable: false),
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    ShippingNumber = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    ShippingDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    ShippingTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    CustomsDocumentNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "space(0)"),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false),
                    ShippingPostalAddressId = table.Column<Guid>(maxLength: 60, nullable: false, defaultValueSql: "space(0)"),
                    CompanyCode = table.Column<decimal>(maxLength: 10, nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    WarehouseCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    ToWarehouseCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    IsOrderBase = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsPrinted = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsTransferApproved = table.Column<bool>(nullable: false),
                    TransferApprovedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrShipmentHeaders", x => x.ShipmentHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccs",
                columns: table => new
                {
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrAccTypeCode = table.Column<byte>(nullable: false),
                    CompanyCode = table.Column<byte>(nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false, defaultValueSql: "space(0)"),
                    LastName = table.Column<string>(maxLength: 60, nullable: true, defaultValueSql: "space(0)"),
                    FatherName = table.Column<string>(maxLength: 60, nullable: true, defaultValueSql: "space(0)"),
                    NewPassword = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    IdentityNum = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "space(0)"),
                    TaxNum = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "space(0)"),
                    DataLanguageCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    CreditLimit = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    IsVIP = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    CustomerTypeCode = table.Column<byte>(nullable: false),
                    VendorTypeCode = table.Column<byte>(nullable: false),
                    CustomerPosDiscountRate = table.Column<double>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false),
                    BonusCardNum = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    Address = table.Column<string>(maxLength: 150, nullable: true, defaultValueSql: "space(0)"),
                    PhoneNum = table.Column<string>(maxLength: 150, nullable: true, defaultValueSql: "space(0)"),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true, defaultValue: new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccs", x => x.CurrAccCode);
                    table.ForeignKey(
                        name: "FK_DcCurrAccs_DcCurrAccTypes_CurrAccTypeCode",
                        column: x => x.CurrAccTypeCode,
                        principalTable: "DcCurrAccTypes",
                        principalColumn: "CurrAccTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcProducts",
                columns: table => new
                {
                    ProductCode = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Barcode = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "space(0)"),
                    ProductTypeCode = table.Column<byte>(nullable: false),
                    UsePos = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    PromotionCode = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    PromotionCode2 = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    TaxRate = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    PosDiscount = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    IsDisabled = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    RetailPrice = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    PurchasePrice = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    WholesalePrice = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    UseInternet = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    ProductDescription = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProducts", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                        column: x => x.ProductTypeCode,
                        principalTable: "DcProductTypes",
                        principalColumn: "ProductTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrRoleClaims",
                columns: table => new
                {
                    RoleClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    RoleCode = table.Column<string>(nullable: false),
                    ClaimCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrRoleClaims", x => x.RoleClaimId);
                    table.ForeignKey(
                        name: "FK_TrRoleClaims_DcClaims_ClaimCode",
                        column: x => x.ClaimCode,
                        principalTable: "DcClaims",
                        principalColumn: "ClaimCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrRoleClaims_DcRoles_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "DcRoles",
                        principalColumn: "RoleCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrShipmentLines",
                columns: table => new
                {
                    ShipmentLineId = table.Column<Guid>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    ShipmentHeaderId = table.Column<Guid>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true, defaultValueSql: "space(0)"),
                    ColorCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    ProductDimensionCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    Qty = table.Column<int>(nullable: false),
                    SalespersonCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    LineDescription = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "space(0)"),
                    UsedBarcode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    Price = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrShipmentLines", x => x.ShipmentLineId);
                    table.ForeignKey(
                        name: "FK_TrShipmentLines_TrShipmentHeaders_ShipmentHeaderId",
                        column: x => x.ShipmentHeaderId,
                        principalTable: "TrShipmentHeaders",
                        principalColumn: "ShipmentHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrCurrAccRoles",
                columns: table => new
                {
                    CurrAccRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    CurrAccCode = table.Column<string>(nullable: true),
                    RoleCode = table.Column<string>(nullable: true)
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
                    InvoiceHeaderId = table.Column<Guid>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    RelatedInvoiceId = table.Column<Guid>(nullable: true),
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    DocumentNumber = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    IsReturn = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    Description = table.Column<string>(maxLength: 200, nullable: true, defaultValueSql: "space(0)"),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: true),
                    OfficeCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    WarehouseCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    CustomsDocumentNumber = table.Column<string>(maxLength: 30, nullable: true),
                    PosTerminalId = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    IsSuspended = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IsCompleted = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IsPrinted = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    FiscalPrintedState = table.Column<byte>(nullable: false, defaultValueSql: "space(0)"),
                    IsSalesViaInternet = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IsLocked = table.Column<bool>(nullable: false, defaultValueSql: "0")
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
                });

            migrationBuilder.CreateTable(
                name: "TrFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrFeatures_DcFeatures_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "DcFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrFeatures_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceLines",
                columns: table => new
                {
                    InvoiceLineId = table.Column<Guid>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InvoiceHeaderId = table.Column<Guid>(nullable: false),
                    RelatedLineId = table.Column<Guid>(nullable: true),
                    ProductCode = table.Column<string>(maxLength: 30, nullable: false),
                    Qty = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    Price = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    Amount = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    PosDiscount = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    DiscountCampaign = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    NetAmount = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    VatRate = table.Column<float>(nullable: false, defaultValueSql: "0"),
                    LineDescription = table.Column<string>(maxLength: 100, nullable: true, defaultValueSql: "space(0)"),
                    SalesPersonCode = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: true, defaultValueSql: "space(0)"),
                    ExchangeRate = table.Column<double>(nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceLines", x => x.InvoiceLineId);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentHeaders",
                columns: table => new
                {
                    PaymentHeaderId = table.Column<Guid>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    InvoiceHeaderId = table.Column<Guid>(nullable: true, defaultValueSql: "space(0)"),
                    DocumentNumber = table.Column<string>(nullable: true, defaultValueSql: "space(0)"),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    InvoiceNumber = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    Description = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "convert(varchar(10), GETDATE(), 108)"),
                    CompanyCode = table.Column<decimal>(nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    PosterminalId = table.Column<short>(nullable: false, defaultValueSql: "space(0)"),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    ExchangeRate = table.Column<double>(maxLength: 60, nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPaymentHeaders", x => x.PaymentHeaderId);
                    table.ForeignKey(
                        name: "FK_TrPaymentHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentLines",
                columns: table => new
                {
                    PaymentLineId = table.Column<Guid>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: true, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    PaymentHeaderId = table.Column<Guid>(nullable: false),
                    PaymentTypeCode = table.Column<byte>(nullable: false),
                    Payment = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    LineDescription = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "space(0)"),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    ExchangeRate = table.Column<double>(nullable: false, defaultValueSql: "0"),
                    BankId = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPaymentLines", x => x.PaymentLineId);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                        column: x => x.PaymentHeaderId,
                        principalTable: "TrPaymentHeaders",
                        principalColumn: "PaymentHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                        column: x => x.PaymentTypeCode,
                        principalTable: "DcPaymentTypes",
                        principalColumn: "PaymentTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "Id", "GetPrint", "GridViewLayout", "PrintDesignPath", "PrinterCopyNum", "PrinterName" },
                values: new object[] { 1, false, @"<XtraSerializer version=""1.0"" application=""View"">
  <property name=""#LayoutVersion"" />
  <property name=""#LayoutScaleFactor"">@1,Width=1@1,Height=1</property>
  <property name=""Appearance"" isnull=""true"" iskey=""true"">
    <property name=""Row"" iskey=""true"" value=""Row"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
      <property name=""Font"">Tahoma, 12pt</property>
    </property>
    <property name=""FooterPanel"" iskey=""true"" value=""FooterPanel"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
      <property name=""Font"">Tahoma, 12pt</property>
    </property>
  </property>
  <property name=""OptionsBehavior"" isnull=""true"" iskey=""true"">
    <property name=""Editable"">false</property>
  </property>
  <property name=""OptionsView"" isnull=""true"" iskey=""true"">
    <property name=""ColumnHeaderAutoHeight"">True</property>
    <property name=""ShowAutoFilterRow"">true</property>
    <property name=""ShowGroupPanel"">false</property>
    <property name=""ShowIndicator"">false</property>
  </property>
  <property name=""FixedLineWidth"">2</property>
  <property name=""IndicatorWidth"">-1</property>
  <property name=""ColumnPanelRowHeight"">-1</property>
  <property name=""RowSeparatorHeight"">0</property>
  <property name=""FooterPanelHeight"">-1</property>
  <property name=""HorzScrollVisibility"">Auto</property>
  <property name=""VertScrollVisibility"">Auto</property>
  <property name=""RowHeight"">-1</property>
  <property name=""GroupRowHeight"">-1</property>
  <property name=""GroupFormat"">{0}: [#image]{1} {2}</property>
  <property name=""ChildGridLevelName"" />
  <property name=""VertScrollTipFieldName"" />
  <property name=""PreviewFieldName"" />
  <property name=""GroupPanelText"" />
  <property name=""NewItemRowText"" />
  <property name=""LevelIndent"">-1</property>
  <property name=""PreviewIndent"">-1</property>
  <property name=""PreviewLineCount"">-1</property>
  <property name=""ScrollStyle"">LiveVertScroll, LiveHorzScroll</property>
  <property name=""FocusRectStyle"">CellFocus</property>
  <property name=""HorzScrollStep"">0</property>
  <property name=""ActiveFilterEnabled"">true</property>
  <property name=""ViewCaptionHeight"">-1</property>
  <property name=""Columns"" iskey=""true"" value=""0"" />
  <property name=""ViewCaption"" />
  <property name=""BorderStyle"">Default</property>
  <property name=""SynchronizeClones"">true</property>
  <property name=""DetailTabHeaderLocation"">Top</property>
  <property name=""Name"">gridView1</property>
  <property name=""DetailHeight"">350</property>
  <property name=""Tag"" isnull=""true"" />
  <property name=""GroupSummary"" iskey=""true"" value=""0"" />
  <property name=""ActiveFilterString"" />
  <property name=""FormatRules"" iskey=""true"" value=""0"" />
  <property name=""FormatConditions"" iskey=""true"" value=""0"" />
  <property name=""GroupSummarySortInfoState"" />
  <property name=""FindFilterText"" />
  <property name=""FindPanelVisible"">false</property>
</XtraSerializer>", null, 0, null });

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "ClaimDesc" },
                values: new object[] { "PosDiscount", "POS Endirimi" });

            migrationBuilder.InsertData(
                table: "DcCurrAccTypes",
                columns: new[] { "CurrAccTypeCode", "CurrAccTypeDescription", "IsDisabled", "RowGuid" },
                values: new object[,]
                {
                    { (byte)1, "Müştəri", false, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (byte)2, "Tədarikçi", false, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (byte)3, "Personal", false, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[,]
                {
                    { "OFS01", 0m, false, "Bakıxanov Ofisi", new Guid("00000000-0000-0000-0000-000000000000") },
                    { "OFS02", 0m, false, "Elmlər Ofisi", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "DcPaymentTypes",
                columns: new[] { "PaymentTypeCode", "PaymentTypeDesc" },
                values: new object[,]
                {
                    { (byte)1, "Nağd" },
                    { (byte)2, "Visa" }
                });

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "ProcessDescription" },
                values: new object[,]
                {
                    { "RS", "Pərakəndə Satış" },
                    { "RP", "Pərakəndə Alış" },
                    { "P", "Ödəmə" },
                    { "SB", "Toptan Alış" },
                    { "W", "Toptan Satış" },
                    { "EX", "Xərclər" }
                });

            migrationBuilder.InsertData(
                table: "DcProductTypes",
                columns: new[] { "ProductTypeCode", "ProductTypeDesc" },
                values: new object[,]
                {
                    { (byte)2, "Xərc" },
                    { (byte)1, "Məhsul" }
                });

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "Id", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery" },
                values: new object[] { new Guid("01fdab8b-0c03-4bdb-bc07-c03ff743ce45"), null, null, "Satis", "select * from TrInvoiceLines" });

            migrationBuilder.InsertData(
                table: "DcRoles",
                columns: new[] { "RoleCode", "RoleDesc" },
                values: new object[,]
                {
                    { "Admin", "Administrator" },
                    { "MGZ", "Mağaza İstifadəçisi" }
                });

            migrationBuilder.InsertData(
                table: "DcStores",
                columns: new[] { "StoreCode", "CompanyCode", "IsDisabled", "RowGuid", "StoreDesc" },
                values: new object[,]
                {
                    { "mgz-01", 0m, false, new Guid("00000000-0000-0000-0000-000000000000"), "Bakıxanov" },
                    { "mgz-02", 0m, false, new Guid("00000000-0000-0000-0000-000000000000"), "Elmlər" }
                });

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[,]
                {
                    { "CA", null, "Cari" },
                    { "PR", null, "Məhsul" },
                    { "RS", null, "Pərakəndə Satış" },
                    { "RP", null, "Pərakəndə Alış" },
                    { "P", null, "Ödəmə" },
                    { "SB", null, "Toptan Alış" },
                    { "W", null, "Toptan Satış" },
                    { "EX", null, "Xərclər" }
                });

            migrationBuilder.InsertData(
                table: "DcWarehouses",
                columns: new[] { "WarehouseCode", "ControlStockLevel", "IsDefault", "IsDisabled", "PermitNegativeStock", "RowGuid", "WarehouseDesc", "WarehouseTypeCode", "WarnNegativeStock", "WarnStockLevelRate" },
                values: new object[,]
                {
                    { "depo-01", false, false, false, false, new Guid("00000000-0000-0000-0000-000000000000"), "Bakıxanov deposu", (byte)0, false, false },
                    { "depo-02", false, false, false, false, new Guid("00000000-0000-0000-0000-000000000000"), "Elmlər deposu", (byte)0, false, false }
                });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "CompanyCode", "ConfirmPassword", "CurrAccTypeCode", "CustomerPosDiscountRate", "CustomerTypeCode", "FirstName", "IsDisabled", "LastName", "NewPassword", "PhoneNum", "RowGuid", "VendorTypeCode" },
                values: new object[,]
                {
                    { "CA-1", (byte)0, null, (byte)1, 0.0, (byte)0, "Sübhan", false, "Hüseynzadə", "123", "0519678909", new Guid("00000000-0000-0000-0000-000000000000"), (byte)0 },
                    { "CA-2", (byte)0, null, (byte)2, 0.0, (byte)0, "Orxan", false, "Sederek", "456", "0773628800", new Guid("00000000-0000-0000-0000-000000000000"), (byte)0 },
                    { "CA-3", (byte)0, null, (byte)3, 0.0, (byte)0, "Vagif", false, "Mustafayev", "456", "0553628804", new Guid("00000000-0000-0000-0000-000000000000"), (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "Barcode", "ProductDescription", "ProductTypeCode", "RetailPrice" },
                values: new object[,]
                {
                    { "test01", "123456", "Papaq", (byte)1, 4.5 },
                    { "test02", "2000000000013", "Salvar", (byte)1, 2.5 }
                });

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "Barcode", "ProductDescription", "ProductTypeCode" },
                values: new object[,]
                {
                    { "xerc01", "", "Yol Xerci", (byte)2 },
                    { "xerc02", "", "Isiq Pulu", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[] { 1, "PosDiscount", "Admin" });

            migrationBuilder.InsertData(
                table: "TrCurrAccRoles",
                columns: new[] { "CurrAccRoleId", "CurrAccCode", "RoleCode" },
                values: new object[] { 1, "CA-1", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_CurrAccTypeCode",
                table: "DcCurrAccs",
                column: "CurrAccTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeCode",
                table: "DcProducts",
                column: "ProductTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccRoles_CurrAccCode",
                table: "TrCurrAccRoles",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccRoles_RoleCode",
                table: "TrCurrAccRoles",
                column: "RoleCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_ProductCode",
                table: "TrFeatures",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_FeatureId_ProductCode",
                table: "TrFeatures",
                columns: new[] { "FeatureId", "ProductCode" },
                unique: true,
                filter: "[ProductCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CurrAccCode",
                table: "TrInvoiceHeaders",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaderId",
                table: "TrInvoiceLines",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCode",
                table: "TrInvoiceLines",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_InvoiceHeaderId",
                table: "TrPaymentHeaders",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_PaymentHeaderId",
                table: "TrPaymentLines",
                column: "PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_PaymentTypeCode",
                table: "TrPaymentLines",
                column: "PaymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrRoleClaims_ClaimCode",
                table: "TrRoleClaims",
                column: "ClaimCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrRoleClaims_RoleCode",
                table: "TrRoleClaims",
                column: "RoleCode");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentHeaderID",
                table: "TrShipmentLines",
                column: "ShipmentHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "DcOffices");

            migrationBuilder.DropTable(
                name: "DcProcesses");

            migrationBuilder.DropTable(
                name: "DcReports");

            migrationBuilder.DropTable(
                name: "DcStores");

            migrationBuilder.DropTable(
                name: "DcTerminals");

            migrationBuilder.DropTable(
                name: "DcVariables");

            migrationBuilder.DropTable(
                name: "DcWarehouses");

            migrationBuilder.DropTable(
                name: "sysdiagrams");

            migrationBuilder.DropTable(
                name: "TrCurrAccRoles");

            migrationBuilder.DropTable(
                name: "TrFeatures");

            migrationBuilder.DropTable(
                name: "TrInvoiceLines");

            migrationBuilder.DropTable(
                name: "TrPaymentLines");

            migrationBuilder.DropTable(
                name: "TrRoleClaims");

            migrationBuilder.DropTable(
                name: "TrShipmentLines");

            migrationBuilder.DropTable(
                name: "DcFeatures");

            migrationBuilder.DropTable(
                name: "DcProducts");

            migrationBuilder.DropTable(
                name: "TrPaymentHeaders");

            migrationBuilder.DropTable(
                name: "DcPaymentTypes");

            migrationBuilder.DropTable(
                name: "DcClaims");

            migrationBuilder.DropTable(
                name: "DcRoles");

            migrationBuilder.DropTable(
                name: "TrShipmentHeaders");

            migrationBuilder.DropTable(
                name: "DcProductTypes");

            migrationBuilder.DropTable(
                name: "TrInvoiceHeaders");

            migrationBuilder.DropTable(
                name: "DcCurrAccs");

            migrationBuilder.DropTable(
                name: "DcCurrAccTypes");
        }
    }
}
