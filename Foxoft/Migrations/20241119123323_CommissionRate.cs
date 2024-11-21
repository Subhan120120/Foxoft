using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class CommissionRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CommissionRate",
                table: "DcPaymentPlans",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M03",
                column: "CommissionRate",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M06",
                column: "CommissionRate",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M09",
                column: "CommissionRate",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M12",
                column: "CommissionRate",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M18",
                column: "CommissionRate",
                value: 0f);

            migrationBuilder.UpdateData(
                table: "DcPaymentPlans",
                keyColumn: "PaymentPlanCode",
                keyValue: "M24",
                column: "CommissionRate",
                value: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcReportVariables",
                keyColumn: "VariableId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CommissionRate",
                table: "DcPaymentPlans");

            migrationBuilder.UpdateData(
                table: "DcReportVariables",
                keyColumn: "VariableId",
                keyValue: 1,
                columns: new[] { "ReportId", "Representative", "VariableOperator", "VariableProperty", "VariableTypeId", "VariableValue", "VariableValueType" },
                values: new object[] { 13, "{CurrAccCode}", "=", "CurrAccCode", (byte)2, "c-0000001", "System.String" });

            migrationBuilder.UpdateData(
                table: "DcReportVariables",
                keyColumn: "VariableId",
                keyValue: 2,
                columns: new[] { "ReportId", "Representative", "VariableOperator", "VariableProperty", "VariableValue", "VariableValueType" },
                values: new object[] { 17, "{StartDate}", "<=", "DocumentDate", "08.01.2030", "System.DateTime" });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 4,
                column: "ReportQuery",
                value: "\r\n\r\n--Declare @invoiceHeader nvarchar(50) = 'dd6927e4-d33c-4dc7-929c-1410c299e0a9'\r\n\r\n	select  TrInvoiceLines.InvoiceLineId\r\n			,	[Marka] = isnull(' ' +  Feature02Desc,'')\r\n		  , [Ceki] = isnull(' ' + Feature04Desc,'')\r\n		  , [Reng] = isnull(' ' + Feature05Desc,'')\r\n		  , [Məhsul Tipi] = isnull(' ' + Feature06Desc,'')\r\n		  , [Soyutma Tipi] = isnull(' ' + Feature07Desc,'')\r\n		  , [BTU] = isnull(' ' + Feature09Desc,'')\r\n		  , [Ekran Ölçüsü] = isnull(' ' + Feature10Desc,'')\r\n		  , [Ekran İcazəsi] = isnull(' ' + Feature11Desc,'')\r\n		  , [Motorun Növü] = isnull(' ' + Feature12Desc,'')\r\n		  , [Həcmi] = isnull(' ' + Feature13Desc,'')\r\n		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + Feature14Desc,'')\r\n		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + Feature15Desc,'')\r\n		  , [Istehsalçı Ölkə] = isnull(' ' + Feature16Desc,'')\r\n		  , [Məhsuldarlıq] = isnull(' ' + Feature17Desc,'')\r\n		  , [Güc] = isnull(' ' + Feature18Desc,'')\r\n		  , [Tərtib Edən İstifadəçi] =( select CurrAccDesc from DcCurrAccs where CurrAccCode = TrInvoiceHeaders.CreatedUserName)\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, DcProducts.ProductCode\r\n	, ProductDesc\r\n	, QtyIn = QtyIn\r\n	, QtyOut = QtyOut\r\n	, Price\r\n	, TrInvoiceLines.PosDiscount\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, ProcessDesc\r\n	, TrInvoiceLines.CurrencyCode\r\n	, DcProducts.HierarchyCode\r\n	, HierarchyDesc\r\n	, IsReturn\r\n	, CustomsDocumentNumber\r\n	, PrintCount\r\n	, NetAmount\r\n	, LineDescription\r\n	, PriceLoc\r\n	, PriceDiscounted\r\n	, PriceDiscountedLoc\r\n	, TrInvoiceLines.ExchangeRate\r\n	, NetAmountLoc = (QtyIn-QtyOut) * PriceDiscountedLoc\r\n	, DocumentNumber\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, DcCurrAccs.CurrAccCode\r\n	, DcCurrAccs.CurrAccDesc\r\n	, DcCurrAccs.FirstName\r\n	, DcCurrAccs.PhoneNum\r\n	, HeaderCreatedDate = TrInvoiceHeaders.CreatedDate\r\n	, LineCreatedDate = TrInvoiceLines.CreatedDate\r\n	, TrInvoiceHeaders.CreatedUserName\r\n	, CurrAccBalance = dbo.CurrAccBalance(TrInvoiceHeaders.CurrAccCode, CAST(DocumentDate as Datetime) + CAST(DocumentTime as Datetime))\r\n	, BalanceCode = 'M' + Convert(nvarchar, Format((select SUM(QtyIn - QtyOut) ProductBalance\r\n						from TrInvoiceLines il \r\n						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n						where il.ProductCode = TrInvoiceLines.ProductCode and WarehouseCode = TrInvoiceHeaders.WarehouseCode\r\n						and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'CI', 'CO', 'IT' )),'000')) \r\n						\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, TrInvoiceHeaders.ToWarehouseCode\r\n	, [Depodan] = wareIn.WarehouseDesc\r\n	, [Depoya] = wareOut.WarehouseDesc\r\n	, Description\r\n	, TrInvoiceHeaders.StoreCode\r\n	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl \r\n							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)\r\n	, ProductCost\r\n	, StorePhoneNum = store.PhoneNum\r\n	, StoreAddress = store.Address\r\n	from TrInvoiceLines\r\n	left join TrInvoiceLineExts on TrInvoiceLineExts.InvoiceLineId = TrInvoiceLines.InvoiceLineId\r\n	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n	left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\n	left join DcHierarchies on DcHierarchies.HierarchyCode = DcProducts.HierarchyCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = TrInvoiceLines.CurrencyCode\r\n	left join DcWarehouses wareIn on wareIn.WarehouseCode = TrInvoiceHeaders.WarehouseCode\r\n	left join DcWarehouses wareOut on wareOut.WarehouseCode = TrInvoiceHeaders.ToWarehouseCode\r\n	left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n	left join DcCurrAccs store on store.CurrAccCode = TrInvoiceHeaders.StoreCode\r\n\r\n	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader\r\n\r\n\r\n	order by TrInvoiceLines.CreatedDate\r\n\r\n\r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 14,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\n\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')\r\n		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		  + isnull(' ' + Feature29,'') \r\n\r\n\r\n, ProductDesc\r\n, QtyIn\r\n, QtyOut\r\n, Price\r\n, PriceLoc\r\n, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))\r\n, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))\r\n, Amount\r\n, NetAmountLoc\r\n, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines \r\n		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId\r\n		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, DocumentNumber\r\n, IsReturn\r\n, ProductCost\r\n, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceLines.PosDiscount\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs .CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, PrintCount\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il \r\n					left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n					where il.ProductCode = TrInvoiceLines.ProductCode\r\n					and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'CI', 'CO', 'IT'))\r\n, TrInvoiceHeaders.CreatedUserName\r\n, ImagePath\r\n--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  \r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n\r\norder by DocumentDate, DocumentTime\r\n\r\n\r\n");
        }
    }
}
