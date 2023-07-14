

select ProductCode
	, [Feature01] = isnull(' ' + [1],'')
	, [Feature02] = isnull(' ' + [2],'')
	, [Feature03] = isnull(' ' + [3],'')
	, [Feature04] = isnull(' ' + [4],'')
	, [Feature05] = isnull(' ' + [5],'')
	, [Feature06] = isnull(' ' + [6],'')
	, [Feature07] = isnull(' ' + [7],'')
	, [Feature08] = isnull(' ' + [8],'')
	, [Feature09] = isnull(' ' + [9],'')
	, [Feature10] = isnull(' ' + [10],'')
	, [Feature11] = isnull(' ' + [11],'')
	, [Feature12] = isnull(' ' + [12],'')
	, [Feature13] = isnull(' ' + [13],'')
	, [Feature14] = isnull(' ' + [14],'')
	, [Feature15] = isnull(' ' + [15],'')
	, [Feature16] = isnull(' ' + [16],'')
	, [Feature17] = isnull(' ' + [17],'')
	, [Feature18] = isnull(' ' + [18],'')
	, [Feature19] = isnull(' ' + [19],'')
	, [Feature20] = isnull(' ' + [20],'') 
	, [Feature21] = isnull(' ' + [21],'') 
	, [Feature22] = isnull(' ' + [22],'') 
	, [Feature23] = isnull(' ' + [23],'') 
	, [Feature24] = isnull(' ' + [24],'') 
	, [Feature25] = isnull(' ' + [25],'') 
	, [Feature26] = isnull(' ' + [26],'') 
	, [Feature27] = isnull(' ' + [27],'') 
	, [Feature28] = isnull(' ' + [28],'') 
	, [Feature29] = isnull(' ' + [29],'') 
	, [Feature30] = isnull(' ' + [30],'') 
	, [Feature31] = isnull(' ' + [31],'') 
	, [Feature32] = isnull(' ' + [32],'') 
	, [Feature33] = isnull(' ' + [33],'') 
	, [Feature34] = isnull(' ' + [34],'') 
	, [Feature35] = isnull(' ' + [35],'') 
	, [Feature36] = isnull(' ' + [36],'') 
	, [Feature37] = isnull(' ' + [37],'') 
	, [Feature38] = isnull(' ' + [38],'') 
	, [Feature39] = isnull(' ' + [39],'') 
	, [Feature40] = isnull(' ' + [40],'') 
	, [Feature41] = isnull(' ' + [41],'') 
	, [Feature42] = isnull(' ' + [42],'') 
	, [Feature43] = isnull(' ' + [43],'') 
	, [Feature44] = isnull(' ' + [44],'') 
	, [Feature45] = isnull(' ' + [45],'') 
	, [Feature46] = isnull(' ' + [46],'') 
	, [Feature47] = isnull(' ' + [47],'') 
	, [Feature48] = isnull(' ' + [48],'') 
	, [Feature49] = isnull(' ' + [49],'') 
	, [Feature50] = isnull(' ' + [50],'') 

from (
	select TrProductFeatures.ProductCode
		, FeatureDesc
		, DcFeatures.FeatureTypeId		
	from TrProductFeatures 
	left join DcFeatures on TrProductFeatures.FeatureCode = DcFeatures.FeatureCode
) as tblo
PIVOT (Max(FeatureDesc) FOR FeatureTypeId IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25],
[26], [27], [28], [29], [30], [31], [32], [33], [34], [35], [36], [37], [38], [39], [40], [41], [42], [43], [44], [45], [46], [47], [48], [49], [50])) AS PivotTable








