using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Foxoft.Models
{
    [Display(Name = "Ödəmə Metodu Endirimi")]
    public partial class TrPaymentMethodDiscount
    {

        [Key, Column(Order = 0)]
        [Display(Name = "Endirim İd")]
        [ForeignKey("DcDiscount")]
        public int DiscountId { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Ödəmə Tipi Kodu")]
        [ForeignKey("DcPaymentMethod")]
        public int PaymentMethodId { get; set; }


        [JsonIgnore]
        [ForeignKey("DiscountId")]
        public virtual DcDiscount DcDiscount { get; set; }

        [ForeignKey("PaymentMethodId")]
        public virtual DcPaymentMethod DcPaymentMethod { get; set; }
    }
}
