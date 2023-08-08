using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class DcDiscount : BaseEntity
    {
        public DcDiscount()
        {
            TrPaymentMethodDiscounts = new HashSet<TrPaymentMethodDiscount>();
            TrProductDiscounts = new HashSet<TrProductDiscount>();
        }

        [Key]
        [Display(Name = "Endirim İd")]
        public int DiscountId { get; set; }

        //[ForeignKey("DcProduct")]
        [Display(Name = "Endirim Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string DiscountDesc { get; set; }

        [Display(Name = "Faiz")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal DiscountPercent { get; set; }

        public virtual ICollection<TrPaymentMethodDiscount> TrPaymentMethodDiscounts { get; set; }
        public virtual ICollection<TrProductDiscount> TrProductDiscounts { get; set; }
    }
}
