using System;
using System.ComponentModel.DataAnnotations;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Warehouse), ResourceType = typeof(Resources))]
    public partial class DcWarehouse : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_Warehouse_Code), ResourceType = typeof(Resources))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string WarehouseCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string WarehouseDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_Type), ResourceType = typeof(Resources))]
        public byte WarehouseTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_OfficeCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string OfficeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_StoreCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string StoreCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_PermitNegativeStock), ResourceType = typeof(Resources))]
        public bool PermitNegativeStock { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_WarnNegativeStock), ResourceType = typeof(Resources))]
        public bool WarnNegativeStock { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_ControlStockLevel), ResourceType = typeof(Resources))]
        public bool ControlStockLevel { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_WarnStockLevelRate), ResourceType = typeof(Resources))]
        public bool WarnStockLevelRate { get; set; }

        [Display(Name = nameof(Resources.Entity_Warehouse_IsDefault), ResourceType = typeof(Resources))]
        public bool IsDefault { get; set; }

        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [Display(Name = nameof(Resources.Common_RowGuid), ResourceType = typeof(Resources))]
        public Guid RowGuid { get; set; }
    }
}
