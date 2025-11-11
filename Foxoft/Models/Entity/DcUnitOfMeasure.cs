using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_UnitOfMeasure), ResourceType = typeof(Resources))]
    public partial class DcUnitOfMeasure
    {
        public DcUnitOfMeasure()
        {
            DcProducts = new HashSet<DcProduct>();
            SettingStores = new HashSet<SettingStore>();
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_UnitOfMeasure_Id), ResourceType = typeof(Resources))]
        public int UnitOfMeasureId { get; set; }

        [Display(Name = nameof(Resources.Entity_UnitOfMeasure_Desc), ResourceType = typeof(Resources))]
        [StringLength(25, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string UnitOfMeasureDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_UnitOfMeasure_ParentId), ResourceType = typeof(Resources))]
        public int? ParentUnitOfMeasureId { get; set; }

        [Display(Name = nameof(Resources.Entity_UnitOfMeasure_ConversionRate), ResourceType = typeof(Resources))]
        public decimal ConversionRate { get; set; }

        [Display(Name = nameof(Resources.Entity_UnitOfMeasure_Level), ResourceType = typeof(Resources))]
        public byte Level { get; set; }

        [Display(Name = nameof(Resources.Entity_UnitOfMeasure_IsBasic), ResourceType = typeof(Resources))]
        public bool IsBasic { get; set; }

        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        public virtual AppSetting AppSetting { get; set; }
        public virtual ICollection<DcProduct> DcProducts { get; set; }
        public virtual ICollection<SettingStore> SettingStores { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }

        [ForeignKey(nameof(ParentUnitOfMeasureId))]
        public virtual DcUnitOfMeasure ParentUnitOfMeasure { get; set; }
        public virtual ICollection<DcUnitOfMeasure> ChildUnitOfMeasures { get; set; }
    }
}
