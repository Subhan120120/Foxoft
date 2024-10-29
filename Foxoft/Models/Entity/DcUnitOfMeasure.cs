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
    [Display(Name = "Ölçü Vahidi")]
    public partial class DcUnitOfMeasure
    {
        public DcUnitOfMeasure()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
            DcProducts = new HashSet<DcProduct>();
            SettingStores = new HashSet<SettingStore>();
        }

        [Key]
        [Display(Name = "Ölçü Vahidi Id")]
        public int UnitOfMeasureId { get; set; }

        [Display(Name = "Ölçü Vahidi Açıqlaması")]
        [StringLength(25, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string UnitOfMeasureDesc { get; set; }

        [Display(Name = "Ana Ölçü Vahidi Id")]
        public int ParentUnitOfMeasureId { get; set; }

        [Display(Name = "Dəyişmə Nisbəti")]
        public decimal ConversionRate { get; set; }

        [Display(Name = "Ölçü Vahidi Səviyyəsi")]
        public byte Level { get; set; }


        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<DcProduct> DcProducts { get; set; }
        public virtual ICollection<SettingStore> SettingStores { get; set; }

    }
}
