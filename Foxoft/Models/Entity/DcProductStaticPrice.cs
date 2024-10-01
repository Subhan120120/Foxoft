using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Qiymət")]
    public partial class DcProductStaticPrice : BaseEntity
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }
        
        [Key, Column(Order = 1)]
        [ForeignKey("DcPriceType")]
        [Display(Name = "Qiymət Tipi Kodu")]
        public string PriceTypeCode { get; set; }

        [Display(Name = "Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal Price { get; set; }


        [ForeignKey(nameof(PriceTypeCode))]
        public virtual DcPriceType DcPriceType { get; set; }

        [ForeignKey(nameof(ProductCode))]
        public virtual DcProduct DcProduct { get; set; }
    }
}
