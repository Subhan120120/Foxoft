using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class TrProductFeature
    {
        [Key, Column(Order = 0)]
        [ForeignKey("DcProduct")]
        [Display(Name = "Məhsul Kodu")]
        public string ProductCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("DcFeatureType")]
        [Display(Name = "Özəllik Tipi Kodu")]
        public int FeatureTypeId { get; set; }

        //[Key, Column(Order = 1)]
        [ForeignKey("DcFeature")]
        [Display(Name = "Özəllik Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string FeatureCode { get; set; }



        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct { get; set; }

        [ForeignKey("FeatureTypeId")]
        public virtual DcFeatureType DcFeatureType { get; set; }

        [ForeignKey("FeatureCode")]
        public virtual DcFeature DcFeature { get; set; }
    }
}
