   
  --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

SELECT TrInvoiceHeaders.ProcessCode
, ProcessDescription
, StoreCode
, Qty = SUM(TrInvoiceLines.QtyIn - TrInvoiceLines.QtyOut)
, Amount = SUM((TrInvoiceLines.QtyIn - TrInvoiceLines.QtyOut) * TrInvoiceLines.Price)
, PosDiscount = SUM(TrInvoiceLines.PosDiscount)
, NetAmount = SUM(((TrInvoiceLines.QtyIn - TrInvoiceLines.QtyOut) * TrInvoiceLines.Price) - TrInvoiceLines.PosDiscount)
, IsReturn = IsReturn
FROM TrInvoiceLines
JOIN TrInvoiceHeaders ON TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
LEFT JOIN DcProcesses ON TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
WHERE DocumentDate BETWEEN @StartDate AND @EndDate AND TrInvoiceHeaders.ProcessCode != 'EX'
GROUP BY StoreCode
, TrInvoiceHeaders.ProcessCode
, ProcessDescription
, IsReturn
ORDER BY MAX(TrInvoiceLines.CreatedDate)

