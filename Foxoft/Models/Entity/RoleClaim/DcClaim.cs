using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties; // Resources üçün

namespace Foxoft.Models.Entity.RoleClaim
{
    [Display(Name = nameof(Resources.Entity_Claim), ResourceType = typeof(Resources))]
    public partial class DcClaim
    {
        public DcClaim()
        {
            TrRoleClaims = new HashSet<TrRoleClaim>();
            TrClaimReports = new HashSet<TrClaimReport>();
        }

        [Key]
        [Display(Name = nameof(Resources.Entity_Claim_Code), ResourceType = typeof(Resources))]
        public string ClaimCode { get; set; }

        [Display(Name = nameof(Resources.Entity_Claim_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string ClaimDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_Claim_TypeId), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [ForeignKey(nameof(DcClaimType))]
        public byte ClaimTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_Claim_CategoryId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcClaimCategory))]
        public int CategoryId { get; set; }

        [Display(Name = nameof(Resources.Entity_Claim_Id), ResourceType = typeof(Resources))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual DcClaimType DcClaimType { get; set; }
        public virtual DcClaimCategory DcClaimCategory { get; set; }
        public virtual ICollection<TrRoleClaim> TrRoleClaims { get; set; }
        public virtual ICollection<TrClaimReport> TrClaimReports { get; set; }
    }
}
