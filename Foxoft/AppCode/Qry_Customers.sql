

select * from (
	select ih.CurrAccCode, DcCurrAccs.FirstName, (NetAmount - ISNULL(Payment, 0)) as Borc, IIF(NetAmount <> ISNULL(Payment, 0), 1, 0) as borclu from DcCurrAccs
	left join TrInvoiceHeaders as ih on DcCurrAccs.CurrAccCode = ih.CurrAccCode
	left join (select InvoiceHeaderId, sum(NetAmount) as NetAmount 
				from TrInvoiceLines group by InvoiceHeaderId) as il
				on ih.InvoiceHeaderId = il.InvoiceHeaderId
	left join TrPaymentHeaders on ih.InvoiceHeaderId = TrPaymentHeaders.InvoiceHeaderId
	left join TrPaymentLines on TrPaymentHeaders.PaymentHeaderId = TrPaymentLines.PaymentHeaderId
	where ih.ProcessCode = 'RS') as invoice
where invoice.borclu = 1