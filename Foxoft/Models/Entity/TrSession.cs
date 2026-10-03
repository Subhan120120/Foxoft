using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_Session), ResourceType = typeof(Resources))]
    public partial class TrSession : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_Session_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = nameof(Resources.Entity_User_UserName), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; }

        [NotMapped]
        public string UserName
        {
            get => CurrAccCode;
            set => CurrAccCode = value;
        }

        [Display(Name = nameof(Resources.Entity_Session_PID), ResourceType = typeof(Resources))]
        [Range(1, int.MaxValue,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        public int PID { get; set; }

        [DefaultValueSql("0")]
        [Display(Name = nameof(Resources.Entity_Session_IsBlocked), ResourceType = typeof(Resources))]
        public bool IsBlocked { get; set; }
    }
}
