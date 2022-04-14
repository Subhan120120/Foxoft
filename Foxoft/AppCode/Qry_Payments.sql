  
  
  --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

SELECT TrPaymentHeaders.StoreCode
, Cash = SUM(case when TrPaymentLines.PaymentTypeCode = 1 then TrPaymentLines.Payment else 0 end)
, Cashless = SUM(case when TrPaymentLines.PaymentTypeCode = 2 then TrPaymentLines.Payment else 0 end)
, BankId = MAX(TrPaymentLines.BankId)
FROM TrPaymentLines
JOIN TrPaymentHeaders ON TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
JOIN DcPaymentTypes ON TrPaymentLines.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode
LEFT JOIN TrInvoiceHeaders on TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
WHERE TrPaymentHeaders.OperationDate BETWEEN @StartDate AND @EndDate
--AND TrInvoiceHeaders.ProcessCode != 'EX'
GROUP BY TrPaymentHeaders.StoreCode
, TrPaymentLines.PaymentTypeCode
, PaymentTypeDesc
ORDER BY MAX(TrPaymentLines.CreatedDate)

