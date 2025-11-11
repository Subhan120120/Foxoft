using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Discount), ResourceType = typeof(Resources))]
    public partial class DcDiscount : BaseEntity
    {
        public DcDiscount()
        {
            TrPaymentMethodDiscounts = new HashSet<TrPaymentMethodDiscount>();
            TrProductDiscounts = new HashSet<TrProductDiscount>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Discount_Id), ResourceType = typeof(Resources))]
        public int DiscountId { get; set; }

        [Display(Name = nameof(Resources.Entity_Discount_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string DiscountDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Discount_Percent), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public decimal DiscountPercent { get; set; }

        public virtual ICollection<TrPaymentMethodDiscount> TrPaymentMethodDiscounts { get; set; }
        public virtual ICollection<TrProductDiscount> TrProductDiscounts { get; set; }
    }
}
