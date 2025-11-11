using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PriceListHeader), ResourceType = typeof(Resources))]
    public partial class TrPriceListHeader : BaseEntity
    {
        public TrPriceListHeader() { TrPriceListLines = new HashSet<TrPriceListLine>(); }

        [Key]
        public Guid PriceListHeaderId { get; set; }

        [Display(Name = nameof(Resources.Entity_PriceListHeader_DocumentNumber), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string DocumentNumber { get; set; }

        [ForeignKey(nameof(DcPriceListType))]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_PriceTypeCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string PriceTypeCode { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_DocumentDate), ResourceType = typeof(Resources))]
        public DateTime DocumentDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_DocumentTime), ResourceType = typeof(Resources))]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan DocumentTime { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_OperationDate), ResourceType = typeof(Resources))]
        public DateTime OperationDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_OperationTime), ResourceType = typeof(Resources))]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan OperationTime { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_DueDate), ResourceType = typeof(Resources))]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_DueTime), ResourceType = typeof(Resources))]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan DueTime { get; set; }

        [Display(Name = nameof(Resources.Entity_PriceListHeader_Description), ResourceType = typeof(Resources))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string Description { get; set; }

        [Display(Name = nameof(Resources.Entity_PriceListHeader_OfficeCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string OfficeCode { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_IsTexIncluded), ResourceType = typeof(Resources))]
        public bool IsTexIncluded { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_PriceListHeader_IsConfirmed), ResourceType = typeof(Resources))]
        public bool IsConfirmed { get; set; }

        public virtual ICollection<TrPriceListLine> TrPriceListLines { get; set; }
        public virtual DcPriceType DcPriceListType { get; set; }
    }
}
