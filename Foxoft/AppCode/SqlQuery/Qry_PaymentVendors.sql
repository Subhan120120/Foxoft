
  --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

select FirstName
 , DcCurrAccs.CurrAccDesc
 , Cash = (case when PaymentTypeCode = 1 then Payment else 0 end)
 , Cashless = (case when PaymentTypeCode = 2 then Payment else 0 end)
from TrPaymentLines
left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
left join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
where OperationDate BETWEEN @StartDate AND @EndDate AND TrPaymentHeaders.ProcessCode != 'EX'
--and PaymentKindId = 1
and Payment < 0

