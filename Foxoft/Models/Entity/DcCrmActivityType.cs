using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    [Display(Name = "CRM Aktivlik Növü")]
    public partial class DcCrmActivityType
    {
        public DcCrmActivityType()
        {
            TrCrmActivities = new HashSet<TrCrmActivity>();
        }

        [Key]
        [Display(Name = "Id")]
        public byte ActivityTypeId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Aktivlik Növü")]
        public string ActivityTypeDesc { get; set; }

        [Display(Name = "Deaktivdir")]
        public bool IsDisabled { get; set; }

        public virtual ICollection<TrCrmActivity> TrCrmActivities { get; set; }
    }
}
