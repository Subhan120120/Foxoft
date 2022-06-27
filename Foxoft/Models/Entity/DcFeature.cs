using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcFeature
    {
        public DcFeature()
        {
            TrFeatures = new HashSet<TrFeature>();
        }

        [Key]
        [DisplayName("Özəllik Kodu")]
        public int Id { get; set; }

        [DefaultValue("400")]
        [DisplayName("Özəllik Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string FeatureName { get; set; }

        public virtual ICollection<TrFeature> TrFeatures { get; set; }
    }
}
