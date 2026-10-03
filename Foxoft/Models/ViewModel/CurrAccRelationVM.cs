using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    public class CurrAccRelationVM
    {
        [Display(Name = nameof(Resources.Entity_CurrAccRelation_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccRelation_RelatedCurrAccCode), ResourceType = typeof(Resources))]
        public string RelatedCurrAccCode { get; set; } = string.Empty;

        [Display(Name = nameof(Resources.Entity_CurrAccRelation_RelatedCurrAccDesc), ResourceType = typeof(Resources))]
        public string? RelatedCurrAccDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccRelation_RelationType), ResourceType = typeof(Resources))]
        public string? RelationTypeName { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccRelation_Note), ResourceType = typeof(Resources))]
        public string? Note { get; set; }
    }
}
