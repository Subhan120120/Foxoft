
select DcCurrAccs.CurrAccCode
, Amount = sum(Amount)
from 
DcCurrAccs
left join 
(

	select CurrAccCode
	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd
	from TrInvoiceLines 
	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
	
	UNION ALL 
	
	select CurrAccCode
	, Amount = PaymentLoc -- 200 usd
	from TrPaymentLines
	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId

) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode
--where DcCurrAccs.CurrAccCode ='1505'
group by DcCurrAccs.CurrAccCode
