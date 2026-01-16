using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_ProductBarcode), ResourceType = typeof(Resources))]
    public partial class TrBarcodeOperationHeader : BaseEntity
    {
        public TrBarcodeOperationHeader()
        {
            TrBarcodeOperationLines = new BindingList<TrBarcodeOperationLine>();
        }
        [Key]
        [Display(Name = nameof(Resources.Entity_BarcodeOperationHeader_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [Display(Name = nameof(Resources.Entity_BarcodeOperationHeader_Name), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string Name { get; set; }

        public virtual ICollection<TrBarcodeOperationLine> TrBarcodeOperationLines { get; set; }
    }
}
