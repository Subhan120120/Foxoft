using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_SerialNumber), ResourceType = typeof(Resources))]
    public partial class DcSerialNumber
    {
        public DcSerialNumber() { TrInvoiceLines = new HashSet<TrInvoiceLine>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_SerialNumber_Code), ResourceType = typeof(Resources))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string SerialNumberCode { get; set; }

        [Display(Name = nameof(Resources.Entity_SerialNumber_ProductCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProduct))]
        public string ProductCode { get; set; }

        public virtual DcProduct DcProduct { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
    }
}
