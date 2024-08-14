using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    [Display(Name = "Depo")]
    public partial class DcWarehouse : BaseEntity
    {
        [Key]
        [Display(Name = "Depo Kodu")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string WarehouseCode { get; set; }

        [Display(Name = "Depo Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string WarehouseDesc { get; set; }

        [Display(Name = "Depo Tipi")]
        public byte WarehouseTypeCode { get; set; }

        [Display(Name = "Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [Display(Name = "Mağaza Kodu")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [Display(Name = "Mənfi Stoka İcazə Ver")]
        public bool PermitNegativeStock { get; set; }

        [Display(Name = "Mənfi Stokda Xəbərdar Et")]
        public bool WarnNegativeStock { get; set; }

        [Display(Name = "Stok Səviyyəsi")]
        public bool ControlStockLevel { get; set; }

        [Display(Name = "Stok Səviyyəsini Xəbardar Et")]
        public bool WarnStockLevelRate { get; set; }

        [Display(Name = "Varsayılandır")]
        public bool IsDefault { get; set; }

        [Display(Name = "Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [Display(Name = "Guid Id")]
        public Guid RowGuid { get; set; }
    }
}
