	--declare @StartDate date = dateadd(DAY, 1, getdate())
	--declare @StartTime time =  '00:00:00.000'

select DcProducts.ProductCode
, [Məhsulun Geniş Adı] = isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc 
		  + isnull(' ' + Feature01,'') + isnull(' ' + Feature02,'') + isnull(' ' + Feature03,'') + isnull(' ' + Feature04,'') + isnull(' ' + Feature05,'') 
		  + isnull(' ' + Feature06,'') + isnull(' ' + Feature07,'') + isnull(' ' + Feature08,'') + isnull(' ' + Feature09,'') + isnull(' ' + Feature10,'') 
		  + isnull(' ' + Feature11,'') + isnull(' ' + Feature12,'') + isnull(' ' + Feature13,'') + isnull(' ' + Feature16,'') + isnull(' ' + Feature17,'') 
		  + isnull(' ' + Feature18,'') + isnull(' ' + Feature19,'') + isnull(' ' + Feature20,'')
, ProductDesc
, WholesalePrice
, DcHierarchies.HierarchyCode
, HierarchyDesc
, ProductTypeCode
, [01] = isnull(' ' + Feature01Desc,'')
, [02] = isnull(' ' + Feature02Desc,'')
, [03] = isnull(' ' + Feature03Desc,'')
, [04] = isnull(' ' + Feature04Desc,'')
, [05] = isnull(' ' + Feature05Desc,'')
, [06] = isnull(' ' + Feature06Desc,'')
, [07] = isnull(' ' + Feature07Desc,'')
, [09] = isnull(' ' + Feature09Desc,'')
, [10] = isnull(' ' + Feature10Desc,'')
, [11] = isnull(' ' + Feature11Desc,'')
, [12] = isnull(' ' + Feature12Desc,'')
, [13] = isnull(' ' + Feature13Desc,'')
, [14] = isnull(' ' + Feature14Desc,'')
, [15] = isnull(' ' + Feature15Desc,'')
, [16] = isnull(' ' + Feature16Desc,'')
, [17] = isnull(' ' + Feature17Desc,'')
, [18] = isnull(' ' + Feature18Desc,'')
, [19] = isnull(' ' + Feature22Desc,'')
, [20] = isnull(' ' + Feature23Desc,'')

from DcProducts

left join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode
left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode

where ProductTypeCode = 1
			
order by isnull(DcHierarchies.HierarchyCode + ' ','')  + ProductDesc
