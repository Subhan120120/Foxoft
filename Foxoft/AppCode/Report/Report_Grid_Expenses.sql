







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

select Price = isnull((
    select sum(l.AmountLoc)
    from TrPayrollLines l
    where l.PayrollHeaderId = prh.Id
      and l.PayrollItemType in (1, 2, 3)
), 0)
, ProductDesc = CONCAT(N'Əməkhaqqı - ', DcCurrAccs.CurrAccDesc)
, CurrencyCode = 'AZN'
, NetAmountLoc = isnull((
    select sum(l.AmountLoc)
    from TrPayrollLines l
    where l.PayrollHeaderId = prh.Id
      and l.PayrollItemType in (1, 2, 3)
), 0)
, DocumentDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))
, LineDescription = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı (', DcCurrAccs.CurrAccDesc, ')')
, StoreCode = DcCurrAccs.StoreCode
from TrPayrollHeaders prh
left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id
left join DcCurrAccs on prh.CurrAccCode = DcCurrAccs.CurrAccCode