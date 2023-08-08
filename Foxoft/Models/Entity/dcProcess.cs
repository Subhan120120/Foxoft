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
   public partial class DcProcess
   {
      public DcProcess()
      {
         TrInvoiceHeaders = new HashSet<TrInvoiceHeader>();
         TrPaymentHeaders = new HashSet<TrPaymentHeader>();
      }

      [Key]
      [Display(Name = "Proses Kodu")]
      [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string ProcessCode { get; set; }

      [Display(Name = "Proses Adı")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string ProcessDesc { get; set; }

      [Display(Name = "Proses İstiqaməti")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public byte ProcessDir { get; set; }

      [Display(Name = "Xüsusi Valyuta")]
      [ForeignKey("DcCurrency")]
      public string? CustomCurrencyCode { get; set; }


      public virtual ICollection<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
      public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }

      public virtual DcCurrency DcCurrency { get; set; }
   }
}
