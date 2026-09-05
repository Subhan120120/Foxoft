

SELECT 
 Menfeet = Satis - Maya
, [Net Menfeet] = Satis - Maya - Xərc
, *
FROM  (
select  TrInvoiceLines.InvoiceLineId
, TrInvoiceHeaders.InvoiceHeaderId
, TrInvoiceLines.ProductCode
, ProductDesc
, Price
, PriceLoc
, Amount
, NetAmountLoc
, TrInvoiceLines.PosDiscount
, QtyIn
, QtyOut
, Satis = case when TrInvoiceHeaders.ProcessCode IN ('WS', 'RS', 'IS') then NetAmountLoc else 0 end
, Maya = CASE WHEN TrInvoiceHeaders.ProcessCode IN ('WS', 'RS', 'IS') THEN (QtyOut - QtyIn) * COALESCE(ProductCost, 0) ELSE 0 END
, Xərc = case when TrInvoiceHeaders.ProcessCode = 'EX' then NetAmountLoc else 0 end
, Artirma = case when TrInvoiceHeaders.ProcessCode = 'CI' then NetAmountLoc else 0 end
, Silinme = case when TrInvoiceHeaders.ProcessCode = 'CO' then NetAmountLoc else 0 end
, IsReturn
, ProductCost
--, SonQiymet = dbo.GetProductCost(TrInvoiceLines.ProductCode, CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))
, LineDescription
, SalesPersonCode
, CurrencyCode
, ExchangeRate
, TrInvoiceHeaders.ProcessCode
, ProcessDesc
, InvoiceNumber = DocumentNumber
--, Faiz =Round( ((PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100) - ProductCost)  / NULLIF(ProductCost,0) * 100,2)
, DocumentDate
, DocumentTime
, OperationDate
, OperationTime
, Description
, TrInvoiceHeaders.CurrAccCode
, DcCurrAccs.CurrAccDesc
, DcCurrAccTypes.CurrAccTypeDesc
, DcCurrAccs.CurrAccTypeCode
, TrInvoiceHeaders.OfficeCode
, TrInvoiceHeaders.StoreCode
, WarehouseCode
, CustomsDocumentNumber
, PosTerminalId
, IsSuspended
, IsCompleted
, IsSalesViaInternet
, IsLocked
, DcProducts.ProductTypeCode
, ProductTypeDesc
, UsePos
, PromotionCode
, TaxRate
, RetailPrice
, PurchasePrice
, WholesalePrice
, TrInvoiceLines.CreatedDate
, TrInvoiceLines.CreatedUserName
, TrInvoiceLineExts.PriceDiscountedLoc

from TrInvoiceLines 
left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join TrInvoiceLineExts on TrInvoiceLineExts.InvoiceLineId = TrInvoiceLines.InvoiceLineId
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
left join DcProductTypes on DcProducts.ProductTypeCode = DcProductTypes.ProductTypeCode
left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode
left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
left join DcCurrAccs as SalesPerson on TrInvoiceLines.SalesPersonCode = SalesPerson.CurrAccCode	

where TrInvoiceHeaders.ProcessCode IN ('CI', 'CO', 'WS', 'RS', 'IS', 'EX')
--and DocumentNumber = 'RS-000012'

UNION ALL

select InvoiceLineId = cast(cast(0 as binary) as uniqueidentifier)
, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)
, ProductCode = ''
, ProductDesc = CONCAT(N'Əməkhaqqı - ', DcCurrAccs.CurrAccDesc)
, Price = prh.GrossSalary
, PriceLoc = prh.GrossSalary
, Amount = prh.GrossSalary
, NetAmountLoc = prh.GrossSalary
, PosDiscount = cast(0 as decimal(18, 2))
, QtyIn = cast(0 as decimal(18, 4))
, QtyOut = cast(0 as decimal(18, 4))
, Satis = cast(0 as decimal(18, 2))
, Maya = cast(0 as decimal(18, 2))
, Xərc = prh.GrossSalary
, Artirma = cast(0 as decimal(18, 2))
, Silinme = cast(0 as decimal(18, 2))
, IsReturn = cast(0 as bit)
, ProductCost = cast(0 as decimal(18, 2))
, LineDescription = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı (', DcCurrAccs.CurrAccDesc, ')')
, SalesPersonCode = ''
, CurrencyCode = 'AZN'
, ExchangeRate = cast(1 as decimal(18, 4))
, ProcessCode = 'PR'
, ProcessDesc = N'Əməkhaqqı'
, InvoiceNumber = CONCAT('PR-', prp.PeriodYear, '-', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2))
, DocumentDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))
, DocumentTime = CAST('23:59:59' AS TIME)
, OperationDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))
, OperationTime = CAST('23:59:59' AS TIME)
, Description = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı')
, CurrAccCode = prh.CurrAccCode
, CurrAccDesc = DcCurrAccs.CurrAccDesc
, CurrAccTypeDesc = DcCurrAccTypes.CurrAccTypeDesc
, CurrAccTypeCode = DcCurrAccs.CurrAccTypeCode
, OfficeCode = ''
, StoreCode = DcCurrAccs.StoreCode
, WarehouseCode = ''
, CustomsDocumentNumber = ''
, PosTerminalId = cast(null as int)
, IsSuspended = cast(0 as bit)
, IsCompleted = cast(1 as bit)
, IsSalesViaInternet = cast(0 as bit)
, IsLocked = prp.IsClosed
, ProductTypeCode = cast(null as int)
, ProductTypeDesc = ''
, UsePos = cast(0 as bit)
, PromotionCode = ''
, TaxRate = cast(0 as decimal(18, 2))
, RetailPrice = cast(0 as decimal(18, 2))
, PurchasePrice = cast(0 as decimal(18, 2))
, WholesalePrice = cast(0 as decimal(18, 2))
, CreatedDate = cast(null as datetime)
, CreatedUserName = ''
, PriceDiscountedLoc = cast(0 as decimal(18, 2))
from TrPayrollHeaders prh
left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id
left join DcCurrAccs on prh.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcCurrAccTypes on DcCurrAccs.CurrAccTypeCode = DcCurrAccTypes.CurrAccTypeCode
) Dvijok
order by Dvijok.DocumentDate








