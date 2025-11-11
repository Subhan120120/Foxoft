using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_PaymentHeader), ResourceType = typeof(Resources))]
    public partial class TrPaymentHeader : BaseEntity
    {
        public TrPaymentHeader() { TrPaymentLines = new HashSet<TrPaymentLine>(); }

        [Key]
        public Guid PaymentHeaderId { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_InvoiceHeaderId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(TrInvoiceHeader))]
        public Guid? InvoiceHeaderId { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_DocumentNumber), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        public string DocumentNumber { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_ProcessCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProcess))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProcessCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_DocumentDate), ResourceType = typeof(Resources))]
        [DefaultValue("getdate()")]
        [Column(TypeName = "date")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_DocumentTime), ResourceType = typeof(Resources))]
        [Column(TypeName = "time(0)")]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan DocumentTime { get; set; }

        [DefaultValue("getdate()")]
        [Column(TypeName = "date")]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_OperationDate), ResourceType = typeof(Resources))]
        public DateTime OperationDate { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_OperationTime), ResourceType = typeof(Resources))]
        [Column(TypeName = "time(0)")]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan OperationTime { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_CurrAccCode), ResourceType = typeof(Resources))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [ForeignKey(nameof(DcCurrAcc))]
        public string? CurrAccCode { get; set; }

        [ForeignKey(nameof(ToCashReg))]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_ToCashRegCode), ResourceType = typeof(Resources))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? ToCashRegCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_FromCashRegCode), ResourceType = typeof(Resources))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? FromCashRegCode { get { return CurrAccCode; } set { CurrAccCode = value; } }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_Description), ResourceType = typeof(Resources))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? Description { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_OperationType), ResourceType = typeof(Resources))]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? OperationType { get; set; }

        [ForeignKey(nameof(DcPaymentKind))]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_PaymentKindId), ResourceType = typeof(Resources))]
        public byte? PaymentKindId { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_CompanyCode), ResourceType = typeof(Resources))]
        public string? CompanyCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_OfficeCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string OfficeCode { get; set; }

        [ForeignKey(nameof(DcStore))]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_StoreCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string StoreCode { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_PosterminalId), ResourceType = typeof(Resources))]
        public short PosterminalId { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_IsCompleted), ResourceType = typeof(Resources))]
        public bool IsCompleted { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_IsSent), ResourceType = typeof(Resources))]
        public bool IsSent { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_IsLocked), ResourceType = typeof(Resources))]
        public bool IsLocked { get; set; }

        [Display(Name = nameof(Resources.Entity_PaymentHeader_IsMainTF), ResourceType = typeof(Resources))]
        public bool IsMainTF { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_CurrAccDesc), ResourceType = typeof(Resources))]
        public string CurrAccDesc { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_PaymentHeader_TotalPayment), ResourceType = typeof(Resources))]
        public decimal TotalPayment { get; set; }

        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcCurrAcc ToCashReg { get; set; }
        public virtual DcCurrAcc DcStore { get; set; }
        public virtual DcProcess DcProcess { get; set; }
        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcPaymentKind DcPaymentKind { get; set; }
        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
    }
}
