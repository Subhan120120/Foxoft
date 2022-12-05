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
   [Index(nameof(DocumentNumber), nameof(ProcessCode), nameof(CurrAccCode))]
   public partial class TrInvoiceHeader : BaseEntity
   {
      public TrInvoiceHeader()
      {
         TrInvoiceLines = new HashSet<TrInvoiceLine>();
         TrPaymentHeaders = new HashSet<TrPaymentHeader>();
      }

      [Key]
      public Guid InvoiceHeaderId { get; set; }
      public Guid? RelatedInvoiceId { get; set; }

      [DisplayName("Proses")]
      [ForeignKey("DcProcess")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string ProcessCode { get; set; }

      [DisplayName("Faktura Nömrəsi")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string DocumentNumber { get; set; }

      [DisplayName("Geri Qaytarma")]
      public bool IsReturn { get; set; }

      [Column(TypeName = "date")]
      [DefaultValue("getdate()")]
      [DisplayName("Faktura Tarixi")]
      public DateTime DocumentDate { get; set; }

      [Column(TypeName = "time(0)")]
      [DisplayName("Faktura Vaxtı")]
      [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
      public TimeSpan DocumentTime { get; set; }

      [Column(TypeName = "date")]
      [DefaultValue("getdate()")]
      [DisplayName("Əməliyat Tarixi")]
      public DateTime OperationDate { get; set; }

      [Column(TypeName = "time(0)")]
      [DisplayName("Əməliyat Vaxtı")]
      [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
      public TimeSpan OperationTime { get; set; }


      [DisplayName("Açıqlama")]
      [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string Description { get; set; }

#nullable enable
      [DisplayName("Cari Hesab")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      [ForeignKey("DcCurrAcc")]
      public string? CurrAccCode { get; set; }
#nullable disable

      [DisplayName("Ofis")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string OfficeCode { get; set; }

      [DisplayName("Mağaza Kodu")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string StoreCode { get; set; }

      [DisplayName("Depodan")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string WarehouseCode { get; set; }

      [DisplayName("Depoya")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string ToWarehouseCode { get; set; }

      [DisplayName("Fərdi Sənəd Nömrəsi")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string CustomsDocumentNumber { get; set; }

      [DisplayName("POS Terminal")]
      //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string PosTerminalId { get; set; }

      [DefaultValue("0")]
      [DisplayName("Asqıdadır")]
      public bool IsSuspended { get; set; }

      [DefaultValue("0")]
      [DisplayName("Tamamlanıb")]
      public bool IsCompleted { get; set; }

      [DefaultValue("0")]
      [DisplayName("Print Olunub")]
      public byte PrintCount { get; set; }

      [DefaultValue("0")]
      [DisplayName("Fiscal Çap Durumu")]
      public byte FiscalPrintedState { get; set; }

      [DefaultValue("0")]
      [DisplayName("İnternet Üzərindən Satış")]
      public bool IsSalesViaInternet { get; set; }

      [DefaultValue("0")]
      [DisplayName("Kilidlənib")]
      public bool IsLocked { get; set; }

      //[NotMapped] //datalayoutColntrola gore
      //[DisplayName("Cari Hesab Adı")]
      //public string CurrAccDescription { get { if (!Object.ReferenceEquals(DcCurrAcc, null)) { return DcCurrAcc.CurrAccDesc; } else return ""; } }

      [NotMapped]
      [DisplayName("Cari Hesab Adı")]
      public string CurrAccDesc { get; set; }

      //FormInvoiceHeaderList'de CurrAccDesc gostermir, DcCurrAcc null olaraq gelir
      //public string CurrAccDesc { get { if (!Object.ReferenceEquals(DcCurrAcc, null)) { return DcCurrAcc.CurrAccDesc; } else return ""; } set { } }

      [NotMapped]
      [DisplayName("Tutar")]
      public decimal TotalNetAmount { get; set; }
      //public decimal TotalNetAmount { get { return TrInvoiceLines.Sum(l => l.NetAmountLoc / 1.703m); } set { } }


      public virtual DcCurrAcc DcCurrAcc { get; set; }
      public virtual DcProcess DcProcess { get; set; }
      public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
      public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
   }
}
