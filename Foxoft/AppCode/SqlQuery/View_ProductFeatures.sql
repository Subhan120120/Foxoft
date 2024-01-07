

select ProductCode
	, [Feature01] = MAX(PivotTable2.[1]	)
	, [Feature02] = MAX(PivotTable2.[2]	)
	, [Feature03] = MAX(PivotTable2.[3]	)
	, [Feature04] = MAX(PivotTable2.[4]	)
	, [Feature05] = MAX(PivotTable2.[5]	)
	, [Feature06] = MAX(PivotTable2.[6]	)
	, [Feature07] = MAX(PivotTable2.[7]	)
	, [Feature08] = MAX(PivotTable2.[8]	)
	, [Feature09] = MAX(PivotTable2.[9]	)
	, [Feature10] = MAX(PivotTable2.[10])
	, [Feature11] = MAX(PivotTable2.[11])
	, [Feature12] = MAX(PivotTable2.[12])
	, [Feature13] = MAX(PivotTable2.[13])
	, [Feature14] = MAX(PivotTable2.[14])
	, [Feature15] = MAX(PivotTable2.[15])
	, [Feature16] = MAX(PivotTable2.[16])
	, [Feature17] = MAX(PivotTable2.[17])
	, [Feature18] = MAX(PivotTable2.[18])
	, [Feature19] = MAX(PivotTable2.[19])
	, [Feature20] = MAX(PivotTable2.[20]) 
	, [Feature21] = MAX(PivotTable2.[21]) 
	, [Feature22] = MAX(PivotTable2.[22]) 
	, [Feature23] = MAX(PivotTable2.[23]) 
	, [Feature24] = MAX(PivotTable2.[24]) 
	, [Feature25] = MAX(PivotTable2.[25]) 
	, [Feature26] = MAX(PivotTable2.[26]) 
	, [Feature27] = MAX(PivotTable2.[27]) 
	, [Feature28] = MAX(PivotTable2.[28]) 
	, [Feature29] = MAX(PivotTable2.[29]) 
	, [Feature30] = MAX(PivotTable2.[30]) 
	, [Feature31] = MAX(PivotTable2.[31]) 
	, [Feature32] = MAX(PivotTable2.[32]) 
	, [Feature33] = MAX(PivotTable2.[33]) 
	, [Feature34] = MAX(PivotTable2.[34]) 
	, [Feature35] = MAX(PivotTable2.[35]) 
	, [Feature36] = MAX(PivotTable2.[36]) 
	, [Feature37] = MAX(PivotTable2.[37]) 
	, [Feature38] = MAX(PivotTable2.[38]) 
	, [Feature39] = MAX(PivotTable2.[39]) 
	, [Feature40] = MAX(PivotTable2.[40]) 
	, [Feature41] = MAX(PivotTable2.[41]) 
	, [Feature42] = MAX(PivotTable2.[42]) 
	, [Feature43] = MAX(PivotTable2.[43]) 
	, [Feature44] = MAX(PivotTable2.[44]) 
	, [Feature45] = MAX(PivotTable2.[45]) 
	, [Feature46] = MAX(PivotTable2.[46]) 
	, [Feature47] = MAX(PivotTable2.[47]) 
	, [Feature48] = MAX(PivotTable2.[48]) 
	, [Feature49] = MAX(PivotTable2.[49]) 
	, [Feature50] = MAX(PivotTable2.[50])
	, [Feature01Desc] = MAX(PivotTable2.[01]	)
	, [Feature02Desc] = MAX(PivotTable2.[02]	)
	, [Feature03Desc] = MAX(PivotTable2.[03]	)
	, [Feature04Desc] = MAX(PivotTable2.[04]	)
	, [Feature05Desc] = MAX(PivotTable2.[05]	)
	, [Feature06Desc] = MAX(PivotTable2.[06]	)
	, [Feature07Desc] = MAX(PivotTable2.[07]	)
	, [Feature08Desc] = MAX(PivotTable2.[08]	)
	, [Feature09Desc] = MAX(PivotTable2.[09]	)
	, [Feature10Desc] = MAX(PivotTable2.[010])
	, [Feature11Desc] = MAX(PivotTable2.[011])
	, [Feature12Desc] = MAX(PivotTable2.[012])
	, [Feature13Desc] = MAX(PivotTable2.[013])
	, [Feature14Desc] = MAX(PivotTable2.[014])
	, [Feature15Desc] = MAX(PivotTable2.[015])
	, [Feature16Desc] = MAX(PivotTable2.[016])
	, [Feature17Desc] = MAX(PivotTable2.[017])
	, [Feature18Desc] = MAX(PivotTable2.[018])
	, [Feature19Desc] = MAX(PivotTable2.[019])
	, [Feature20Desc] = MAX(PivotTable2.[020]) 
	, [Feature21Desc] = MAX(PivotTable2.[021]) 
	, [Feature22Desc] = MAX(PivotTable2.[022]) 
	, [Feature23Desc] = MAX(PivotTable2.[023]) 
	, [Feature24Desc] = MAX(PivotTable2.[024]) 
	, [Feature25Desc] = MAX(PivotTable2.[025]) 
	, [Feature26Desc] = MAX(PivotTable2.[026]) 
	, [Feature27Desc] = MAX(PivotTable2.[027]) 
	, [Feature28Desc] = MAX(PivotTable2.[028]) 
	, [Feature29Desc] = MAX(PivotTable2.[029]) 
	, [Feature30Desc] = MAX(PivotTable2.[030]) 
	, [Feature31Desc] = MAX(PivotTable2.[031]) 
	, [Feature32Desc] = MAX(PivotTable2.[032]) 
	, [Feature33Desc] = MAX(PivotTable2.[033]) 
	, [Feature34Desc] = MAX(PivotTable2.[034]) 
	, [Feature35Desc] = MAX(PivotTable2.[035]) 
	, [Feature36Desc] = MAX(PivotTable2.[036]) 
	, [Feature37Desc] = MAX(PivotTable2.[037]) 
	, [Feature38Desc] = MAX(PivotTable2.[038]) 
	, [Feature39Desc] = MAX(PivotTable2.[039]) 
	, [Feature40Desc] = MAX(PivotTable2.[040]) 
	, [Feature41Desc] = MAX(PivotTable2.[041]) 
	, [Feature42Desc] = MAX(PivotTable2.[042]) 
	, [Feature43Desc] = MAX(PivotTable2.[043]) 
	, [Feature44Desc] = MAX(PivotTable2.[044]) 
	, [Feature45Desc] = MAX(PivotTable2.[045]) 
	, [Feature46Desc] = MAX(PivotTable2.[046]) 
	, [Feature47Desc] = MAX(PivotTable2.[047]) 
	, [Feature48Desc] = MAX(PivotTable2.[048]) 
	, [Feature49Desc] = MAX(PivotTable2.[049]) 
	, [Feature50Desc] = MAX(PivotTable2.[050])
