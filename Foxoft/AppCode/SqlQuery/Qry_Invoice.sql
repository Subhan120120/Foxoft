
   
	--Declare @invoiceHeader nvarchar(50) = '36a9b346-e5f2-4c79-9634-e439a2897520'
	--Declare @exRate real = 1.703

	select  InvoiceLineId
	, TrInvoiceHeaders.InvoiceHeaderId
	, DcProducts.ProductCode
	, ProductDesc
	, QtyIn = QtyIn
	, QtyOut = QtyOut
	, Price
	, CurrencyCode
	, NetAmount
	, LineDescription
	, PriceLoc
	, NetAmountLoc
	, DocumentNumber
	, DocumentDate
	, DocumentTime
	, DcCurrAccs.CurrAccCode
	, DcCurrAccs.CurrAccDesc
	, FirstName
	, PhoneNum
	, CurrAccBalance = (select sum((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd
							from TrInvoiceLines il
							left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
							where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode)
							+ 
							(select sum(PaymentLoc) -- 200 usd
							from TrPaymentLines pl
							left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
							where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode)

	, WarehouseCode
	, Description
	, TrInvoiceHeaders.StoreCode
	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl 
							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)
	from TrInvoiceLines

	join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode

	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader

	order by TrInvoiceLines.CreatedDate





