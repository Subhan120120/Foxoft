   
  --Declare @StartDate Date = '2022-03-25' -- getdate() --
  --Declare @EndDate Date = '2022-03-25' -- getdate() --

SELECT TrInvoiceHeaders.ProcessCode
, ProcessDescription
, TrInvoiceHeaders.StoreCode
, Qty = sum(Qty)
, Amount = sum(Amount)
, PosDiscount = sum(PosDiscount)
, NetAmount = sum(NetAmount)
, IsReturn = IsReturn
, Cash = sum(Cash)
, Cashless = sum(Cashless)
, TrInvoiceHeaders.DocumentDate
--, TrInvoiceHeaders.InvoiceHeaderId
FROM TrInvoiceHeaders 

Left JOIN 
		( select InvoiceHeaderId
			, Qty = SUM(TrInvoiceLines.QtyIn - TrInvoiceLines.QtyOut)
			, Amount = SUM((TrInvoiceLines.QtyIn - TrInvoiceLines.QtyOut) * TrInvoiceLines.Price)
			, PosDiscount = SUM(TrInvoiceLines.PosDiscount)
			, NetAmount = SUM(((TrInvoiceLines.QtyIn - TrInvoiceLines.QtyOut) * TrInvoiceLines.Price) - TrInvoiceLines.PosDiscount)
			from TrInvoiceLines 
			group by InvoiceHeaderId
		) InvoiceLines on TrInvoiceHeaders.InvoiceHeaderId = InvoiceLines.InvoiceHeaderId

LEFT JOIN DcProcesses ON TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode

left join 
			(select InvoiceHeaderId
			, Cash = sum(case when PaymentTypeCode = 1 then Payment else 0 end) 
			, Cashless = sum(case when PaymentTypeCode = 2 then Payment else 0 end) 
			from TrPaymentLines 
			left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
			group by InvoiceHeaderId
			) as payments on payments.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId

WHERE TrInvoiceHeaders.DocumentDate BETWEEN @StartDate AND @EndDate AND TrInvoiceHeaders.ProcessCode != 'EX'
GROUP BY TrInvoiceHeaders.StoreCode
		,TrInvoiceHeaders.ProcessCode
		, ProcessDescription
		, IsReturn
		, TrInvoiceHeaders.DocumentDate
		--, TrInvoiceHeaders.InvoiceHeaderId
ORDER BY TrInvoiceHeaders.DocumentDate


