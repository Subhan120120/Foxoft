using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;

namespace Foxoft.AppCode.Service.Backup
{
    public sealed class GoogleDriveBackupService : IDisposable
    {
        private const string ApplicationName = "Foxoft";
        private const string CredentialData = "DQogICAgICAgIHsNCiAgICAgICAgICAgImluc3RhbGxlZCI6IHsNCiAgICAgICAgICAgICAgImNsaWVudF9pZCI6ICI4ODQyNzM5NzA5OTctbTJ0MmRxZDg4dG5vNDRkYjZkdmxzcXU4dm1hdHVjaWkuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLA0KICAgICAgICAgICAgICAicHJvamVjdF9pZCI6ICJzdHJpa2luZy1hcmJvci0yOTIwMTgiLA0KICAgICAgICAgICAgICAiYXV0aF91cmkiOiAiaHR0cHM6Ly9hY2NvdW50cy5nb29nbGUuY29tL28vb2F1dGgyL2F1dGgiLA0KICAgICAgICAgICAgICAidG9rZW5fdXJpIjogImh0dHBzOi8vb2F1dGgyLmdvb2dsZWFwaXMuY29tL3Rva2VuIiwNCiAgICAgICAgICAgICAgImF1dGhfcHJvdmlkZXJfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9vYXV0aDIvdjEvY2VydHMiLA0KICAgICAgICAgICAgICAiY2xpZW50X3NlY3JldCI6ICJHT0NTUFgtd3UyMnBSZmR4MzJrcksxSlJUYXJGeDRQLUdfVyIsDQogICAgICAgICAgICAgICJyZWRpcmVjdF91cmlzIjogWyAiaHR0cDovL2xvY2FsaG9zdCIgXQ0KICAgICAgICAgICB9DQogICAgICAgIH0=";

        private static string TokenPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "Foxoft",
            "GoogleDriveToken");

        private DriveService? _driveService;
        private bool _disposed;

