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
    public partial class TrShipmentLine : BaseEntity
    {
        [Key]
        public Guid ShipmentLineId { get; set; }

        [ForeignKey("TrShipmentHeader")]
        public Guid ShipmentHeaderId { get; set; }

        [DisplayName("Sıra Nömrəsi")]
        public int SortOrder { get; set; }

        [DisplayName("Məhsul")]
        public string ProductCode { get; set; }

        [DisplayName("Rəng")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ColorCode { get; set; }

        [DisplayName("Ölçü")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductDimensionCode { get; set; }

        [DisplayName("Say")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} {1} dan az ola bilməz \n")]
        public int Qty { get; set; }

        [DisplayName("Satıcı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string SalespersonCode { get; set; }

        [DisplayName("Sətir Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string LineDescription { get; set; }

        [DisplayName("Daxili Barkod")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string UsedBarcode { get; set; }

        [DisplayName("Valyuta")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CurrencyCode { get; set; }

        [DisplayName("Qiymət")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        public virtual TrShipmentHeader TrShipmentHeader { get; set; }
    }
}
