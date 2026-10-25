using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foxoft.Migrations
{
    /// <inheritdoc />
    public partial class OpenAiApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrMessageLogs_Sender",
                table: "TrMessageLogs");

            migrationBuilder.UpdateData(
                table: "AppSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OpenAIApiKey", "OpenAIModel" },
                values: new object[] { null, "gpt-4o" });

            migrationBuilder.InsertData(
                table: "TrRoleClaims",
                columns: new[] { "RoleClaimId", "ClaimCode", "RoleCode" },
                values: new object[] { 221, "GoogleContactWizard", "Admin" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrCurrAccRelations");

            migrationBuilder.DropTable(
                name: "TrUserStores");

            migrationBuilder.DropTable(
                name: "DcCurrAccRelationTypes");

            migrationBuilder.DeleteData(
                table: "TrRoleClaims",
                keyColumn: "RoleClaimId",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "DcClaims",
                keyColumn: "ClaimCode",
                keyValue: "GoogleContactWizard");

            migrationBuilder.DropColumn(
                name: "AutoCreateGoogleContact",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "OpenAIApiKey",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "OpenAIModel",
                table: "AppSettings");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 2,
                column: "ReportQuery",
                value: "select DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, Balance = ISNULL(SUM(CAST(Amount as money)), 0)\n, PhoneNum\n, IsVIP\n, CurrAccTypeCode\n, PersonalTypeCode\n, IsDisabled\nfrom \nDcCurrAccs \nleft join \n(\n	select CurrAccCode\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\n	from TrInvoiceLines il\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\n	where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS')\n	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n\n	UNION ALL \n	\n	select CurrAccCode\n	, Amount = PaymentLoc -- 200 usd\n	from TrPaymentLines pl\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	\n	where 1=1 AND pl.PaymentTypeCode != 4\n	--and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n\n	UNION ALL\n\n	select CurrAccCode = prh.CurrAccCode\n	, Amount = prh.NetSalary\n	from TrPayrollHeaders prh\n	left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id\n	where 1 = 1\n	--and (CAST(EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1)) AS DATETIME) + CAST('23:59:59' AS DATETIME)) <=\n	--(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\nwhere 1 = 1 \n	and IsDisabled = 0\n	--and DcCurrAccs.IsVIP = 1 \n	--and balance.CurrAccCode = '1403'\ngroup by DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, PhoneNum\n, IsVIP\n, CurrAccTypeCode\n, IsDisabled\n, PersonalTypeCode\norder by CurrAccDesc");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 9,
                column: "ReportQuery",
                value: "\r\n\r\nselect ph.*\r\n	, ProcessDesc\r\n	, pl.PaymentLineId\r\n	, pl.PaymentTypeCode\r\n	, pl.Payment\r\n	, pl.PaymentLoc\r\n	, pl.CurrencyCode\r\n	, pl.ExchangeRate\r\n	, pl.LineDescription\r\n	, pl.CashRegisterCode\r\n	, pl.PaymentMethodId\r\n	, cari.CurrAccDesc\r\n	, cari.PhoneNum\r\n	, CashRegisterDesc = kassa.CurrAccDesc\r\n	, DcPaymentTypes.PaymentTypeDesc\r\n	, CurrAccBalance = dbo.CurrAccBalance(ph.CurrAccCode, CAST(ph.OperationDate as Datetime) + CAST(ph.OperationTime as Datetime))\r\n	\r\n	, StorePhoneNum = store.PhoneNum\r\n	, StoreAddress = store.Address\r\n\r\n	from TrPaymentLines pl \r\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\r\n	left join DcPaymentTypes on DcPaymentTypes.PaymentTypeCode = pl.PaymentTypeCode\r\n	left join DcCurrAccs cari on cari.CurrAccCode = ph.CurrAccCode\r\n	left join DcCurrAccs kassa on kassa.CurrAccCode = pl.CashRegisterCode\r\n	left join DcProcesses on DcProcesses.ProcessCode = ph.ProcessCode\r\n	left join DcCurrAccs store on store.CurrAccCode = ph.StoreCode\r\n	left join DcCurrencies on DcCurrencies.CurrencyCode = pl.CurrencyCode\r\n\r\n	where ph.PaymentHeaderId = @PaymentHeaderId\n	order by DocumentDate\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 10,
                column: "ReportQuery",
                value: "select prh.Id\n	, prh.CurrAccCode\n	, prh.PayrollPeriodId\n	, prh.GrossSalary\n	, prh.NetSalary\n	, PayrollLineId = prl.Id\n	, prl.PayrollItemType\n	, PayrollItemTypeName = case prl.PayrollItemType\n		when 1 then 'Maaş'\n		when 2 then 'Bonus'\n		when 3 then 'Əlavə İş'\n		when 4 then 'Vergi'\n		when 5 then 'Sığorta'\n		when 6 then 'Tutulma'\n		else 'Digər'\n	  end\n	, LineDescription = prl.Description\n	, prl.Amount\n	, prl.CurrencyCode\n	, prl.ExchangeRate\n	, prl.AmountLoc\n	, cari.CurrAccDesc\n	, cari.FirstName\n	, cari.LastName\n	, cari.PhoneNum\n	, EmployeeName = isnull(nullif(cari.CurrAccDesc, ''), rtrim(isnull(cari.FirstName, '') + ' ' + isnull(cari.LastName, '')))\n	, prp.PeriodYear\n	, prp.PeriodMonth\n	, PeriodName = right('0000' + cast(prp.PeriodYear as varchar(4)), 4) + '-' + right('00' + cast(prp.PeriodMonth as varchar(2)), 2)\n\n	from TrPayrollLines prl\n	inner join TrPayrollHeaders prh on prl.PayrollHeaderId = prh.Id\n	left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id\n	left join DcCurrAccs cari on cari.CurrAccCode = prh.CurrAccCode\n\n	where prh.Id = @PayrollHeaderId\n	order by prl.PayrollItemType\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 11,
                column: "ReportQuery",
                value: "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nselect Price\r\n, ProductDesc\r\n, CurrencyCode\r\n, NetAmountLoc\r\n, DocumentDate \r\n, LineDescription\r\n, StoreCode\r\nfrom TrInvoiceLines\r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nwhere ProcessCode = 'EX'\r\n\r\nUNION ALL\r\n\r\nselect Price = prh.GrossSalary\r\n, ProductDesc = CONCAT(N'Əməkhaqqı - ', DcCurrAccs.CurrAccDesc)\r\n, CurrencyCode = 'AZN'\r\n, NetAmountLoc = prh.GrossSalary\r\n, DocumentDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))\r\n, LineDescription = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı (', DcCurrAccs.CurrAccDesc, ')')\r\n, StoreCode = DcCurrAccs.StoreCode\r\nfrom TrPayrollHeaders prh\r\nleft join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id\r\nleft join DcCurrAccs on prh.CurrAccCode = DcCurrAccs.CurrAccCode");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 13,
                column: "ReportQuery",
                value: "select 	CurrAccDesc\n	--, ProductDesc\n	, NetAmountLoc\n	, PaymentLoc\n	, [Ara Toplam] = sum(Summary) OVER (ORDER BY DocumentDate, DocumentTime )\n	, ProcessDesc\n	, DocumentNumber\n	, CurrAccCode\n	, DocumentDate\n	, DocumentTime\n	, InvoiceHeaderId\n	, PaymentHeaderId\n	, PayrollHeaderId\n	, LineDescription\n	, IsReturn\n	, StoreCode\n	--, LineId\nfrom (\n	select FirstName\n	, CurrAccDesc\n	--, ProductDesc\n	, ih.InvoiceHeaderId\n	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)\n	, PayrollHeaderId = cast(cast(0 as binary) as uniqueidentifier)\n	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\n	, PaymentLoc= 0\n	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd\n	, ProcessDesc = IIF(IsReturn = 1, ProcessDesc + ' - Geri Qaytarma', ProcessDesc)\n	, DocumentNumber\n	, ih.StoreCode\n	, ih.CurrAccCode\n	, ih.DocumentDate\n	, ih.DocumentTime\n	, LineDescription = ih.Description\n	, ih.ProcessCode\n	, IsReturn\n	--, LineId = InvoiceLineId\n	from TrInvoiceLines \n	left join TrInvoiceHeaders ih on TrInvoiceLines.InvoiceHeaderId = ih.InvoiceHeaderId\n	left join DcCurrAccs on ih.CurrAccCode = DcCurrAccs.CurrAccCode\n	left join DcProcesses on DcProcesses.ProcessCode = ih.ProcessCode\n	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode\n	where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )\n	group by FirstName\n			, CurrAccDesc\n			, ProcessDesc\n			, DocumentNumber\n			, ih.InvoiceHeaderId\n			, ih.CurrAccCode\n			, ih.DocumentDate	\n			, ih.DocumentTime\n			, ih.Description\n			, ih.StoreCode\n			, ih.ProcessCode\n			, IsReturn\n	\n	UNION ALL \n	\n	select FirstName\n	--, ProductCode = ''\n	, CurrAccDesc = CurrAccDesc\n	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\n	, TrPaymentHeaders.PaymentHeaderId\n	, PayrollHeaderId = cast(cast(0 as binary) as uniqueidentifier)\n	, NetAmountLoc = 0\n	, PaymentLoc\n	, Summary = PaymentLoc\n	, ProcessDesc = IIF(PaymentTypeCode = 3, N'Bonus', N'Ödəniş')\n	, DocumentNumber\n	, TrPaymentHeaders.StoreCode\n	, TrPaymentHeaders.CurrAccCode\n	, DocumentDate = TrPaymentHeaders.OperationDate\n	, DocumentTime = TrPaymentHeaders.OperationTime\n	, LineDescription\n	, ProcessCode = 'PA'\n	, IsReturn = CAST(0 as bit)\n	--, LineId = PaymentLineId\n	from TrPaymentLines\n	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId\n	left join DcCurrAccs  on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode	\n\n	UNION ALL\n\n	select FirstName = DcCurrAccs.FirstName\n	, CurrAccDesc = DcCurrAccs.CurrAccDesc\n	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\n	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)\n	, PayrollHeaderId = prh.Id\n	, NetAmountLoc = prh.NetSalary\n	, PaymentLoc = 0\n	, Summary = prh.NetSalary\n	, ProcessDesc = N'Əməkhaqqı'\n	, DocumentNumber = CONCAT('PR-', prp.PeriodYear, '-', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2))\n	, StoreCode = DcCurrAccs.StoreCode\n	, CurrAccCode = prh.CurrAccCode\n	, DocumentDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))\n	, DocumentTime = CAST('23:59:59' AS TIME)\n	, LineDescription = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı')\n	, ProcessCode = 'PR'\n	, IsReturn = CAST(0 as bit)\n	from TrPayrollHeaders prh\n	left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id\n	left join DcCurrAccs on prh.CurrAccCode = DcCurrAccs.CurrAccCode\n\n) as CurrAccExtra where 1=1 {CurrAccCode}\n\norder by DocumentDate, DocumentTime");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 15,
                column: "ReportQuery",
                value: "\r\n\r\nSELECT \r\n Menfeet = Satis - Maya\r\n, [Net Menfeet] = Satis - Maya - Xərc\r\n, *\r\nFROM  (\r\nselect  TrInvoiceLines.InvoiceLineId\r\n, TrInvoiceHeaders.InvoiceHeaderId\r\n, TrInvoiceLines.ProductCode\r\n, ProductDesc\r\n, Price\r\n, PriceLoc\r\n, Amount\r\n, NetAmountLoc\r\n, TrInvoiceLines.PosDiscount\r\n, QtyIn\r\n, QtyOut\r\n, Satis = case when TrInvoiceHeaders.ProcessCode IN ('WS', 'RS', 'IS') then NetAmountLoc else 0 end\r\n, Maya = CASE WHEN TrInvoiceHeaders.ProcessCode IN ('WS', 'RS', 'IS') THEN (QtyOut - QtyIn) * COALESCE(ProductCost, 0) ELSE 0 END\r\n, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end\r\n, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end\r\n, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end\r\n, IsReturn\r\n, ProductCost\r\n--, SonQiymet = dbo.GetProductCost(TrInvoiceLines.ProductCode, CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))\r\n, LineDescription\r\n, SalesPersonCode\r\n, CurrencyCode\r\n, ExchangeRate\r\n, TrInvoiceHeaders.ProcessCode\r\n, ProcessDesc\r\n, InvoiceNumber = DocumentNumber\r\n--, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)  / NULLIF(ProductCost,0) * 100,2)\r\n, DocumentDate\r\n, DocumentTime\r\n, OperationDate\r\n, OperationTime\r\n, Description\r\n, TrInvoiceHeaders.CurrAccCode\r\n, DcCurrAccs.CurrAccDesc\r\n, DcCurrAccTypes.CurrAccTypeDesc\r\n, DcCurrAccs.CurrAccTypeCode\r\n, TrInvoiceHeaders.OfficeCode\r\n, TrInvoiceHeaders.StoreCode\r\n, WarehouseCode\r\n, CustomsDocumentNumber\r\n, PosTerminalId\r\n, IsSuspended\r\n, IsCompleted\r\n, IsSalesViaInternet\r\n, IsLocked\r\n, DcProducts.ProductTypeCode\r\n, ProductTypeDesc\r\n, UsePos\r\n, PromotionCode\r\n, TaxRate\r\n, RetailPrice\r\n, PurchasePrice\r\n, WholesalePrice\r\n, TrInvoiceLines.CreatedDate\r\n, TrInvoiceLines.CreatedUserName\r\n, TrInvoiceLineExts.PriceDiscountedLoc\r\n\r\nfrom TrInvoiceLines \r\nleft join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId\r\nleft join TrInvoiceLineExts on TrInvoiceLineExts.InvoiceLineId = TrInvoiceLines.InvoiceLineId\r\nleft join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode\r\nleft join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode\r\nleft join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\nleft join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode\r\nleft join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	\r\n\r\nwhere TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'WS', 'RS', 'IS', 'EX')\r\n--and DocumentNumber = 'RS-000012'\r\n\r\nUNION ALL\r\n\r\nselect InvoiceLineId = cast(cast(0 as binary) as uniqueidentifier)\r\n, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)\r\n, ProductCode = ''\r\n, ProductDesc = CONCAT(N'Əməkhaqqı - ', DcCurrAccs.CurrAccDesc)\r\n, Price = prh.GrossSalary\r\n, PriceLoc = prh.GrossSalary\r\n, Amount = prh.GrossSalary\r\n, NetAmountLoc = prh.GrossSalary\r\n, PosDiscount = cast(0 as decimal(18, 2))\r\n, QtyIn = cast(0 as decimal(18, 4))\r\n, QtyOut = cast(0 as decimal(18, 4))\r\n, Satis = cast(0 as decimal(18, 2))\r\n, Maya = cast(0 as decimal(18, 2))\r\n, Xərc = prh.GrossSalary\r\n, Artirma = cast(0 as decimal(18, 2))\r\n, Silinme = cast(0 as decimal(18, 2))\r\n, IsReturn = cast(0 as bit)\r\n, ProductCost = cast(0 as decimal(18, 2))\r\n, LineDescription = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı (', DcCurrAccs.CurrAccDesc, ')')\r\n, SalesPersonCode = ''\r\n, CurrencyCode = 'AZN'\r\n, ExchangeRate = cast(1 as decimal(18, 4))\r\n, ProcessCode = 'PR'\r\n, ProcessDesc = N'Əməkhaqqı'\r\n, InvoiceNumber = CONCAT('PR-', prp.PeriodYear, '-', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2))\r\n, DocumentDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))\r\n, DocumentTime = CAST('23:59:59' AS TIME)\r\n, OperationDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))\r\n, OperationTime = CAST('23:59:59' AS TIME)\r\n, Description = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı')\r\n, CurrAccCode = prh.CurrAccCode\r\n, CurrAccDesc = DcCurrAccs.CurrAccDesc\r\n, CurrAccTypeDesc = DcCurrAccTypes.CurrAccTypeDesc\r\n, CurrAccTypeCode = DcCurrAccs.CurrAccTypeCode\r\n, OfficeCode = ''\r\n, StoreCode = DcCurrAccs.StoreCode\r\n, WarehouseCode = ''\r\n, CustomsDocumentNumber = ''\r\n, PosTerminalId = cast(null as int)\r\n, IsSuspended = cast(0 as bit)\r\n, IsCompleted = cast(1 as bit)\r\n, IsSalesViaInternet = cast(0 as bit)\r\n, IsLocked = prp.IsClosed\r\n, ProductTypeCode = cast(null as int)\r\n, ProductTypeDesc = ''\r\n, UsePos = cast(0 as bit)\r\n, PromotionCode = ''\r\n, TaxRate = cast(0 as decimal(18, 2))\r\n, RetailPrice = cast(0 as decimal(18, 2))\r\n, PurchasePrice = cast(0 as decimal(18, 2))\r\n, WholesalePrice = cast(0 as decimal(18, 2))\r\n, CreatedDate = cast(null as datetime)\r\n, CreatedUserName = ''\r\n, PriceDiscountedLoc = cast(0 as decimal(18, 2))\r\nfrom TrPayrollHeaders prh\r\nleft join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id\r\nleft join DcCurrAccs on prh.CurrAccCode = DcCurrAccs.CurrAccCode\r\nleft join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode\r\n) Dvijok\r\norder by Dvijok.DocumentDate\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 20,
                column: "ReportQuery",
                value: "--declare @EndDate date = dateadd(DAY, 1, getdate())\n--declare @EndTime time =  '00:00:00.000'\n\nselect DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, PhoneNum\n, IsVIP\n, Amount = sum(isnull(Amount,0))\n, DcCurrAccs.CurrAccTypeCode\n, CurrAccTypeDesc\n	from \nDcCurrAccs \nleft join \n(\n	select CurrAccCode\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\n	from TrInvoiceLines il\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\n--	where 1=1\n--	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n\n	UNION ALL \n	\n	select CurrAccCode\n	, Amount = PaymentLoc -- 200 usd\n	from TrPaymentLines pl\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\n--	where 1=1 \n--	and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n\n	UNION ALL\n\n	select CurrAccCode = prh.CurrAccCode\n	, Amount = prh.NetSalary\n	from TrPayrollHeaders prh\n	left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id\n--	where 1=1\n--	and (CAST(EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1)) AS DATETIME) + CAST('23:59:59' AS DATETIME)) <=\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\njoin DcCurrAccTypes on DcCurrAccTypes.CurrAccTypeCode = DcCurrAccs.CurrAccTypeCode\nwhere 1 = 1 \n	and DcCurrAccs.CurrAccTypeCode in (1, 2, 3)\n	--and DcCurrAccs.IsVIP = 1 \n	--and balance.CurrAccCode = '1403'\ngroup by DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, PhoneNum\n, IsVIP\n, DcCurrAccs.CurrAccTypeCode\n, CurrAccTypeDesc\n\nhaving   sum(Amount) < 0\norder by CurrAccDesc");

            migrationBuilder.UpdateData(
                table: "DcReports",
                keyColumn: "ReportId",
                keyValue: 21,
                column: "ReportQuery",
                value: "--declare @EndDate date = dateadd(DAY, 1, getdate())\n--declare @EndTime time =  '00:00:00.000'\n\nselect DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, PhoneNum\n, IsVIP\n, Amount = sum(Amount)\nfrom \nDcCurrAccs \nleft join \n(\n	select CurrAccCode\n	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd\n	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd\n	from TrInvoiceLines il\n	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId\n--	where 1=1\n--	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n\n	UNION ALL \n	\n	select CurrAccCode\n	, Amount = PaymentLoc -- 200 usd\n	from TrPaymentLines pl\n	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId\n--	where 1=1 \n--	and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n\n	UNION ALL\n\n	select CurrAccCode = prh.CurrAccCode\n	, Amount = prh.NetSalary\n	from TrPayrollHeaders prh\n	left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id\n--	where 1=1\n--	and (CAST(EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1)) AS DATETIME) + CAST('23:59:59' AS DATETIME)) <=\n--	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))\n) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode\nwhere 1 = 1 \nand CurrAccTypeCode in (1,2,3)\n	--and DcCurrAccs.IsVIP = 1 \n	--and balance.CurrAccCode = '1403'\ngroup by DcCurrAccs.CurrAccCode\n, CurrAccDesc\n, PhoneNum\n, IsVIP\n\nhaving   sum(Amount) > 0");

            migrationBuilder.CreateIndex(
                name: "IX_TrSessions_CurrAccCode",
                table: "TrSessions",
                column: "CurrAccCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrMessageLogs_Sender",
                table: "TrMessageLogs",
                column: "Sender");

            migrationBuilder.CreateIndex(
                name: "IX_TrCurrAccRoles_CurrAccCode",
                table: "TrCurrAccRoles",
                column: "CurrAccCode");
        }
    }
}
