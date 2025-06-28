using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Ödəmə Metodu")]
    public partial class DcPaymentMethod
    {
        public DcPaymentMethod()
        {
            TrPaymentLines = new HashSet<TrPaymentLine>();
            TrPaymentMethodDiscounts = new HashSet<TrPaymentMethodDiscount>();
            DcPaymentPlans = new HashSet<DcPaymentPlan>();
        }

        [Key]
        [Display(Name = "Ödəmə Tipi Kodu")]
        public int PaymentMethodId { get; set; }

        [ForeignKey("DcPaymentType")]
        [Display(Name = "Ödəmə Tipi Kodu")]
        public byte PaymentTypeCode { get; set; }

        [Display(Name = "Ödəmə Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PaymentMethodDesc { get; set; }

        [ForeignKey("DcCashReg")]
        [Display(Name = "Default Kassa")]
        public string? DefaultCashRegCode { get; set; }


        //[ForeignKey("DcCashReg")]
        [Display(Name = "Yönləndiriləndir")]
        public bool IsRedirected { get; set; }

        [ForeignKey("DcCurrAcc")]
        [Display(Name = "Yönləndirilmiş Cari Hesab")]
        public string? RedirectedCurrAccCode { get; set; }

        [Display(Name = "Default Ödəmə Metodu")]
        public bool IsDefault { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }


        [ForeignKey("DefaultCashRegCode")]
        public virtual DcCurrAcc DcCashReg { get; set; }
        [ForeignKey("RedirectedCurrAccCode")]
        public virtual DcCurrAcc DcCurrAcc { get; set; }
        [ForeignKey("PaymentTypeCode")]
        public virtual DcPaymentType DcPaymentType { get; set; }
        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
        public virtual ICollection<TrPaymentMethodDiscount> TrPaymentMethodDiscounts { get; set; }
        public virtual ICollection<DcPaymentPlan> DcPaymentPlans { get; set; }
    }
}
