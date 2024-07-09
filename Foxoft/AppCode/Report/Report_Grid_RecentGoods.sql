


select 
 [Topdan Sat. Qiy.] =  Round(WholesalePrice, 0)
, [Maya Dəyəri.] =  Round(ProductCost, 0)
, [%] =CONVERT(int, Round((1 - (PivotTable.ProductCost / NULLIF(PivotTable.WholesalePrice,0))) * 100, 0)) 
, *
from (
	select prdcts.ProductCode
	, LastUpdatedDate
	, UseInternet
	, ProductDesc 
	, HierarchyCode 
	, FeatureCode
	, FeatureTypeId
	, WholesalePrice
	, ProductCost = (select top 1  PriceLoc * (1 - (PosDiscount / 100))	
								from TrInvoiceLines il
								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId
								where il.ProductCode = prdcts.ProductCode
								and ih.ProcessCode IN ('RP', 'CI') 
								and ih.IsReturn = 0
								order by ih.DocumentDate desc
										, ih.CreatedDate desc
								)
	, [Son Alış Günü] = (select top 1  il.LastUpdatedDate	
								from TrInvoiceLines il
								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId
								where il.ProductCode = prdcts.ProductCode
								and ih.ProcessCode IN ('RP') 
								and ih.IsReturn = 0
								order by ih.DocumentDate desc
										, ih.CreatedDate desc
								)
	, Balance = (Select sum(QtyIn - QtyOut) from TrInvoiceLines il 
								left join TrInvoiceHeaders ih on ih.InvoiceHeaderId = il.InvoiceHeaderId
								where il.ProductCode = prdcts.ProductCode
								and ih.WarehouseCode = 'depo-01')
	from DcProducts prdcts
	left join TrProductFeatures on TrProductFeatures.ProductCode = prdcts.ProductCode

	where ProductTypeCode = 1
	) pro
PIVOT (Max(FeatureCode) FOR FeatureTypeId IN ([3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25]) 
) AS PivotTable 
order by PivotTable.[Son Alış Günü] 