        public async Task<DriveService> GetDriveServiceAsync(CancellationToken ct = default)
        {
            if (_driveService != null)
                return _driveService;

            EnsureTokenDirectoryAccess(TokenPath);

            byte[] credentialBytes = Convert.FromBase64String(CredentialData);
            using MemoryStream stream = new(credentialBytes);

            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive },
                "user",
                ct,
                new FileDataStore(TokenPath, true));

            _driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return _driveService;
        }

        public async Task<(bool isSuccess, string message)> TestConnectionAsync(CancellationToken ct = default)
        {
            try
            {
                var service = await GetDriveServiceAsync(ct);
                var aboutReq = service.About.Get();
                aboutReq.Fields = "user,storageQuota";
                var about = await aboutReq.ExecuteAsync(ct);

                string email = about.User?.EmailAddress ?? "Naməlum istifadəçi";
                long? limit = about.StorageQuota?.Limit;
                long? usage = about.StorageQuota?.Usage;

                string quotaInfo = limit.HasValue && limit > 0
                    ? $" ({usage / (1024 * 1024):N0} MB / {limit / (1024 * 1024):N0} MB)"
                    : string.Empty;

                return (true, $"Google Drive əlaqəsi uğurludur: {email}{quotaInfo}");
            }
            catch (Exception ex)
            {
                return (false, $"Google Drive əlaqə xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Uploads a file to Google Drive under the specified folder ID or folder name.
        /// </summary>
        public async Task<string> UploadFileAsync(
            string localFilePath,
            string? folderIdOrName = null,
            CancellationToken ct = default)
        {
            if (!File.Exists(localFilePath))
                throw new FileNotFoundException("Yükləmək üçün fayl tapılmadı: " + localFilePath);

            var service = await GetDriveServiceAsync(ct);

            string? targetFolderId = null;
            if (!string.IsNullOrWhiteSpace(folderIdOrName))
            {
                targetFolderId = await ResolveOrCreateFolderAsync(folderIdOrName.Trim(), service, ct);
            }

            string fileName = Path.GetFileName(localFilePath);
            string mimeType = GetMimeType(localFilePath);

            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = fileName,
                MimeType = mimeType,
                Parents = !string.IsNullOrEmpty(targetFolderId) ? new List<string> { targetFolderId } : null
            };

            await using FileStream fileStream = new(localFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var uploadRequest = service.Files.Create(fileMetadata, fileStream, mimeType);
            uploadRequest.Fields = "id, name, size";

            Exception? uploadException = null;
            uploadRequest.ProgressChanged += (IUploadProgress progress) =>
            {
                if (progress.Status == UploadStatus.Failed)
                    uploadException = progress.Exception;
            };

            var progressResult = await uploadRequest.UploadAsync(ct);
            if (progressResult.Status == UploadStatus.Failed || uploadException != null)
            {
                throw new InvalidOperationException($"Google Drive yükləməsi uğursuz oldu: {uploadException?.Message ?? progressResult.Exception?.Message}");
            }

            return uploadRequest.ResponseBody?.Id ?? string.Empty;
        }

        /// <summary>
        /// Deletes backup files in target Google Drive folder older than retentionDays.
        /// </summary>
        public async Task<int> CleanupExpiredBackupsAsync(
            string? folderIdOrName,
            int retentionDays,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(folderIdOrName) || retentionDays <= 0)
                return 0;

            var service = await GetDriveServiceAsync(ct);
            string? folderId = await ResolveOrCreateFolderAsync(folderIdOrName.Trim(), service, ct);
            if (string.IsNullOrEmpty(folderId))
                return 0;

            DateTime cutoffDate = DateTime.UtcNow.AddDays(-retentionDays);
            string rfc3339Cutoff = cutoffDate.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");

            string query = $"'{folderId}' in parents and trashed = false and createdTime < '{rfc3339Cutoff}' and mimeType != 'application/vnd.google-apps.folder'";

            var listReq = service.Files.List();
            listReq.Q = query;
            listReq.Fields = "files(id, name, createdTime)";
            listReq.PageSize = 100;

            var result = await listReq.ExecuteAsync(ct);
            int deletedCount = 0;

            if (result.Files != null)
            {
                foreach (var file in result.Files)
                {
                    try
                    {
                        await service.Files.Delete(file.Id).ExecuteAsync(ct);
                        deletedCount++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Köhnə faylı silərkən xəta ({file.Name}): {ex.Message}");
                    }
                }
            }

            return deletedCount;
        }

        private async Task<string> ResolveOrCreateFolderAsync(string folderNameOrId, DriveService service, CancellationToken ct)
        {
            // If it looks like a folder ID (alphanumeric, no spaces, length > 20)
            if (folderNameOrId.Length > 20 && !folderNameOrId.Contains(" ") && !folderNameOrId.Contains("/") && !folderNameOrId.Contains("\\"))
            {
                try
                {
                    var getReq = service.Files.Get(folderNameOrId);
                    getReq.Fields = "id, mimeType, trashed";
                    var existing = await getReq.ExecuteAsync(ct);
                    if (existing != null && existing.MimeType == "application/vnd.google-apps.folder" && existing.Trashed != true)
                    {
                        return existing.Id;
                    }
                }
                catch
                {
                    // If not found as ID, treat as folder name
                }
            }

            // Look for existing folder by name
            string safeName = folderNameOrId.Replace("'", "\\'");
            string q = $"name = '{safeName}' and mimeType = 'application/vnd.google-apps.folder' and trashed = false";

            var listReq = service.Files.List();
            listReq.Q = q;
            listReq.Fields = "files(id, name)";
            var list = await listReq.ExecuteAsync(ct);

            if (list.Files != null && list.Files.Count > 0)
            {
                return list.Files[0].Id;
            }

            // Create new folder
            var folderMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = folderNameOrId,
                MimeType = "application/vnd.google-apps.folder"
            };

            var createReq = service.Files.Create(folderMetadata);
            createReq.Fields = "id";
            var created = await createReq.ExecuteAsync(ct);
            return created.Id;
        }

        private static string GetMimeType(string path)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            return ext switch
            {
                ".zip" => "application/zip",
                ".rar" => "application/vnd.rar",
                ".bak" => "application/octet-stream",
                _ => "application/octet-stream"
            };
        }

        private static void EnsureTokenDirectoryAccess(string tokenDirectoryPath)
        {
            DirectoryInfo dirInfo = new(tokenDirectoryPath);
            if (!dirInfo.Exists)
                dirInfo.Create();

            try
            {
                DirectorySecurity security = dirInfo.GetAccessControl();
                SecurityIdentifier usersGroup = new(WellKnownSidType.BuiltinUsersSid, null);
                security.AddAccessRule(new FileSystemAccessRule(
                    usersGroup,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow));
                dirInfo.SetAccessControl(security);
            }
            catch
            {
                // Access control setting is optional if running under limited privileges
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _driveService?.Dispose();
                _driveService = null;
                _disposed = true;
            }
        }
    }
}
