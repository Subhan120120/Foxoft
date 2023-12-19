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
    public partial class DcTerminal : BaseEntity
    {
        [Key]
        [Display(Name = "Terminal Id")]
        [StringLength(50, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public int TerminalId { get; set; }

        [Display(Name = "Terminal Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string TerminalDesc { get; set; }

        [DefaultValue("0")]
        [Display(Name = "Qeyri-Aktiv")]
        public bool IsDisabled { get; set; }

        [Display(Name = "Guid Id")]
        public Guid? RowGuid { get; set; }

        [Display(Name = "TouchScreen Mod")]
        public bool TouchUIMode { get; set; }

        [Display(Name = "Toxunma Ölçüsü Faktoru")]
        public int TouchScaleFactor { get; set; }
    }
}
