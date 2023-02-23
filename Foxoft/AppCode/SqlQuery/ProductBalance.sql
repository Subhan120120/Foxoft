
--declare @StartDate date = dateadd(DAY, 1, getdate())
--declare @StartTime time =  '00:00:00.000'

select top 10000000 ProductCode
	  , ProductDesc
	  , LastPurchasePrice
	  , Mərkəz = ISNULL([depo-01],0)
	  , [Sıra 20] = ISNULL([depo-02],0)
	  , [Sıra 5] = ISNULL([depo-03],0)
	  , Balance = isnull([depo-01],0) + isnull([depo-02],0) + isnull([depo-03],0)
	  , WholesalePrice
	  , Marka
	  , ProductTypeCode
from ( select DcProducts.ProductCode
				, DcProducts.ProductDesc
				, WarehouseCode
				, WholesalePrice 
				, Marka = FeatureDesc
				, ProductTypeCode
				, LastPurchasePrice = (select top 1 toplam = TrInvoiceLines.PriceLoc * (1 - (TrInvoiceLines.PosDiscount / 100))  
												from TrInvoiceLines 
												join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId
												where TrInvoiceLines.ProductCode = DcProducts.ProductCode
												and TrInvoiceHeaders.ProcessCode IN ( 'RP','CI')
												and TrInvoiceHeaders.IsReturn = 0
												ORDER BY TrInvoiceHeaders.DocumentDate desc
												, TrInvoiceLines.CreatedDate desc
								)											 
	, SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0)) Balance 
	--, LastPurchasePrice = ()
	from DcProducts
	
	left join TrInvoiceLines il on il.ProductCode = DcProducts.ProductCode
	left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
	left join DcProductDcFeatures fea on fea.ProductCode = DcProducts.ProductCode
					and fea.FeatureId = 3
	
	--where ProductTypeCode = 1
	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))
		--and il.ProductCode = '5503'
	
	group by DcProducts.ProductCode
			 , DcProducts.ProductDesc
			 , WholesalePrice 
			 , WarehouseCode
			 , FeatureDesc				
			 , ProductTypeCode
) AS SourceTable  
PIVOT  
(  
 AVG(Balance)
  FOR WarehouseCode IN ([depo-01], [depo-02], [depo-03])  
) AS PivotTable 
--order by ProductDesc
