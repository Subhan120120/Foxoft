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
    [Microsoft.EntityFrameworkCore.Index(nameof(DocumentNumber), nameof(ProcessCode), nameof(CurrAccCode))]
    public partial class TrInvoiceHeader : BaseEntity
    {
        public TrInvoiceHeader()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
            TrPaymentHeaders = new HashSet<TrPaymentHeader>();
            InverseRelatedHeaders = new HashSet<TrInvoiceHeader>();
        }

        [Key]
        public Guid InvoiceHeaderId { get; set; }


        [ForeignKey("RelatedHeader")]
        public Guid? RelatedInvoiceId { get; set; }

        [Display(Name = "Proses")]
        [ForeignKey("DcProcess")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProcessCode { get; set; }

        [Display(Name = "Faktura Nömrəsi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string DocumentNumber { get; set; }

        [Display(Name = "Geri Qaytarma")]
        public bool IsReturn { get; set; }

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


        [Display(Name = "Açıqlama")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? Description { get; set; }

#nullable enable
        [Display(Name = "Cari Hesab")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        [ForeignKey("DcCurrAcc")]
        public string? CurrAccCode { get; set; }
#nullable disable

        [Display(Name = "Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [Display(Name = "Mağaza Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [Display(Name = "Depodan")]
        //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string WarehouseCode { get; set; }

        [Display(Name = "Depoya")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ToWarehouseCode { get; set; }

        [Display(Name = "Fərdi Sənəd Nömrəsi")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CustomsDocumentNumber { get; set; }

        [Display(Name = "POS Terminal")]
        //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PosTerminalId { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Asqıdadır")]
        public bool IsSuspended { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Göndərilib")]
        public bool IsSent { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Açıqdır")]
        public bool IsOpen { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Tamamlanıb")]
        public bool IsCompleted { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Çap Sayı")]
        public byte PrintCount { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Fiscal Çap Durumu")]
        public byte FiscalPrintedState { get; set; }

        [DefaultValue("0")]
        [Display(Name = "İnternet Üzərindən Satış")]
        public bool IsSalesViaInternet { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Kilidlənib")]
        public bool IsLocked { get; set; }

        [Display(Name = "Əsas Transfer")]
        //[DefaultValue("1")]
        public bool IsMainTF { get; set; }

        //[NotMapped] //datalayoutColntrola gore
        //[Display(Name = "Cari Hesab Adı")]
        //public string CurrAccDescription { get { if (!Object.ReferenceEquals(DcCurrAcc, null)) { return DcCurrAcc.CurrAccDesc; } else return ""; } }

        [NotMapped]
        [Display(Name = "Cari Hesab Adı")]
        public string CurrAccDesc { get; set; }

        //FormInvoiceHeaderList'de CurrAccDesc gostermir, DcCurrAcc null olaraq gelir
        //public string CurrAccDesc { get { if (!Object.ReferenceEquals(DcCurrAcc, null)) { return DcCurrAcc.CurrAccDesc; } else return ""; } set { } }

        [NotMapped]
        [Display(Name = "Tutar")]
        public decimal TotalNetAmount { get; set; }
        //public decimal TotalNetAmount { get { return TrInvoiceLines.Sum(l => l.NetAmountLoc / 1.703m); } set { } }


        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcProcess DcProcess { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }


        public virtual TrInvoiceHeader RelatedHeader { get; set; } // Navigation property to the related line
        public virtual ICollection<TrInvoiceHeader> InverseRelatedHeaders { get; set; } // Navigation property for the inverse relationship
    }
}
