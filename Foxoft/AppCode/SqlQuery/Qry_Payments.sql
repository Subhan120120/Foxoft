  
  
  --Declare @StartDate Date = '2022-06-22' -- getdate() --
  --Declare @EndDate Date = '2022-06-22' -- getdate() --

SELECT TrPaymentHeaders.StoreCode
, Cash = SUM(case when TrPaymentLines.PaymentTypeCode = 1 then TrPaymentLines.PaymentLoc else 0 end)
, Cashless = SUM(case when TrPaymentLines.PaymentTypeCode = 2 then TrPaymentLines.PaymentLoc else 0 end)
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

