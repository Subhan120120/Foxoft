

	select CashRegisterCode = DcCurrAccs.CurrAccCode
	, [Kassa Adı] = CurrAccDesc
	, Balance =ISNULL(SUM(CAST(PaymentLoc as money)),0)
	, PhoneNum
	, IsVIP
	, CurrAccTypeCode
	, StoreCode
	from 
	DcCurrAccs 
	left join  TrPaymentLines on TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode and PaymentTypeCode = 1
	where CurrAccTypeCode = 5 and IsDisabled = 0
		--and DcCurrAccs.IsVIP = 1 
		--and balance.CurrAccCode = '1403'
	group by DcCurrAccs.CurrAccCode
	, CurrAccDesc
	, PhoneNum
	, IsVIP
	, CurrAccTypeCode
	, CashRegisterCode 
	, StoreCode
	order by CurrAccDesc