using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    /// <summary>
    /// EF Entity-lərində olmayan, xüsusi SQL sorğularında və hesabatlarda
    /// hesablanan sahələrin lokalizasiya atributları kataloqu.
    /// </summary>
    public class ReportCustomColumns
    {
        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_GrossProfit))]
        public decimal GrossProfit { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_NetProfit))]
        public decimal NetProfit { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_Sales))]
        public decimal Sales { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_Cost))]
        public decimal Cost { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_Expense))]
        public decimal Expense { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_Increase))]
        public decimal Increase { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_WriteOff))]
        public decimal WriteOff { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_Balance))]
        public decimal Balance { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_Total))]
        public decimal Total { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_Total))]
        public decimal Toplam { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_RemainingAmount))]
        public decimal RemainingAmount { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_MonthlyPayment))]
        public decimal MonthlyPayment { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_DueAmount))]
        public decimal DueAmount { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_OverDueDays))]
        public int OverDueDays { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_InstallmentAmount))]
        public decimal InstallmentAmount { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_InstallmentPaid))]
        public decimal InstallmentPaid { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_DownPayment))]
        public decimal DownPayment { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_PassedMonth))]
        public int PassedMonth { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_PaidMonth))]
        public int PaidMonth { get; set; }

        [Display(ResourceType = typeof(Resources), Name = nameof(Resources.Common_InstallmentStatus))]
        public int InstallmentStatus { get; set; }
    }
}
