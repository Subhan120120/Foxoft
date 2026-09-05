







select Price
, ProductDesc
, CurrencyCode
, NetAmountLoc
, DocumentDate 
, LineDescription
, StoreCode
from TrInvoiceLines
left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
where ProcessCode = 'EX'

UNION ALL

select Price = prh.GrossSalary
, ProductDesc = CONCAT(N'Əməkhaqqı - ', DcCurrAccs.CurrAccDesc)
, CurrencyCode = 'AZN'
, NetAmountLoc = prh.GrossSalary
, DocumentDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))
, LineDescription = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı (', DcCurrAccs.CurrAccDesc, ')')
, StoreCode = DcCurrAccs.StoreCode
from TrPayrollHeaders prh
left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id
left join DcCurrAccs on prh.CurrAccCode = DcCurrAccs.CurrAccCode