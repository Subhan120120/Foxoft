






	--declare @StartDate date = dateadd(DAY, 1, getdate())
	--declare @StartTime time =  '00:00:00.000'

	select ProductCode
		  , [Məhsulun Geniş Adı]= isnull(HierarchyCode + ' ','')  + ProductDesc +  isnull(' ' + [4],'') + isnull(' ' + [5],'') 
		  + isnull(' ' + [6],'') + isnull(' ' + [7],'') + isnull(' ' + [8],'') + isnull(' ' + [9],'') + isnull(' ' + [10],'') 
		  + isnull(' ' + [11],'') + isnull(' ' + [12],'') + isnull(' ' + [13],'') + isnull(' ' + [16],'') + isnull(' ' + [17],'') 
		  + isnull(' ' + [18],'') + isnull(' ' + [19] + 'x' + [20] + 'x' + [21],'') + isnull(' ' + [22],'')+ isnull(' ' + [23],'')
		  + isnull(' ' + [24],'') + isnull(' ' + [25],'') + isnull(' ' + [26],'') + isnull(' ' + [27],'') + isnull(' ' + [28],'') 
, ProductDesc 
		  , LastPurchasePrice = CAST(LastPurchasePrice as money)
		  , Mərkəz = ISNULL([depo-01], 0)
		  , [Sıra 20] = ISNULL([depo-02], 0)
		  , [Sıra 5] = ISNULL([depo-03], 0)
		  , Balance = isnull([depo-01], 0) + isnull([depo-02],0) + isnull([depo-03],0)
		  , WholesalePrice
		  , Manatla = ROUND(WholesalePrice*1.703, -1 )
		  , HierarchyCode
		  , HierarchyDesc
		  , ProductTypeCode
		  , ProductId
		  , [Marka] = isnull(' ' + [3],'')
		  , [Çəki] = isnull(' ' + [4],'')
		  , [Rəng] = isnull(' ' + [5],'')
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
		  , [Kameranın Həcmi] = isnull(' ' + [19] + 'x' + [20] + 'x' + [21] ,'')
		  , [Dispenser] = isnull(' ' + [22],'')
		  , [Tutum Dəst] = isnull(' ' + [23],'')
		  , [Rəflərin Sayı] = isnull(' ' + [24],'')
		  , [Fırlanma Sürəti] = isnull(' ' + [25],'')
		  , [Ocaq Sayı] = isnull(' ' + [26],'')
		  , [Qaz Kontrol] = isnull(' ' + [27],'')
		  , [Ocaq Növü] = isnull(' ' + [28],'')
		  , [Programların Sayı] = isnull(' ' + [29],'')
	from ( select 
	*
			from (
				select DcProducts.ProductCode
							, ProductDesc
							, DcHierarchies.HierarchyCode
							, HierarchyDesc
							, FeatureCode
							, WarehouseCode
							, WholesalePrice 
							, ProductTypeCode
							, FeatureTypeId
							, ProductId
							, LastPurchasePrice = (select top 1 toplam = TrInvoiceLines.PriceLoc * (1 - (TrInvoiceLines.PosDiscount / 100))  
															from TrInvoiceLines 
															join TrInvoiceHeaders on TrInvoiceHeaders.InvoiceHeaderId = TrInvoiceLines.InvoiceHeaderId
															where TrInvoiceLines.ProductCode = DcProducts.ProductCode
															and TrInvoiceHeaders.ProcessCode IN ( 'RP','CI')
															and TrInvoiceHeaders.IsReturn = 0
															ORDER BY TrInvoiceHeaders.DocumentDate desc, DcHierarchies.HierarchyCode desc
															, TrInvoiceLines.CreatedDate desc
											)											 
				, Balance = SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0))  
				--, LastPurchasePrice = ()
				from DcProducts
			
				left join TrInvoiceLines il on il.ProductCode = DcProducts.ProductCode
				left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
				left join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode
				left join TrProductFeatures on TrProductFeatures.ProductCode = DcProducts.ProductCode
				left join SiteProducts on SiteProducts.ProductCode = DcProducts.ProductCode

				--where ProductTypeCode = 1
				--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
				--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))
					--and il.ProductCode = '5503'
			
				group by DcProducts.ProductCode
						 , DcProducts.ProductDesc
						 , WholesalePrice 
						 , WarehouseCode
						 , FeatureCode				
						 , ProductTypeCode
						 , DcHierarchies.HierarchyCode
						 , HierarchyDesc
						 , FeatureTypeId
						 , ProductId
						 --, reng.FeatureCode
						 --, frost.FeatureCode 
				 ) as st
				 PIVOT  
				 (  
				  Max(FeatureCode)
				   FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25], [26], [27], [28], [29])  
				 ) AS PivotTable2
	) AS SourceTable  
	PIVOT  
	(  
	 AVG(Balance)
	  FOR WarehouseCode IN ([depo-01], [depo-02], [depo-03])  
	) AS PivotTable 






