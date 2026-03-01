using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    [Microsoft.EntityFrameworkCore.Index(nameof(DocumentNumber), nameof(ProcessCode), nameof(CurrAccCode))]
    [Display(Name = nameof(Resources.Entity_InvoiceHeader), ResourceType = typeof(Resources))]
    public partial class TrInvoiceHeader : BaseEntity
    {
        public TrInvoiceHeader()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
            TrPaymentHeaders = new HashSet<TrPaymentHeader>();
            InverseRelatedHeaders = new HashSet<TrInvoiceHeader>();
            TrLoyaltyTxns = new HashSet<TrLoyaltyTxn>();
        }

        [Key]
        public Guid InvoiceHeaderId { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_RelatedInvoiceId), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(RelatedHeader))]
        public Guid? RelatedInvoiceId { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_ProcessCode), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcProcess))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources),
                         ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string ProcessCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_DocumentNumber), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string DocumentNumber { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_IsReturn), ResourceType = typeof(Resources))]
        public bool IsReturn { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_DocumentDate), ResourceType = typeof(Resources))]
        public DateTime DocumentDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_DocumentTime), ResourceType = typeof(Resources))]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan DocumentTime { get; set; }

        [Column(TypeName = "date")]
        [DefaultValue("getdate()")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_OperationDate), ResourceType = typeof(Resources))]
        public DateTime OperationDate { get; set; }

        [Column(TypeName = "time(0)")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_OperationTime), ResourceType = typeof(Resources))]
        [DefaultValue("convert(varchar(10), GETDATE(), 108)")]
        public TimeSpan OperationTime { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_Description), ResourceType = typeof(Resources))]
        [StringLength(200, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? Description { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_Code), ResourceType = typeof(Resources))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        [ForeignKey(nameof(DcCurrAcc))]
        public string? CurrAccCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_OfficeCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string OfficeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_StoreCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                           ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string StoreCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_WarehouseCode), ResourceType = typeof(Resources))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string WarehouseCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_ToWarehouseCode), ResourceType = typeof(Resources))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? ToWarehouseCode { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_CustomsDocumentNumber), ResourceType = typeof(Resources))]
        [StringLength(30, ErrorMessageResourceType = typeof(Resources),
                          ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? CustomsDocumentNumber { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_TerminalId), ResourceType = typeof(Resources))]
        public int? TerminalId { get; set; }

        [ForeignKey(nameof(DcLoyaltyCard))]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_LoyaltyCardId), ResourceType = typeof(Resources))]
        public Guid? LoyaltyCardId { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_IsSuspended), ResourceType = typeof(Resources))]
        public bool IsSuspended { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_IsSent), ResourceType = typeof(Resources))]
        public bool IsSent { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_IsOpen), ResourceType = typeof(Resources))]
        public bool IsOpen { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_IsCompleted), ResourceType = typeof(Resources))]
        public bool IsCompleted { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_PrintCount), ResourceType = typeof(Resources))]
        public byte PrintCount { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_FiscalPrintedState), ResourceType = typeof(Resources))]
        public byte FiscalPrintedState { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_IsSalesViaInternet), ResourceType = typeof(Resources))]
        public bool IsSalesViaInternet { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_IsLocked), ResourceType = typeof(Resources))]
        public bool IsLocked { get; set; }

        [Display(Name = nameof(Resources.Entity_InvoiceHeader_IsMainTF), ResourceType = typeof(Resources))]
        public bool IsMainTF { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_CurrAccDesc), ResourceType = typeof(Resources))]
        public string CurrAccDesc { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Entity_InvoiceHeader_TotalNetAmount), ResourceType = typeof(Resources))]
        public decimal TotalNetAmount { get; set; }

        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcProcess DcProcess { get; set; }
        public virtual DcLoyaltyCard DcLoyaltyCard { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
        public virtual TrInstallment TrInstallment { get; set; }

        public virtual TrInvoiceHeader RelatedHeader { get; set; } // Navigation property to the related line
        public virtual ICollection<TrInvoiceHeader> InverseRelatedHeaders { get; set; } // Navigation property for the inverse relationship

        public virtual ICollection<TrLoyaltyTxn> TrLoyaltyTxns { get; set; }
    }
}
