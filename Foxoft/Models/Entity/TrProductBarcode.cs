using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProductBarcode), ResourceType = typeof(Resources))]
    public partial class TrProductBarcode : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_ProductBarcode_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductBarcode_Barcode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string Barcode { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductBarcode_ProductCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProduct))]
        public string ProductCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [Display(Name = nameof(Resources.Entity_ProductBarcode_BarcodeTypeCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcBarcodeType))]
        public string BarcodeTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_ProductBarcode_Qty), ResourceType = typeof(Resources))]
        [DefaultValue(1)]
        public decimal Qty { get; set; }

        [ForeignKey(nameof(BarcodeTypeCode))]
        public virtual DcBarcodeType DcBarcodeType { get; set; }

        [ForeignKey(nameof(ProductCode))]
        public virtual DcProduct DcProduct { get; set; }
    }
}
