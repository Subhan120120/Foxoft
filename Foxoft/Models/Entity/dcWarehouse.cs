using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public partial class DcWarehouse : BaseEntity
    {
        [Key]
        [DisplayName("Depo Kodu")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string WarehouseCode { get; set; }

        [DisplayName("Depo Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string WarehouseDesc { get; set; }

        [DisplayName("Depo Tipi")]
        public byte WarehouseTypeCode { get; set; }

        [DisplayName("Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [DisplayName("Mağaza Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [DisplayName("Mənfi Stoka İcazə Ver")]
        public bool PermitNegativeStock { get; set; }

        [DisplayName("Mənfi Stokda Xəbərdar Et")]
        public bool WarnNegativeStock { get; set; }

        [DisplayName("Stok Səviyyəsi")]
        public bool ControlStockLevel { get; set; }

        [DisplayName("Stok Səviyyəsini Xəbardar Et")]
        public bool WarnStockLevelRate { get; set; }

        [DisplayName("Varsayılandır")]
        public bool IsDefault { get; set; }

        [DisplayName("Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [DisplayName("Guid Id")]
        public Guid RowGuid { get; set; }
    }
}
