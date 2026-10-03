using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAccRelationType), ResourceType = typeof(Resources))]
    public partial class DcCurrAccRelationType
    {
        public DcCurrAccRelationType()
        {
            TrCurrAccRelations = new HashSet<TrCurrAccRelation>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_CurrAccRelationType_Id), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelationTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccRelationType_Name), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string RelationTypeName { get; set; } = null!;

        public virtual ICollection<TrCurrAccRelation> TrCurrAccRelations { get; set; }
    }
}
