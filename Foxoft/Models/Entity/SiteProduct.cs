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
    public partial class SiteProduct : BaseEntity
    {
        public SiteProduct()
        {
        }

        [Display(Name = "Məhsul Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }


        [Key]
        [Display(Name = "Umico Kodu")]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }

        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? Description { get; set; }

        public decimal Price { get; set; }
        public int? Rating { get; set; }
        public int CategoryId { get; set; }

        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? Slug { get; set; }
        public int ViewCount { get; set; }


        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct { get; set; }
    }
}
