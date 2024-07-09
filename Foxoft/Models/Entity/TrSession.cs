using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Foxoft.Models
{
    public partial class TrSession : BaseEntity
    {
        public TrSession()
        {
        }

        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [ForeignKey("DcCurrAcc")]
        [Display(Name = "Cari Hesab Kodu")]
        public string CurrAccCode { get; set; }

        [Display(Name = "Cari Hesab Tipi")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} {1} ilə {2} arasinda olmalidir \n")]
        public int PID { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Bloklanib")]
        public bool IsBlocked { get; set; }


        public virtual DcCurrAcc DcCurrAcc { get; set; }
    }
}
