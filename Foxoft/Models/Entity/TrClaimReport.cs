using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public partial class TrClaimReport : BaseEntity
    {
        [Key]
        public int ClaimReportId { get; set; }

        [Required]
        [ForeignKey("DcClaim")]
        public string ClaimCode { get; set; }

        [Required]
        [ForeignKey("DcReport")]
        public int ReportId { get; set; }


        public virtual DcReport DcReport { get; set; }
        public virtual DcClaim DcClaim { get; set; }
    }
}
