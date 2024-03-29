
--Declare @invoiceHeader nvarchar(50) = 'dd6927e4-d33c-4dc7-929c-1410c299e0a9'

	select 
 * from (
	select  InvoiceLineId
			,	[Marka] = isnull(' ' +  Feature02Desc,'')
		  , [Ceki] = isnull(' ' + Feature04Desc,'')
		  , [Reng] = isnull(' ' + Feature05Desc,'')
		  , [Məhsul Tipi] = isnull(' ' + Feature06Desc,'')
		  , [Soyutma Tipi] = isnull(' ' + Feature07Desc,'')
		  , [BTU] = isnull(' ' + Feature09Desc,'')
		  , [Ekran Ölçüsü] = isnull(' ' + Feature10Desc,'')
		  , [Ekran İcazəsi] = isnull(' ' + Feature11Desc,'')
		  , [Motorun Növü] = isnull(' ' + Feature12Desc,'')
		  , [Həcmi] = isnull(' ' + Feature13Desc,'')
		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + Feature14Desc,'')
		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + Feature15Desc,'')
		  , [Istehsalçı Ölkə] = isnull(' ' + Feature16Desc,'')
		  , [Məhsuldarlıq] = isnull(' ' + Feature17Desc,'')
		  , [Güc] = isnull(' ' + Feature18Desc,'')
		  , [Tərtib Edən İstifadəçi] =( select CurrAccDesc from DcCurrAccs where CurrAccCode = TrInvoiceHeaders.CreatedUserName)
	, TrInvoiceHeaders.InvoiceHeaderId
	, DcProducts.ProductCode
	, ProductDesc
	, QtyIn = QtyIn
	, QtyOut = QtyOut
	, Price
	, TrInvoiceLines.PosDiscount
	, TrInvoiceHeaders.ProcessCode
	, ProcessDesc
	, TrInvoiceLines.CurrencyCode
	, DcProducts.HierarchyCode
	, HierarchyDesc
	, IsReturn
	, CustomsDocumentNumber
	, PrintCount
	, NetAmount
	, LineDescription
	, PriceLoc
	, TrInvoiceLines.ExchangeRate
	, NetAmountLoc = (QtyIn-QtyOut) * PriceLoc * (100 - TrInvoiceLines.PosDiscount) / 100
	, DocumentNumber
	, DocumentDate
	, DocumentTime
	, DcCurrAccs.CurrAccCode
	, DcCurrAccs.CurrAccDesc
	, FirstName
	, PhoneNum
	, HeaderCreatedDate = TrInvoiceHeaders.CreatedDate
	, LineCreatedDate = TrInvoiceLines.CreatedDate
	, TrInvoiceHeaders.CreatedUserName
	, CurrAccBalance = ISNULL((select sum((QtyIn - QtyOut) * (PriceLoc - (PriceLoc * PosDiscount / 100)))  -- (-2) * 100 = -200 usd
							 	from TrInvoiceLines il
							 	left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
							 	where ih.CurrAccCode = TrInvoiceHeaders.CurrAccCode
							 	and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
							 	(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))														
							 ), 0)
							 + 
							 ISNULL((select sum(PaymentLoc) -- 200 usd
							 	from TrPaymentLines pl
							 	left join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
							 	where ph.CurrAccCode = TrInvoiceHeaders.CurrAccCode
							 		and (CAST(ph.DocumentDate AS DATETIME) + CAST(ph.DocumentTime AS DATETIME)) <=
							 		(CAST(TrInvoiceHeaders.DocumentDate AS DATETIME) + CAST(TrInvoiceHeaders.DocumentTime AS DATETIME))
							 ), 0)
	, BalanceCode = 'M' + Convert(nvarchar, Format((select SUM(QtyIn - QtyOut) ProductBalance
						from TrInvoiceLines il 
						left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
						where il.ProductCode = TrInvoiceLines.ProductCode and WarehouseCode = TrInvoiceHeaders.WarehouseCode),'000'))
	, TrInvoiceHeaders.WarehouseCode
	, TrInvoiceHeaders.ToWarehouseCode
	, [Depodan] = wareIn.WarehouseDesc
	, [Depoya] = wareOut.WarehouseDesc
	, Description
	, TrInvoiceHeaders.StoreCode
	, PaymentLoc = ISNULL((	select sum(PaymentLoc) from TrPaymentLines pl 
							join TrPaymentHeaders ph on pl.PaymentHeaderId = ph.PaymentHeaderId
							where ph.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId), 0)
	, LastPurchasePrice
	from TrInvoiceLines

	join TrInvoiceHeaders on TrInvoiceLines.InvoiceHeaderId = TrInvoiceHeaders.InvoiceHeaderId
	left join DcCurrAccs on TrInvoiceHeaders.CurrAccCode = DcCurrAccs.CurrAccCode
	left join DcProducts on TrInvoiceLines.ProductCode = DcProducts.ProductCode
	left join DcProcesses on TrInvoiceHeaders.ProcessCode = DcProcesses.ProcessCode
	left join DcHierarchies on DcHierarchies.HierarchyCode = DcProducts.HierarchyCode
	left join DcCurrencies on DcCurrencies.CurrencyCode = TrInvoiceLines.CurrencyCode
	left join DcWarehouses wareIn on wareIn.WarehouseCode = TrInvoiceHeaders.WarehouseCode
	left join DcWarehouses wareOut on wareOut.WarehouseCode = TrInvoiceHeaders.ToWarehouseCode
	left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode

	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader


) AS PivotTable2

	order by LineCreatedDate


