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
   public partial class TrPaymentHeader : BaseEntity
   {
      public TrPaymentHeader()
      {
         TrPaymentLines = new HashSet<TrPaymentLine>();
      }

      [Key]
      public Guid PaymentHeaderId { get; set; }

      [DisplayName("Faktura İd")]
      [ForeignKey("TrInvoiceHeader")]
      public Guid? InvoiceHeaderId { get; set; }

      [DisplayName("Ödəniş Nömrəsi")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public string DocumentNumber { get; set; }

      [DefaultValue("getdate()")]
      [Column(TypeName = "date")]
      [DisplayName("Ödəniş Tarixi")]
      public DateTime DocumentDate { get; set; }

      [DisplayName("Ödəniş Vaxtı")]
      [Column(TypeName = "time(0)")]
      [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
      public TimeSpan DocumentTime { get; set; }

      [DefaultValue("getdate()")]
      [Column(TypeName = "date")]
      [DisplayName("Əməliyat Tarixi")]
      public DateTime OperationDate { get; set; }

      [DisplayName("Əməliyat Vaxtı")]
      [Column(TypeName = "time(0)")]
      [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
      public TimeSpan OperationTime { get; set; }

      //[DisplayName("Faktura Nömrəsi")]
      //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      //[StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      //public string InvoiceNumber { get; set; }

      [DisplayName("Cari Hesab")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      [ForeignKey("DcCurrAcc")]
      public string CurrAccCode { get; set; }

      [DisplayName("Açıqlama")]
      [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string Description { get; set; }

      [DisplayName("Əməliyat tipi")]
      [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string OperationType { get; set; }

      [DefaultValue("0")]
      [DisplayName("Şirkət")]
      public decimal CompanyCode { get; set; }

      [DisplayName("Ofis")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string OfficeCode { get; set; }

      [DisplayName("Mağaza")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string StoreCode { get; set; }

      [DisplayName("POS Terminal")]
      public short PosterminalId { get; set; }

      [DefaultValue("0")]
      [DisplayName("Tamamlanıb")]
      public bool IsCompleted { get; set; }

      [DefaultValue("0")]
      [DisplayName("Kilidlənib")]
      public bool IsLocked { get; set; }


      [NotMapped] //datalayoutColntrola gore
      [DisplayName("Cari Hesab Adı")]
      public string CurrAccDesc { get; set; }

      [NotMapped]
      [DisplayName("Toplam")]
      public decimal TotalPayment { get; set; }

      //[NotMapped]
      //[DisplayName("Toplam")]
      //public decimal CurrAccBalanceBefore { get; set; }  

      //[NotMapped]
      //[DisplayName("Toplam")]
      //public decimal CurrAccBalanceAfter { get; set; }


      public virtual DcCurrAcc DcCurrAcc { get; set; }
      public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
      public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
   }
}
