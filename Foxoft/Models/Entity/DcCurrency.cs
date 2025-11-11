using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Currency), ResourceType = typeof(Resources))]
    public partial class DcCurrency
    {
        public DcCurrency()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
            TrPaymentLines = new HashSet<TrPaymentLine>();
            TrPriceListLines = new HashSet<TrPriceListLine>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Currency_Code), ResourceType = typeof(Resources))]
        [StringLength(10,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string CurrencyCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Currency_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string CurrencyDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Currency_ExchangeRate), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public float ExchangeRate { get; set; }

        public virtual AppSetting AppSetting { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
        public virtual ICollection<DcProcess> DcProcesses { get; set; }
        public virtual ICollection<TrPriceListLine> TrPriceListLines { get; set; }
    }
}
