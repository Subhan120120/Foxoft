using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Text;

namespace Foxoft.AppCode
{
    /// <summary>
    /// Google Drive API ilə fayl yükləmə əməliyyatları üçün xidmət sinfi.
    /// IDisposable tətbiq edir — istifadədən sonra Dispose() çağırılmalıdır.
    /// </summary>
    internal class GoogleDriveAPI : IDisposable
    {
        private const string ApplicationName = "Foxoft";
        private const string TokenPath = "token.json";
        private const string CredentialData = "DQogICAgICAgIHsNCiAgICAgICAgICAgImluc3RhbGxlZCI6IHsNCiAgICAgICAgICAgICAgImNsaWVudF9pZCI6ICI4ODQyNzM5NzA5OTctbTJ0MmRxZDg4dG5vNDRkYjZkdmxzcXU4dm1hdHVjaWkuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLA0KICAgICAgICAgICAgICAicHJvamVjdF9pZCI6ICJzdHJpa2luZy1hcmJvci0yOTIwMTgiLA0KICAgICAgICAgICAgICAiYXV0aF91cmkiOiAiaHR0cHM6Ly9hY2NvdW50cy5nb29nbGUuY29tL28vb2F1dGgyL2F1dGgiLA0KICAgICAgICAgICAgICAidG9rZW5fdXJpIjogImh0dHBzOi8vb2F1dGgyLmdvb2dsZWFwaXMuY29tL3Rva2VuIiwNCiAgICAgICAgICAgICAgImF1dGhfcHJvdmlkZXJfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9vYXV0aDIvdjEvY2VydHMiLA0KICAgICAgICAgICAgICAiY2xpZW50X3NlY3JldCI6ICJHT0NTUFgtd3UyMnBSZmR4MzJrcksxSlJUYXJGeDRQLUdfVyIsDQogICAgICAgICAgICAgICJyZWRpcmVjdF91cmlzIjogWyAiaHR0cDovL2xvY2FsaG9zdCIgXQ0KICAgICAgICAgICB9DQogICAgICAgIH0=";
        private const string GoogleSheetsMimeType = "application/vnd.google-apps.spreadsheet";
        private const string XlsxMimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        private DriveService _driveService;
        private bool _disposed;

        /// <summary>
        /// DriveService obyektini yaradır və ya mövcud olanı qaytarır (lazy initialization).
        /// </summary>
        private DriveService GetDriveService()
        {
            if (_driveService != null)
                return _driveService;

            byte[] credentialBytes = Convert.FromBase64String(CredentialData);

            using MemoryStream stream = new(credentialBytes);

            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                new[] { DriveService.Scope.Drive },
                "user",
                CancellationToken.None,
                new FileDataStore(TokenPath, true)).Result;

            _driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return _driveService;
        }


        /// <summary>
        /// Google Sheets və ya xlsx faylını yükləyir və MemoryStream kimi qaytarır.
        /// Əvvəlcə Google Sheets Export (xlsx) yolunu sınayır.
        /// Uğursuz olarsa, adi fayl yükləməsinə (Files.Get) keçir.
        /// </summary>
        /// <param name="fileId">Google Drive fayl ID-si.</param>
        /// <returns>Faylın məzmunu olan MemoryStream (Position = 0). Çağıran tərəf Dispose etməlidir.</returns>
        /// <exception cref="ArgumentException">fileId boş olduqda.</exception>
        /// <exception cref="Exception">Yükləmə uğursuz olduqda və ya məzmun boş olduqda.</exception>
        public MemoryStream DownloadAsStream(string fileId)
        {
            if (string.IsNullOrWhiteSpace(fileId))
                throw new ArgumentException("Fayl ID boş ola bilməz.", nameof(fileId));

            var service = GetDriveService();

            // Faylın MIME type-ını öyrən
            var fileRequest = service.Files.Get(fileId);
            fileRequest.Fields = "mimeType";
            var fileMeta = fileRequest.Execute();

            MemoryStream memoryStream = new();
            Exception downloadError = null;

            if (fileMeta.MimeType == GoogleSheetsMimeType)
            {
                // Google Sheets — xlsx formatında export et
                var exportRequest = service.Files.Export(fileId, XlsxMimeType);
                exportRequest.MediaDownloader.ProgressChanged += (progress) =>
                {
                    if (progress.Status == DownloadStatus.Failed)
                        downloadError = progress.Exception;
                };
                exportRequest.Download(memoryStream);
            }
            else
            {
                // Adi xlsx fayl — birbaşa yüklə
                var getRequest = service.Files.Get(fileId);
                getRequest.MediaDownloader.ProgressChanged += (progress) =>
                {
                    if (progress.Status == DownloadStatus.Failed)
                        downloadError = progress.Exception;
                };
                getRequest.Download(memoryStream);
            }

            if (downloadError != null)
            {
                memoryStream.Dispose();
                throw new Exception($"Fayl yükləmə uğursuz oldu: {downloadError.Message}", downloadError);
            }

            if (memoryStream.Length == 0)
            {
                memoryStream.Dispose();
                throw new Exception("Fayl yükləndi, lakin məzmun boşdur.");
            }

            memoryStream.Position = 0;
            return memoryStream;
        }

        /// <summary>
        /// DriveService resurslarını azad edir.
        /// </summary>
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
