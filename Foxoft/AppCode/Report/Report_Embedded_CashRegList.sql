CashRegisterCode = DcCurrAccs.CurrAccCode
	, [Kassa Adı] = CurrAccDesc
    , CurrAccDesc
    , Balance = ISNULL(SUM(CAST(PaymentLoc AS money)), 0)
    , PhoneNum
    , IsVIP
    , CurrAccTypeCode
    , StoreCode
FROM DcCurrAccs
LEFT JOIN TrPaymentLines 
    ON TrPaymentLines.CashRegisterCode = DcCurrAccs.CurrAccCode
    AND TrPaymentLines.PaymentTypeCode IN (1, 2)
WHERE 
    CurrAccTypeCode = 5
    AND IsDisabled = 0
GROUP BY 
     DcCurrAccs.CurrAccCode
    , CashRegisterCode
    , CurrAccDesc
    , PhoneNum
    , IsVIP
    , CurrAccTypeCode
    , StoreCode
--ORDER BY CurrAccDesc;
