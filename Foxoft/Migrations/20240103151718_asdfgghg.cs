using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfgghg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_DcReportSubQueries_DcReportSubQuerySubQueryId",
                table: "DcQueryParams");

            migrationBuilder.DropTable(
                name: "DcReportSubQueries");

            migrationBuilder.RenameColumn(
                name: "DcReportSubQuerySubQueryId",
                table: "DcQueryParams",
                newName: "TrReportSubQuerySubQueryId");

            migrationBuilder.RenameIndex(
                name: "IX_DcQueryParams_DcReportSubQuerySubQueryId",
                table: "DcQueryParams",
                newName: "IX_DcQueryParams_TrReportSubQuerySubQueryId");

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


            migrationBuilder.CreateIndex(
                name: "IX_TrReportSubQueries_ReportId",
                table: "TrReportSubQueries",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TrReportSubQueryRelationColumns_SubQueryId",
                table: "TrReportSubQueryRelationColumns",
                column: "SubQueryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_TrReportSubQueries_TrReportSubQuerySubQueryId",
                table: "DcQueryParams",
                column: "TrReportSubQuerySubQueryId",
                principalTable: "TrReportSubQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcQueryParams_TrReportSubQueries_TrReportSubQuerySubQueryId",
                table: "DcQueryParams");

            migrationBuilder.DropTable(
                name: "TrReportSubQueryRelationColumns");

            migrationBuilder.DropTable(
                name: "TrReportSubQueries");

            migrationBuilder.RenameColumn(
                name: "TrReportSubQuerySubQueryId",
                table: "DcQueryParams",
                newName: "DcReportSubQuerySubQueryId");

            migrationBuilder.RenameIndex(
                name: "IX_DcQueryParams_TrReportSubQuerySubQueryId",
                table: "DcQueryParams",
                newName: "IX_DcQueryParams_DcReportSubQuerySubQueryId");

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

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 14,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\n\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')\r\n		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		  + isnull(' ' + Feature29,'') \r\n\r\n\r\n, ProductDesc\r\n, QtyIn\r\n, QtyOut\r\n, Price\r\n, PriceLoc\r\n, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))\r\n, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))\r\n, Amount\r\n, NetAmountLoc\r\n, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines \r\n		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId\r\n		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, DocumentNumber\r\n, IsReturn\r\n, LastPurchasePrice\r\n, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - LastPurchasePrice)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceLines.PosDiscount\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs .CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, PrintCount\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, Barcode\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il where il.ProductCode = TrInvoiceLines .ProductCode)\r\n, TrInvoiceHeaders.CreatedUserName\r\n, ImagePath\r\n--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  \r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n\r\norder by DocumentDate, DocumentTime\r\n\r\n\r\n");

            migrationBuilder.CreateIndex(
                name: "IX_DcReportSubQueries_ReportId",
                table: "DcReportSubQueries",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_DcQueryParams_DcReportSubQueries_DcReportSubQuerySubQueryId",
                table: "DcQueryParams",
                column: "DcReportSubQuerySubQueryId",
                principalTable: "DcReportSubQueries",
                principalColumn: "SubQueryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
