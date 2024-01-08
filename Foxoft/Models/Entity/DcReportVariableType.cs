using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public partial class DcReportVariableType
    {
        public DcReportVariableType()
        {
            DcReportVariables = new HashSet<DcReportVariable>();
        }

        [Key]
        [Display(Name = "Dəyişən Tip Id")]
        public byte VariableTypeId { get; set; }

        [Display(Name = "Dəyişən Tipi Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string VariableTypeDesc { get; set; }


        public virtual ICollection<DcReportVariable> DcReportVariables { get; set; }
    }
}
