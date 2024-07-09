using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Foxoft.Models
{
    [Display(Name = "Məhsul Endirimi")]
    public partial class TrProductDiscount
    {
        [Key, Column(Order = 0)]
        [ForeignKey("DcProduct")]
        [Display(Name = "Məhsul Kodu")]
        public string ProductCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("DcDiscount")]
        [Display(Name = "Endirim Id")]
        public int DiscountId { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct { get; set; }

        [JsonIgnore]
        [ForeignKey("DiscountId")]
        public virtual DcDiscount DcDiscount { get; set; }

    }
}
