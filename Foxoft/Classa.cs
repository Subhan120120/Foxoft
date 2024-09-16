using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft
{
    public partial class Classa
    {
        public string query = @"
                            Select  DcProducts.ProductCode
                            , ProductDesc
                            , WholesalePrice
                            , DcHierarchies.HierarchyCode
                            , HierarchyDesc
                            , ProductTypeCode
                            
                            from DcProducts
                            
                            left join DcHierarchies on DcProducts.HierarchyCode = DcHierarchies.HierarchyCode
                            left join ProductFeatures on ProductFeatures.ProductCode = DcProducts.ProductCode
                            
                            where ProductTypeCode = 1
                            order by ProductDesc
                            ";

        string filter = @" where [ProductCode] in ( 'P-001168','P-001577','P-001578','P-000052','P-000815','4474','4966','P-000889','P-000890','P-000057','P-001736','P-001737','P-002460','P-002421','P-002933','P-002799','P-002611','5503','P-001083','P-000187','5455','P-002910','P-000144','P-002785','P-000143','P-002561','P-000878','P-002034','P-002036','P-000460','P-002975','P-002934','P-000661','P-002798','P-000180','4245','P-000657','P-000761','P-001069','P-001855','P-001144','P-002505','P-002671','P-002670','P-001579','P-000817','P-000818','P-002786','P-001304','P-002681','P-002395','P-002396','P-002399','P-001887','P-001192','5742','P-002830','P-002614','6223','P-000891','P-001948','P-000991','P-000690','P-000912','P-001617','6095','P-002673','P-001252','P-001254','P-001255','6338','P-001261','P-000356','P-002256','P-002066','P-002807','P-001854','P-001055','P-001852','P-001853','P-002046','P-003000','P-002483','P-002993','P-002065','P-001528','P-001615') ";

    }
}
