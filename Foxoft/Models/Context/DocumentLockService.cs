
using Foxoft.Models.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Foxoft.Models.Context
{
    public sealed record LockResult(
        bool Acquired,
        bool TakenOver,
        string LockedBy,
        DateTime? LockedAtUtc,
        DateTime? LastHeartbeatAtUtc,
        string Message
    );

    public enum LockCloseReason
    {
        None = 0,
        LOCK_REMOVED = 1,
        OWNERSHIP_CHANGED = 2,
        FORCE_CLOSE = 3
    }

    public sealed record LockCheckResult(
        LockCloseReason Reason,
        string? Note = null,
        string? CurrentOwnerUserId = null
    );

    public sealed class DocumentLockService
    {
        private readonly subContext _db;
        public DocumentLockService(subContext db) => _db = db;

        public LockResult TryAcquire(
            string documentType,
            Guid documentId,
            string userId,
            string? machineName,
            Guid appInstanceId,
            Guid formInstanceId,
            int clientProcessId,
            TimeSpan timeout,
            string? reason = null)
        {
            var now = DateTime.UtcNow;

            var newLock = new DocumentLock
            {
                DocumentType = documentType,
                DocumentId = documentId,
                LockedByUserId = userId,
                LockedAtUtc = now,
                LastHeartbeatAtUtc = now,
                MachineName = machineName,
                AppInstanceId = appInstanceId,
                FormInstanceId = formInstanceId,
                ClientProcessId = clientProcessId,
                Reason = reason
            };

            _db.DocumentLocks.Add(newLock);

            try
            {
                _db.SaveChanges();

                AddAudit(documentType, documentId, "LOCK", userId, machineName, null);

                return new LockResult(
                    Acquired: true,
                    TakenOver: false,
                    LockedBy: userId,
                    LockedAtUtc: null,
                    LastHeartbeatAtUtc: null,
                    Message: "LOCK_ACQUIRED"
                );
            }
            catch (DbUpdateException ex) when (IsUniqueConstraintViolation(ex))
            {
                _db.ChangeTracker.Clear();

                var existing = _db.DocumentLocks
                    .AsNoTracking()
                    .FirstOrDefault(x => x.DocumentType == documentType && x.DocumentId == documentId);

                if (existing is null)
                    return new LockResult(false, false, null, null, null, "LOCK_RACE_RETRY");

                // Timeout takeover
                if (now - existing.LastHeartbeatAtUtc >= timeout)
                {
                    using var tx = _db.Database.BeginTransaction();

                    var rows = _db.DocumentLocks
                        .Where(x => x.DocumentType == documentType
                                 && x.DocumentId == documentId
                                 && x.LastHeartbeatAtUtc == existing.LastHeartbeatAtUtc)
                        .ExecuteUpdate(setters => setters
                            .SetProperty(x => x.LockedByUserId, userId)
                            .SetProperty(x => x.LockedAtUtc, now)
                            .SetProperty(x => x.LastHeartbeatAtUtc, now)
                            .SetProperty(x => x.MachineName, machineName)
                            .SetProperty(x => x.AppInstanceId, appInstanceId)
                            .SetProperty(x => x.FormInstanceId, formInstanceId)
                            .SetProperty(x => x.ClientProcessId, clientProcessId)
                            .SetProperty(x => x.Reason, reason));

                    if (rows == 1)
                    {
                        AddAudit(documentType, documentId, "TAKEOVER", userId, machineName,
                            $"Timeout takeover. Previous: {existing.LockedByUserId}");

                        tx.Commit();

                        return new LockResult(
                            Acquired: true,
                            TakenOver: true,
                            LockedBy: userId,
                            LockedAtUtc: null,
                            LastHeartbeatAtUtc: null,
                            Message: "LOCK_TAKEN_OVER_DUE_TO_TIMEOUT"
                        );
                    }

                    tx.Rollback();

                    existing = _db.DocumentLocks.AsNoTracking()
                        .FirstOrDefault(x => x.DocumentType == documentType && x.DocumentId == documentId);

                    if (existing is null)
                        return new LockResult(false, false, null, null, null, "LOCK_MISSING_AFTER_RACE");

                    return new LockResult(
                        Acquired: false,
                        TakenOver: false,
                        LockedBy: existing.LockedByUserId,
                        LockedAtUtc: existing.LockedAtUtc,
                        LastHeartbeatAtUtc: existing.LastHeartbeatAtUtc,
                        Message: "LOCKED"
                    );
                }

                return new LockResult(
                    Acquired: false,
                    TakenOver: false,
                    LockedBy: existing.LockedByUserId,
                    LockedAtUtc: existing.LockedAtUtc,
                    LastHeartbeatAtUtc: existing.LastHeartbeatAtUtc,
                    Message: "LOCKED"
                );
            }
        }

        private void AddAudit(
            string documentType, Guid documentId, string action,
            string? userId, string? machineName, string? note)
        {
            _db.DocumentLockAudits.Add(new DocumentLockAudit
            {
                DocumentType = documentType,
                DocumentId = documentId,
                Action = action,
                UserId = userId,
                MachineName = machineName,
                ActionAtUtc = DateTime.UtcNow,
                Note = note
            });

            _db.SaveChanges();
        }

        private static bool IsUniqueConstraintViolation(DbUpdateException ex)
        {
            if (ex.InnerException is SqlException sqlEx)
                return sqlEx.Number is 2601 or 2627;
            return false;
        }

        public void ForceCloseRequest(string documentType, Guid documentId, string adminUserId, string? note)
        {
            var now = DateTime.UtcNow;

            var rows = _db.DocumentLocks
                .Where(x => x.DocumentType == documentType && x.DocumentId == documentId)
                .ExecuteUpdate(s => s
                    .SetProperty(x => x.ForceCloseRequestedAtUtc, now)
                    .SetProperty(x => x.ForceCloseReason, note));

            if (rows == 1)
                AddAudit(documentType, documentId, "FORCE_CLOSE_REQUEST", adminUserId, null, note);
        }

        public void ForceUnlock(string documentType, Guid documentId, string adminUserId, string? note)
        {
            // əvvəl kimdə idi - audit üçün (opsional)
            var existing = _db.DocumentLocks.AsNoTracking()
                .FirstOrDefault(x => x.DocumentType == documentType && x.DocumentId == documentId);

            var deleted = _db.DocumentLocks
                .Where(x => x.DocumentType == documentType && x.DocumentId == documentId)
                .ExecuteDelete();

            if (deleted == 1)
                AddAudit(documentType, documentId, "FORCE_UNLOCK", adminUserId, null,
                    existing == null ? note : $"PrevOwner={existing.LockedByUserId}; {note}");
        }

        public void Unlock(
            string documentType,
            Guid documentId,
            string userId,
            string? machineName,
            Guid appInstanceId)
        {
            var deleted = _db.DocumentLocks
                .Where(x => x.DocumentType == documentType
                         && x.DocumentId == documentId
                         && x.LockedByUserId == userId
                         && x.AppInstanceId == appInstanceId)
                .ExecuteDelete();

            if (deleted == 1)
                AddAudit(documentType, documentId, "UNLOCK", userId, machineName, null);
        }

        public LockCheckResult HeartbeatAndCheckForceClose(
            string documentType,
            Guid documentId,
            string userId,
            Guid appInstanceId,
            Guid formInstanceId)
        {
            var now = DateTime.UtcNow;

            // 1) Lock row-u oxu (owner yoxlaması üçün)
            var lockRow = _db.DocumentLocks.AsNoTracking()
                .Where(x => x.DocumentType == documentType && x.DocumentId == documentId)
                .Select(x => new
                {
                    x.LockedByUserId,
                    x.AppInstanceId,
                    x.FormInstanceId,
                    x.ForceCloseRequestedAtUtc,
                    x.ForceCloseReason
                })
                .FirstOrDefault();

            if (lockRow == null)
                return new LockCheckResult(LockCloseReason.LOCK_REMOVED);

            // 2) Ownership dəyişibsə → bağla
            if (lockRow.LockedByUserId != userId
                || lockRow.AppInstanceId != appInstanceId
                || lockRow.FormInstanceId != formInstanceId)
            {
                return new LockCheckResult(
                    Reason: LockCloseReason.OWNERSHIP_CHANGED,
                    Note: "Lock owner changed.",
                    CurrentOwnerUserId: lockRow.LockedByUserId
                );
            }

            // 3) Heartbeat update (mənim lock-umdursa)
            _db.DocumentLocks
                .Where(x => x.DocumentType == documentType
                         && x.DocumentId == documentId
                         && x.LockedByUserId == userId
                         && x.AppInstanceId == appInstanceId
                         && x.FormInstanceId == formInstanceId)
                .ExecuteUpdate(s => s.SetProperty(x => x.LastHeartbeatAtUtc, now));

            // 4) ForceClose flag-ı DƏQİQ yoxlama:
            //    - ya yuxarıdakı lockRow-dan istifadə edə bilərik (minimal gecikmə ilə),
            //    - ya da “ayrı select” ilə ən son dəyəri oxuyuruq (tövsiyə).
            var force = _db.DocumentLocks.AsNoTracking()
                .Where(x => x.DocumentType == documentType
                         && x.DocumentId == documentId
                         && x.LockedByUserId == userId
                         && x.AppInstanceId == appInstanceId
                         && x.FormInstanceId == formInstanceId)
                .Select(x => new { x.ForceCloseRequestedAtUtc, x.ForceCloseReason })
                .FirstOrDefault();

            if (force?.ForceCloseRequestedAtUtc != null)
                return new LockCheckResult(LockCloseReason.FORCE_CLOSE, force.ForceCloseReason);

            return new LockCheckResult(LockCloseReason.None);
        }

        public bool IsLockOwnedByMe(string documentType, Guid documentId, string userId, Guid appInstanceId, Guid formInstanceId)
        {
            return _db.DocumentLocks.AsNoTracking().Any(x =>
                x.DocumentType == documentType &&
                x.DocumentId == documentId &&
                x.LockedByUserId == userId &&
                x.AppInstanceId == appInstanceId &&
                x.FormInstanceId == formInstanceId);
        }
    }
}
