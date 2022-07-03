using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DisplayName("Faktura Tarixi")]
        public DateTime DocumentDate { get; set; }

        [Column(TypeName = "time(0)")]
        [DisplayName("Faktura Vaxtı")]
        public TimeSpan DocumentTime { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Əməliyat Tarixi")]
        public DateTime OperationDate { get; set; }

        [Column(TypeName = "time(0)")]
        [DisplayName("Əməliyat Vaxtı")]
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

        [DisplayName("Mağaza")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [DisplayName("Depo")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string WarehouseCode { get; set; }

        [DisplayName("Fərdi Sənəd Nömrəsi")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CustomsDocumentNumber { get; set; }

        [DisplayName("POS Terminal")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PosTerminalId { get; set; }

        [DisplayName("Asqıdadır")]
        public bool IsSuspended { get; set; }

        [DisplayName("Tamamlanıb")]
        public bool IsCompleted { get; set; }

        [DisplayName("Print Olunub")]
        public bool IsPrinted { get; set; }

        [DisplayName("Fiscal Çap Durumu")]
        public byte FiscalPrintedState { get; set; }

        [DisplayName("İnternet Üzərindən Satış")]
        public bool IsSalesViaInternet { get; set; }

        [DisplayName("Kilidlənib")]
        public bool IsLocked { get; set; }

        [NotMapped]
        [DisplayName("Cari Hesab Açıqlaması")]
        public string CurrAccDesc { get; set; }

        [NotMapped]
        [DisplayName("Tutar")]
        public decimal TotalNetAmount { get; set; }



        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
    }
}
