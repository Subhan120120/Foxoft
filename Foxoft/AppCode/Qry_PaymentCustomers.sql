 
 --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

select Cash = case when PaymentTypeCode = 1 then Payment else 0 end
 , Cashless = case when PaymentTypeCode = 2 then Payment else 0 end
 , FirstName

from TrPaymentLines
left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
left join TrInvoiceHeaders on TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
left join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
where TrPaymentHeaders.OperationDate BETWEEN @StartDate AND @EndDate
		and ProcessCode = 'RS' 		
		and TrPaymentHeaders.OperationDate <> TrInvoiceHeaders.DocumentDate


