using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Foxoft.Models
{
    [Display(Name = "Məhsul Barkodu")]
    public partial class TrProductBarcode : BaseEntity
    {
        public TrProductBarcode()
        {
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Barkod")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string Barcode { get; set; }

        [Display(Name = "Məhsul Kodu")]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [Display(Name = "Barkod Tipi")]
        [ForeignKey("DcBarcodeType")]
        public string BarcodeTypeCode { get; set; }


        [Display(Name = "Say")]
        [DefaultValue(1)]
        public decimal Qty { get; set; }


        [ForeignKey("BarcodeTypeCode")]
        public virtual DcBarcodeType DcBarcodeType { get; set; }

        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct { get; set; }
    }
}
