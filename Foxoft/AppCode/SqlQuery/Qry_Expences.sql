  --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

SELECT ProductCode = TrInvoiceLines.ProductCode
, ProductDesc
, LineDescription
, Amount = Amount * (-1)
FROM TrInvoiceLines
JOIN TrInvoiceHeaders ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
LEFT JOIN DcProcesses ON TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
LEFT JOIN DcProducts ON TrInvoiceLines.ProductCode = DcProducts.ProductCode
WHERE DocumentDate BETWEEN @StartDate AND @EndDate and TrInvoiceHeaders.ProcessCode = 'EX'

UNION ALL

SELECT ProductCode = prh.CurrAccCode
, ProductDesc = CONCAT(N'Əməkhaqqı - ', DcCurrAccs.CurrAccDesc)
, LineDescription = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı (', DcCurrAccs.CurrAccDesc, ')')
, Amount = isnull((
    select sum(l.AmountLoc)
    from TrPayrollLines l
    where l.PayrollHeaderId = prh.Id
      and l.PayrollItemType in (1, 2, 3)
), 0)
FROM TrPayrollHeaders prh
LEFT JOIN DcPayrollPeriods prp ON prh.PayrollPeriodId = prp.Id
LEFT JOIN DcCurrAccs ON prh.CurrAccCode = DcCurrAccs.CurrAccCode
WHERE EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1)) BETWEEN @StartDate AND @EndDate