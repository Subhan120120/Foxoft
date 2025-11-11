using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProcessPriceType), ResourceType = typeof(Resources))]
    public partial class TrProcessPriceType : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ProcessPriceType_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [ForeignKey(nameof(DcProcess))]
        [Display(Name = nameof(Resources.Entity_ProcessPriceType_ProcessCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string ProcessCode { get; set; }

        [ForeignKey(nameof(DcPriceType))]
        [Display(Name = nameof(Resources.Entity_ProcessPriceType_PriceTypeCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string PriceTypeCode { get; set; }

        [ForeignKey(nameof(ProcessCode))]
        public virtual DcProcess DcProcess { get; set; }

        [ForeignKey(nameof(PriceTypeCode))]
        public virtual DcPriceType DcPriceType { get; set; }
    }
}
