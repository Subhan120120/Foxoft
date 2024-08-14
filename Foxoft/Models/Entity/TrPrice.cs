using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Qiymət")]
    public partial class TrPrice : BaseEntity
    {
        [Key]
        public int PriceCode { get; set; }

        [Required]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }

        [Display(Name = "Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal Price { get; set; }

        public virtual DcProduct DcProduct { get; set; }
    }
}
