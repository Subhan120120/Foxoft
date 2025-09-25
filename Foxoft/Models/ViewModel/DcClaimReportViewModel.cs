using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "İyerarxiya Kateqoriyası")]
    public partial class DcClaimReportViewModel : BaseEntity
    {

        [Key]
        [Display(Name = "Kateqoriya Id")]
        public int ReportId { get; set; }

        [Display(Name = "Hesabat Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string ReportName { get; set; }


        [Display(Name = "Role Kodu")]
        public string ClaimCode { get; set; }


        [Display(Name = "Kateqoriya Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string ClaimDesc { get; set; }


        [Display(Name = "Secilendir")]
        public bool? IsSelected { get; set; }


    }
}
