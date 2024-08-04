using DevExpress.Office.Drawing;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
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
    internal class GoogleContactAPI
    {
        public void Contact()
        {
            UserCredential credential;

            // encoding google credential json
            string jsonData = "eyJpbnN0YWxsZWQiOnsiY2xpZW50X2lkIjoiNzE1NTAwMTk4OTItdTVwaXU0dm81ZnVsczM3NGMzZjV2Z2x1Y2ZzdDFtdjcuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJwcm9qZWN0X2lkIjoiYXJjaGVkLXRhcGUtNDMxNTEyLWs3IiwiYXV0aF91cmkiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20vby9vYXV0aDIvYXV0aCIsInRva2VuX3VyaSI6Imh0dHBzOi8vb2F1dGgyLmdvb2dsZWFwaXMuY29tL3Rva2VuIiwiYXV0aF9wcm92aWRlcl94NTA5X2NlcnRfdXJsIjoiaHR0cHM6Ly93d3cuZ29vZ2xlYXBpcy5jb20vb2F1dGgyL3YxL2NlcnRzIiwiY2xpZW50X3NlY3JldCI6IkdPQ1NQWC02QWV2QnhCeGVOVl9mMWlJM3U3S2dCeXdhM2xRIiwicmVkaXJlY3RfdXJpcyI6WyJodHRwOi8vbG9jYWxob3N0Il19fQ==";
            var base64EncodedBytes = Convert.FromBase64String(jsonData);

            using (MemoryStream stream = new(base64EncodedBytes))
            {
                string credPath = "token2.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new string[] { PeopleServiceService.Scope.Contacts },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new PeopleServiceService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Foxoft",
            });

            Person newContact = new Person
            {
                Names = new List<Name>
            {
                new Name
                {
                    GivenName = "John",
                    FamilyName = "Doe"
                }
            },
                EmailAddresses = new List<EmailAddress>
            {
                new EmailAddress
                {
                    Value = "johndoe@example.com"
                }
            },
                PhoneNumbers = new List<PhoneNumber>
            {
                new PhoneNumber
                {
                    Value = "+1234567890"
                }
            }
            };

            try
            {
                PeopleResource.CreateContactRequest request = service.People.CreateContact(newContact);
                Person createdContact = request.Execute();
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show("Google API Error: " + ex.Message);
                MessageBox.Show("Error Code: " + ex.Error.Code);
                MessageBox.Show("Error Details: " + ex.Error.Message);
                if (ex.Error.Errors != null)
                {
                    foreach (var error in ex.Error.Errors)
                    {
                        MessageBox.Show("Error Reason: " + error.Reason);
                        MessageBox.Show("Error Message: " + error.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Error: " + ex.Message);
            }
        }
    }
}
