using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foxoft.Models.Entity.Report;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Form), ResourceType = typeof(Resources))]
    public partial class DcForm
    {
        public DcForm()
        {
            TrFormReports = new HashSet<TrFormReport>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Form_Code), ResourceType = typeof(Resources))]
        public string FormCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Form_Desc), ResourceType = typeof(Resources))]
        public string? FormDesc { get; set; }

        public virtual ICollection<TrFormReport> TrFormReports { get; set; }
    }
}
