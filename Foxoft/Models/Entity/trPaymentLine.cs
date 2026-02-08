using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PaymentLine), ResourceType = typeof(Resources))]
    public partial class TrPaymentLine : BaseEntity
    {
        [Key]
        public Guid PaymentLineId { get; set; }

        [ForeignKey(nameof(TrPaymentHeader))]
        public Guid PaymentHeaderId { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentLine_PaymentTypeCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcPaymentType))]
        public PaymentType PaymentTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentLine_Payment), ResourceType = typeof(Resources))]
        [Column(TypeName = "money")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public decimal Payment { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentLine_PaymentLoc), ResourceType = typeof(Resources))]
        [Column(TypeName = "money")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public decimal PaymentLoc { get { return Math.Round(Payment / (decimal)ExchangeRate, 4); } set { } }

        [Display(Name = nameof(Resources.Entity_PaymentLine_LineDescription), ResourceType = typeof(Resources))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? LineDescription { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentLine_CurrencyCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcCurrency))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string CurrencyCode { get; set; }

        [DefaultValue("1")]
        [Display(Name = nameof(Resources.Entity_PaymentLine_ExchangeRate), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public float ExchangeRate { get; set; } = 1;

        [Display(Name = nameof(Resources.Entity_PaymentLine_CashRegisterCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcCashRegister))]
        public string? CashRegisterCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentLine_PaymentMethodId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcPaymentMethod))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public int PaymentMethodId { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_MakePayment), ResourceType = typeof(Resources))]
        public decimal MakePayment { get { return Payment < 0 ? -Payment : 0; } set => Payment = -value; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_ReceivePayment), ResourceType = typeof(Resources))]
        public decimal ReceivePayment { get { return Payment > 0 ? Payment : 0; } set => Payment = value; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_CurrAccCode), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_CurrAccDesc), ResourceType = typeof(Resources))]
        public string CurrAccDesc { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_DocumentNumber), ResourceType = typeof(Resources))]
        public string DocumentNumber { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_InvoiceNumber), ResourceType = typeof(Resources))]
        public string InvoiceNumber { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_InvoiceHeaderId), ResourceType = typeof(Resources))]
        public Guid? InvoiceHeaderId { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_DocumentDate), ResourceType = typeof(Resources))]
        public DateTime DocumentDate { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_BalanceBefor), ResourceType = typeof(Resources))]
        public decimal BalanceBefor { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentLine_BalanceAfter), ResourceType = typeof(Resources))]
        public decimal BalanceAfter { get; set; }

        public virtual TrPaymentHeader TrPaymentHeader { get; set; }
        public virtual DcPaymentType DcPaymentType { get; set; }
        public virtual DcPaymentMethod DcPaymentMethod { get; set; }
        public virtual DcCurrAcc DcCashRegister { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }
        public virtual TrLoyaltyTxn TrLoyaltyTxn { get; set; }
    }
}
