using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    [Display(Name = "Ödəmə Başlığı")]
    public partial class TrPaymentHeader : BaseEntity
    {
        public TrPaymentHeader()
        {
            TrPaymentLines = new HashSet<TrPaymentLine>();
        }

        [Key]
        public Guid PaymentHeaderId { get; set; }

        [Display(Name = "Faktura İd")]
        [ForeignKey("TrInvoiceHeader")]
        public Guid? InvoiceHeaderId { get; set; }

        //[ForeignKey("RelatedPayment")]
        //public Guid? RelatedPaymentId { get; set; }

        [Display(Name = "Sənəd Nömrəsi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string DocumentNumber { get; set; }

        [Display(Name = "Proses")]
        [ForeignKey("DcProcess")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProcessCode { get; set; }

        [Display(Name = "Sənəd Tarixi")]
        [DefaultValue("getdate()")]
        [Column(TypeName = "date")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Ödəniş Vaxtı")]
        [Column(TypeName = "time(0)")]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan DocumentTime { get; set; }

        [DefaultValue("getdate()")]
        [Column(TypeName = "date")]
        [Display(Name = "Əməliyat Tarixi")]
        public DateTime OperationDate { get; set; }

        [Display(Name = "Əməliyat Vaxtı")]
        [Column(TypeName = "time(0)")]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan OperationTime { get; set; }

        [Display(Name = "Cari Hesab")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        [ForeignKey("DcCurrAcc")]
        public string? CurrAccCode { get; set; }

        [ForeignKey("ToCashReg")]
        [Display(Name = "Kassaya")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? ToCashRegCode { get; set; }

        //[NotMapped]
        [Display(Name = "Kassadan")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? FromCashRegCode { get { return CurrAccCode; } set { CurrAccCode = value; } }

        [Display(Name = "Açıqlama")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? Description { get; set; }

        [Display(Name = "Əməliyat tipi")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? OperationType { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Şirkət")]
        public string? CompanyCode { get; set; }

        [Display(Name = "Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [ForeignKey("DcStore")]
        [Display(Name = "Mağaza Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [Display(Name = "POS Terminal")]
        public short PosterminalId { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Tamamlanıb")]
        public bool IsCompleted { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Göndərilib")]
        public bool IsSent { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Kilidlənib")]
        public bool IsLocked { get; set; }

        //[DefaultValue("1")]
        [Display(Name = "Əsas Qaimə")]
        public bool IsMainTF { get; set; }

        [NotMapped] //datalayoutColntrola gore
        [Display(Name = "Cari Hesab Adı")]
        public string CurrAccDesc { get; set; }

        [NotMapped]
        [Display(Name = "Toplam")]
        public decimal TotalPayment { get; set; }


        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcCurrAcc ToCashReg { get; set; }
        public virtual DcCurrAcc DcStore { get; set; }
        public virtual DcProcess DcProcess { get; set; }
        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }

        //public virtual TrPaymentHeader RelatedPayment { get; set; } // Navigation property to the related line
        //public virtual ICollection<TrPaymentHeader> InversePaymentHeaders { get; set; } // Navigation property for the inverse relationship
    }
}
