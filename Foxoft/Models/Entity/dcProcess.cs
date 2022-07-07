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
    public partial class DcProcess
    {
        public DcProcess()
        {
            TrInvoiceHeaders = new HashSet<TrInvoiceHeader>();
        }

        [Key]
        [DisplayName("Proses Kodu")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProcessCode { get; set; }

        [DisplayName("Proses Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string ProcessDesc { get; set; }

        [DisplayName("Proses İstiqaməti")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(150, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public byte ProcessDir { get; set; }


        public virtual ICollection<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
    }
}
