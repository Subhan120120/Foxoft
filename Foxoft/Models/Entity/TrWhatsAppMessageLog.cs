using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

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

        [StringLength(1000)]
        public string? Message { get; set; }

        [Display(Name = nameof(Resources.Entity_TrWhatsAppMessageLog_IsSuccessful), ResourceType = typeof(Resources))]
        public bool IsSuccessful { get; set; }

        [StringLength(30)]
        public string? Sender { get; set; }

        [StringLength(30)]
        public string? CurrAccCode { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc? DcCurrAcc { get; set; }

        [ForeignKey(nameof(Sender))]
        public virtual DcCurrAcc? DcSender { get; set; }
    }
}
