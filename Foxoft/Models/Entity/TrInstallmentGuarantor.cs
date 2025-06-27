using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Kredit Zamini")]
    public partial class TrInstallmentGuarantor : BaseEntity
    {
        [Key]
        [Display(Name = "Kredit Zamini Id")]
        public int InstallmentGuarantorId { get; set; }

        [ForeignKey("DcCurrAcc")]
        [Display(Name = "Cari Hesab")]
        public string CurrAccCode { get; set; }

        [Display(Name = "Kredit Id")]
        [ForeignKey("TrInstallment")]
        public int InstallmentId { get; set; }


        public virtual DcCurrAcc DcCurrAcc { get; set; }

        public virtual TrInstallment TrInstallment { get; set; }
    }
}
