using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public enum CrmActivityStatus : int
    {
        [Description("Planlandı")]
        Planned = 1,

        [Description("Davam edir")]
        InProgress = 2,

        [Description("Tamamlandı")]
        Completed = 3,

        [Description("Ləğv edildi")]
        Cancelled = 4
    }

    public enum CrmActivityPriority : int
    {
        [Description("Aşağı")]
        Low = 1,

        [Description("Orta")]
        Medium = 2,

        [Description("Yüksək")]
        High = 3
    }

    [Index(nameof(ActivityCode), IsUnique = true)]
    [Index(nameof(CurrAccCode), nameof(ActivityDate))]
    [Display(Name = "CRM Aktivliyi")]
    public partial class TrCrmActivity : BaseEntity
    {
        [Key]
        [Display(Name = "Aktivlik Id")]
        public Guid ActivityId { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(20,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = "Aktivlik Kodu")]
        public string ActivityCode { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [ForeignKey(nameof(DcCurrAcc))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_Code), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(5,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_Office), ResourceType = typeof(Resources))]
        public string OfficeCode { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_StoreCode), ResourceType = typeof(Resources))]
        public string StoreCode { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(200,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = "Mövzu")]
        public string Subject { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [ForeignKey(nameof(DcCrmActivityType))]
        [Display(Name = "Aktivlik Növü")]
        public byte ActivityTypeId { get; set; }

        [Column(TypeName = "tinyint")]
        [Display(Name = "Status")]
        public CrmActivityStatus Status { get; set; }

        [Column(TypeName = "tinyint")]
        [Display(Name = "Prioritet")]
        public CrmActivityPriority Priority { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Tarix")]
        public DateTime ActivityDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = "Başlama Saatı")]
        public TimeSpan? StartTime { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = "Bitmə Saatı")]
        public TimeSpan? EndTime { get; set; }

        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = "Təyin edilən")]
        public string? AssignedCurrAccCode { get; set; }

        [StringLength(2000,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = "Açıqlama")]
        public string? Description { get; set; }

        [StringLength(2000,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [Display(Name = "Nəticə")]
        public string? Result { get; set; }

        [Display(Name = "Tamamlanıb")]
        public bool IsCompleted { get; set; }

        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcCrmActivityType DcCrmActivityType { get; set; }
    }
}
