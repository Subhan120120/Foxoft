using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class TrProductHierarchy
    {
        public TrProductHierarchy()
        {
        }

        [Key, Column(Order = 0)]
        [Display(Name = "İyerarxiya Kodu")]
        [ForeignKey("DcHierarchy")]
        public string HierarchyCode { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Məhsul Kodu")]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }



        [ForeignKey("HierarchyCode")]
        public virtual DcHierarchy DcHierarchy { get; set; }

        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct { get; set; }
    }
}
