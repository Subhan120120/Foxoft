using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class OldDatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrClaimReport_DcClaims_ClaimCode",
                table: "TrClaimReport");

            migrationBuilder.DropForeignKey(
                name: "FK_TrClaimReport_DcReports_ReportId",
                table: "TrClaimReport");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceLineExt");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeType_BarcodeTypeCode",
                table: "TrProductBarcodes");

            migrationBuilder.DropTable(
                name: "sysdiagrams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrInvoiceLineExt",
                table: "TrInvoiceLineExt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrClaimReport",
                table: "TrClaimReport");

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
                keyValue: "PurchaseIsReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "SaleIsReturn");

            migrationBuilder.RenameTable(
                name: "TrInvoiceLineExt",
                newName: "TrInvoiceLineExts");

            migrationBuilder.RenameTable(
                name: "TrClaimReport",
                newName: "TrClaimReports");

            migrationBuilder.RenameTable(
                name: "DcBarcodeType",
                newName: "DcBarcodeTypes");

            migrationBuilder.RenameColumn(
                name: "LastPurchasePrice",
                table: "TrInvoiceLines",
                newName: "ProductCost");

            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceLineExt_InvoiceLineId",
                table: "TrInvoiceLineExts",
                newName: "IX_TrInvoiceLineExts_InvoiceLineId");

            migrationBuilder.RenameIndex(
                name: "IX_TrClaimReport_ReportId",
                table: "TrClaimReports",
                newName: "IX_TrClaimReports_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_TrClaimReport_ClaimCode",
                table: "TrClaimReports",
                newName: "IX_TrClaimReports_ClaimCode");

            migrationBuilder.AlterColumn<string>(
                name: "HierarchyCode",
                table: "TrProductHierarchies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrProductHierarchies",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)")
                .Annotation("Relational:ColumnOrder", 1);

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
                name: "CompanyCode",
                table: "TrPaymentHeaders",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
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

            migrationBuilder.AlterColumn<int>(
                name: "FeatureTypeId",
                table: "TrHierarchyFeatureTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "HierarchyCode",
                table: "TrHierarchyFeatureTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 0);

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

            migrationBuilder.AlterColumn<string>(
                name: "VariableValueType",
                table: "DcReportVariables",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "CompanyCode",
                table: "DcCurrAccs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddColumn<bool>(
                name: "AutoSave",
                table: "AppSettings",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<decimal>(
                name: "LineExpences",
                table: "TrInvoiceLineExts",
                type: "money",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrInvoiceLineExts",
                table: "TrInvoiceLineExts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrClaimReports",
                table: "TrClaimReports",
                column: "ClaimReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcBarcodeTypes",
                table: "DcBarcodeTypes",
                column: "BarcodeTypeCode");

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

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "GridViewLayout",
                value: "<XtraSerializer version=\"1.0\" application=\"View\">\n	<property name=\"#LayoutVersion\" />\n	<property name=\"#LayoutScaleFactor\">@1,Width=1@1,Height=1</property>\n	<property name=\"Appearance\" isnull=\"true\" iskey=\"true\">\n		<property name=\"Row\" iskey=\"true\" value=\"Row\">\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\n				<property name=\"UseFont\">true</property>\n			</property>\n			<property name=\"Font\">Tahoma, 12pt</property>\n		</property>\n		<property name=\"FooterPanel\" iskey=\"true\" value=\"FooterPanel\">\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\n				<property name=\"UseFont\">true</property>\n			</property>\n			<property name=\"Font\">Tahoma, 12pt</property>\n		</property>\n	</property>\n	<property name=\"OptionsBehavior\" isnull=\"true\" iskey=\"true\">\n		<property name=\"Editable\">false</property>\n		<property name=\"ReadOnly\">true</property>\n	</property>\n	<property name=\"OptionsCustomization\" isnull=\"true\" iskey=\"true\">\n		<property name=\"AllowRowSizing\">true</property>\n	</property>\n	<property name=\"OptionsView\" isnull=\"true\" iskey=\"true\">\n		<property name=\"ColumnHeaderAutoHeight\">True</property>\n		<property name=\"ShowAutoFilterRow\">true</property>\n		<property name=\"ShowGroupPanel\">false</property>\n		<property name=\"ShowIndicator\">false</property>\n	</property>\n	<property name=\"OptionsFind\" isnull=\"true\" iskey=\"true\">\n		<property name=\"FindMode\">Always</property>\n		<property name=\"FindDelay\">100</property>\n	</property>\n	<property name=\"FixedLineWidth\">2</property>\n	<property name=\"IndicatorWidth\">-1</property>\n	<property name=\"ColumnPanelRowHeight\">-1</property>\n	<property name=\"RowSeparatorHeight\">0</property>\n	<property name=\"FooterPanelHeight\">-1</property>\n	<property name=\"HorzScrollVisibility\">Auto</property>\n	<property name=\"VertScrollVisibility\">Auto</property>\n	<property name=\"RowHeight\">-1</property>\n	<property name=\"GroupRowHeight\">-1</property>\n	<property name=\"GroupFormat\">{0}: [#image]{1} {2}</property>\n	<property name=\"ChildGridLevelName\" />\n	<property name=\"VertScrollTipFieldName\" />\n	<property name=\"PreviewFieldName\" />\n	<property name=\"GroupPanelText\" />\n	<property name=\"NewItemRowText\" />\n	<property name=\"LevelIndent\">-1</property>\n	<property name=\"PreviewIndent\">-1</property>\n	<property name=\"PreviewLineCount\">-1</property>\n	<property name=\"ScrollStyle\">LiveVertScroll, LiveHorzScroll</property>\n	<property name=\"FocusRectStyle\">CellFocus</property>\n	<property name=\"HorzScrollStep\">0</property>\n	<property name=\"ActiveFilterEnabled\">true</property>\n	<property name=\"ViewCaptionHeight\">-1</property>\n	<property name=\"Columns\" iskey=\"true\" value=\"0\" />\n	<property name=\"ViewCaption\" />\n	<property name=\"BorderStyle\">Default</property>\n	<property name=\"SynchronizeClones\">true</property>\n	<property name=\"DetailTabHeaderLocation\">Top</property>\n	<property name=\"Name\">gridView1</property>\n	<property name=\"DetailHeight\">350</property>\n	<property name=\"Tag\" isnull=\"true\" />\n	<property name=\"GroupSummary\" iskey=\"true\" value=\"0\" />\n	<property name=\"ActiveFilterString\" />\n	<property name=\"FormatRules\" iskey=\"true\" value=\"0\" />\n	<property name=\"FormatConditions\" iskey=\"true\" value=\"0\" />\n	<property name=\"GroupSummarySortInfoState\" />\n	<property name=\"FindFilterText\" />\n	<property name=\"FindPanelVisible\">true</property>\n</XtraSerializer>");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "HierarchyFeatureType", "Özəlliyi İyerarxiyaya Bağlama", (byte)1 },
                    { "ProductFeatureType", "Məhsul Özəlliyi", (byte)1 },
                    { "Session", "Özəlliyi İyerarxiyaya Bağlama", (byte)1 }
                });

            

            migrationBuilder.InsertData(
                table: "DcPriceTypes",
                columns: new[] { "PriceTypeCode", "PriceTypeDesc" },
                values: new object[] { "STD", "Standart" });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[,]
                {
                    { 93, "ProductFeatureType", "Admin" },
                    { 94, "HierarchyFeatureType", "Admin" },
                    { 95, "Session", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrSessions_CurrAccCode",
                table: "TrSessions",
                column: "CurrAccCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrClaimReports_DcClaims_ClaimCode",
                table: "TrClaimReports",
                column: "ClaimCode",
                principalTable: "DcClaims",
                principalColumn: "ClaimCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrClaimReports_DcReports_ReportId",
                table: "TrClaimReports",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLineExts_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceLineExts",
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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders",
                column: "ToCashRegCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeTypes_BarcodeTypeCode",
                table: "TrProductBarcodes",
                column: "BarcodeTypeCode",
                principalTable: "DcBarcodeTypes",
                principalColumn: "BarcodeTypeCode",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrClaimReports_DcClaims_ClaimCode",
                table: "TrClaimReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TrClaimReports_DcReports_ReportId",
                table: "TrClaimReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLineExts_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceLineExts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_StoreCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentHeaders_DcCurrAccs_ToCashRegCode",
                table: "TrPaymentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_TrProductBarcodes_DcBarcodeTypes_BarcodeTypeCode",
                table: "TrProductBarcodes");

            migrationBuilder.DropTable(
                name: "TrSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrInvoiceLineExts",
                table: "TrInvoiceLineExts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrClaimReports",
                table: "TrClaimReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcBarcodeTypes",
                table: "DcBarcodeTypes");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Column_ProductCost");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailPurchaseReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleInvoice");

            migrationBuilder.DeleteData(
                table: "DcPriceTypes",
                keyColumn: "PriceTypeCode",
                keyValue: "STD");

            migrationBuilder.DeleteData(
                table: "DcReportVariables",
                keyColumn: "VariableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DcReportVariables",
                keyColumn: "VariableId",
                keyValue: 2);

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
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "HierarchyFeatureType");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "ProductFeatureType");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "RetailSaleReturn");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "Session");

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "WholesaleReturn");

            migrationBuilder.DropColumn(
                name: "AutoSave",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "LineExpences",
                table: "TrInvoiceLineExts");

            migrationBuilder.RenameTable(
                name: "TrInvoiceLineExts",
                newName: "TrInvoiceLineExt");

            migrationBuilder.RenameTable(
                name: "TrClaimReports",
                newName: "TrClaimReport");

            migrationBuilder.RenameTable(
                name: "DcBarcodeTypes",
                newName: "DcBarcodeType");

            migrationBuilder.RenameColumn(
                name: "ProductCost",
                table: "TrInvoiceLines",
                newName: "LastPurchasePrice");

            migrationBuilder.RenameIndex(
                name: "IX_TrInvoiceLineExts_InvoiceLineId",
                table: "TrInvoiceLineExt",
                newName: "IX_TrInvoiceLineExt_InvoiceLineId");

            migrationBuilder.RenameIndex(
                name: "IX_TrClaimReports_ReportId",
                table: "TrClaimReport",
                newName: "IX_TrClaimReport_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_TrClaimReports_ClaimCode",
                table: "TrClaimReport",
                newName: "IX_TrClaimReport_ClaimCode");

            migrationBuilder.AlterColumn<string>(
                name: "HierarchyCode",
                table: "TrProductHierarchies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrProductHierarchies",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)")
                .OldAnnotation("Relational:ColumnOrder", 1);

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

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrInvoiceLines",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureTypeId",
                table: "TrHierarchyFeatureTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "HierarchyCode",
                table: "TrHierarchyFeatureTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

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

            migrationBuilder.AlterColumn<string>(
                name: "VariableValueType",
                table: "DcReportVariables",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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

            migrationBuilder.AlterColumn<byte>(
                name: "CompanyCode",
                table: "DcCurrAccs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrInvoiceLineExt",
                table: "TrInvoiceLineExt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrClaimReport",
                table: "TrClaimReport",
                column: "ClaimReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcBarcodeType",
                table: "DcBarcodeType",
                column: "BarcodeTypeCode");

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

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "GridViewLayout",
                value: "<XtraSerializer version=\"1.0\" application=\"View\">\r\n	<property name=\"#LayoutVersion\" />\r\n	<property name=\"#LayoutScaleFactor\">@1,Width=1@1,Height=1</property>\r\n	<property name=\"Appearance\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"Row\" iskey=\"true\" value=\"Row\">\r\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\r\n				<property name=\"UseFont\">true</property>\r\n			</property>\r\n			<property name=\"Font\">Tahoma, 12pt</property>\r\n		</property>\r\n		<property name=\"FooterPanel\" iskey=\"true\" value=\"FooterPanel\">\r\n			<property name=\"Options\" isnull=\"true\" iskey=\"true\">\r\n				<property name=\"UseFont\">true</property>\r\n			</property>\r\n			<property name=\"Font\">Tahoma, 12pt</property>\r\n		</property>\r\n	</property>\r\n	<property name=\"OptionsBehavior\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"Editable\">false</property>\r\n		<property name=\"ReadOnly\">true</property>\r\n	</property>\r\n	<property name=\"OptionsCustomization\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"AllowRowSizing\">true</property>\r\n	</property>\r\n	<property name=\"OptionsView\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"ColumnHeaderAutoHeight\">True</property>\r\n		<property name=\"ShowAutoFilterRow\">true</property>\r\n		<property name=\"ShowGroupPanel\">false</property>\r\n		<property name=\"ShowIndicator\">false</property>\r\n	</property>\r\n	<property name=\"OptionsFind\" isnull=\"true\" iskey=\"true\">\r\n		<property name=\"FindMode\">Always</property>\r\n		<property name=\"FindDelay\">100</property>\r\n	</property>\r\n	<property name=\"FixedLineWidth\">2</property>\r\n	<property name=\"IndicatorWidth\">-1</property>\r\n	<property name=\"ColumnPanelRowHeight\">-1</property>\r\n	<property name=\"RowSeparatorHeight\">0</property>\r\n	<property name=\"FooterPanelHeight\">-1</property>\r\n	<property name=\"HorzScrollVisibility\">Auto</property>\r\n	<property name=\"VertScrollVisibility\">Auto</property>\r\n	<property name=\"RowHeight\">-1</property>\r\n	<property name=\"GroupRowHeight\">-1</property>\r\n	<property name=\"GroupFormat\">{0}: [#image]{1} {2}</property>\r\n	<property name=\"ChildGridLevelName\" />\r\n	<property name=\"VertScrollTipFieldName\" />\r\n	<property name=\"PreviewFieldName\" />\r\n	<property name=\"GroupPanelText\" />\r\n	<property name=\"NewItemRowText\" />\r\n	<property name=\"LevelIndent\">-1</property>\r\n	<property name=\"PreviewIndent\">-1</property>\r\n	<property name=\"PreviewLineCount\">-1</property>\r\n	<property name=\"ScrollStyle\">LiveVertScroll, LiveHorzScroll</property>\r\n	<property name=\"FocusRectStyle\">CellFocus</property>\r\n	<property name=\"HorzScrollStep\">0</property>\r\n	<property name=\"ActiveFilterEnabled\">true</property>\r\n	<property name=\"ViewCaptionHeight\">-1</property>\r\n	<property name=\"Columns\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"ViewCaption\" />\r\n	<property name=\"BorderStyle\">Default</property>\r\n	<property name=\"SynchronizeClones\">true</property>\r\n	<property name=\"DetailTabHeaderLocation\">Top</property>\r\n	<property name=\"Name\">gridView1</property>\r\n	<property name=\"DetailHeight\">350</property>\r\n	<property name=\"Tag\" isnull=\"true\" />\r\n	<property name=\"GroupSummary\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"ActiveFilterString\" />\r\n	<property name=\"FormatRules\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"FormatConditions\" iskey=\"true\" value=\"0\" />\r\n	<property name=\"GroupSummarySortInfoState\" />\r\n	<property name=\"FindFilterText\" />\r\n	<property name=\"FindPanelVisible\">true</property>\r\n</XtraSerializer>");

            migrationBuilder.InsertData(
                table: "DcClaims",
                columns: new[] { "ClaimCode", "ClaimDesc", "ClaimTypeId" },
                values: new object[,]
                {
                    { "Column_LastPurchasePrice", "Son Alış Qiyməti", (byte)1 },
                    { "PurchaseIsReturn", "Alışın Qaytarılması", (byte)1 },
                    { "SaleIsReturn", "Satışın Qaytarılması", (byte)1 }
                });

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000001",
                column: "CompanyCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000002",
                column: "CompanyCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000003",
                column: "CompanyCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000004",
                column: "CompanyCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000005",
                column: "CompanyCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "kassa01",
                column: "CompanyCode",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "mgz01",
                column: "CompanyCode",
                value: (byte)0);

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
                keyValue: 11,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nselect Price\r\n, ProductDesc\r\n, CurrencyCode\r\n, NetAmountLoc\r\n, DocumentDate \r\n, LineDescription\r\n, StoreCode\r\nfrom TrInvoiceLines\r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nwhere ProcessCode = 'EX'");

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
                value: "\r\n\r\n\r\n\r\n\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')\r\n		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		  + isnull(' ' + Feature29,'') \r\n\r\n\r\n, ProductDesc\r\n, QtyIn\r\n, QtyOut\r\n, Price\r\n, PriceLoc\r\n, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))\r\n, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))\r\n, Amount\r\n, NetAmountLoc\r\n, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines \r\n		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId\r\n		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, DocumentNumber\r\n, IsReturn\r\n, LastPurchasePrice\r\n, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - LastPurchasePrice)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceLines.PosDiscount\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs .CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, PrintCount\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il where il.ProductCode = TrInvoiceLines .ProductCode)\r\n, TrInvoiceHeaders.CreatedUserName\r\n, ImagePath\r\n--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  \r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n\r\norder by DocumentDate, DocumentTime\r\n\r\n\r\n");

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
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 18,
                column: "ReportQuery",
                value: "	--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n	--declare @StartTime time =  '00:00:00.000'\r\n\r\nselect DcProducts.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc \r\n		  + isnull(' ' + Feature01,'') + isnull(' ' + Feature02,'') + isnull(' ' + Feature03,'') + isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19,'') + isnull(' ' + Feature20,'')\r\n, ProductDesc\r\n, WholesalePrice\r\n, DcHierarchies.HierarchyCode\r\n, HierarchyDesc\r\n, ProductTypeCode\r\n, [01] = isnull(' ' + Feature01Desc,'')\r\n, [02] = isnull(' ' + Feature02Desc,'')\r\n, [03] = isnull(' ' + Feature03Desc,'')\r\n, [04] = isnull(' ' + Feature04Desc,'')\r\n, [05] = isnull(' ' + Feature05Desc,'')\r\n, [06] = isnull(' ' + Feature06Desc,'')\r\n, [07] = isnull(' ' + Feature07Desc,'')\r\n, [09] = isnull(' ' + Feature09Desc,'')\r\n, [10] = isnull(' ' + Feature10Desc,'')\r\n, [11] = isnull(' ' + Feature11Desc,'')\r\n, [12] = isnull(' ' + Feature12Desc,'')\r\n, [13] = isnull(' ' + Feature13Desc,'')\r\n, [14] = isnull(' ' + Feature14Desc,'')\r\n, [15] = isnull(' ' + Feature15Desc,'')\r\n, [16] = isnull(' ' + Feature16Desc,'')\r\n, [17] = isnull(' ' + Feature17Desc,'')\r\n, [18] = isnull(' ' + Feature18Desc,'')\r\n, [19] = isnull(' ' + Feature22Desc,'')\r\n, [20] = isnull(' ' + Feature23Desc,'')\r\n\r\nfrom DcProducts\r\n\r\nleft join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\nwhere ProductTypeCode = 1\r\n			\r\norder by isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc\r\n");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 4,
                column: "ClaimCode",
                value: "Column_LastPurchasePrice");

            migrationBuilder.UpdateData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 15,
                column: "ClaimCode",
                value: "PurchaseIsReturn");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TrClaimReport_DcClaims_ClaimCode",
                table: "TrClaimReport",
                column: "ClaimCode",
                principalTable: "DcClaims",
                principalColumn: "ClaimCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrClaimReport_DcReports_ReportId",
                table: "TrClaimReport",
                column: "ReportId",
                principalTable: "DcReports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLineExt_TrInvoiceLines_InvoiceLineId",
                table: "TrInvoiceLineExt",
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
        }
    }
}
