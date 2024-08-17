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
    [Display(Name = "Seria Nömrəsi")]
    public partial class DcUnitOfMeasure
    {
        public DcUnitOfMeasure()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
        }

        [Key]
        [Display(Name = "Ölçü Vahidi Kodu")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string UnitOfMeasureCode { get; set; }


        [Display(Name = "Ölçü Vahidi Səviyyəsi")]
        public byte Level { get; set; }


        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }

    }
}
