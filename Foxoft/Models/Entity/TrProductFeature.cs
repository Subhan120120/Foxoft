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
      [ForeignKey("DcFeature")]
      [Display(Name = "Özəllik Kodu")]
      public int FeatureId { get; set; }

      [Display(Name = "Özəllik Dəyəri")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public string FeatureDesc { get; set; }

      public virtual DcProduct DcProduct { get; set; }
      public virtual DcFeatureType DcFeature { get; set; }
   }
}
