
select *

from (

	select ProductDesc
	, Payment = NetAmount
	, ProcessCode = ProcessDesc
	, DocumentNumber
	, CurrAccCode
	, StoreCode
	, TrInvoiceHeaders.DocumentDate
	, LineId = InvoiceLineId
	from TrInvoiceLines 
	left join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
	left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode
	left join DcProcesses on DcProcesses.ProcessCode = TrInvoiceHeaders.ProcessCode

	--where CurrAccCode = 'ca-86'
	
	UNION ALL 
	
	select ProductCode = ''
	, Payment = Payment
	, ProcessCode = OperationType
	, DocumentNumber
	, CurrAccCode
	, StoreCode
	, TrPaymentHeaders.DocumentDate
	, LineId = PaymentLineId
	from TrPaymentLines
	left join TrPaymentHeaders on TrPaymentLines.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
	--where CurrAccCode = 'ca-86'

) as CurrAccExtra 
order by CurrAccExtra.DocumentDate