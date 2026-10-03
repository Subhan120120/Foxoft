using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAccRelation), ResourceType = typeof(Resources))]
    public partial class TrCurrAccRelation : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = nameof(Resources.Entity_CurrAccRelation_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [ForeignKey(nameof(DcCurrAcc))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_Code), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(RelatedDcCurrAcc))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = nameof(Resources.Entity_CurrAccRelation_RelatedCurrAccCode), ResourceType = typeof(Resources))]
        public string RelatedCurrAccCode { get; set; } = null!;

        [ForeignKey(nameof(DcCurrAccRelationType))]
        [Display(Name = nameof(Resources.Entity_CurrAccRelation_RelationType), ResourceType = typeof(Resources))]
        public int? RelationTypeId { get; set; }

        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = nameof(Resources.Entity_CurrAccRelation_Note), ResourceType = typeof(Resources))]
        public string? Note { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual DcCurrAcc DcCurrAcc { get; set; } = null!;

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual DcCurrAcc RelatedDcCurrAcc { get; set; } = null!;

        [DeleteBehavior(DeleteBehavior.SetNull)]
        public virtual DcCurrAccRelationType? DcCurrAccRelationType { get; set; }
    }
}
