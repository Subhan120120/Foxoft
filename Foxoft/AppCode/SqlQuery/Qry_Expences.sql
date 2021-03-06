  
  --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

SELECT  TrInvoiceLines.ProductCode
, ProductDesc
, LineDescription
, Amount = Amount * (-1)
FROM TrInvoiceLines
JOIN TrInvoiceHeaders ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
LEFT JOIN DcProcesses ON TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
LEFT JOIN DcProducts ON TrInvoiceLines.ProductCode = DcProducts.ProductCode
WHERE DocumentDate BETWEEN @StartDate AND @EndDate and TrInvoiceHeaders.ProcessCode = 'EX'
ORDER BY TrInvoiceLines.CreatedDate

