using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Installment), ResourceType = typeof(Resources))]
    public partial class TrInstallment
    {
        public TrInstallment() { TrInstallmentGuarantors = new HashSet<TrInstallmentGuarantor>(); }

        [Key]
        [Display(Name = nameof(Resources.Entity_Installment_Id), ResourceType = typeof(Resources))]
        public int InstallmentId { get; set; }

        [ForeignKey(nameof(TrInvoiceHeader))]
        [Display(Name = nameof(Resources.Entity_Installment_InvoiceHeaderId), ResourceType = typeof(Resources))]
        public Guid InvoiceHeaderId { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = nameof(Resources.Entity_Installment_Date), ResourceType = typeof(Resources))]
        public DateTime InstallmentDate { get; set; }

        [Display(Name = nameof(Resources.Entity_Installment_PlanCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcInstallmentPlan))]
        public string InstallmentPlanCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Installment_Commission), ResourceType = typeof(Resources))]
        public decimal Commission { get; set; }

        [Display(Name = nameof(Resources.Entity_Installment_InterestRate), ResourceType = typeof(Resources))]
        [Range(0, 100,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        public float InterestRate { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_Installment_TotalPaid), ResourceType = typeof(Resources))]
        public decimal TotalPaid { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_Installment_RemainingBalance), ResourceType = typeof(Resources))]
        public decimal RemainingBalance { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_Installment_MonthlyPayment), ResourceType = typeof(Resources))]
        public decimal MonthlyPayment { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_Installment_DueAmount), ResourceType = typeof(Resources))]
        public decimal DueAmount { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_Installment_OverdueDays), ResourceType = typeof(Resources))]
        public int OverdueDays { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_Installment_OverdueDate), ResourceType = typeof(Resources))]
        public DateTime? OverdueDate { get; set; }

        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcInstallmentPlan DcInstallmentPlan { get; set; }
        public virtual ICollection<TrInstallmentGuarantor> TrInstallmentGuarantors { get; set; }
    }
}
