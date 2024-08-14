using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Foxoft.Models
{
    [Display(Name = "Sayt Məhsulu")]
    public partial class SiteProduct : BaseEntity
    {
        public SiteProduct()
        {
        }

        [Display(Name = "Məhsul Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }


        [Key]
        [Display(Name = "Məhsul Kodu")]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }

        [Display(Name = "Məhsul Açıqlaması")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? Desc { get; set; }

        [Display(Name = "Qiymət")]
        public decimal Price { get; set; }

        [Display(Name = "Reytinq")]
        public int? Rating { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Slug")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? Slug { get; set; }

        [Display(Name = "Baxış Sayı")]
        public int ViewCount { get; set; }


        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct { get; set; }
    }
}
