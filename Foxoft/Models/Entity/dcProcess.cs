using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Process), ResourceType = typeof(Resources))]
    public partial class DcProcess
    {
        public DcProcess()
        {
            TrInvoiceHeaders = new HashSet<TrInvoiceHeader>();
            TrPaymentHeaders = new HashSet<TrPaymentHeader>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Process_Code), ResourceType = typeof(Resources))]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources),
                        ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProcessCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Process_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProcessDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Process_Dir), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public byte ProcessDir { get; set; }

        [Display(Name = nameof(Resources.Entity_Process_CustomCurrency), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcCurrency))]
        public string? CustomCurrencyCode { get; set; }

        public virtual ICollection<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }
    }
}
