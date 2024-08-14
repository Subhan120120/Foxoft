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
    public partial class DcSerialNumber
    {
        public DcSerialNumber()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
        }

        [Key]
        [Display(Name = "Seria Nömrəsi Kodu")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string SerialNumberCode { get; set; }


        [Display(Name = "Məhsul Kodu")]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }

        //[Display(Name = "Seria Nömrəsi Açıqlaması")]
        //[Required(ErrorMessage = "{0} boş buraxıla bilmez \n")]
        //[StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        //public string SerialNumberDesc { get; set; }


        public virtual DcProduct DcProduct { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }

    }
}
