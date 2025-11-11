using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProductUnitOfMeasure), ResourceType = typeof(Resources))]
    public partial class TrProductUnitOfMeasure
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ProductUnitOfMeasure_Id), ResourceType = typeof(Resources))]
        public int ProductUnitOfMeasureId { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductUnitOfMeasure_ProductCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProduct))]
        public string ProductCode { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductUnitOfMeasure_UnitOfMeasureId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcUnitOfMeasure))]
        public int UnitOfMeasureId { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductUnitOfMeasure_ConversionRate), ResourceType = typeof(Resources))]
        public decimal ConversionRate { get; set; }
    }
}