from (
	select TrProductFeatures.ProductCode
		, TrProductFeatures.FeatureCode
		, FeatureDesc
		, DcFeatures.FeatureTypeId	
		, FeatureTypeId2 = '0' + DcFeatures.FeatureTypeId
	from TrProductFeatures 
	left join DcFeatures on TrProductFeatures.FeatureCode = DcFeatures.FeatureCode
		and TrProductFeatures.FeatureTypeId = DcFeatures.FeatureTypeId
	--where ProductCode = 'P-001247'
) as tblo
PIVOT (Max(FeatureCode) FOR FeatureTypeId IN ([1], [2], [3], [4], [5], [6], [7], [8], [9], [10], [11], [12], [13], [14], [15], [16], [17], [18], [19], [20], [21], [22], [23], [24], [25],
[26], [27], [28], [29], [30], [31], [32], [33], [34], [35], [36], [37], [38], [39], [40], [41], [42], [43], [44], [45], [46], [47], [48], [49], [50])) AS PivotTable
PIVOT (Max(FeatureDesc) FOR FeatureTypeId2 IN ([01], [02], [03], [04], [05], [06], [07], [08], [09], [010], [011], [012], [013], [014], [015], [016], [017], [018], [019], [020], [021], [022], [023], [024], [025],
[026], [027], [028], [029], [030], [031], [032], [033], [034], [035], [036], [037], [038], [039], [040], [041], [042], [043], [044], [045], [046], [047], [048], [049], [050])) AS PivotTable2
group by ProductCode






