
  --Declare @StartDate Date = '2022-06-22' -- getdate() --
  --Declare @EndDate Date = '2022-06-22' -- getdate() --

--  select FirstName
-- , Cash = case when PaymentTypeCode = 1 then Payment else 0 end / 1.703
-- , Cashless = case when PaymentTypeCode = 2 then Payment else 0 end / 1.703
 

--from TrPaymentLines
--left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
--left join TrInvoiceHeaders on TrPaymentHeaders.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
--left join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
--where TrPaymentHeaders.OperationDate BETWEEN @StartDate AND @EndDate
--		and ProcessCode = 'RS' 		
--		and TrPaymentHeaders.OperationDate <> TrInvoiceHeaders.DocumentDate

--union all   

select FirstName
 , DcCurrAccs.CurrAccDesc 
 , Cash = (case when PaymentTypeCode = 1 then Payment else 0 end)
 , Cashless = (case when PaymentTypeCode = 2 then Payment else 0 end)
 
from TrPaymentLines
left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
left join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
where TrPaymentHeaders.OperationDate BETWEEN @StartDate AND @EndDate 
		--and PaymentKindId = 1
		and Payment > 0
