using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
   public partial class DcProductDcFeature
   {
      [Key, Column(Order = 0)]
      [ForeignKey("DcProduct")]
      [DisplayName("Məhsul Kodu")]
      public string ProductCode { get; set; }

      [Key, Column(Order = 1)]
      [ForeignKey("DcFeature")]
      [DisplayName("Özəllik Kodu")]
      public int FeatureId { get; set; }

      [DisplayName("Özəllik Dəyəri")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public string FeatureDesc { get; set; }

      public virtual DcProduct DcProduct { get; set; }
      public virtual DcFeature DcFeature { get; set; }
   }
}
