using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_InvoiceLineFeatureLink), ResourceType = typeof(Resources))]
    public partial class TrInvoiceLineFeature
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(TrInvoiceLine))]
        [Display(Name = nameof(Resources.Entity_InvoiceLine), ResourceType = typeof(Resources))]
        public Guid InvoiceLineId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(DcInvoiceLineFeatureType))]
        [Display(Name = nameof(Resources.Entity_InvoiceLineFeatureType_Id), ResourceType = typeof(Resources))]
        public int InvoiceLineFeatureTypeId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey(nameof(DcInvoiceLineFeature))]
        [Display(Name = nameof(Resources.Entity_InvoiceLineFeature_Code), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string InvoiceLineFeatureCode { get; set; }

        [Display(Name = nameof(Resources.Common_Identity), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdentityColumn { get; set; }

        [ForeignKey(nameof(InvoiceLineId))]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public virtual TrInvoiceLine TrInvoiceLine { get; set; }
        [ForeignKey(nameof(InvoiceLineFeatureTypeId))]
        public virtual DcInvoiceLineFeatureType DcInvoiceLineFeatureType { get; set; }
        [ForeignKey(nameof(InvoiceLineFeatureCode))]
        public virtual DcInvoiceLineFeature DcInvoiceLineFeature { get; set; }
    }
}
