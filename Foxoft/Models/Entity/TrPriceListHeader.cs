using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
//#nullable disable

namespace Foxoft.Models
{
    public partial class TrPriceListHeader : BaseEntity
    {
        public TrPriceListHeader()
        {
            TrPriceListLines = new HashSet<TrPriceListLine>();
            //TrPaymentHeaders = new HashSet<TrPaymentHeader>();
        }

        [Key]
        public Guid PriceListHeaderId { get; set; }

        [Display(Name = "Faktura Nömrəsi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string DocumentNumber { get; set; }

        [ForeignKey("DcPriceListType")]
        [Display(Name = "Qiymət Siyahı Tipi Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string PriceTypeCode { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = "Faktura Tarixi")]
        public DateTime DocumentDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = "Faktura Vaxtı")]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan DocumentTime { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = "Əməliyat Tarixi")]
        public DateTime OperationDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = "Əməliyat Vaxtı")]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan OperationTime { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = "Əməliyat Tarixi")]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = "Əməliyat Vaxtı")]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan DueTime { get; set; }

        [Display(Name = "Açıqlama")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Description { get; set; }

        [Display(Name = "Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }


        [DefaultValue("0")]
        [Display(Name = "Ləğv Edilib")]
        public bool IsDisabled { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Vergi Daxil")]
        public bool IsTexIncluded { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Təsdiqlənib")]
        public bool IsConfirmed { get; set; }


        public virtual ICollection<TrPriceListLine> TrPriceListLines { get; set; }
        public virtual DcPriceType DcPriceListType { get; set; }
    }
}
