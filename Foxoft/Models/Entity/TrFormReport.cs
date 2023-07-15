using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class TrFormReport
    {
        [Key, Column(Order = 0)]
        [ForeignKey("DcForm")]
        [Display(Name = "Form Kodu")]
        public string FormCode { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("DcReport")]
        [Display(Name = "Report Id")]
        public int ReportId { get; set; }


        [ForeignKey("FormCode")]
        public virtual DcForm DcForm { get; set; }

        [ForeignKey("ReportId")]
        public virtual DcReport DcReport { get; set; }
        
    }
}
