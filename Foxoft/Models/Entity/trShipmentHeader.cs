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
    public partial class TrShipmentHeader : BaseEntity
    {
        public TrShipmentHeader()
        {
            TrShipmentLines = new HashSet<TrShipmentLine>();
        }

        [Key]
        public Guid ShipmentHeaderId { get; set; }
        public byte ShipTypeCode { get; set; }

        [Display(Name = "Proses")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProcessCode { get; set; }

        [Display(Name = "Daşıma Nömrəsi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ShippingNumber { get; set; }

        [Display(Name = "Daşıma Tarixi")]
        [Column(TypeName = "date")]
        public DateTime ShippingDate { get; set; }

        [Display(Name = "Daşıma Vaxtı")]
        [Column(TypeName = "time(0)")]
        public TimeSpan ShippingTime { get; set; }

        [Display(Name = "Əməliyat Tarixi")]
        [Column(TypeName = "date")]
        public DateTime OperationDate { get; set; }

        [Display(Name = "Əməliyat Vaxtı")]
        [Column(TypeName = "time(0)")]
        public TimeSpan OperationTime { get; set; }

        [Display(Name = "Fərdi Sənəd Nömrəsi")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CustomsDocumentNumber { get; set; }

        [Display(Name = "Açıqlama")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Description { get; set; }

        [Display(Name = "Cari Hesab")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CurrAccCode { get; set; }

        [Display(Name = "Daşıma Adresi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public Guid? ShippingPostalAddressId { get; set; }

        [Display(Name = "Şirkət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public decimal CompanyCode { get; set; }

        [Display(Name = "Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [Display(Name = "Mağaza Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [Display(Name = "Depo")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string WarehouseCode { get; set; }

        [Display(Name = "Depoya")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ToWarehouseCode { get; set; }

        [Display(Name = "Sifariş Əsaslıdır")]
        public bool IsOrderBase { get; set; }

        [Display(Name = "Tamamlanıb")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Çap Edilib")]
        public bool IsPrinted { get; set; }

        [Display(Name = "Kilidlənib")]
        public bool IsLocked { get; set; }

        [Display(Name = "Təsdiqlənib")]
        public bool IsTransferApproved { get; set; }

        [Display(Name = "Təsdiqlənmə Tarixi")]
        public DateTime TransferApprovedDate { get; set; }


        public virtual ICollection<TrShipmentLine> TrShipmentLines { get; set; }
    }
}
