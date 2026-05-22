using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_InvoiceLineFeatureType), ResourceType = typeof(Resources))]
    public partial class DcInvoiceLineFeatureType
    {
        public DcInvoiceLineFeatureType()
        {
            TrInvoiceLineFeatures = new HashSet<TrInvoiceLineFeature>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_InvoiceLineFeatureType_Id), ResourceType = typeof(Resources))]
        public int InvoiceLineFeatureTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLineFeatureType_Name), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string FeatureTypeName { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLineFeatureType_Order), ResourceType = typeof(Resources))]
        public int Order { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLineFeatureType_Filterable), ResourceType = typeof(Resources))]
        public bool Filterable { get; set; }

        public virtual ICollection<TrInvoiceLineFeature> TrInvoiceLineFeatures { get; set; }
    }
}
