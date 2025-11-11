using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProductDiscount), ResourceType = typeof(Resources))]
    public partial class TrProductDiscount
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(DcProduct))]
        [Display(Name = nameof(Resources.Entity_ProductDiscount_ProductCode), ResourceType = typeof(Resources))]
        public string ProductCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(DcDiscount))]
        [Display(Name = nameof(Resources.Entity_ProductDiscount_DiscountId), ResourceType = typeof(Resources))]
        public int DiscountId { get; set; }

        [JsonIgnore] public virtual DcProduct DcProduct { get; set; }
        [JsonIgnore] public virtual DcDiscount DcDiscount { get; set; }
    }
}
