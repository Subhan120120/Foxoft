using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class TrReportSubQueryRelationColumn : BaseEntity
    {
        public TrReportSubQueryRelationColumn()
        {
        }

        [Key]
        [Display(Name = "İyerarxiya Kodu")]
        public int Id { get; set; }

        [Display(Name = "MainColumnName")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string ParentColumnName { get; set; }

        [Display(Name = "SubColumnName")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string SubColumnName { get; set; }

        [Display(Name = "Sorğu Kodu")]
        [ForeignKey("TrReportSubQuery")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public int SubQueryId { get; set; }


        public virtual TrReportSubQuery TrReportSubQuery { get; set; }
    }
}
