



select  PaymentLineId
, TrPaymentHeaders.PaymentHeaderId
, TrPaymentHeaders.InvoiceHeaderId
, InvoiceNumber = tph.DocumentNumber
, DcPaymentTypes.PaymentTypeCode
, PaymentTypeDesc
, PaymentLoc
, Payment
, CurrencyCode
, LineDescription
, TrPaymentHeaders.DocumentNumber
, TrPaymentHeaders.DocumentDate
, TrPaymentHeaders.DocumentTime
, TrPaymentHeaders.OperationDate
, TrPaymentHeaders.OperationTime
, PaymentKindId
, TrPaymentHeaders.CurrAccCode
, CashRegisterCode
, FirstName
, DcCurrAccs.CurrAccDesc
, TrPaymentHeaders.StoreCode
, tpl.CreatedDate
, tpl.CreatedUserName
, [Cari Hesab Balansı] = (	(select sum ((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd
	--, Amount = NetAmountLoc  -- (-2) * 100 = -200 usd
	from TrInvoiceLines il
	left join TrInvoiceHeaders ih  on il.InvoiceHeaderId = ih.InvoiceHeaderId
	where DcCurrAccs.CurrAccCode = ih.CurrAccCode
	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
	(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))
		+ 
(select Sum(PaymentLoc) -- 200 usd
	from TrPaymentLines pl
	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	
	where DcCurrAccs.CurrAccCode = ph.CurrAccCode 
			and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=
			(CAST(tph.DocumentDate AS DATETIME) + CAST(tph.DocumentTime AS DATETIME)))
		)

 from TrPaymentLines tpl
left join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
left join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId
left Join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode
order by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc



