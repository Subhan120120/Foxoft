using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models
{
    [Table("TrUserStores")]
    [Index(nameof(UserName), IsUnique = true)]
    [Display(Name = nameof(Resources.Entity_UserStore), ResourceType = typeof(Resources))]
    public partial class TrUserStore : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserStoreId { get; set; }

        [Display(Name = nameof(Resources.Entity_UserStore_UserName), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string UserName { get; set; } = null!;

        [ForeignKey(nameof(DcStore))]
        [Display(Name = nameof(Resources.Entity_UserStore_StoreCode), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string StoreCode { get; set; } = null!;

        [DeleteBehavior(DeleteBehavior.Cascade)]
        [InverseProperty(nameof(DcCurrAcc.TrUserStores))]
        public virtual DcCurrAcc? DcStore { get; set; }
    }
}
