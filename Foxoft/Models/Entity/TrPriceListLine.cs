
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
    public partial class TrPriceListLine : BaseEntity
    {
        [Key]
        public Guid PriceListLineId { get; set; }

        [ForeignKey("TrPriceListHeader")]
        public Guid PriceListHeaderId { get; set; }

        [Display(Name = "Məhsul Kodu")]
        [ForeignKey("DcProduct")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProductCode { get; set; }

        [Display(Name = "Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public decimal Price { get; set; }

        [Display(Name = "Valyuta")]
        [ForeignKey("DcCurrency")]
        public string CurrencyCode { get; set; } = Properties.Settings.Default.AppSetting.LocalCurrencyCode;

        [Display(Name = "Sətir Açıqlaması")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilmez \n")]
        public string LineDescription { get; set; }


        public virtual TrPriceListHeader TrPriceListHeader { get; set; }
        public virtual DcProduct DcProduct { get; set; }
        public virtual DcCurrency DcCurrency { get; set; }
    }
}
