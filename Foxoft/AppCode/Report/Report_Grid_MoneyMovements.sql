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

--, [Cari Hesab Balansı] = dbo.CurrAccBalance(ph.CurrAccCode, CAST(ph.OperationDate AS DATETIME) + CAST(ph.OperationTime AS DATETIME))

from TrPaymentLines pl
left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
left join TrInvoiceHeaders ih on ph.InvoiceHeaderId = ih.InvoiceHeaderId
left join DcCurrAccs on ph.CurrAccCode = DcCurrAccs.CurrAccCode
left join DcPaymentTypes on pl.PaymentTypeCode = DcPaymentTypes.PaymentTypeCode
left join TrInvoiceLines il on il.InvoiceLineId = pl.PaymentLineId
left Join DcProducts on il.ProductCode = DcProducts.ProductCode
order by ph.OperationDate asc, ph.OperationTime asc