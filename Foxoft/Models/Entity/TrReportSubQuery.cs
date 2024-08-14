using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Hesabat Alt Sorğusu")]
    public partial class TrReportSubQuery
    {
        public TrReportSubQuery()
        {
            TrReportSubQueryRelationColumns = new HashSet<TrReportSubQueryRelationColumn>();
        }

        [Key]
        [Display(Name = "Sorğu Kodu")]
        public int SubQueryId { get; set; }

        [ForeignKey("DcReport")]
        [Display(Name = "Hesabat Id")]
        public int ReportId { get; set; }

        [Display(Name = "Sorğu Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string SubQueryName { get; set; }

        [Display(Name = "Sorğu Mətni")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string SubQueryText { get; set; }

        public virtual DcReport DcReport { get; set; }
        public virtual ICollection<TrReportSubQueryRelationColumn> TrReportSubQueryRelationColumns { get; set; }
    }
}