  
  
--Declare @StartDate Date = getdate() --'2021-10-21'
--Declare @EndDate Date = getdate() --'2021-10-21'

SELECT TrPaymentHeaders.StoreCode
, TrPaymentLines.PaymentTypeCode
, PaymentTypeDesc
, Payment = SUM(TrPaymentLines.Payment)
, BankId = MAX(TrPaymentLines.BankId)
FROM TrPaymentLines
JOIN TrPaymentHeaders ON TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
JOIN DcPaymentTypes ON TrPaymentLines.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode
LEFT JOIN TrInvoiceHeaders on TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
WHERE TrPaymentHeaders.DocumentDate BETWEEN @StartDate AND @EndDate
AND TrInvoiceHeaders.ProcessCode != 'EX'
GROUP BY TrPaymentHeaders.StoreCode
, TrPaymentLines.PaymentTypeCode
, PaymentTypeDesc
ORDER BY MAX(TrPaymentLines.CreatedDate)

