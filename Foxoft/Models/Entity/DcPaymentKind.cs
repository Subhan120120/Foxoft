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
    [Display(Name = "Ödəmə Növü")]
    public partial class DcPaymentKind
    {
        public DcPaymentKind()
        {
            TrPaymentHeaders = new HashSet<TrPaymentHeader>();
        }
        [Key]
        [Display(Name = "Ödəmə Növü Kodu")]
        public byte PaymentKindId { get; set; }

        [Display(Name = "Ödəmə Növü Açıqlaması")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(100, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string PaymentKindDesc { get; set; }

        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
    }
}
