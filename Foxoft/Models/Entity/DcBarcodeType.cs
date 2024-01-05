using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcBarcodeType
    {
        public DcBarcodeType()
        {
            TrProductBarcodes = new HashSet<TrProductBarcode>();
    }

        [Key]
        [Display(Name = "Barkod Tipi Kodu")]
        public string BarcodeTypeCode { get; set; }

        [Display(Name = "Barkod Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string BarcodeTypeDesc { get; set; }

        public virtual ICollection<TrProductBarcode> TrProductBarcodes { get; set; }
    }
}
