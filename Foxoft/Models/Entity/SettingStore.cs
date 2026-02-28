using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_StoreSetting), ResourceType = typeof(Resources))]
    public partial class SettingStore
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_StoreSetting_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = nameof(Resources.Entity_StoreSetting_StoreCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcStore))]
        public string StoreCode { get; set; }

        [Display(Name = nameof(Resources.Entity_StoreSetting_DesignFolder), ResourceType = typeof(Resources))]
        public string? DesignFileFolder { get; set; }

        [Display(Name = nameof(Resources.Entity_StoreSetting_ImageFolder), ResourceType = typeof(Resources))]
        public string? ImageFolder { get; set; }

        [Display(Name = nameof(Resources.Entity_StoreSetting_SalesmanContinuity), ResourceType = typeof(Resources))]
        public bool SalesmanContinuity { get; set; }

        [Display(Name = nameof(Resources.Entity_StoreSetting_DefaultUnitOfMeasureId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcUnitOfMeasure))]
        public int DefaultUnitOfMeasureId { get; set; }

        [ForeignKey(nameof(StoreCode))]
        public virtual DcCurrAcc DcStore { get; set; }
        public virtual DcUnitOfMeasure DcUnitOfMeasure { get; set; }
    }
}
