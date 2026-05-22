using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_InvoiceLineFeature), ResourceType = typeof(Resources))]
    public partial class DcInvoiceLineFeature
    {
        public DcInvoiceLineFeature()
        {
            TrInvoiceLineFeatures = new HashSet<TrInvoiceLineFeature>();
        }

        [Key, Column(Order = 0)]
        [Display(Name = nameof(Resources.Entity_InvoiceLineFeature_Code), ResourceType = typeof(Resources))]
        public string InvoiceLineFeatureCode { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = nameof(Resources.Entity_InvoiceLineFeature_TypeId), ResourceType = typeof(Resources))]
        public int InvoiceLineFeatureTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLineFeature_Desc), ResourceType = typeof(Resources))]
        public string? FeatureDesc { get; set; }

        [ForeignKey(nameof(InvoiceLineFeatureTypeId))]
        public virtual DcInvoiceLineFeatureType DcInvoiceLineFeatureType { get; set; }

        public virtual ICollection<TrInvoiceLineFeature> TrInvoiceLineFeatures { get; set; }
    }
}
