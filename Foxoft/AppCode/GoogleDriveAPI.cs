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

            string json = @"Foxoft.AppCode.client_secret.json";

            using (Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(json))
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
