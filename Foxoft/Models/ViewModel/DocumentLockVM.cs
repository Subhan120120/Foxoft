namespace Foxoft.Models.Entity
{
    public sealed class DocumentLockVM
    {
        public Guid LockId { get; set; }

        public string DocumentType { get; set; }
        public Guid DocumentId { get; set; }

        public DateTime LockedAtUtc { get; set; }
        public string LockedByUserId { get; set; }

        // NEW
        public string? DocumentNumber { get; set; }
        public string? LockedByUserName { get; set; }
    }
}