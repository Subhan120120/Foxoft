using System.Collections.Generic;
using System.ComponentModel;
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

        [Display(Name = "Özəllik Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string FeatureName { get; set; }


        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
    }
}
