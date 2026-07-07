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
        [Column(TypeName = "tinyint")]
        public ContactType ContactTypeId { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_Code), ResourceType = typeof(Resources))]
        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required)
        )]
        [ForeignKey(nameof(DcCurrAcc))]
        public string CurrAccCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccContactDetail_SendWhatsapp), ResourceType = typeof(Resources))]
        public bool SendWhatsapp { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAccContactDetail_WhatsAppGroupJid), ResourceType = typeof(Resources))]
        [StringLength(100,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max)
        )]
        public string? WhatsAppGroupJid { get; set; }

        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcContactType DcContactType { get; set; }
    }
}
