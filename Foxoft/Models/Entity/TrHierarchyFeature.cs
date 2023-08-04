using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class TrHierarchyFeature
    {
        [Key, Column(Order = 0)]
        [ForeignKey("DcHierarchy")]
        [Display(Name = "İyerarxiya Kodu")]
        public string HierarchyCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("DcFeatureType")]
        [Display(Name = "Özəllik Tipi Kodu")]
        public int FeatureTypeId { get; set; }



        [ForeignKey("HierarchyCode")]
        public virtual DcHierarchy DcHierarchy { get; set; }

        [ForeignKey("FeatureTypeId")]
        public virtual DcFeatureType DcFeatureType { get; set; }
        
    }
}
