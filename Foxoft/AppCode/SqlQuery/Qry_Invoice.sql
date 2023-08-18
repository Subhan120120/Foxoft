
--Declare @invoiceHeader nvarchar(50) = 'd4e7daf5-cdbc-47a2-a683-bdc4764a22a3'
--Declare @exRate real = 1.703

	select 
			[Marka] = isnull(' ' + [3],'')
		  , [Ceki] = isnull(' ' + [4],'')
		  , [Reng] = isnull(' ' + [5],'')
		  , [Məhsul Tipi] = isnull(' ' + [6],'')
		  , [Soyutma Tipi] = isnull(' ' + [7],'')
		  , [BTU] = isnull(' ' + [9],'')
		  , [Ekran Ölçüsü] = isnull(' ' + [10],'')
		  , [Ekran İcazəsi] = isnull(' ' + [11],'')
		  , [Motorun Növü] = isnull(' ' + [12],'')
		  , [Həcmi] = isnull(' ' + [13],'')
		  , [Soyuducu Kameranın Həcmi] = isnull(' ' + [14],'')
		  , [Dondurucu Kameranın Həcmi] = isnull(' ' + [15],'')
		  , [Istehsalçı Ölkə] = isnull(' ' + [16],'')
		  , [Məhsuldarlıq] = isnull(' ' + [17],'')
		  , [Güc] = isnull(' ' + [18],'')
		  , [Tərtib Edən İstifadəçi] =( select CurrAccDesc from DcCurrAccs where CurrAccCode = PivotTable2.CreatedUserName)
		  , * from (
	select  InvoiceLineId
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
	, FeatureCode
	, FeatureTypeId
	, TrInvoiceHeaders.CreatedDate
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
						where il.ProductCode = TrInvoiceLines.ProductCode and WarehouseCode = 'depo-01'),'000'))
	, WarehouseCode
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
	left join TrProductFeatures on TrProductFeatures.ProductCode = DcProducts.ProductCode
	left join DcCurrencies on DcCurrencies.CurrencyCode = TrInvoiceLines.CurrencyCode

	where TrInvoiceHeaders.InvoiceHeaderId = @invoiceHeader

	 ) as cedvel
PIVOT  
(  
 Max(FeatureCode)
  FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21])  
) AS PivotTable2

	order by CreatedDate


