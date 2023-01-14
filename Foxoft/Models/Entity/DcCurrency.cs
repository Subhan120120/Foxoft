using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
   public partial class DcCurrency
   {
      public DcCurrency()
      {
         TrInvoiceLines = new HashSet<TrInvoiceLine>();
         TrPaymentLines = new HashSet<TrPaymentLine>();
      }

      [Key]
      [DisplayName("Valyuta")]
      [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
      public string CurrencyCode { get; set; }

      [DisplayName("Valyuta Açıqlaması")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public string CurrencyDesc { get; set; }

      [DisplayName("Valyuta Kursu")]
      [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
      public float ExchangeRate { get; set; }


      public virtual AppSetting AppSetting { get; set; }
      public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
      public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
   }
}
