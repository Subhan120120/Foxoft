using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Məzənnə")]
    public partial class DcCurrency
    {
        public DcCurrency()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
            TrInstallments = new HashSet<TrInstallment>();
            TrPaymentLines = new HashSet<TrPaymentLine>();
            TrPriceListLines = new HashSet<TrPriceListLine>();
        }

        [Key]
        [Display(Name = "Valyuta")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Valyuta Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string CurrencyDesc { get; set; }

        [Display(Name = "Valyuta Kursu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public float ExchangeRate { get; set; }


        public virtual AppSetting AppSetting { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrInstallment> TrInstallments { get; set; }
        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
        public virtual ICollection<DcProcess> DcProcesses { get; set; }
        public virtual ICollection<TrPriceListLine> TrPriceListLines { get; set; }
    }
}
