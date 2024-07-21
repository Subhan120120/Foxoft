using DevExpress.Office.Drawing;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.AppCode
{
    internal class GoogleDriveAPI
    {
        public string Drive()
        {
            UserCredential credential;

            // encoding google credential json
            string jsonData = "DQogICAgICAgIHsNCiAgICAgICAgICAgImluc3RhbGxlZCI6IHsNCiAgICAgICAgICAgICAgImNsaWVudF9pZCI6ICI4ODQyNzM5NzA5OTctbTJ0MmRxZDg4dG5vNDRkYjZkdmxzcXU4dm1hdHVjaWkuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLA0KICAgICAgICAgICAgICAicHJvamVjdF9pZCI6ICJzdHJpa2luZy1hcmJvci0yOTIwMTgiLA0KICAgICAgICAgICAgICAiYXV0aF91cmkiOiAiaHR0cHM6Ly9hY2NvdW50cy5nb29nbGUuY29tL28vb2F1dGgyL2F1dGgiLA0KICAgICAgICAgICAgICAidG9rZW5fdXJpIjogImh0dHBzOi8vb2F1dGgyLmdvb2dsZWFwaXMuY29tL3Rva2VuIiwNCiAgICAgICAgICAgICAgImF1dGhfcHJvdmlkZXJfeDUwOV9jZXJ0X3VybCI6ICJodHRwczovL3d3dy5nb29nbGVhcGlzLmNvbS9vYXV0aDIvdjEvY2VydHMiLA0KICAgICAgICAgICAgICAiY2xpZW50X3NlY3JldCI6ICJHT0NTUFgtd3UyMnBSZmR4MzJrcksxSlJUYXJGeDRQLUdfVyIsDQogICAgICAgICAgICAgICJyZWRpcmVjdF91cmlzIjogWyAiaHR0cDovL2xvY2FsaG9zdCIgXQ0KICAgICAgICAgICB9DQogICAgICAgIH0=";
            var base64EncodedBytes = Convert.FromBase64String(jsonData);

            using (MemoryStream stream = new(base64EncodedBytes))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new string[] { DriveService.Scope.Drive },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Foxoft",
            });

            var request = service.Files.Get("1NCnJoEonMjtzxIaM3n5x5ppC3DlvpLCu");

            request.MediaDownloader.ProgressChanged += (progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };

            MemoryStream memoryStream = new();
            request.Download(memoryStream);

            memoryStream.Position = 0; // Reset the stream position
            using (StreamReader reader = new(memoryStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
