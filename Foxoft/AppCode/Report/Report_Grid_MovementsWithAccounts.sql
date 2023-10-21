


select 	CurrAccDesc
	--, ProductDesc
	, NetAmountLoc
	, PaymentLoc
	, [Ara Toplam] = sum(Summary) OVER (ORDER BY DocumentDate, DocumentTime )
	, ProcessDesc
	, DocumentNumber
	, CurrAccCode
	, DocumentDate
	, DocumentTime
	, InvoiceHeaderId
	, PaymentHeaderId
	, LineDescription
	, IsReturn
	, StoreCode
	--, LineId
from (
	select FirstName
	, CurrAccDesc
	--, ProductDesc
	, TrInvoiceHeaders.InvoiceHeaderId
	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)
	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd
	, PaymentLoc= 0
	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd
	, ProcessDesc = ProcessDesc
	, DocumentNumber
	, TrInvoiceHeaders.StoreCode
	, TrInvoiceHeaders.CurrAccCode
	, TrInvoiceHeaders.DocumentDate
	, TrInvoiceHeaders.DocumentTime
	, LineDescription = TrInvoiceHeaders.Description
	, TrInvoiceHeaders.ProcessCode
	, IsReturn
	--, LineId = InvoiceLineId
	from TrInvoiceLines 
	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
	left join DcProcesses on DcProcesses.ProcessCode = TrInvoiceHeaders.ProcessCode
	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode
	group by FirstName
			, CurrAccDesc
			, ProcessDesc
			, DocumentNumber
			, TrInvoiceHeaders.InvoiceHeaderId
			, TrInvoiceHeaders.CurrAccCode
			, TrInvoiceHeaders.DocumentDate	
			, TrInvoiceHeaders.DocumentTime
			, TrInvoiceHeaders.Description
			, TrInvoiceHeaders.StoreCode
	, TrInvoiceHeaders.ProcessCode
	, IsReturn
	
	UNION ALL 
	
	select FirstName
	--, ProductCode = ''
	, CurrAccDesc = CurrAccDesc
	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)
	, TrPaymentHeaders.PaymentHeaderId
	, NetAmountLoc = 0
	, PaymentLoc
	, Summary = PaymentLoc
	, ProcessDesc = N'Ödəniş'
	, DocumentNumber
	, TrPaymentHeaders.StoreCode
	, TrPaymentHeaders.CurrAccCode
	, DocumentDate = TrPaymentHeaders.OperationDate
	, DocumentTime = TrPaymentHeaders.OperationTime
	, LineDescription
	, ProcessCode = 'PA'
	, IsReturn = CAST(0 as bit)
	--, LineId = PaymentLineId
	from TrPaymentLines
	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
	left join DcCurrAccs  on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode	

) as CurrAccExtra where 1=1 {CurrAccCode}

order by DocumentDate, DocumentTime