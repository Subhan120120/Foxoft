





--declare @StartDate date = dateadd(DAY, 1, getdate())
--declare @StartTime time =  '00:00:00.000'

select * from (

Select pro.ProductCode
		, pro.HierarchyCode
		, [Məhsulun Genis Adi]= isnull(pro.HierarchyCode + ' ','')  + ProductDesc 
			+ isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') + isnull(' ' + Feature06,'') + isnull(' ' +Feature07,'')
			+ isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') + isnull(' ' + Feature11,'')
			+ isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') 
			+ isnull(' ' + Feature18,'') + isnull(' ' + Feature19 + 'x' + Feature20 + 'x' + Feature21,'') + isnull(' ' + Feature22,'')
			+ isnull(' ' + Feature23,'') + isnull(' ' + Feature24,'') + isnull(' ' + Feature25,'') + isnull(' ' + Feature26,'') 
			+ isnull(' ' + Feature27,'') + isnull(' ' + Feature28,'') 
		, ProductDesc
		, Balance = CAST(isnull(ProductBalance.[depo-01],0) AS INT)
		, WholesalePrice
		, HierarchyDesc
		, ProductTypeCode
		--, ProductId	
		, ProductCost = dbo.GetProductCost(pro.ProductCode, null)
		--, CalcClosingStockFifo.FIFO_CORG
		, IsDisabled
		
from DcProducts pro

left join DcHierarchies on pro.HierarchyCode = DcHierarchies.HierarchyCode
--left join SiteProducts on SiteProducts.ProductCode = pro.ProductCode
left join ProductFeatures ON pro.ProductCode = ProductFeatures.ProductCode 
left join ProductBalance on ProductBalance.ProductCode = pro.ProductCode
left join CalcClosingStockFifo on CalcClosingStockFifo.ProductCode = pro.ProductCode

	--where ProductTypeCode = 1
	--and (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
	--	(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))
	--and il.ProductCode = '5503'

) as tablo 
	order by 
tablo.HierarchyCode 
, tablo.ProductDesc 




