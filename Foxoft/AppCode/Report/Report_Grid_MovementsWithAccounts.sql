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
	, PayrollHeaderId
	, LineDescription
	, IsReturn
	, StoreCode
	--, LineId
from (
	select FirstName
	, CurrAccDesc
	--, ProductDesc
	, ih.InvoiceHeaderId
	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)
	, PayrollHeaderId = cast(cast(0 as binary) as uniqueidentifier)
	, NetAmountLoc = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd
	, PaymentLoc= 0
	, Summary = sum((QtyIn - QtyOut) * (PriceLoc * (100 - PosDiscount) / 100))  -- (-2) * 100 = -200 usd
	, ProcessDesc = IIF(IsReturn = 1, ProcessDesc + ' - Geri Qaytarma', ProcessDesc)
	, DocumentNumber
	, ih.StoreCode
	, ih.CurrAccCode
	, ih.DocumentDate
	, ih.DocumentTime
	, LineDescription = ih.Description
	, ih.ProcessCode
	, IsReturn
	--, LineId = InvoiceLineId
	from TrInvoiceLines 
	left join TrInvoiceHeaders ih on TrInvoiceLines.InvoiceHeaderId = ih.InvoiceHeaderId
	left join DcCurrAccs on ih.CurrAccCode = DcCurrAccs.CurrAccCode
	left join DcProcesses on DcProcesses.ProcessCode = ih.ProcessCode
	--left join DcProducts on DcProducts.ProductCode = TrInvoiceLines.ProductCode
	where ih.ProcessCode in ('RP', 'WP', 'RS', 'WS', 'IS', 'CI', 'CO', 'IT' )
	group by FirstName
			, CurrAccDesc
			, ProcessDesc
			, DocumentNumber
			, ih.InvoiceHeaderId
			, ih.CurrAccCode
			, ih.DocumentDate	
			, ih.DocumentTime
			, ih.Description
			, ih.StoreCode
			, ih.ProcessCode
			, IsReturn
	
	UNION ALL 
	
	select FirstName
	--, ProductCode = ''
	, CurrAccDesc = CurrAccDesc
	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)
	, TrPaymentHeaders.PaymentHeaderId
	, PayrollHeaderId = cast(cast(0 as binary) as uniqueidentifier)
	, NetAmountLoc = 0
	, PaymentLoc
	, Summary = PaymentLoc
	, ProcessDesc = IIF(PaymentTypeCode = 3, N'Bonus', N'Ödəniş')
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

	UNION ALL

	select FirstName = DcCurrAccs.FirstName
	, CurrAccDesc = DcCurrAccs.CurrAccDesc
	, InvoiceHeaderId = cast(cast(0 as binary) as uniqueidentifier)
	, PaymentHeaderId = cast(cast(0 as binary) as uniqueidentifier)
	, PayrollHeaderId = prh.Id
	, NetAmountLoc = prh.NetSalary
	, PaymentLoc = 0
	, Summary = prh.NetSalary
	, ProcessDesc = N'Əməkhaqqı'
	, DocumentNumber = CONCAT('PR-', prp.PeriodYear, '-', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2))
	, StoreCode = DcCurrAccs.StoreCode
	, CurrAccCode = prh.CurrAccCode
	, DocumentDate = EOMONTH(DATEFROMPARTS(prp.PeriodYear, prp.PeriodMonth, 1))
	, DocumentTime = CAST('23:59:59' AS TIME)
	, LineDescription = CONCAT(prp.PeriodYear, ' / ', RIGHT('0' + CAST(prp.PeriodMonth AS VARCHAR(2)), 2), N' dövrü üzrə əməkhaqqı')
	, ProcessCode = 'PR'
	, IsReturn = CAST(0 as bit)
	from TrPayrollHeaders prh
	left join DcPayrollPeriods prp on prh.PayrollPeriodId = prp.Id
	left join DcCurrAccs on prh.CurrAccCode = DcCurrAccs.CurrAccCode

) as CurrAccExtra where 1=1 {CurrAccCode}

order by DocumentDate, DocumentTime