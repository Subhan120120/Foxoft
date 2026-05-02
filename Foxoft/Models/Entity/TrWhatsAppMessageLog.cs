using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxoft.Models
{
    public class TrWhatsAppMessageLog : BaseEntity
    {
        [Key]
        public Guid WhatsAppMessageLogId { get; set; }

        public Guid? DocumentHeaderId { get; set; }

        [StringLength(30)]
        public string? ReceiverPhoneNumber { get; set; }

        [StringLength(50)]
        public string? MessageType { get; set; }

        [StringLength(30)]
        public string? Sender { get; set; }
    }
}
