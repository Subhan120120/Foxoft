using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAccContactDetail), ResourceType = typeof(Resources))]
    public partial class DcCurrAccContactDetail
    {
        public DcCurrAccContactDetail() { }

        [Key]
        [Display(Name = nameof(Resources.Entity_CurrAccContactDetail_Id), ResourceType = typeof(Resources))]
        public int Id { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccContactDetail_Desc), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        public string ContactDesc { get; set; }

        [Display(Name = nameof(Resources.Entity_ContactType), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [ForeignKey(nameof(DcContactType))]
        public byte ContactTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_Code), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [ForeignKey(nameof(DcCurrAcc))]
        public string CurrAccCode { get; set; }

        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcContactType DcContactType { get; set; }
    }
}
