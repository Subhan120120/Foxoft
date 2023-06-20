using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcFeature
    {
        public DcFeature()
        {
            TrProductFeatures = new HashSet<TrProductFeature>();
        }

        [Key]
        [Display(Name = "Özəllik Kodu")]
        public string FeatureCode { get; set; }

        //[Key, Column(Order = 1)]
        [Display(Name = "Özəllik Tipi Kodu")]
        public int FeatureTypeId { get; set; }

        [Display(Name = "Özəllik Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string FeatureDesc { get; set; }


        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
    }
}
