
select DcCurrAccs.CurrAccCode
, Amount = sum(Amount)
from 
DcCurrAccs
left join 
(
	select CurrAccCode
	, Amount = (QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100))  -- (-2) * 100 = -200 usd
	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd
	from TrInvoiceLines 
	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
	where TrInvoiceHeaders.DocumentDate <= '2022-07-28' 


	UNION ALL 
	
	select CurrAccCode
	, Amount = PaymentLoc -- 200 usd
	from TrPaymentLines
	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
		where TrPaymentHeaders.OperationDate  <= '2022-07-28'

) as balance on balance.CurrAccCode = DcCurrAccs.CurrAccCode
where DcCurrAccs.CurrAccCode ='1325'
group by DcCurrAccs.CurrAccCode


