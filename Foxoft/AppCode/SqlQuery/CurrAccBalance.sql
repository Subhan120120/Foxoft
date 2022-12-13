
declare @EndDate date = dateadd(DAY, 1, getdate())
declare @EndTime time =  '00:00:00.000'

select DcCurrAccs.CurrAccCode
, CurrAccDesc
, Amount = sum(Amount)
, PhoneNum
, IsVIP
from 
DcCurrAccs 
left join 
(
	select CurrAccCode
	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd
	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd
	from TrInvoiceLines il
	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId

	where 1=1
	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))

	UNION ALL 
	
	select CurrAccCode
	, Amount = PaymentLoc -- 200 usd
	from TrPaymentLines pl
	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
	
	where 1=1 
	and (CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME)) <=
	(CAST(@EndDate AS DATETIME) + CAST(@EndTime AS DATETIME))
) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode
where 1 = 1 
	--and DcCurrAccs.IsVIP = 1 
	--and balance.CurrAccCode = '1403'
group by DcCurrAccs.CurrAccCode
, CurrAccDesc
, PhoneNum
, IsVIP


