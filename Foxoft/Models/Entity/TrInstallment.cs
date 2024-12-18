﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Ödəmə Planı")]
    public partial class TrInstallment
    {
        public TrInstallment()
        {
        }

        [Key]
        [Display(Name = "Ödəmə Planı İd")]
        public int InstallmentId { get; set; }

        [ForeignKey("TrInvoiceHeader")]
        [Display(Name = "Faktura İd")]
        public Guid InvoiceHeaderId { get; set; }

        [Display(Name = "Ödəmə Planı Kodu")]
        [ForeignKey("DcPaymentPlan")]
        public string PaymentPlanCode { get; set; }

        [Display(Name = "Komissiya")]
        public decimal Commission { get; set; } // Interest rate associated with the plan, if applicable 

        [Display(Name = "Ümumi Məbləğ")]
        public decimal Amount { get; set; }

        [ForeignKey("DcCurrency")]
        [Display(Name = "Valyuta")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Valyuta Kursu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public float ExchangeRate { get; set; }

        public virtual DcCurrency DcCurrency { get; set; }
        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcPaymentPlan DcPaymentPlan { get; set; }

    }
}
