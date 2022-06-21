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
        }

        [Key]
        [StringLength(30)]
        [DisplayName("Cari Hesab Kodu")]
        public string CurrAccCode { get; set; }

        [ForeignKey("DcCurrAccType")]
        [DisplayName("Cari Hesab Tipi Kodu")]
        public byte CurrAccTypeCode { get; set; }

        [DisplayName("Şirkət")]
        public byte CompanyCode { get; set; }

        [DisplayName("Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [DisplayName("Mağaza")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string LastName { get; set; }

        [DisplayName("Ata Adı")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FatherName { get; set; }

        //[DisplayName("Şifrə")]
        //[Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        //public string Password { get; set; }

        [DataType(DataType.Password), Display(Name = "Yeni Şifrə")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password), Compare("NewPassword", ErrorMessage = "Şifrələr biri birinə uyğun deyil"), Display(Name = "Şifrəni Təsdiqlə")]
        public string ConfirmPassword { get; set; }


        [DisplayName("Ş.V.Nömrəsi")]
        [StringLength(20, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string IdentityNum { get; set; }

        [DisplayName("Vergi Nömrəsi")]
        [StringLength(20, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string TaxNum { get; set; }

        [DisplayName("İstifadəçi Dili")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string DataLanguageCode { get; set; }

        [DisplayName("Kredit Limiti")]
        [Column(TypeName = "money")]
        public decimal CreditLimit { get; set; }

        [Column("IsVIP")]
        [DisplayName("VIP")]
        public bool IsVip { get; set; }

        [DisplayName("Müştəri Tipi")]
        public byte CustomerTypeCode { get; set; }

        [DisplayName("Tədarikçi Tipi")]
        public byte VendorTypeCode { get; set; }

        [DisplayName("Müştəri Endirim Dərəcəsi")]
        public double CustomerPosDiscountRate { get; set; }

        [DisplayName("Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [DisplayName("Guid Id")]
        public Guid RowGuid { get; set; }

        [DisplayName("Bonus Kartı")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string BonusCardNum { get; set; }

        [DisplayName("Adres")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Address { get; set; }


        [DataType(DataType.PhoneNumber)]
        [DisplayName("Telefon")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PhoneNum { get; set; }

        [DisplayName("Doğum Günü")]
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }


        public virtual DcCurrAccType DcCurrAccType { get; set; }
        public virtual ICollection<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
        public virtual ICollection<TrCurrAccRole> TrCurrAccRole { get; set; }
    }
}
