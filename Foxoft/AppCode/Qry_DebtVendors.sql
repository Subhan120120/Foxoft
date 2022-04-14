
  --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

select * from (select DcCurrAccs.CurrAccCode
	, DcCurrAccs.FirstName
	, NetAmount
	, payment.Payment
	, borclu =  IIF(NetAmount <> ISNULL(Payment, 0), 1, 0) 
	, borc = (NetAmount - ISNULL(Payment, 0))
	from DcCurrAccs
	
	left join (select CurrAccCode 
			   ,NetAmount = sum(NetAmount)
			   from TrInvoiceLines il
			   left join TrInvoiceHeaders as ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
			   where ih.ProcessCode = 'RP'
			   group by CurrAccCode
			   ) as invoice on invoice.CurrAccCode = DcCurrAccs.CurrAccCode

	left join (select CurrAccCode
			  , Payment = sum(Payment) * (-1)
			  from TrPaymentHeaders
			  left join TrPaymentLines on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId
			  group by CurrAccCode
			  ) as payment on payment.CurrAccCode = DcCurrAccs.CurrAccCode
	) as invoice
where  invoice.borclu = 1