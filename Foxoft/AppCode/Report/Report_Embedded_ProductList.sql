
--declare @StartDate date = dateadd(DAY, 1, getdate())
--declare @StartTime time =  '00:00:00.000'


select DcProducts.ProductCode
		, [Məhsulun Geniş Adı]= isnull(DcProducts.HierarchyCode + ' ','')  + ProductDesc 
			+ isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') + isnull(' ' + Feature06,'') + isnull(' ' +Feature07,'')
			+ isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') + isnull(' ' + Feature11,'')
			+ isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') 
			+ isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')
			+ isnull(' ' + Feature23,'') + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') 
			+ isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') 
		, ProductDesc
		, Mərkəz = ISNULL([depo-01], 0)
		, [Sıra 20] = ISNULL([depo-02], 0)
		, [Sıra 5] = ISNULL([depo-03], 0)
		, Balance = isnull([depo-01], 0) + isnull([depo-02],0) + isnull([depo-03],0)
		, WholesalePrice
		, Manatla = ROUND(WholesalePrice*1.703, -1 )
		, DcProducts.HierarchyCode
		, HierarchyDesc
		, ProductTypeCode
		, ProductId
		--, [Marka] = isnull(' ' + Feature03,'')
		, LastPurchasePrice = CAST((select top 1 toplam = TrInvoiceLines.PriceLoc * (1 - (TrInvoiceLines.PosDiscount / 100))  
							 from TrInvoiceLines 
							 join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId
							 where TrInvoiceLines.ProductCode = DcProducts.ProductCode
								and TrInvoiceHeaders.ProcessCode IN ( 'RP','CI')
								and TrInvoiceHeaders.IsReturn = 0
							 ORDER BY TrInvoiceHeaders.DocumentDate desc
								, DcHierarchies.HierarchyCode desc
								, TrInvoiceLines.CreatedDate desc) as money)									 
		
from DcProducts

left join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode
left join SiteProducts on SiteProducts.ProductCode = DcProducts.ProductCode
left join ProductFeatures ON DcProducts.ProductCode = ProductFeatures.ProductCode 
left join (select * from (
					select ProductCode
						, WarehouseCode
						, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  
					from TrInvoiceLines il
					left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
					group by ProductCode
						, WarehouseCode
				) AS SourceTable  
				PIVOT  
				( AVG(Balance)
				  FOR WarehouseCode IN ([depo-01], [depo-02], [depo-03])  
				) AS PivotTable 
			 ) as depolar on depolar.ProductCode = DcProducts.ProductCode

	--where ProductTypeCode = 1
	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))
	--and il.ProductCode = '5503'
			

