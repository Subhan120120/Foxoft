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
, [Cari Hesab Balansı] = (
	ISNULL((
		select sum((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))
		from TrInvoiceLines il
		left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
		where ih.CurrAccCode = TrPaymentHeaders.CurrAccCode
		  and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT')
		  and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
		      (CAST(TrPaymentHeaders.DocumentDate AS DATETIME) + CAST(TrPaymentHeaders.DocumentTime AS DATETIME))
	), 0)
	+ 
	ISNULL((
		select sum(pl.PaymentLoc)
		from TrPaymentLines pl
		left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	
		where ph.CurrAccCode = TrPaymentHeaders.CurrAccCode 
		  and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=
		      (CAST(TrPaymentHeaders.DocumentDate AS DATETIME) + CAST(TrPaymentHeaders.DocumentTime AS DATETIME))
	), 0)
	+
	ISNULL((
		select sum(prh.NetSalary)
		from TrPayrollHeaders prh
		left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id
		where prh.CurrAccCode = TrPaymentHeaders.CurrAccCode
		  and (CAST(EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1)) AS DATETIME) + CAST('23:59:59' AS DATETIME)) <=
		      (CAST(TrPaymentHeaders.DocumentDate AS DATETIME) + CAST(TrPaymentHeaders.DocumentTime AS DATETIME))
	), 0)
)

from TrPaymentLines tpl
left join TrPaymentHeaders on tpl.PaymentHeaderId = TrPaymentHeaders.PaymentHeaderId
left join TrInvoiceHeaders tph on TrPaymentHeaders.InvoiceHeaderId = tph.InvoiceHeaderId
left join DcCurrAccs on TrPaymentHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcPaymentTypes on tpl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode
order by TrPaymentHeaders.OperationDate asc, TrPaymentHeaders.OperationTime asc