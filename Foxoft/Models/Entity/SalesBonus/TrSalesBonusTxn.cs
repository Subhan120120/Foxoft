using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    /// <summary>
    /// Satıcı bonus jurnalı (audit ledger). Hər hesablama/ləğv/düzəliş ayrıca sətir kimi yazılır, mövcud sətirlər silinmir.
    /// Faktura səviyyəli metodlar üçün açar (Plan, Satıcı, InvoiceHeaderId), dövr səviyyəli metodlar üçün (Plan, Satıcı, PeriodYear, PeriodNo).
    /// </summary>
    [Index(nameof(SalesPersonCode), nameof(DocumentDate))]
    [Index(nameof(SalesBonusPlanId), nameof(SalesPersonCode), nameof(PeriodYear), nameof(PeriodNo))]
    [Index(nameof(InvoiceHeaderId))]
    [Index(nameof(PaymentHeaderId))]
    [Index(nameof(PayrollHeaderId))]
    [Display(Name = nameof(Resources.Entity_SalesBonusTxn), ResourceType = typeof(Resources))]
    public partial class TrSalesBonusTxn : BaseEntity
    {
        [Key]
        public Guid SalesBonusTxnId { get; set; } = Guid.NewGuid();

        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_PlanId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcSalesBonusPlan))]
        public Guid SalesBonusPlanId { get; set; }

        [ForeignKey(nameof(TrSalesBonusAssignment))]
        public Guid? SalesBonusAssignmentId { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusAssignment_SalesPersonCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcCurrAcc))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string SalesPersonCode { get; set; } = string.Empty;

        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_TxnType), ResourceType = typeof(Resources))]
        public BonusTxnType TxnType { get; set; }

        /// <summary>Hesablama anındakı metod (plan sonradan dəyişsə belə audit üçün saxlanılır).</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_CalcMethod), ResourceType = typeof(Resources))]
        public BonusCalcMethod CalcMethod { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusPlan_TriggerType), ResourceType = typeof(Resources))]
        public BonusTriggerType TriggerType { get; set; }

        /// <summary>Əməliyyatın (hadisənin) tarixi. Əməkhaqqı bu tarixə görə bonusları dövrə daxil edir.</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_DocumentDate), ResourceType = typeof(Resources))]
        [Column(TypeName = "date")]
        public DateTime DocumentDate { get; set; } = DateTime.Today;

        /// <summary>Bonusun aid olduğu dövr (il).</summary>
        public int PeriodYear { get; set; }

        /// <summary>Bonusun aid olduğu dövr nömrəsi (aylıq: 1-12, rüblük: 1-4, illik: 1).</summary>
        public int PeriodNo { get; set; }

        /// <summary>Bonusun hesablandığı baza (xalis satış, mənfəət, say və ya yığılan məbləğ).</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_BaseAmount), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BaseAmount { get; set; }

        /// <summary>Tətbiq olunan effektiv dərəcə (faiz və ya vahid başına məbləğ).</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_Rate), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(9,4)")]
        public decimal Rate { get; set; }

        /// <summary>Bonus məbləği (+ qazanc, - ləğv). Yerli valyutada.</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_Amount), ResourceType = typeof(Resources))]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Display(Name = nameof(Resources.Entity_Currency_Code), ResourceType = typeof(Resources))]
        [StringLength(10)]
        public string CurrencyCode { get; set; } = Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";

        [ForeignKey(nameof(TrInvoiceHeader))]
        public Guid? InvoiceHeaderId { get; set; }

        /// <summary>Faktura nömrəsinin mətn surəti (faktura silinsə belə audit üçün qalır).</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_InvoiceDocumentNumber), ResourceType = typeof(Resources))]
        [StringLength(30)]
        public string? InvoiceDocumentNumber { get; set; }

        [ForeignKey(nameof(TrPaymentHeader))]
        public Guid? PaymentHeaderId { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_PaymentDocumentNumber), ResourceType = typeof(Resources))]
        [StringLength(30)]
        public string? PaymentDocumentNumber { get; set; }

        /// <summary>Əlaqəli əməliyyat (məs. ləğvin aid olduğu əvvəlki qazanc).</summary>
        [ForeignKey(nameof(RelatedTxn))]
        public Guid? RelatedTxnId { get; set; }

        /// <summary>Bonusun daxil edildiyi əməkhaqqı sənədi. Boşdursa hələ ödənilməyib.</summary>
        [ForeignKey(nameof(TrPayrollHeader))]
        public Guid? PayrollHeaderId { get; set; }

        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_Note), ResourceType = typeof(Resources))]
        [StringLength(250)]
        public string? Note { get; set; }

        /// <summary>Hesablamanın tam izahı (JSON): baza, dərəcə, sətirlər, intervallar, ödəniş nisbəti və s.</summary>
        [Display(Name = nameof(Resources.Entity_SalesBonusTxn_CalcDetails), ResourceType = typeof(Resources))]
        public string? CalcDetails { get; set; }

        public virtual DcSalesBonusPlan DcSalesBonusPlan { get; set; } = null!;

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual TrSalesBonusAssignment? TrSalesBonusAssignment { get; set; }

        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual TrInvoiceHeader? TrInvoiceHeader { get; set; }

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual TrPaymentHeader? TrPaymentHeader { get; set; }

        public virtual TrSalesBonusTxn? RelatedTxn { get; set; }

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual TrPayrollHeader? TrPayrollHeader { get; set; }
    }
}
