using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Foxoft.Properties;

namespace Foxoft.Models
{
    public class TrMessageLog : BaseEntity
    {
        [Key]
        [Display(Name = nameof(Resources.Entity_TrMessageLog_MessageLogId), ResourceType = typeof(Resources))]
        public Guid MessageLogId { get; set; }

        public Guid? DocumentHeaderId { get; set; }

        [StringLength(30)]
        [Display(Name = nameof(Resources.Entity_TrMessageLog_ReceiverPhoneNumber), ResourceType = typeof(Resources))]
        public string? ReceiverPhoneNumber { get; set; }

        [StringLength(30)]
        [Display(Name = nameof(Resources.Entity_TrMessageLog_ChannelCode), ResourceType = typeof(Resources))]
        public string? ChannelCode { get; set; }

        [StringLength(50)]
        [Display(Name = nameof(Resources.Entity_TrMessageLog_MessageType), ResourceType = typeof(Resources))]
        public string? MessageType { get; set; }

        [StringLength(1000)]
        [Display(Name = nameof(Resources.Entity_TrMessageLog_Message), ResourceType = typeof(Resources))]
        public string? Message { get; set; }

        [Display(Name = nameof(Resources.Entity_TrMessageLog_IsSuccessful), ResourceType = typeof(Resources))]
        public bool IsSuccessful { get; set; }

        [StringLength(30)]
        public string? Sender { get; set; }

        [StringLength(30)]
        [Display(Name = nameof(Resources.Entity_TrMessageLog_CurrAccCode), ResourceType = typeof(Resources))]
        public string? CurrAccCode { get; set; }

        [StringLength(100)]
        [Display(Name = nameof(Resources.Entity_TrMessageLog_ImageFileName), ResourceType = typeof(Resources))]
        public string? ImageFileName { get; set; }

        public int TryCount { get; set; }

        public DateTime? LastTryDate { get; set; }

        [Display(Name = nameof(Resources.Entity_TrMessageLog_ErrorMessage), ResourceType = typeof(Resources))]
        [Column("LastError")]
        public string? LastError { get; set; }

        [NotMapped]
        public string? ErrorMessage
        {
            get => LastError;
            set => LastError = value;
        }

        [ForeignKey(nameof(CurrAccCode))]
        public virtual DcCurrAcc? DcCurrAcc { get; set; }

        [ForeignKey(nameof(Sender))]
        public virtual DcCurrAcc? DcSender { get; set; }
    }
}
