using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Foxoft.Models
{
    [Display(Name = "Özəllik")]
    [Index(nameof(ProductCode), IsUnique = true)]
    [Index(nameof(ScaleProductNumber), IsUnique = true)]
    public partial class DcProductScale
    {
        public DcProductScale()
        {
        }

        [Key]
        [Display(Name = "Özəllik Kodu")]
        public int Id { get; set; }

        [Display(Name = "Məhsul Kodu")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]

        public string ProductCode { get; set; }

        [Display(Name = "Tərəzi Məhsul Açıqlaması")]
        public string? ScaleProductDesc { get; set; }

        [Display(Name = "Tərəzi Məhsul Kodu")]
        public int? ScaleProductNumber { get; set; }


        [ForeignKey("ProductCode")]
        public virtual DcProduct DcProduct{ get; set; }
    }
}
