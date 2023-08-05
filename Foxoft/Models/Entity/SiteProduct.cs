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

        [Key]
        [Display(Name = "Məhsul Kodu")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public int ProductId { get; set; }

        [Display(Name = "Umico Kodu")]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }


        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct { get; set; }
    }
}
