using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
   public partial class DcFeatureDcProduct
   {
      public DcFeatureDcProduct()
      {
         DcProducts = new HashSet<DcProduct>();
      }

      [Key, Column(Order = 0)]
      [DisplayName("Özəllik Kodu")]
      public int DcFeaturesId { get; set; }

      [Key, Column(Order = 1)]
      [DisplayName("Özəllik Kodu")]
      public string DcProductsProductCode { get; set; }

      [DisplayName("Özəllik Adı")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public string FeatureDesc { get; set; }

      public virtual ICollection<DcProduct> DcProducts { get; set; }
   }
}
