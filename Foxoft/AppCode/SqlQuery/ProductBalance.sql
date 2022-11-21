

declare @StartDate date = dateadd(DAY, 1, getdate())
declare @StartTime time =  '00:00:00.000'
select 
*
, Balance = isnull([depo-01],0) + isnull([depo-02],0) + isnull([depo-03],0)
from (
	select DcProducts.ProductCode
	, DcProducts.ProductDesc
		, WarehouseCode
	, SUM(ISNULL(QtyIn,0) - ISNULL(QtyOut,0)) Balance 
	--, LastPurchasePrice = ()
	from DcProducts
	
	left join TrInvoiceLines il on il.ProductCode = DcProducts.ProductCode
	left join TrInvoiceHeaders ih on il.InvoiceHeaderId = ih.InvoiceHeaderId
	
	where (CAST(ih.DocumentDate AS DATETIME) + CAST(ih.DocumentTime AS DATETIME)) <=
		(CAST(@StartDate AS DATETIME) + CAST(@StartTime AS DATETIME))
		--and il.ProductCode = '5503'
	
	group by DcProducts.ProductCode
		, DcProducts.ProductDesc
		, WarehouseCode
) AS SourceTable  
PIVOT  
(  
 AVG(Balance)
  FOR WarehouseCode IN ([depo-01], [depo-02], [depo-03])  
) AS PivotTable;  



