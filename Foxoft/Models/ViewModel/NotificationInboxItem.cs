namespace Foxoft.Models.ViewModel
{
    public sealed class NotificationInboxItem
    {
        public long NotificationId { get; set; }
        public long NotificationRecipientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string NotificationTypeCode { get; set; } = string.Empty;
        public string NotificationTypeDesc { get; set; } = string.Empty;
        public string CategoryCode { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string? StoreCode { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string NotificationStatus { get; set; } = string.Empty;
        public string RecipientStatus { get; set; } = string.Empty;
        public string? EntityType { get; set; }
        public string? EntityKey { get; set; }
        public DateTime? SnoozedUntil { get; set; }
        public DateTime LastRaisedDate { get; set; }
    }
}
