
declare @StartDate date = dateadd(DAY, 1, getdate())
declare @StartTime time =  '00:00:00.000'

select DcCurrAccs.CurrAccCode
, CurrAccDesc
, Amount = sum(Amount)
from 
DcCurrAccs
left join 
(
	select CurrAccCode
	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd
	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd
	from TrInvoiceLines il
	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId

	where (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))

	UNION ALL 
	
	select CurrAccCode
	, Amount = PaymentLoc -- 200 usd
	from TrPaymentLines pl
	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
	
	where (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=
	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))
) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode
where 1 = 1 
	--and DcCurrAccs.IsVIP = 1 
	--and balance.CurrAccCode = '1079'
group by DcCurrAccs.CurrAccCode, CurrAccDesc


