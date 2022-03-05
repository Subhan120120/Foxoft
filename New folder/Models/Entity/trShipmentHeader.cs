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

        [DisplayName("Proses")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProcessCode { get; set; }

        [DisplayName("Daşıma Nömrəsi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ShippingNumber { get; set; }

        [DisplayName("Daşıma Tarixi")]
        [Column(TypeName = "date")]
        public DateTime ShippingDate { get; set; }

        [DisplayName("Daşıma Vaxtı")]
        [Column(TypeName = "time(0)")]
        public TimeSpan ShippingTime { get; set; }

        [DisplayName("Əməliyat Tarixi")]
        [Column(TypeName = "date")]
        public DateTime OperationDate { get; set; }

        [DisplayName("Əməliyat Vaxtı")]
        [Column(TypeName = "time(0)")]
        public TimeSpan OperationTime { get; set; }

        [DisplayName("Fərdi Sənəd Nömrəsi")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CustomsDocumentNumber { get; set; }

        [DisplayName("Açıqlama")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Description { get; set; }

        [DisplayName("Cari Hesab")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CurrAccCode { get; set; }

        [DisplayName("Daşıma Adresi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public Guid? ShippingPostalAddressId { get; set; }

        [DisplayName("Şirkət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public decimal CompanyCode { get; set; }

        [DisplayName("Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [DisplayName("Mağaza")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [DisplayName("Depo")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string WarehouseCode { get; set; }

        [DisplayName("Depoya")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ToWarehouseCode { get; set; }

        [DisplayName("Sifariş Əsaslıdır")]
        public bool IsOrderBase { get; set; }

        [DisplayName("Tamamlanıb")]
        public bool IsCompleted { get; set; }

        [DisplayName("Çap Edilib")]
        public bool IsPrinted { get; set; }

        [DisplayName("Kilidlənib")]
        public bool IsLocked { get; set; }

        [DisplayName("Təsdiqlənib")]
        public bool IsTransferApproved { get; set; }

        [DisplayName("Təsdiqlənmə Tarixi")]
        public DateTime TransferApprovedDate { get; set; }


        public virtual ICollection<TrShipmentLine> TrShipmentLines { get; set; }
    }
}
