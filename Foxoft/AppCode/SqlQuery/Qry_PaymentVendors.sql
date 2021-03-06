
  --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

select FirstName
 , DcCurrAccs.CurrAccDesc
 , Cash = (case when PaymentTypeCode = 1 then Payment else 0 end) / 1.703
 , Cashless = (case when PaymentTypeCode = 2 then Payment else 0 end) / 1.703
from TrPaymentLines
left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
left join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
where OperationDate BETWEEN @StartDate AND @EndDate 
--and OperationType = 'payment' 
and Payment < 0

