using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class DcForm
    {
        public DcForm()
        {
            TrFormReports = new HashSet<TrFormReport>();
        }

        [Key]
        [Display(Name = "Form Kodu")]
        public string FormCode { get; set; }

        [Display(Name = "Form Açıqlaması")]
        //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public string? FormDesc { get; set; }


        public virtual ICollection<TrFormReport> TrFormReports { get; set; }
    }
}
