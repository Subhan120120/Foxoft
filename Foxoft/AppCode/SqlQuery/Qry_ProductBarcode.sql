--declare @ProductCode nvarchar(MAX)= '4885'
select DcProducts.ProductCode
				, DcProducts.ProductDesc
				, WholesalePrice 
				, Marka = FeatureDesc		
				, Barcode
	from DcProducts
	left join DcProductDcFeatures fea on fea.ProductCode = DcProducts.ProductCode
					and fea.FeatureId = 3
	
	where ProductTypeCode = 1
		and DcProducts.ProductCode = @ProductCode	
	--group by DcProducts.ProductCode
	--		 , DcProducts.ProductDesc
	--		 , WholesalePrice 
	--		 , FeatureDesc



