using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    //[Index(nameof(CurrAccTypeCode))]
    public partial class DcCurrAcc : BaseEntity
    {
        public DcCurrAcc()
        {
            TrInvoiceHeaders = new HashSet<TrInvoiceHeader>();
            TrPaymentHeaders = new HashSet<TrPaymentHeader>();
            ToCashRegTrPaymentHeaders = new HashSet<TrPaymentHeader>();
            DcStoreTrPaymentHeaders = new HashSet<TrPaymentHeader>();
            TrPaymentLines = new HashSet<TrPaymentLine>();
            DcPaymentMethods = new HashSet<DcPaymentMethod>();
        }

        [Key]
        [StringLength(30)]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Cari Hesab Kodu")]
        public string CurrAccCode { get; set; }

        [Display(Name = "Cari Hesab Adı")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? CurrAccDesc { get; set; }

        [ForeignKey("DcCurrAccType")]
        [Display(Name = "Cari Hesab Tipi")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} boş buraxila bilmez \n")]
        public byte CurrAccTypeCode { get; set; }

        [Display(Name = "Şirkət")]
        public string? CompanyCode { get; set; }

        [Display(Name = "Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [Display(Name = "Mağaza Kodu")]
        //[ForeignKey("TrPaymentHeadersForStore")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [Display(Name = "Adı")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? FirstName { get; set; }

        [Display(Name = "Soyadı")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? LastName { get; set; }

        [Display(Name = "Ata Adı")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? FatherName { get; set; }

        [DataType(DataType.Password), Display(Name = "Yeni Şifrə")]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password), Compare("NewPassword", ErrorMessage = "Şifrələr biri birinə uyğun deyil"), Display(Name = "Şifrəni Təsdiqlə")]
        public string? ConfirmPassword { get; set; }


        [Display(Name = "Ş.V.Nömrəsi")]
        [StringLength(20, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? IdentityNum { get; set; }

        [Display(Name = "Vergi Nömrəsi")]
        [StringLength(20, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? TaxNum { get; set; }

        [Display(Name = "İstifadəçi Dili")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? DataLanguageCode { get; set; }

        [DefaultValue("0")]
        [Column(TypeName = "money")]
        [Display(Name = "Kredit Limiti")]
        public decimal CreditLimit { get; set; }

        [Column("IsVIP")]
        [DefaultValue("0")]
        [Display(Name = "VIP")]
        public bool IsVip { get; set; }

        [Display(Name = "Müştəri Tipi")]
        public byte? CustomerTypeCode { get; set; }

        [Display(Name = "Tədarikçi Tipi")]
        public byte? VendorTypeCode { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Müştəri Endirim Dərəcəsi")]
        public double CustomerPosDiscountRate { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [Display(Name = "Guid Id")]
        public Guid RowGuid { get; set; }

        [Display(Name = "Bonus Kartı")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? BonusCardNum { get; set; }

        [Display(Name = "Adres")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? Address { get; set; }

        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        //[RegularExpression(@"\d{2}[ ][0-9]{3}[ ][0-9]{2}[ ][0-9]{2}", ErrorMessage = "Duzgun Format Daxil Edin.")]
        public string? PhoneNum { get; set; }

        [Display(Name = "Doğum Günü")]
        [Column(TypeName = "date")]
        [DefaultValue("'1901-01-01'")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Varsayılan Müstəri")]
        public bool IsDefault { get; set; }

        [Display(Name = "Tema")]
        public string? Theme { get; set; }

        [Display(Name = "Kassanın Ödəmə Tipi")]
        public byte? CashRegPaymentTypeCode { get; set; }


        [NotMapped]
        [Display(Name = "Qalıq")]
        public decimal Balance { get; set; }




        public virtual DcCurrAccType DcCurrAccType { get; set; }
        [ForeignKey("CashRegPaymentTypeCode")]
        public virtual DcPaymentType DcPaymentType { get; set; }
        public virtual TrSession TrSession { get; set; }
        public virtual ICollection<SettingStore> SettingStores { get; set; }
        public virtual ICollection<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }

        //[ForeignKey("StoreCode")]
        public virtual ICollection<TrPaymentHeader> DcStoreTrPaymentHeaders { get; set; }
        public virtual ICollection<TrPaymentHeader> ToCashRegTrPaymentHeaders { get; set; }
        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
        public virtual ICollection<TrCurrAccRole> TrCurrAccRoles { get; set; }
        public virtual ICollection<DcPaymentMethod> DcPaymentMethods { get; set; }
    }
}
