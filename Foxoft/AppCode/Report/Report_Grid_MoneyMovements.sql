select  PaymentLineId
, ph.PaymentHeaderId
, ph.InvoiceHeaderId
, InvoiceNumber = ih.DocumentNumber
, DcPaymentTypes.PaymentTypeCode
, PaymentTypeDesc
, PaymentLoc
, Payment
, pl.CurrencyCode
, pl.LineDescription
, ph.DocumentNumber
, ph.DocumentDate
, ph.DocumentTime
, ph.OperationDate
, ph.OperationTime
, PaymentKindId
, ph.CurrAccCode
, CashRegisterCode
, FirstName
, ph.StoreCode
, pl.CreatedDate
, pl.CreatedUserName
, pl.ExchangeRate
, OperationType
, CurrAccTypeCode
, ih.Description

, CurrAccDesc = Case when ih.ProcessCode IN ('EX', 'EI') then DcProducts.ProductDesc else DcCurrAccs.CurrAccDesc end 

--, [Cari Hesab Balansı] = (
--	ISNULL((
--		select sum((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))
--		from TrInvoiceLines il
--		left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
--		where ih.CurrAccCode = TrPaymentHeaders.CurrAccCode
--		  and ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT')
--		  and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
--		      (CAST(TrPaymentHeaders.DocumentDate AS DATETIME) + CAST(TrPaymentHeaders.DocumentTime AS DATETIME))
--	), 0)
--	+ 
--	ISNULL((
--		select sum(pl.PaymentLoc)
--		from TrPaymentLines pl
--		left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId	
--		where ph.CurrAccCode = TrPaymentHeaders.CurrAccCode 
--		  and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=
--		      (CAST(TrPaymentHeaders.DocumentDate AS DATETIME) + CAST(TrPaymentHeaders.DocumentTime AS DATETIME))
--	), 0)
--	+
--	ISNULL((
--		select sum(prh.NetSalary)
--		from TrPayrollHeaders prh
--		left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id
--		where prh.CurrAccCode = TrPaymentHeaders.CurrAccCode
--		  and (CAST(EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1)) AS DATETIME) + CAST('23:59:59' AS DATETIME)) <=
--		      (CAST(TrPaymentHeaders.DocumentDate AS DATETIME) + CAST(TrPaymentHeaders.DocumentTime AS DATETIME))
--	), 0)
--)

from TrPaymentLines pl
left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
left join TrInvoiceHeaders ih on ph.InvoiceHeaderId = ih.InvoiceHeaderId
left join DcCurrAccs on ph.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcPaymentTypes on pl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode
left join TrInvoiceLines il on il.InvoiceLineId = pl.PaymentLineId
left Join DcProducts on il.ProductCode = DcProducts.ProductCode
order by ph.OperationDate asc, ph.OperationTime asc