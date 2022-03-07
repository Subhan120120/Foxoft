  
  --Declare @StartDate Date = getdate() --'2021-10-21'
  --Declare @EndDate Date = getdate() --'2021-10-21'

SELECT  ProductCode
, Amount = Amount * (-1)
FROM TrInvoiceLines
JOIN TrInvoiceHeaders ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
LEFT JOIN DcProcesses ON TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
WHERE DocumentDate BETWEEN @StartDate AND @EndDate and TrInvoiceHeaders.ProcessCode = 'EX'
ORDER BY TrInvoiceLines.CreatedDate

