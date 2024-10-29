using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    [Display(Name = "Məhsul Ölçü Vahidi")]
    public partial class TrProductUnitOfMeasure
    {
        public TrProductUnitOfMeasure()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
        }

        [Key]
        [Display(Name = "Ölçü Vahidi Id")]
        public int ProductUnitOfMeasureId { get; set; }

        [Display(Name = "Məhsul Kodu")]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }

        [Display(Name = "Ölçü Vahidi Id")]
        [ForeignKey("DcUnitOfMeasure")]
        public int UnitOfMeasureId { get; set; }

        [Display(Name = "Dəyişmə Nisbəti")]
        public decimal ConversionRate { get; set; }


        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual DcProduct DcProduct { get; set; }
        public virtual DcUnitOfMeasure DcUnitOfMeasure { get; set; }

    }
}
