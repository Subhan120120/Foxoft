
select * from (select DcCurrAccs.CurrAccCode
	, DcCurrAccs.FirstName
	, DcCurrAccs.CurrAccDesc
	, NetAmountRS = sales.NetAmount
	, NetAmountRP= parchses.NetAmount
	, NetAmount = ISNULL(ISNULL(sales.NetAmount,0) + ISNULL(parchses.NetAmount, 0), 0)
	, Payment = ISNULL(Payment, 0)
	, borclu =  (case when ISNULL(sales.NetAmount, 0) + ISNULL(parchses.NetAmount, 0) + ISNULL(Payment, 0) > 0 then 1
					when ISNULL(sales.NetAmount, 0) + ISNULL(parchses.NetAmount, 0) + ISNULL(Payment, 0) < 0 then 2 else 0 end )
	, borc = ISNULL(sales.NetAmount, 0) + ISNULL(parchses.NetAmount, 0) + ISNULL(Payment, 0)
	from DcCurrAccs
	
	left join (select CurrAccCode 
			   ,NetAmount = sum(ISNULL(NetAmount,0)) * (-1)
			   from TrInvoiceLines il
			   left join TrInvoiceHeaders as ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
			   where ih.ProcessCode = 'RS'
			   group by CurrAccCode
			   ) as sales on sales.CurrAccCode = DcCurrAccs.CurrAccCode

	left join (select CurrAccCode 
			   ,NetAmount = sum(ISNULL(NetAmount,0))
			   from TrInvoiceLines il
			   left join TrInvoiceHeaders as ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
			   where ih.ProcessCode = 'RP'
			   group by CurrAccCode
			   ) as parchses on parchses.CurrAccCode = DcCurrAccs.CurrAccCode

	left join (select CurrAccCode
			  , Payment = sum(Payment)
			  from TrPaymentHeaders
			  left join TrPaymentLines on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId
			  group by CurrAccCode
			  ) as payment on payment.CurrAccCode = DcCurrAccs.CurrAccCode
			 
	) as invoice
where invoice.borclu <> 0

