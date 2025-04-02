using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    [Display(Name = "Cari Hesab Əlaqə Məlumatları")]
    public partial class DcCurrAccContactDetail
    {
        public DcCurrAccContactDetail()
        {
        }

        [Key]
        [Display(Name = "Əlaqə Məlumatları İd")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Əlaqə Məlumatları Açıqlaması")]
        public string ContactDesc { get; set; }

        [Required]
        [Display(Name = "Əlaqə Məlumatları Tipi")]
        [ForeignKey("DcContactType")]
        public byte ContactTypeId { get; set; }

        [Required]
        [Display(Name = "Cari Hesab Kodu")]
        [ForeignKey("DcCurrAcc")]
        public string CurrAccCode { get; set; }


        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual DcContactType DcContactType { get; set; }
    }
}
