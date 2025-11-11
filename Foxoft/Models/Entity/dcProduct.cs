using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Index(nameof(ProductTypeCode))]
    [Display(Name = nameof(Resources.Entity_Product), ResourceType = typeof(Resources))]
    public partial class DcProduct : BaseEntity
    {
        public DcProduct()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
            TrStaticPrices = new HashSet<DcProductStaticPrice>();
            TrProductFeatures = new HashSet<TrProductFeature>();
            TrProductDiscounts = new HashSet<TrProductDiscount>();
            TrPriceListLines = new HashSet<TrPriceListLine>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Product_Code), ResourceType = typeof(Resources))]
        [Required(AllowEmptyStrings = false,
                  ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProductCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_Code2), ResourceType = typeof(Resources))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? ProductCode2 { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_Id), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_Desc), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProductDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_Feature), ResourceType = typeof(Resources))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? ProductFeature { get; set; }

        [ForeignKey(nameof(DcProductType))]
        [Display(Name = nameof(Resources.Entity_Product_Type), ResourceType = typeof(Resources))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources),
                             ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        public byte ProductTypeCode { get; set; }

        [ForeignKey(nameof(DcHierarchy))]
        [Display(Name = nameof(Resources.Entity_Product_HierarchyCode), ResourceType = typeof(Resources))]
        public string? HierarchyCode { get; set; }

        [DefaultValue("1")]
        [Display(Name = nameof(Resources.Entity_Product_UsePos), ResourceType = typeof(Resources))]
        public bool UsePos { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_PromotionCode), ResourceType = typeof(Resources))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? PromotionCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_PromotionCode2), ResourceType = typeof(Resources))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? PromotionCode2 { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_Product_TaxRate), ResourceType = typeof(Resources))]
        public double TaxRate { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_Product_PosDiscount), ResourceType = typeof(Resources))]
        public double PosDiscount { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        //const string qiymetler = "Qiymətlər";
        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_Product_PurchasePrice), ResourceType = typeof(Resources), GroupName = nameof(Resources.Entity_Product_Prices), Order = 0)]
        public decimal PurchasePrice { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_Product_WholesalePrice), ResourceType = typeof(Resources), GroupName = nameof(Resources.Entity_Product_Prices), Order = 1)]
        public decimal WholesalePrice { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_Product_RetailPrice), ResourceType = typeof(Resources), GroupName = nameof(Resources.Entity_Product_Prices), Order = 2)]
        public decimal RetailPrice { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_Product_UseInternet), ResourceType = typeof(Resources))]
        public bool UseInternet { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_ImagePath), ResourceType = typeof(Resources))]
        [StringLength(300, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? ImagePath { get; set; }

        [ForeignKey(nameof(DcUnitOfMeasure))]
        [Display(Name = nameof(Resources.Entity_Product_DefaultUnitOfMeasureId), ResourceType = typeof(Resources))]
        public int DefaultUnitOfMeasureId { get; set; }

        [Display(Name = nameof(Resources.Entity_Product_BalanceWarningLevel), ResourceType = typeof(Resources))]
        public decimal BalanceWarningLevel { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Common_Balance), ResourceType = typeof(Resources))]
        public decimal Balance { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_Product_ProductCost), ResourceType = typeof(Resources))]
        public decimal? ProductCost { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_Product_LastSalePrice), ResourceType = typeof(Resources))]
        public decimal? LastSalePrice { get; set; }

        public virtual DcProductType DcProductType { get; set; }
        public virtual SiteProduct SiteProduct { get; set; }
        public virtual DcUnitOfMeasure DcUnitOfMeasure { get; set; }
        public virtual DcProductScale DcProductScale { get; set; }
        public virtual DcHierarchy DcHierarchy { get; set; }
        public virtual ProductBalance ProductBalance { get; set; }
        public virtual ICollection<DcSerialNumber> DcSerialNumbers { get; set; }
        public virtual ICollection<DcProductStaticPrice> TrStaticPrices { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrProductFeature> TrProductFeatures { get; set; }
        public virtual ICollection<TrProductDiscount> TrProductDiscounts { get; set; }
        public virtual ICollection<TrPriceListLine> TrPriceListLines { get; set; }
        public virtual ICollection<TrProductBarcode> TrProductBarcodes { get; set; }
    }
}
