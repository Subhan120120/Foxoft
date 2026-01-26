using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;
using Foxoft.Models.Entity.Report;
using Foxoft.Models.Entity.RoleClaim;

namespace Foxoft.Models
{
    [Display(Name = nameof(Resources.Entity_CurrAcc), ResourceType = typeof(Resources))]
    public partial class DcCurrAcc : BaseEntity
    {
        public DcCurrAcc()
        {
            TrInvoiceHeaders = new HashSet<TrInvoiceHeader>();
            TrPaymentHeaders = new HashSet<TrPaymentHeader>();
            ToCashRegTrPaymentHeaders = new HashSet<TrPaymentHeader>();
            DcStoreTrPaymentHeaders = new HashSet<TrPaymentHeader>();
            TrPaymentLines = new HashSet<TrPaymentLine>();
            TrReportCustomizations = new HashSet<TrReportCustomization>();
            TrCurrAccFeatures = new HashSet<TrCurrAccFeature>();
            DcCurrAccContactDetails = new HashSet<DcCurrAccContactDetail>();
            TrInstallmentGuarantors = new HashSet<TrInstallmentGuarantor>(); 
            TrEmployeePositions = new HashSet<TrEmployeePosition>();
            TrEmployeeContracts = new HashSet<TrEmployeeContract>();
            TrAttendances = new HashSet<TrAttendance>();
            TrPayrollHeaders = new HashSet<TrPayrollHeader>();
        }

        [Key]
        [StringLength(30)]
        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_Code), ResourceType = typeof(Resources))]
        public string CurrAccCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_Desc), ResourceType = typeof(Resources))]
        [StringLength(60,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? CurrAccDesc { get; set; }

        [ForeignKey(nameof(DcCurrAccType))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_Type), ResourceType = typeof(Resources))]
        [Range(1, int.MaxValue,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Range_Min))]
        public byte CurrAccTypeCode { get; set; }

        // Reuse existing "Company" label from Resources (already added previously)
        [Display(Name = nameof(Resources.Entity_Company), ResourceType = typeof(Resources))]
        public string? CompanyCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_Office), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(5,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string OfficeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_StoreCode), ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Required))]
        [StringLength(30,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string StoreCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_FirstName), ResourceType = typeof(Resources))]
        [StringLength(60,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? FirstName { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_LastName), ResourceType = typeof(Resources))]
        [StringLength(60,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? LastName { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_FatherName), ResourceType = typeof(Resources))]
        [StringLength(60,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? FatherName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(Resources.Entity_CurrAcc_NewPassword), ResourceType = typeof(Resources))]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword),
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_Compare_Mismatch))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_ConfirmPassword), ResourceType = typeof(Resources))]
        public string? ConfirmPassword { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_IdentityNum), ResourceType = typeof(Resources))]
        [StringLength(20,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? IdentityNum { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_TaxNum), ResourceType = typeof(Resources))]
        [StringLength(20,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? TaxNum { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_Language), ResourceType = typeof(Resources))]
        [ForeignKey(nameof(DcUILanguage))]
        public string? LanguageCode { get; set; }

        [DefaultValue("0")]
        [Column(TypeName = "money")]
        [Display(Name = nameof(Resources.Entity_CurrAcc_CreditLimit), ResourceType = typeof(Resources))]
        public decimal CreditLimit { get; set; }

        [Column("IsVIP")]
        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_CurrAcc_VIP), ResourceType = typeof(Resources))]
        public bool IsVip { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_CustomerType), ResourceType = typeof(Resources))]
        public byte? CustomerTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_VendorType), ResourceType = typeof(Resources))]
        public byte? VendorTypeCode { get; set; }

        [ForeignKey(nameof(DcPersonalType))]
        [Display(Name = nameof(Resources.Entity_CurrAcc_PersonalType), ResourceType = typeof(Resources))]
        public byte? PersonalTypeCode { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_CashRegPaymentType), ResourceType = typeof(Resources))]
        public byte? CashRegPaymentTypeCode { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Entity_CurrAcc_CustomerPosDiscountRate), ResourceType = typeof(Resources))]
        public double CustomerPosDiscountRate { get; set; }

        [DefaultValue("0")]
        [Display(Name = nameof(Resources.Common_IsDisabled), ResourceType = typeof(Resources))]
        public bool IsDisabled { get; set; }

        [Display(Name = nameof(Resources.Common_RowGuid), ResourceType = typeof(Resources))]
        public Guid? RowGuid { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_BonusCardNum), ResourceType = typeof(Resources))]
        [StringLength(50,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? BonusCardNum { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_Address), ResourceType = typeof(Resources))]
        [StringLength(150,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? Address { get; set; }

        [Display(Name = nameof(Resources.Common_Phone), ResourceType = typeof(Resources))]
        [DataType(DataType.PhoneNumber)]
        [StringLength(150,
            ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = nameof(Resources.Validation_StringLength_Max))]
        public string? PhoneNum { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_BirthDate), ResourceType = typeof(Resources))]
        [Column(TypeName = "date")]
        [DefaultValue("'1901-01-01'")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = nameof(Resources.Entity_CurrAcc_IsDefault), ResourceType = typeof(Resources))]
        public bool IsDefault { get; set; }

        [Display(Name = nameof(Resources.Common_Theme), ResourceType = typeof(Resources))]
        public string? Theme { get; set; }

        [NotMapped]
        [Display(Name = nameof(Resources.Common_Balance), ResourceType = typeof(Resources))]
        public decimal Balance { get; set; }

        [Required]
        public Gender Gender { get; set; } = Gender.Unknown;

        [Required]
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.Unknown;


        public virtual ICollection<TrEmployeePosition> TrEmployeePositions { get; set; }
        public virtual ICollection<TrEmployeeContract> TrEmployeeContracts { get; set; }
        public virtual ICollection<TrAttendance> TrAttendances { get; set; }

        public virtual ICollection<TrPayrollHeader> TrPayrollHeaders { get; set; }
        public virtual DcCurrAccType DcCurrAccType { get; set; }
        public virtual DcUILanguage DcUILanguage { get; set; }
        public virtual DcPersonalType DcPersonalType { get; set; }
        [ForeignKey(nameof(CashRegPaymentTypeCode))]
        public virtual DcPaymentType DcPaymentType { get; set; }
        public virtual TrSession TrSession { get; set; }
        public virtual SettingStore SettingStore { get; set; }
        public virtual ICollection<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
        public virtual ICollection<TrPaymentHeader> DcStoreTrPaymentHeaders { get; set; }
        public virtual ICollection<TrPaymentHeader> ToCashRegTrPaymentHeaders { get; set; }
        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; } // as Cash register
        public virtual ICollection<TrCurrAccRole> TrCurrAccRoles { get; set; }
        public virtual ICollection<DcPaymentMethod> CashRegDcPaymentMethods { get; set; }
        public virtual ICollection<DcPaymentMethod> CurrAccDcPaymentMethods { get; set; }
        public virtual ICollection<TrReportCustomization> TrReportCustomizations { get; set; }
        public virtual ICollection<TrCurrAccFeature> TrCurrAccFeatures { get; set; }
        public virtual ICollection<DcCurrAccContactDetail> DcCurrAccContactDetails { get; set; }
        public virtual ICollection<TrInstallmentGuarantor> TrInstallmentGuarantors { get; set; }
    }
}
