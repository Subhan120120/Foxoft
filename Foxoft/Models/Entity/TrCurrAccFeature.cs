using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAccFeatureLink), ResourceType = typeof(Resources))]
    public partial class TrCurrAccFeature
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(DcCurrAcc))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_Code), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(DcCurrAccFeatureType))]
        [Display(Name = nameof(Resources.Entity_CurrAccFeatureType_Id), ResourceType = typeof(Resources))]
        public int CurrAccFeatureTypeId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey(nameof(DcCurrAccFeature))]
        [Display(Name = nameof(Resources.Entity_CurrAccFeature_Code), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string CurrAccFeatureCode { get; set; }

        [Display(Name = nameof(Resources.Common_Identity), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdentityColumn { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc DcCurrAcc { get; set; }
        [ForeignKey(nameof(CurrAccFeatureTypeId))]
        public virtual DcCurrAccFeatureType DcCurrAccFeatureType { get; set; }
        [ForeignKey(nameof(CurrAccFeatureCode))]
        public virtual DcCurrAccFeature DcCurrAccFeature { get; set; }
    }
}
