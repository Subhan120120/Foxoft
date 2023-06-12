using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
   public partial class DcFeatureType
   {
      public DcFeatureType()
      {
         DcProducts = new HashSet<DcProduct>();
      }

      [Key]
      [Display(Name = "Özəllik Kodu")]
      public int FeatureTypeId { get; set; }

      [Display(Name = "Özəllik Adı")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public string FeatureTypeName { get; set; }

      public virtual ICollection<DcProduct> DcProducts { get; set; }
      //public virtual ICollection<DcProductDcFeature> DcProductDcFeatures { get; set; }
   }
}
