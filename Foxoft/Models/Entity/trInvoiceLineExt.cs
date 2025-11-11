using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_InvoiceLineExt), ResourceType = typeof(Resources))]
    public partial class trInvoiceLineExt : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_InvoiceLineExt_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [ForeignKey(nameof(TrInvoiceLine))]
        public Guid InvoiceLineId { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLineExt_PriceDiscounted), ResourceType = typeof(Resources))]
        [Column(TypeName = "money")]
        public decimal PriceDiscounted { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLineExt_PriceDiscountedLoc), ResourceType = typeof(Resources))]
        [Column(TypeName = "money")]
        public decimal PriceDiscountedLoc { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceLineExt_LineExpences), ResourceType = typeof(Resources))]
        [Column(TypeName = "money")]
        public decimal? LineExpences { get; set; }

        public virtual TrInvoiceLine TrInvoiceLine { get; set; }
    }
}
