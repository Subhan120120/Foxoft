using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class DcReportQuery
    {
        public DcReportQuery()
        {

        }

        [Key]
        [Display(Name = "Sorğu Kodu")]
        public int QueryId { get; set; }

        //[ForeignKey("DcReport")]
        [Display(Name = "Hesabat Id")]
        public int ReportId { get; set; }

        [Display(Name = "Sorğu Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string QueryName { get; set; }

        [Display(Name = "Sorğu Mətni")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string QueryText { get; set; }

        //public virtual DcReport DcReport { get; set; }
        public virtual ICollection<DcQueryParam> DcQueryParams { get; set; }
    }
}
