using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foxoft.Migrations
{
    public partial class asdfhgj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 4,
                columns: new[] { "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[] { "Report_Embedded_InvoiceReport", "\r\n--Declare @invoiceHeader nvarchar(50) = 'dd6927e4-d33c-4dc7-929c-1410c299e0a9'\r\n\r\n	select \r\n * from (\r\n	select  InvoiceLineId\r\n			,	[Marka] = isnull(' ' +  Feature02Desc,'')\r\n		  , [Ceki] = isnull(' ' + Feature04Desc,'')\r\n		  , [Reng] = isnull(' ' + Feature05Desc,'')\r\n		  , [Məhsul Tipi] = isnull(' ' + Feature06Desc,'')\r\n		  , [Soyutma Tipi] = isnull(' ' + Feature07Desc,'')\r\n		  , [BTU] = isnull(' ' + Feature09Desc,'')\r\n		  , [Ekran Ölçüsü] = isnull(' ' + Feature10Desc,'')\r\n		  , [Ekran İcazəsi] = isnull(' ' + Feature11Desc,'')\r\n		  , [Motorun Növü] = isnull(' ' + Feature12Desc,'')\r\n		  , [Həcmi] = isnull(' ' + Feature13Desc,'')\r\n		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + Feature14Desc,'')\r\n		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + Feature15Desc,'')\r\n		  , [Istehsalçı Ölkə] = isnull(' ' + Feature16Desc,'')\r\n		  , [Məhsuldarlıq] = isnull(' ' + Feature17Desc,'')\r\n		  , [Güc] = isnull(' ' + Feature18Desc,'')\r\n		  , [Tərtib Edən İstifadəçi] =( select CurrAccDesc from DcCurrAccs where CurrAccCode = TrInvoiceHeaders.CreatedUserName)\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, DcProducts.ProductCode\r\n	, ProductDesc\r\n	, QtyIn = QtyIn\r\n	, QtyOut = QtyOut\r\n	, Price\r\n	, TrInvoiceLines.PosDiscount\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, ProcessDesc\r\n	, TrInvoiceLines.CurrencyCode\r\n	, DcProducts.HierarchyCode\r\n	, HierarchyDesc\r\n	, IsReturn\r\n	, CustomsDocumentNumber\r\n	, PrintCount\r\n	, NetAmount\r\n	, LineDescription\r\n	, PriceLoc\r\n	, TrInvoiceLines.ExchangeRate\r\n	, NetAmountLoc = (QtyIn-QtyOut) * PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100\r\n	, DocumentNumber\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, DcCurrAccs.CurrAccCode\r\n	, DcCurrAccs.CurrAccDesc\r\n	, FirstName\r\n	, PhoneNum\r\n	, HeaderCreatedDate = TrInvoiceHeaders.CreatedDate\r\n	, LineCreatedDate = TrInvoiceLines.CreatedDate\r\n	, TrInvoiceHeaders.CreatedUserName\r\n	, CurrAccBalance = ISNULL((select sum((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n							 	from TrInvoiceLines il\r\n							 	left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n							 	where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode\r\n							 	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n							 	(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))														\r\n							 ), 0)\r\n							 + \r\n							 ISNULL((select sum(PaymentLoc) -- 200 usd\r\n							 	from TrPaymentLines pl\r\n							 	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							 	where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode\r\n							 		and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n							 		(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n							 ), 0)\r\n	, BalanceCode = 'M' + Convert(nvarchar, Format((select SUM(QtyIn - QtyOut) ProductBalance\r\n						from TrInvoiceLines il \r\n						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n						where il.ProductCode = TrInvoiceLines.ProductCode and WarehouseCode = TrInvoiceHeaders.WarehouseCode),'000'))\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, TrInvoiceHeaders.ToWarehouseCode\r\n	, [Depodan] = wareIn.WarehouseDesc\r\n	, [Depoya] = wareOut.WarehouseDesc\r\n	, Description\r\n	, TrInvoiceHeaders.StoreCode\r\n	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl \r\n							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)\r\n	, LastPurchasePrice\r\n	from TrInvoiceLines\r\n\r\n	join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n	left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\n	left join DcHierarchies on DcHierarchies.HierarchyCode = DcProducts.HierarchyCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = TrInvoiceLines.CurrencyCode\r\n	left join DcWarehouses wareIn on wareIn.WarehouseCode = TrInvoiceHeaders.WarehouseCode\r\n	left join DcWarehouses wareOut on wareOut.WarehouseCode = TrInvoiceHeaders.ToWarehouseCode\r\n	left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader\r\n\r\n\r\n) AS PivotTable2\r\n\r\n	order by LineCreatedDate\r\n\r\n\r\n", (byte)0 });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000001");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000002");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000003");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000004");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "C-000005");

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 18);

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "AppSettings");

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "Address", "BonusCardNum", "CashRegPaymentTypeCode", "CompanyCode", "ConfirmPassword", "CreatedDate", "CurrAccDesc", "CurrAccTypeCode", "CustomerTypeCode", "DataLanguageCode", "FatherName", "FirstName", "IdentityNum", "IsDefault", "LastName", "NewPassword", "OfficeCode", "PhoneNum", "RowGuid", "StoreCode", "TaxNum", "Theme", "VendorTypeCode" },
                values: new object[,]
                {
                    { "CA-1", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, null, null, null, "Administrator", null, false, null, "123", "ofs01", "0519678909", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "CA-2", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, null, null, null, "Mudir", null, false, "Mudir", "123", "ofs01", "0519678909", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "CA-3", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, null, null, null, "Operator", null, false, "Operator", "123", "ofs01", "0773628800", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "CA-4", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)3, null, null, null, "Satici", null, false, "Satici", "123", "ofs01", "0553628804", new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null },
                    { "CA-5", null, null, null, (byte)0, null, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ümumi Müştəri", (byte)1, null, null, null, "Ümumi Müştəri", null, true, null, "123", "ofs01", null, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "EUR",
                column: "ExchangeRate",
                value: 1.798f);

            migrationBuilder.UpdateData(
                table: "DcCurrencies",
                keyColumn: "CurrencyCode",
                keyValue: "USD",
                column: "ExchangeRate",
                value: 1.703f);

            migrationBuilder.UpdateData(
                table: "DcOffices",
                keyColumn: "OfficeCode",
                keyValue: "ofs01",
                column: "OfficeDesc",
                value: "Bakıxanov Ofisi");

            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[] { "ofs02", 0m, false, "Elmlər Ofisi", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01",
                column: "ProductDesc",
                value: "Yol Xerci");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02",
                column: "ProductDesc",
                value: "Isiq Pulu");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "ProductDesc",
                value: "Papaq");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "ProductDesc",
                value: "Salvar");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 4,
                columns: new[] { "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[] { "Report_Grid_Expenses", "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nselect Price\r\n, ProductDesc\r\n, CurrencyCode\r\n, NetAmountLoc\r\n, DocumentDate \r\n, LineDescription\r\n, StoreCode\r\nfrom TrInvoiceLines\r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nwhere ProcessCode = 'EX'", (byte)1 });

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 11,
                columns: new[] { "ReportName", "ReportQuery" },
                values: new object[] { "Report_Detail_ProductCard", "	--declare @StartDate date = dateadd(DAY, 1, getdate())\r\n	--declare @StartTime time =  '00:00:00.000'\r\n\r\nselect DcProducts.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc \r\n		  + isnull(' ' + Feature01,'') + isnull(' ' + Feature02,'') + isnull(' ' + Feature03,'') + isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19,'') + isnull(' ' + Feature20,'')\r\n, ProductDesc\r\n, WholesalePrice\r\n, DcHierarchies.HierarchyCode\r\n, HierarchyDesc\r\n, ProductTypeCode\r\n, [01] = isnull(' ' + Feature01Desc,'')\r\n, [02] = isnull(' ' + Feature02Desc,'')\r\n, [03] = isnull(' ' + Feature03Desc,'')\r\n, [04] = isnull(' ' + Feature04Desc,'')\r\n, [05] = isnull(' ' + Feature05Desc,'')\r\n, [06] = isnull(' ' + Feature06Desc,'')\r\n, [07] = isnull(' ' + Feature07Desc,'')\r\n, [09] = isnull(' ' + Feature09Desc,'')\r\n, [10] = isnull(' ' + Feature10Desc,'')\r\n, [11] = isnull(' ' + Feature11Desc,'')\r\n, [12] = isnull(' ' + Feature12Desc,'')\r\n, [13] = isnull(' ' + Feature13Desc,'')\r\n, [14] = isnull(' ' + Feature14Desc,'')\r\n, [15] = isnull(' ' + Feature15Desc,'')\r\n, [16] = isnull(' ' + Feature16Desc,'')\r\n, [17] = isnull(' ' + Feature17Desc,'')\r\n, [18] = isnull(' ' + Feature18Desc,'')\r\n, [19] = isnull(' ' + Feature22Desc,'')\r\n, [20] = isnull(' ' + Feature23Desc,'')\r\n\r\nfrom DcProducts\r\n\r\nleft join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\nwhere ProductTypeCode = 1\r\n			\r\norder by isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc\r\n" });

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "ReportId", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery", "ReportTypeId" },
                values: new object[,]
                {
                    { 10, null, "", "Report_Grid_WarehouseBalance", "\r\n\r\nselect DcProducts.ProductCode\r\n	, DcProducts.ProductDesc\r\n	, TrInvoiceHeaders.WarehouseCode\r\n	, Balance = sum(QtyIn - QtyOut)\r\n	, LastPurchasePrice = (select top 1 PriceLoc * (100 - PosDiscount)/100\r\n					from TrInvoiceLines \r\n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \r\n					{StartDate}\r\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\r\n					)\r\n	, Toplam = sum(QtyIn - QtyOut) * (select top 1 PriceLoc * (100 - PosDiscount)/100\r\n					from TrInvoiceLines \r\n					left join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId\r\n					where TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\n					and (ProcessCode = 'RP' or ProcessCode = 'CI') \r\n					{StartDate}\r\n					order by TrInvoiceHeaders.DocumentDate desc, TrInvoiceHeaders.DocumentTime desc\r\n					)\r\nfrom TrInvoiceLines\r\nLEFT JOIN TrInvoiceHeaders \r\n	ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nLEFT JOIN DcProducts \r\n	on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\nwhere DcProducts.ProductTypeCode = 1\r\n{StartDate}\r\nGroup by DcProducts.ProductCode\r\n	, DcProducts.ProductDesc\r\n	, TrInvoiceHeaders.WarehouseCode\r\n\r\n", (byte)1 },
                    { 8, null, "", "Report_Grid_Profit", "\r\n\r\n\r\nSELECT Maya = (-1)*(case when Dvijok.ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0) else 0 end)\r\n, Menfeet = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0)) else 0 end)\r\n, [Net Menfeet] = (-1)*(case when ProcessCode = 'RS' then (Dvijok.QtyIn - Dvijok.QtyOut) * ((Dvijok.PriceLoc * (100 - PosDiscount) / 100) - ISNULL(ISNULL(NULLIF(SonQiymet, 0), LastPurchasePrice),0)) else 0 end) - Xərc\r\n, *\r\nFROM (\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, ProductDesc\r\n, Qty = (QtyIn-QtyOut)*(-1)\r\n, Price\r\n, PriceLoc\r\n, Amount\r\n, TrInvoiceLines.PosDiscount\r\n, QtyIn\r\n, QtyOut\r\n, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end\r\n, Satis = (-1)*(case when TrInvoiceHeaders.ProcessCode = 'RS' then (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100)) else 0 end)\r\n, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end\r\n, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end\r\n, LastPurchasePrice\r\n, SonQiymet = (select top 1 toplam = il.PriceLoc * (1 - (il.PosDiscount / 100))  \r\n					from TrInvoiceLines il\r\n					join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n					where il.ProductCode = TrInvoiceLines.ProductCode\r\n					and (ih.ProcessCode = 'RP' or ih.ProcessCode = 'CI')\r\n					and ih.IsReturn = 0\r\n					and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n						 (CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n					ORDER BY ih.DocumentDate desc\r\n					, il.CreatedDate desc )	\r\n\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, InvoiceNumber = DocumentNumber\r\n, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - LastPurchasePrice)  / NULLIF(LastPurchasePrice,0) * 100,2)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs.CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, Barcode\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	\r\n\r\nwhere TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'RS', 'EX')\r\n--and DocumentNumber = 'RS-000012'\r\n) Dvijok\r\norder by Dvijok.DocumentDate\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n", (byte)1 },
                    { 7, null, "", "Report_Grid_ProductMovements", "\r\n\r\n\r\n\r\n\r\nselect  InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, [Məhsulun Geniş Adı] = isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') \r\n		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') \r\n		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') \r\n		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')+ isnull(' ' + Feature23,'')\r\n		  + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') + isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') \r\n		  + isnull(' ' + Feature29,'') \r\n\r\n\r\n, ProductDesc\r\n, QtyIn\r\n, QtyOut\r\n, Price\r\n, PriceLoc\r\n, Net = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * TrInvoiceLines.PosDiscount / 100))\r\n, [Qiymət End.li] = Price * (1 - (TrInvoiceLines.PosDiscount / 100))\r\n, Amount\r\n, NetAmountLoc\r\n, [Qaime Üzrə Ödəniş] = (select sum(TrPaymentLines.PaymentLoc) from TrPaymentLines \r\n		join TrPaymentHeaders on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId\r\n		where TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId)\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, DocumentNumber\r\n, IsReturn\r\n, LastPurchasePrice\r\n, Benefit = (QtyIn - QtyOut) * ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - LastPurchasePrice)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceLines.PosDiscount\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs .CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, PrintCount\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, Barcode\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il where il.ProductCode = TrInvoiceLines .ProductCode)\r\n, TrInvoiceHeaders.CreatedUserName\r\n, ImagePath\r\n--, ROW_NUMBER() OVER (ORDER BY DocumentDate DESC) AS RowNum  \r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode\r\nleft join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode\r\n\r\n\r\norder by DocumentDate, DocumentTime\r\n\r\n\r\n", (byte)1 },
                    { 6, null, "", "Report_Grid_MovementsWithAccounts", "\r\n\r\n\r\nselect 	CurrAccDesc\r\n	--, ProductDesc\r\n	, NetAmountLoc\r\n	, PaymentLoc\r\n	, [Ara Toplam] = sum(Summary) OVER (ORDER BY DocumentDate, DocumentTime )\r\n	, ProcessDesc\r\n	, DocumentNumber\r\n	, CurrAccCode\r\n	, DocumentDate\r\n	, DocumentTime\r\n	, InvoiceHeaderId\r\n	, PaymentHeaderId\r\n	, LineDescription\r\n	, IsReturn\r\n	, StoreCode\r\n	--, LineId\r\nfrom (\r\n	select FirstName\r\n	, CurrAccDesc\r\n	--, ProductDesc\r\n	, TrInvoiceHeaders.InvoiceHeaderId\r\n	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, PaymentLoc= 0\r\n	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\r\n	, ProcessDesc = ProcessDesc\r\n	, DocumentNumber\r\n	, TrInvoiceHeaders.StoreCode\r\n	, TrInvoiceHeaders.CurrAccCode\r\n	, TrInvoiceHeaders.DocumentDate\r\n	, TrInvoiceHeaders.DocumentTime\r\n	, LineDescription = TrInvoiceHeaders.Description\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, IsReturn\r\n	--, LineId = InvoiceLineId\r\n	from TrInvoiceLines \r\n	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\n	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = TrInvoiceHeaders.ProcessCode\r\n	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode\r\n	group by FirstName\r\n			, CurrAccDesc\r\n			, ProcessDesc\r\n			, DocumentNumber\r\n			, TrInvoiceHeaders.InvoiceHeaderId\r\n			, TrInvoiceHeaders.CurrAccCode\r\n			, TrInvoiceHeaders.DocumentDate	\r\n			, TrInvoiceHeaders.DocumentTime\r\n			, TrInvoiceHeaders.Description\r\n			, TrInvoiceHeaders.StoreCode\r\n	, TrInvoiceHeaders.ProcessCode\r\n	, IsReturn\r\n	\r\n	UNION ALL \r\n	\r\n	select FirstName\r\n	--, ProductCode = ''\r\n	, CurrAccDesc = CurrAccDesc\r\n	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n	, TrPaymentHeaders.PaymentHeaderId\r\n	, NetAmountLoc = 0\r\n	, PaymentLoc\r\n	, Summary = PaymentLoc\r\n	, ProcessDesc = N'Ödəniş'\r\n	, DocumentNumber\r\n	, TrPaymentHeaders.StoreCode\r\n	, TrPaymentHeaders.CurrAccCode\r\n	, DocumentDate = TrPaymentHeaders.OperationDate\r\n	, DocumentTime = TrPaymentHeaders.OperationTime\r\n	, LineDescription\r\n	, ProcessCode = 'PA'\r\n	, IsReturn = CAST(0 as bit)\r\n	--, LineId = PaymentLineId\r\n	from TrPaymentLines\r\n	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\n	left join DcCurrAccs  on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode	\r\n\r\n) as CurrAccExtra where 1=1 {CurrAccCode}\r\n\r\norder by DocumentDate, DocumentTime", (byte)1 },
                    { 5, null, "", "Report_Grid_MoneyMovements", "\r\n\r\n\r\n\r\nselect  PaymentLineId\r\n, TrPaymentHeaders.PaymentHeaderId\r\n, TrPaymentHeaders.InvoiceHeaderId\r\n, InvoiceNumber = tph.DocumentNumber\r\n, DcPaymentTypes.PaymentTypeCode\r\n, PaymentTypeDesc\r\n, PaymentLoc\r\n, Payment\r\n, CurrencyCode\r\n, LineDescription\r\n, TrPaymentHeaders.DocumentNumber\r\n, TrPaymentHeaders.DocumentDate\r\n, TrPaymentHeaders.DocumentTime\r\n, TrPaymentHeaders.OperationDate\r\n, TrPaymentHeaders.OperationTime\r\n, OperationType\r\n, TrPaymentHeaders.CurrAccCode\r\n, CashRegisterCode\r\n, FirstName\r\n, DcCurrAccs.CurrAccDesc\r\n, TrPaymentHeaders.StoreCode\r\n, tpl.CreatedDate\r\n, tpl.CreatedUserName\r\n, [Cari Hesab Balansı] = (	(select sum ((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd\r\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\r\n	from TrInvoiceLines il\r\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\r\n	where DcCurrAccs.CurrAccCode = ih.CurrAccCode\r\n	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\r\n	(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		+ \r\n(select Sum(PaymentLoc) -- 200 usd\r\n	from TrPaymentLines pl\r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\r\n	where DcCurrAccs.CurrAccCode = ph.CurrAccCode \r\n			and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=\r\n			(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))\r\n		)\r\n\r\n from TrPaymentLines tpl\r\nleft join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\r\nleft join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId\r\nleft Join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode\r\norder by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc\r\n\r\n\r\n\r\n", (byte)1 },
                    { 9, null, "", "Report_Grid_RecentGoods", "\r\n\r\n\r\nselect \r\n [Topdan Sat. Qiy.] =  Round(WholesalePrice, 0)\r\n, [Son Alış Qiy.] =  Round(LastPurchasePrice, 0)\r\n, [%] =CONVERT(int, Round((1 - (PivotTable.LastPurchasePrice / NULLIF(PivotTable.WholesalePrice,0))) * 100, 0)) \r\n, *\r\nfrom (\r\n	select prdcts.ProductCode\r\n	, LastUpdatedDate\r\n	, UseInternet\r\n	, ProductDesc \r\n	, HierarchyCode \r\n	, FeatureCode\r\n	, FeatureTypeId\r\n	, WholesalePrice\r\n	, LastPurchasePrice = (select top 1  PriceLoc * (1 - (PosDiscount / 100))	\r\n								from TrInvoiceLines il\r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.ProcessCode IN ('RP', 'CI') \r\n								and ih.IsReturn = 0\r\n								order by ih.DocumentDate desc\r\n										, ih.CreatedDate desc\r\n								)\r\n	, [Son Alış Günü] = (select top 1  il.LastUpdatedDate	\r\n								from TrInvoiceLines il\r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.ProcessCode IN ('RP') \r\n								and ih.IsReturn = 0\r\n								order by ih.DocumentDate desc\r\n										, ih.CreatedDate desc\r\n								)\r\n	, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il \r\n								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId\r\n								where il.ProductCode = prdcts.ProductCode\r\n								and ih.WarehouseCode = 'depo-01')\r\n	from DcProducts prdcts\r\n	left join TrProductFeatures on TrProductFeatures.ProductCode = prdcts.ProductCode\r\n\r\n	where ProductTypeCode = 1\r\n	) pro\r\nPIVOT (Max(FeatureCode) FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25]) \r\n) AS PivotTable \r\norder by PivotTable.[Son Alış Günü] \r\n\r\n\r\n\r\n", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "DcWarehouses",
                columns: new[] { "WarehouseCode", "ControlStockLevel", "IsDefault", "IsDisabled", "OfficeCode", "PermitNegativeStock", "RowGuid", "StoreCode", "WarehouseDesc", "WarehouseTypeCode", "WarnNegativeStock", "WarnStockLevelRate" },
                values: new object[] { "depo-02", false, false, false, "ofs01", false, new Guid("00000000-0000-0000-0000-000000000000"), "mgz01", "Elmlər deposu", (byte)0, false, false });

            migrationBuilder.UpdateData(
                table: "TrCurrAccRoles",
                keyColumn: "CurrAccRoleId",
                keyValue: 1,
                column: "CurrAccCode",
                value: "CA-1");
        }
    }
}
