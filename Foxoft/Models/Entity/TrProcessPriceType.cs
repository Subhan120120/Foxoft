using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Foxoft.Models
{
    [Display(Name = "Proses Qiymət Tipi")]
    public partial class TrProcessPriceType : BaseEntity
    {
        public TrProcessPriceType()
        {
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("DcProcess")]
        [Display(Name = "Proses Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string ProcessCode { get; set; }

        [ForeignKey("DcPriceType")]
        [Display(Name = "Qiymət Tipi Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string PriceTypeCode { get; set; }



        [ForeignKey("ProcessCode")]
        public virtual DcProcess DcProcess { get; set; }

        [ForeignKey("PriceTypeCode")]
        public virtual DcPriceType DcPriceType { get; set; }
    }
}
