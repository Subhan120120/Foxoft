

select ph.*
	, ProcessDesc
	, pl.PaymentLineId
	, pl.PaymentTypeCode
	, pl.Payment
	, pl.PaymentLoc
	, pl.CurrencyCode
	, pl.ExchangeRate
	, pl.LineDescription
	, pl.CashRegisterCode
	, pl.PaymentMethodId
	, cari.CurrAccDesc
	, cari.PhoneNum
	, CashRegisterDesc = kassa.CurrAccDesc
	, DcPaymentTypes.PaymentTypeDesc
	, CurrAccBalance = dbo.CurrAccBalance(ph.CurrAccCode, DocumentDate)
	from TrPaymentLines pl 
	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
	left join DcPaymentTypes on DcPaymentTypes.PaymentTypeCode = pl.PaymentTypeCode
	left join DcCurrAccs cari on cari.CurrAccCode = ph.CurrAccCode
	left join DcCurrAccs kassa on kassa.CurrAccCode = pl.CashRegisterCode
	left join DcProcesses on DcProcesses.ProcessCode = ph.ProcessCode

	where ph.ProcessCode = 'PA' AND ph.PaymentHeaderId = @PaymentHeaderId
	order by DocumentDate

