using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdsdfgfgj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "DcClaims",
            //    columns: new[] { "ClaimCode", "ClaimDesc", "ClaimTypeId" },
            //    values: new object[,]
            //    {
            //        { "ButunHesabatlar", "Butun Hesabatlar", (byte)2 },
            //        { "SaleIsReturn", "Satışın Qaytarılması", (byte)1 },
            //        { "RetailSaleInvoice", "Satış Fakturası", (byte)1 },
            //        { "RetailPurchaseInvoice", "Alış Fakturası", (byte)1 },
            //        { "ReportZet", "Gün Sonu Hesabatı", (byte)1 },
            //        { "Products", "Məhsullar", (byte)1 },
            //        { "PriceList", "Qiymət Cədvəli", (byte)1 },
            //        { "PaymentDetail", "Ödəmə", (byte)1 },
            //        { "InventoryTransfer", "Mal Transferi", (byte)1 },
            //        { "PurchaseIsReturn", "Alışın Qaytarılması", (byte)1 },
            //        { "DiscountList", "Endirim Siyahısı", (byte)1 },
            //        { "CurrAccs", "Cari Hesablar", (byte)1 },
            //        { "CountOut", "Sayım Azaltma", (byte)1 },
            //        { "CountIn", "Sayım Artırma", (byte)1 },
            //        { "Column_LastPurchasePrice", "Son Alış Qiyməti", (byte)1 },
            //        { "CashTransfer", "Pul Transferi", (byte)1 },
            //        { "CashRegs", "Kassalar", (byte)1 },
            //        { "Expense", "Xərc", (byte)1 }
            //    });

            //migrationBuilder.InsertData(
            //    table: "DcReportTypes",
            //    columns: new[] { "ReportTypeId", "IsDisabled", "ReportTypeDesc", "RowGuid" },
            //    values: new object[] { (byte)0, false, "Embedded", new Guid("00000000-0000-0000-0000-000000000000") });

            //migrationBuilder.InsertData(
            //    table: "DcReports",
            //    columns: new[] { "ReportId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
            //    values: new object[,]
            //    {
            //        { 11, null, "", "Report_Detail_ProductCard", "	--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n	--declare @StartTime time =  '00:00:00.000'\r\n\r\nselect DcProducts.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc \r\n		  + isnull(' ' + Feature01,'') + isnull(' ' + Feature02,'') + isnull(' ' + Feature03,'') + isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19,'') + isnull(' ' + Feature20,'')\r\n, ProductDesc\r\n, WholesalePrice\r\n, DcHierarchies.HierarchyCode\r\n, HierarchyDesc\r\n, ProductTypeCode\r\n, [01] = isnull(' ' + Feature01Desc,'')\r\n, [02] = isnull(' ' + Feature02Desc,'')\r\n, [03] = isnull(' ' + Feature03Desc,'')\r\n, [04] = isnull(' ' + Feature04Desc,'')\r\n, [05] = isnull(' ' + Feature05Desc,'')\r\n, [06] = isnull(' ' + Feature06Desc,'')\r\n, [07] = isnull(' ' + Feature07Desc,'')\r\n, [09] = isnull(' ' + Feature09Desc,'')\r\n, [10] = isnull(' ' + Feature10Desc,'')\r\n, [11] = isnull(' ' + Feature11Desc,'')\r\n, [12] = isnull(' ' + Feature12Desc,'')\r\n, [13] = isnull(' ' + Feature13Desc,'')\r\n, [14] = isnull(' ' + Feature14Desc,'')\r\n, [15] = isnull(' ' + Feature15Desc,'')\r\n, [16] = isnull(' ' + Feature16Desc,'')\r\n, [17] = isnull(' ' + Feature17Desc,'')\r\n, [18] = isnull(' ' + Feature18Desc,'')\r\n, [19] = isnull(' ' + Feature22Desc,'')\r\n, [20] = isnull(' ' + Feature23Desc,'')\r\n\r\nfrom DcProducts\r\n\r\nleft join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\nwhere ProductTypeCode = 1\r\n			\r\norder by isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc\r\n", (byte)1 },
            //        { 10, null, "", "Report_Grid_WarehouseBalance", "\r\n\r\nselect DcProducts.ProductCode\r\n	, DcProducts.ProductDesc\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, Balance = sum(QtyIn - QtyOut)\r\n	, LastPurchasePrice = (select top 1 PriceLoc * (100 - PosDiscount)/100\r\n					from TrInvoiceLines \r\n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \r\n					{StartDate}\r\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\r\n					)\r\n	, Toplam = sum(QtyIn - QtyOut) * (select top 1 PriceLoc * (100 - PosDiscount)/100\r\n					from TrInvoiceLines \r\n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \r\n					{StartDate}\r\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\r\n					)\r\nfrom TrInvoiceLines\r\nLEFT JOIN TrInvoiceHeaders \r\n	ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nLEFT JOIN DcProducts \r\n	on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\nwhere DcProducts.ProductTypeCode = 1\r\n{StartDate}\r\nGroup by DcProducts.ProductCode\r\n	, DcProducts.ProductDesc\r\n	, TrInvoiceHeaders.WarehouseCode\r\n\r\n", (byte)1 },
            //        { 9, null, "", "Report_Grid_RecentGoods", "\r\n\r\n\r\nselect \r\n [Topdan Sat. Qiy.] =  Round(WholesalePrice, 0)\r\n, [Son Alış Qiy.] =  Round(LastPurchasePrice, 0)\r\n, [%] =CONVERT(int, Round((1 - (PivotTable.LastPurchasePrice / NULLIF(PivotTable.WholesalePrice,0))) * 100, 0)) \r\n, *\r\nfrom (\r\n	select prdcts.ProductCode\r\n	, LastUpdatedDate\r\n	, UseInternet\r\n	, ProductDesc \r\n	, HierarchyCode \r\n	, FeatureCode\r\n	, FeatureTypeId\r\n	, WholesalePrice\r\n	, LastPurchasePrice = (select top 1  PriceLoc * (1 - (PosDiscount / 100))	\r\n								from TrInvoiceLines il\r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.ProcessCode IN ('RP', 'CI') \r\n								and ih.IsReturn = 0\r\n								order by ih.DocumentDate desc\r\n										, ih.CreatedDate desc\r\n								)\r\n	, [Son Alış Günü] = (select top 1  il.LastUpdatedDate	\r\n								from TrInvoiceLines il\r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.ProcessCode IN ('RP') \r\n								and ih.IsReturn = 0\r\n								order by ih.DocumentDate desc\r\n										, ih.CreatedDate desc\r\n								)\r\n	, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il \r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.WarehouseCode = 'depo-01')\r\n	from DcProducts prdcts\r\n	left join TrProductFeatures on TrProductFeatures.ProductCode = prdcts.ProductCode\r\n\r\n	where ProductTypeCode = 1\r\n	) pro\r\nPIVOT (Max(FeatureCode) FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25]) \r\n) AS PivotTable \r\norder by PivotTable.[Son Alış Günü] \r\n\r\n\r\n\r\n", (byte)1 },
            //        { 4, null, "", "Report_Grid_Expenses", "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nselect Price\r\n, ProductDesc\r\n, CurrencyCode\r\n, NetAmountLoc\r\n, DocumentDate \r\n, LineDescription\r\n, StoreCode\r\nfrom TrInvoiceLines\r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nwhere ProcessCode = 'EX'", (byte)1 },
            //        { 7, null, "", "Report_Grid_ProductMovements", "\r\n\r\n\r\n\r\n\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')\r\n		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		  + isnull(' ' + Feature29,'') \r\n\r\n\r\n, ProductDesc\r\n, QtyIn\r\n, QtyOut\r\n, Price\r\n, PriceLoc\r\n, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))\r\n, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))\r\n, Amount\r\n, NetAmountLoc\r\n, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines \r\n		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId\r\n		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, DocumentNumber\r\n, IsReturn\r\n, LastPurchasePrice\r\n, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - LastPurchasePrice)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceLines.PosDiscount\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs .CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, PrintCount\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, Barcode\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il where il.ProductCode = TrInvoiceLines .ProductCode)\r\n, TrInvoiceHeaders.CreatedUserName\r\n, ImagePath\r\n--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  \r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n\r\norder by DocumentDate, DocumentTime\r\n\r\n\r\n", (byte)1 },
            //        { 6, null, "", "Report_Grid_MovementsWithAccounts", "\r\n\r\n\r\nselect 	CurrAccDesc\r\n	--, ProductDesc\r\n	, NetAmountLoc\r\n	, PaymentLoc\r\n	, [Ara Toplam] = sum(Summary) OVER (ORDER BY DocumentDate, DocumentTime )\r\n	, ProcessDesc\r\n	, DocumentNumber\r\n	, CurrAccCode\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, InvoiceHeaderId\r\n	, PaymentHeaderId\r\n	, LineDescription\r\n	, IsReturn\r\n	, StoreCode\r\n	--, LineId\r\nfrom (\r\n	select FirstName\r\n	, CurrAccDesc\r\n	--, ProductDesc\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, PaymentLoc= 0\r\n	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, ProcessDesc = ProcessDesc\r\n	, DocumentNumber\r\n	, TrInvoiceHeaders.StoreCode\r\n	, TrInvoiceHeaders.CurrAccCode\r\n	, TrInvoiceHeaders.DocumentDate\r\n	, TrInvoiceHeaders.DocumentTime\r\n	, LineDescription = TrInvoiceHeaders.Description\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, IsReturn\r\n	--, LineId = InvoiceLineId\r\n	from TrInvoiceLines \r\n	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = TrInvoiceHeaders.ProcessCode\r\n	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\n	group by FirstName\r\n			, CurrAccDesc\r\n			, ProcessDesc\r\n			, DocumentNumber\r\n			, TrInvoiceHeaders.InvoiceHeaderId\r\n			, TrInvoiceHeaders.CurrAccCode\r\n			, TrInvoiceHeaders.DocumentDate	\r\n			, TrInvoiceHeaders.DocumentTime\r\n			, TrInvoiceHeaders.Description\r\n			, TrInvoiceHeaders.StoreCode\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, IsReturn\r\n	\r\n	UNION ALL \r\n	\r\n	select FirstName\r\n	--, ProductCode = ''\r\n	, CurrAccDesc = CurrAccDesc\r\n	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, TrPaymentHeaders.PaymentHeaderId\r\n	, NetAmountLoc = 0\r\n	, PaymentLoc\r\n	, Summary = PaymentLoc\r\n	, ProcessDesc = N'Ödəniş'\r\n	, DocumentNumber\r\n	, TrPaymentHeaders.StoreCode\r\n	, TrPaymentHeaders.CurrAccCode\r\n	, DocumentDate = TrPaymentHeaders.OperationDate\r\n	, DocumentTime = TrPaymentHeaders.OperationTime\r\n	, LineDescription\r\n	, ProcessCode = 'PA'\r\n	, IsReturn = CAST(0 as bit)\r\n	--, LineId = PaymentLineId\r\n	from TrPaymentLines\r\n	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\n	left join DcCurrAccs  on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode	\r\n\r\n) as CurrAccExtra where 1=1 {CurrAccCode}\r\n\r\norder by DocumentDate, DocumentTime", (byte)1 },
            //        { 5, null, "", "Report_Grid_MoneyMovements", "\r\n\r\n\r\n\r\nselect  PaymentLineId\r\n, TrPaymentHeaders.PaymentHeaderId\r\n, TrPaymentHeaders.InvoiceHeaderId\r\n, InvoiceNumber = tph.DocumentNumber\r\n, DcPaymentTypes.PaymentTypeCode\r\n, PaymentTypeDesc\r\n, PaymentLoc\r\n, Payment\r\n, CurrencyCode\r\n, LineDescription\r\n, TrPaymentHeaders.DocumentNumber\r\n, TrPaymentHeaders.DocumentDate\r\n, TrPaymentHeaders.DocumentTime\r\n, TrPaymentHeaders.OperationDate\r\n, TrPaymentHeaders.OperationTime\r\n, OperationType\r\n, TrPaymentHeaders.CurrAccCode\r\n, CashRegisterCode\r\n, FirstName\r\n, DcCurrAccs.CurrAccDesc\r\n, TrPaymentHeaders.StoreCode\r\n, tpl.CreatedDate\r\n, tpl.CreatedUserName\r\n, [Cari Hesab Balansı] = (	(select sum ((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where DcCurrAccs.CurrAccCode = ih.CurrAccCode\r\n	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		+ \r\n(select Sum(PaymentLoc) -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where DcCurrAccs.CurrAccCode = ph.CurrAccCode \r\n			and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n			(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		)\r\n\r\n from TrPaymentLines tpl\r\nleft join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\nleft join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId\r\nleft Join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode\r\norder by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc\r\n\r\n\r\n\r\n", (byte)1 },
            //        { 8, null, "", "Report_Grid_Profit", "\r\n\r\n\r\nSELECT Maya = (-1)*(case when Dvijok.ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0) else 0 end)\r\n, Menfeet = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0)) else 0 end)\r\n, [Net Menfeet] = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0)) else 0 end) - Xərc\r\n, *\r\nFROM (\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, ProductDesc\r\n, Qty = (QtyIn-QtyOut)*(-1)\r\n, Price\r\n, PriceLoc\r\n, Amount\r\n, TrInvoiceLines.PosDiscount\r\n, QtyIn\r\n, QtyOut\r\n, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end\r\n, Satis = (-1)*(case when TrInvoiceHeaders.ProcessCode = 'RS' then (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100)) else 0 end)\r\n, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end\r\n, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end\r\n, LastPurchasePrice\r\n, SonQiymet = (select top 1 toplam = il.PriceLoc * (1 - (il.PosDiscount / 100))  \r\n					from TrInvoiceLines il\r\n					join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n					where il.ProductCode = TrInvoiceLines.ProductCode\r\n					and (ih.ProcessCode = 'RP' or ih.ProcessCode = 'CI')\r\n					and ih.IsReturn = 0\r\n					and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n						 (CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n					ORDER BY ih.DocumentDate desc\r\n					, il.CreatedDate desc )	\r\n\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, InvoiceNumber = DocumentNumber\r\n, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - LastPurchasePrice)  / NULLIF(LastPurchasePrice,0) * 100,2)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs.CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, Barcode\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	\r\n\r\nwhere TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'RS', 'EX')\r\n--and DocumentNumber = 'RS-000012'\r\n) Dvijok\r\norder by Dvijok.DocumentDate\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n", (byte)1 }
            //    });

            //migrationBuilder.InsertData(
            //    table: "TrRoleClaims",
            //    columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
            //    values: new object[] { 12, "PosDiscount", "Admin" });

            //migrationBuilder.UpdateData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 1,
            //    columns: new[] { "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
            //    values: new object[] { "", "Report_Embedded_ProductList", "\r\n\r\n\r\n\r\n\r\n\r\n\r\n	--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n	--declare @StartTime time =  '00:00:00.000'\r\n\r\n	select ProductCode\r\n		  , [Məhsulun Geniş Adı]= isnull(HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + [4],'') + isnull(' ' + [5],'') \r\n		  + isnull(' ' + [6],'') + isnull(' ' + [7],'') + isnull(' ' + [8],'') + isnull(' ' + [9],'') + isnull(' ' + [10],'') \r\n		  + isnull(' ' + [11],'') + isnull(' ' + [12],'') + isnull(' ' + [13],'') + isnull(' ' + [16],'') + isnull(' ' + [17],'') \r\n		  + isnull(' ' + [18],'') + isnull(' ' + [19] + 'x' + [20] + 'x' + [21],'') + isnull(' ' + [22],'')+ isnull(' ' + [23],'')\r\n		  + isnull(' ' + [24],'') + isnull(' ' + [25],'') + isnull(' ' + [26],'') + isnull(' ' + [27],'') + isnull(' ' + [28],'') \r\n, ProductDesc \r\n		  , LastPurchasePrice = CAST(LastPurchasePrice as money)\r\n		  , Mərkəz = ISNULL([depo-01], 0)\r\n		  , [Sıra 20] = ISNULL([depo-02], 0)\r\n		  , [Sıra 5] = ISNULL([depo-03], 0)\r\n		  , Balance = isnull([depo-01], 0) + isnull([depo-02],0) + isnull([depo-03],0)\r\n		  , WholesalePrice\r\n		  , Manatla = ROUND(WholesalePrice*1.703, -1 )\r\n		  , HierarchyCode\r\n		  , HierarchyDesc\r\n		  , ProductTypeCode\r\n		  , ProductId\r\n		  , [Marka] = isnull(' ' + [3],'')\r\n		  , [Çəki] = isnull(' ' + [4],'')\r\n		  , [Rəng] = isnull(' ' + [5],'')\r\n		  , [Məhsul Tipi] = isnull(' ' + [6],'')\r\n		  , [Soyutma Tipi] = isnull(' ' + [7],'')\r\n		  , [BTU] = isnull(' ' + [9],'')\r\n		  , [Ekran Ölçüsü] = isnull(' ' + [10],'')\r\n		  , [Ekran İcazəsi] = isnull(' ' + [11],'')\r\n		  , [Motorun Növü] = isnull(' ' + [12],'')\r\n		  , [Həcmi] = isnull(' ' + [13],'')\r\n		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + [14],'')\r\n		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + [15],'')\r\n		  , [Istehsalçı Ölkə] = isnull(' ' + [16],'')\r\n		  , [Məhsuldarlıq] = isnull(' ' + [17],'')\r\n		  , [Güc] = isnull(' ' + [18],'')\r\n		  , [Kameranın Həcmi] = isnull(' ' + [19] + 'x' + [20] + 'x' + [21] ,'')\r\n		  , [Dispenser] = isnull(' ' + [22],'')\r\n		  , [Tutum Dəst] = isnull(' ' + [23],'')\r\n		  , [Rəflərin Sayı] = isnull(' ' + [24],'')\r\n		  , [Fırlanma Sürəti] = isnull(' ' + [25],'')\r\n		  , [Ocaq Sayı] = isnull(' ' + [26],'')\r\n		  , [Qaz Kontrol] = isnull(' ' + [27],'')\r\n		  , [Ocaq Növü] = isnull(' ' + [28],'')\r\n		  , [Programların Sayı] = isnull(' ' + [29],'')\r\n	from ( select \r\n	*\r\n			from (\r\n				select DcProducts.ProductCode\r\n							, ProductDesc\r\n							, DcHierarchies.HierarchyCode\r\n							, HierarchyDesc\r\n							, FeatureCode\r\n							, WarehouseCode\r\n							, WholesalePrice \r\n							, ProductTypeCode\r\n							, FeatureTypeId\r\n							, ProductId\r\n							, LastPurchasePrice = (select top 1 toplam = TrInvoiceLines.PriceLoc * (1 - (TrInvoiceLines.PosDiscount / 100))  \r\n															from TrInvoiceLines \r\n															join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n															where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n															and TrInvoiceHeaders.ProcessCode IN ( 'RP','CI')\r\n															and TrInvoiceHeaders.IsReturn = 0\r\n															ORDER BY TrInvoiceHeaders.DocumentDate desc, DcHierarchies.HierarchyCode desc\r\n															, TrInvoiceLines.CreatedDate desc\r\n											)											 \r\n				, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  \r\n				--, LastPurchasePrice = ()\r\n				from DcProducts\r\n			\r\n				left join TrInvoiceLines il on il.ProductCode = DcProducts.ProductCode\r\n				left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n				left join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode\r\n				left join TrProductFeatures on TrProductFeatures.ProductCode = DcProducts.ProductCode\r\n				left join SiteProducts on SiteProducts.ProductCode = DcProducts.ProductCode\r\n\r\n				--where ProductTypeCode = 1\r\n				--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n				--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))\r\n					--and il.ProductCode = '5503'\r\n			\r\n				group by DcProducts.ProductCode\r\n						 , DcProducts.ProductDesc\r\n						 , WholesalePrice \r\n						 , WarehouseCode\r\n						 , FeatureCode				\r\n						 , ProductTypeCode\r\n						 , DcHierarchies.HierarchyCode\r\n						 , HierarchyDesc\r\n						 , FeatureTypeId\r\n						 , ProductId\r\n						 --, reng.FeatureCode\r\n						 --, frost.FeatureCode \r\n				 ) as st\r\n				 PIVOT  \r\n				 (  \r\n				  Max(FeatureCode)\r\n				   FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25], [26], [27], [28], [29])  \r\n				 ) AS PivotTable2\r\n	) AS SourceTable  \r\n	PIVOT  \r\n	(  \r\n	 AVG(Balance)\r\n	  FOR WarehouseCode IN ([depo-01], [depo-02], [depo-03])  \r\n	) AS PivotTable \r\n\r\n\r\n\r\n\r\n\r\n\r\n", (byte)0 });

            //migrationBuilder.InsertData(
            //    table: "DcReports",
            //    columns: new[] { "ReportId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
            //    values: new object[,]
            //    {
            //        { 2, null, "", "Report_Embedded_CurrAccList", "\r\n\r\nselect top 10000000 DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, Balance =ISNULL(SUM(CAST(Amount as money)),0)\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\nfrom \r\nDcCurrAccs \r\nleft join \r\n(\r\n	select CurrAccCode\r\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where 1=1\r\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n\r\n	UNION ALL \r\n	\r\n	select CurrAccCode\r\n	, Amount = PaymentLoc -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where 1=1 \r\n	--and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\r\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\r\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\r\nwhere 1 = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\norder by CurrAccDesc", (byte)0 },
            //        { 3, null, "", "Report_Embedded_CashRegList", "\r\n\r\n\r\n\r\nselect top 10000000  DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\nfrom \r\nDcCurrAccs \r\nleft join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode\r\nwhere CurrAccTypeCode = 5 and IsDisabled = 0 and PaymentTypeCode = 1 \r\n	--and DcCurrAccs.IsVIP = 1 \r\n	--and balance.CurrAccCode = '1403'\r\ngroup by DcCurrAccs.CurrAccCode\r\n, CurrAccDesc\r\n, PhoneNum\r\n, IsVIP\r\n, CurrAccTypeCode\r\norder by CurrAccDesc\r\n\r\n\r\n\r\n\r\n\r\n\r\n", (byte)0 }
            //    });

            //migrationBuilder.InsertData(
            //    table: "TrClaimReport",
            //    columns: new[] { "ClaimReportId", "ClaimCode", "ReportId" },
            //    values: new object[,]
            //    {
            //        { 11, "ButunHesabatlar", 11 },
            //        { 10, "ButunHesabatlar", 10 },
            //        { 9, "ButunHesabatlar", 9 },
            //        { 8, "ButunHesabatlar", 8 },
            //        { 7, "ButunHesabatlar", 7 },
            //        { 6, "ButunHesabatlar", 6 },
            //        { 5, "ButunHesabatlar", 5 },
            //        { 4, "ButunHesabatlar", 4 },
            //        { 1, "ButunHesabatlar", 1 }
            //    });

            //migrationBuilder.UpdateData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 1,
            //    column: "ClaimCode",
            //    value: "ButunHesabatlar");

            //migrationBuilder.InsertData(
            //    table: "TrRoleClaims",
            //    columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
            //    values: new object[,]
            //    {
            //        { 13, "PriceList", "Admin" },
            //        { 2, "CashRegs", "Admin" },
            //        { 3, "CashTransfer", "Admin" },
            //        { 4, "Column_LastPurchasePrice", "Admin" },
            //        { 5, "CountIn", "Admin" },
            //        { 6, "CountOut", "Admin" },
            //        { 7, "CurrAccs", "Admin" },
            //        { 8, "DiscountList", "Admin" },
            //        { 9, "Expense", "Admin" },
            //        { 19, "SaleIsReturn", "Admin" },
            //        { 18, "RetailSaleInvoice", "Admin" },
            //        { 17, "RetailPurchaseInvoice", "Admin" },
            //        { 16, "ReportZet", "Admin" },
            //        { 10, "InventoryTransfer", "Admin" },
            //        { 14, "Products", "Admin" },
            //        { 11, "PaymentDetail", "Admin" },
            //        { 15, "PurchaseIsReturn", "Admin" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "TrClaimReport",
            //    columns: new[] { "ClaimReportId", "ClaimCode", "ReportId" },
            //    values: new object[] { 2, "ButunHesabatlar", 2 });

            //migrationBuilder.InsertData(
            //    table: "TrClaimReport",
            //    columns: new[] { "ClaimReportId", "ClaimCode", "ReportId" },
            //    values: new object[] { 3, "ButunHesabatlar", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 5);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 6);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 7);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 8);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 9);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 10);

            //migrationBuilder.DeleteData(
            //    table: "TrClaimReport",
            //    keyColumn: "ClaimReportId",
            //    keyValue: 11);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 5);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 6);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 7);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 8);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 9);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 10);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 11);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 12);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 13);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 14);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 15);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 16);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 17);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 18);

            //migrationBuilder.DeleteData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 19);

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "ButunHesabatlar");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "CashRegs");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "CashTransfer");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "Column_LastPurchasePrice");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "CountIn");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "CountOut");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "CurrAccs");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "DiscountList");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "Expense");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "InventoryTransfer");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "PaymentDetail");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "PriceList");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "Products");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "PurchaseIsReturn");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "ReportZet");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "RetailPurchaseInvoice");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "RetailSaleInvoice");

            //migrationBuilder.DeleteData(
            //    table: "DcClaims",
            //    keyColumn: "ClaimCode",
            //    keyValue: "SaleIsReturn");

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 5);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 6);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 7);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 8);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 9);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 10);

            //migrationBuilder.DeleteData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 11);

            //migrationBuilder.DeleteData(
            //    table: "DcReportTypes",
            //    keyColumn: "ReportTypeId",
            //    keyValue: (byte)0);

            //migrationBuilder.UpdateData(
            //    table: "DcReports",
            //    keyColumn: "ReportId",
            //    keyValue: 1,
            //    columns: new[] { "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
            //    values: new object[] { null, "Satis", "select * from TrInvoiceLines", (byte)1 });

            //migrationBuilder.UpdateData(
            //    table: "TrRoleClaims",
            //    keyColumn: "RoleClaimId",
            //    keyValue: 1,
            //    column: "ClaimCode",
            //    value: "PosDiscount");
        }
    }
}
