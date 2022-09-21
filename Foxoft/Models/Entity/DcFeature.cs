using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
   public partial class DcFeature
   {
      public DcFeature()
      {
         DcProducts = new HashSet<DcProduct>();
      }

      [Key]
      [DisplayName("Özəllik Kodu")]
      public int Id { get; set; }

      [DisplayName("Özəllik Adı")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public string FeatureName { get; set; }

      public virtual ICollection<DcProduct> DcProducts { get; set; }
   }
}
