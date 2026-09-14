using System.ComponentModel.DataAnnotations;

namespace Foxoft.Models
{
    public class CurrAccRoleVM
    {
        [Display(Name = "Seçilib")]
        public bool IsAssigned { get; set; }

        [Display(Name = "Rol Kodu")]
        public string RoleCode { get; set; } = string.Empty;

        [Display(Name = "Rol Təsviri")]
        public string RoleDesc { get; set; } = string.Empty;
    }
}
