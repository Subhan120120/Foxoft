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
    [Display(Name = "Dəyişən")]
    public partial class DcVariable
    {
        [Key]
        [Display(Name = "Dəyişən Kodu")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string VariableCode { get; set; }

        [Display(Name = "Dəyişən Kodu")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string? VariableDesc { get; set; }

        [Display(Name = "Sonuncu Nömrə")]
        public int? LastNumber { get; set; }
    }
}
