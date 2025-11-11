using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PaymentMethodDiscount), ResourceType = typeof(Resources))]
    public partial class TrPaymentMethodDiscount
    {
        [Key, Column(Order = 0)]
        [Display(Name = nameof(Resources.Entity_PaymentMethodDiscount_DiscountId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcDiscount))]
        public int DiscountId { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = nameof(Resources.Entity_PaymentMethodDiscount_PaymentMethodId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcPaymentMethod))]
        public int PaymentMethodId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(DiscountId))]
        public virtual DcDiscount DcDiscount { get; set; }

        [ForeignKey(nameof(PaymentMethodId))]
        public virtual DcPaymentMethod DcPaymentMethod { get; set; }
    }
}
