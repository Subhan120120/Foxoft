using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_InstallmentGuarantor), ResourceType = typeof(Resources))]
    public partial class TrInstallmentGuarantor : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_InstallmentGuarantor_Id), ResourceType = typeof(Resources))]
        public int InstallmentGuarantorId { get; set; }

        [ForeignKey(nameof(DcCurrAcc))]
        [Display(Name = nameof(Resources.Entity_InstallmentGuarantor_CurrAccCode), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InstallmentGuarantor_InstallmentId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(TrInstallment))]
        public int InstallmentId { get; set; }

        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual TrInstallment TrInstallment { get; set; }
    }
}
