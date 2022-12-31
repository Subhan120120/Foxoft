   
	--Declare @invoiceHeader nvarchar(50) = '0ca38b4b-b465-47ac-bbc5-9a3e53cfe094'
	--Declare @exRate real = 1.703

	select  InvoiceLineId
	, TrInvoiceHeaders.InvoiceHeaderId
	, DcProducts.ProductCode
	, ProductDesc
	, QtyIn = QtyIn
	, QtyOut = QtyOut
	, Price
	, TrInvoiceLines.PosDiscount
	, TrInvoiceHeaders.ProcessCode
	, ProcessDesc
	, CurrencyCode
	, IsReturn
	, CustomsDocumentNumber
	, PrintCount
	, NetAmount
	, LineDescription
	, PriceLoc
	, NetAmountLoc = (QtyIn-QtyOut)*PriceLoc*(100-TrInvoiceLines.PosDiscount)/100
	, DocumentNumber
	, DocumentDate
	, DocumentTime
	, DcCurrAccs.CurrAccCode
	, DcCurrAccs.CurrAccDesc
	, FirstName
	, PhoneNum
	, CurrAccBalance = ISNULL((select sum((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd
							 	from TrInvoiceLines il
							 	left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
							 	where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode
							 	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
							 	(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))														
							 ), 0)
							 + 
							 ISNULL((select sum(PaymentLoc) -- 200 usd
							 	from TrPaymentLines pl
							 	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
							 	where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode
							 		and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=
							 		(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))
							 ), 0)

	, WarehouseCode
	, Description
	, TrInvoiceHeaders.StoreCode
	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl 
							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)
	, LastPurchasePrice
	from TrInvoiceLines

	join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
	left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode

	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader

	order by TrInvoiceLines.CreatedDate




