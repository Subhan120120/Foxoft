using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Foxoft.AppCode
{
    public class GoogleContactAPI : IDisposable
    {
        private const string ApplicationName = "Foxoft";
        private const string CredentialData = "eyJpbnN0YWxsZWQiOnsiY2xpZW50X2lkIjoiNzE1NTAwMTk4OTItdTVwaXU0dm81ZnVsczM3NGMzZjV2Z2x1Y2ZzdDFtdjcuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJwcm9qZWN0X2lkIjoiYXJjaGVkLXRhcGUtNDMxNTEyLWs3IiwiYXV0aF91cmkiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20vby9vYXV0aDIvYXV0aCIsInRva2VuX3VyaSI6Imh0dHBzOi8vb2F1dGgyLmdvb2dsZWFwaXMuY29tL3Rva2VuIiwiYXV0aF9wcm92aWRlcl94NTA5X2NlcnRfdXJsIjoiaHR0cHM6Ly93d3cuZ29vZ2xlYXBpcy5jb20vb2F1dGgyL3YxL2NlcnRzIiwiY2xpZW50X3NlY3JldCI6IkdPQ1NQWC02QWV2QnhCeGVOVl9mMWlJM3U3S2dCeXdhM2xRIiwicmVkaXJlY3RfdXJpcyI6WyJodHRwOi8vbG9jYWxob3N0Il19fQ==";

        private static string TokenPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "Foxoft",
            "GoogleContactToken");

        private PeopleServiceService? _peopleService;
        private bool _disposed;

        public async Task<PeopleServiceService> GetPeopleServiceAsync(CancellationToken ct = default)
        {
            if (_peopleService != null)
                return _peopleService;

            EnsureTokenDirectoryAccess(TokenPath);

            byte[] credentialBytes = Convert.FromBase64String(CredentialData);
            using MemoryStream stream = new(credentialBytes);

            UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                new[] { PeopleServiceService.Scope.Contacts },
                "user",
                ct,
                new CompanyGoogleTokenDataStore(TokenPath));

            _peopleService = new PeopleServiceService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return _peopleService;
        }

        public async Task<(bool isSuccess, string message, string? info)> TestConnectionAsync(CancellationToken ct = default)
        {
            try
            {
                var service = await GetPeopleServiceAsync(ct);

                // Use Connections.List to verify contacts access (fully supported under Scope.Contacts)
                var listRequest = service.People.Connections.List("people/me");
                listRequest.PageSize = 1;
                listRequest.PersonFields = "names";
                var res = await listRequest.ExecuteAsync(ct);

                int totalCount = res.TotalPeople ?? res.TotalItems ?? 0;
                string infoText = totalCount > 0
                    ? $"Google Contacts ({totalCount:N0})"
                    : "Google Contacts";

                return (true, "OK", infoText);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }

        public void ResetToken()
        {
            try
            {
                _peopleService?.Dispose();
                _peopleService = null;

                CompanyGoogleTokenDataStore store = new(TokenPath);
                _ = store.ClearAsync();
            }
            catch
            {
                // Ignore cleanup errors
            }
        }

        public async Task<Dictionary<string, string>> GetExistingContactsMapAsync(CancellationToken ct = default)
        {
            Dictionary<string, string> phoneToNameMap = new(StringComparer.OrdinalIgnoreCase);

            try
            {
                var service = await GetPeopleServiceAsync(ct);
                string? pageToken = null;

                do
                {
                    var listRequest = service.People.Connections.List("people/me");
                    listRequest.PersonFields = "names,phoneNumbers";
                    listRequest.PageSize = 1000;
                    listRequest.PageToken = pageToken;

                    var response = await listRequest.ExecuteAsync(ct);

                    if (response.Connections != null)
                    {
                        foreach (var connection in response.Connections)
                        {
                            string contactName = connection.Names?.FirstOrDefault()?.DisplayName ?? string.Empty;

                            if (connection.PhoneNumbers != null)
                            {
                                foreach (var phone in connection.PhoneNumbers)
                                {
                                    string norm = NormalizePhone(phone.Value);
                                    if (!string.IsNullOrEmpty(norm) && !phoneToNameMap.ContainsKey(norm))
                                        phoneToNameMap[norm] = contactName;
                                }
                            }
                        }
                    }

                    pageToken = response.NextPageToken;
                }
                while (!string.IsNullOrEmpty(pageToken) && !ct.IsCancellationRequested);
            }
            catch
            {
                // In case reading connections fails, return partial or empty map gracefully
            }

            return phoneToNameMap;
        }

        public async Task<HashSet<string>> GetExistingPhoneNumbersAsync(CancellationToken ct = default)
        {
            var map = await GetExistingContactsMapAsync(ct);
            return new HashSet<string>(map.Keys, StringComparer.OrdinalIgnoreCase);
        }

        public static string NormalizePhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;

            string digits = Regex.Replace(phone, @"\D", "");
            if (digits.Length == 10 && digits.StartsWith("0"))
                digits = "994" + digits.Substring(1);
            else if (digits.Length == 9)
                digits = "994" + digits;

            return digits;
        }

        public async Task<Person> CreateContactAsync(DcCurrAcc acc, GoogleContactExportOptions? options = null, CancellationToken ct = default)
        {
            options ??= new GoogleContactExportOptions();

            var item = new GoogleContactWizardItemVM
            {
                CurrAccCode = acc.CurrAccCode,
                CurrAccDesc = acc.CurrAccDesc ?? string.Empty,
                FirstName = acc.FirstName,
                LastName = acc.LastName,
                FatherName = acc.FatherName,
                PhoneNum = acc.PhoneNum ?? string.Empty,
                Address = acc.Address,
                CurrAccTypeCode = acc.CurrAccTypeCode
            };

            if (acc.DcCurrAccContactDetails != null)
            {
                foreach (var detail in acc.DcCurrAccContactDetails)
                {
                    if (detail.ContactTypeId == ContactType.Phone && !string.IsNullOrWhiteSpace(detail.ContactDesc))
                    {
                        if (string.IsNullOrWhiteSpace(item.PhoneNum))
                            item.PhoneNum = detail.ContactDesc.Trim();
                        else if (detail.ContactDesc.Trim() != item.PhoneNum.Trim())
                            item.AdditionalPhoneNumbers.Add(detail.ContactDesc.Trim());
                    }
                    else if (detail.ContactTypeId == ContactType.Email && !string.IsNullOrWhiteSpace(detail.ContactDesc))
                    {
                        if (string.IsNullOrWhiteSpace(item.Email))
                            item.Email = detail.ContactDesc.Trim();
                        else if (detail.ContactDesc.Trim() != item.Email.Trim())
                            item.AdditionalEmails.Add(detail.ContactDesc.Trim());
                    }
                }
            }

            return await CreateContactAsync(item, options, ct);
        }

        public async Task<Person> CreateContactAsync(GoogleContactWizardItemVM item, GoogleContactExportOptions options, CancellationToken ct = default)
        {
            var service = await GetPeopleServiceAsync(ct);

            string givenName = string.Empty;
            string familyName = string.Empty;
            string middleName = item.FatherName ?? string.Empty;

            if (options.NameFormat == ContactNameFormat.FirstAndLastName &&
                (!string.IsNullOrWhiteSpace(item.FirstName) || !string.IsNullOrWhiteSpace(item.LastName)))
            {
                givenName = item.FirstName ?? string.Empty;
                familyName = item.LastName ?? string.Empty;
            }
            else if (!string.IsNullOrWhiteSpace(item.CurrAccDesc))
            {
                string desc = item.CurrAccDesc.Trim();
                string[] parts = desc.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 1)
                {
                    givenName = parts[0];
                }
                else if (parts.Length == 2)
                {
                    familyName = parts[0];
                    givenName = parts[1];
                }
                else
                {
                    familyName = parts[0];
                    givenName = string.Join(" ", parts.Skip(1));
                }
            }
            else
            {
                givenName = item.CurrAccCode;
            }

            if (options.AddPrefix && !string.IsNullOrWhiteSpace(options.Prefix))
            {
                givenName = options.Prefix.Trim() + " " + givenName;
            }

            Person newContact = new()
            {
                Names = new List<Name>
                {
                    new Name
                    {
                        GivenName = givenName.Trim(),
                        FamilyName = familyName.Trim(),
                        MiddleName = middleName.Trim()
                    }
                }
            };

            List<PhoneNumber> phoneList = new();
            if (!string.IsNullOrWhiteSpace(item.PhoneNum))
            {
                phoneList.Add(new PhoneNumber
                {
                    Value = item.PhoneNum.Trim(),
                    Type = "mobile"
                });
            }

            foreach (var addPhone in item.AdditionalPhoneNumbers)
            {
                if (!string.IsNullOrWhiteSpace(addPhone) && !phoneList.Any(p => p.Value == addPhone.Trim()))
                {
                    phoneList.Add(new PhoneNumber
                    {
                        Value = addPhone.Trim(),
                        Type = "work"
                    });
                }
            }

            if (phoneList.Count > 0)
                newContact.PhoneNumbers = phoneList;

            List<EmailAddress> emailList = new();
            if (!string.IsNullOrWhiteSpace(item.Email))
            {
                emailList.Add(new EmailAddress
                {
                    Value = item.Email.Trim(),
                    Type = "work"
                });
            }

            foreach (var addEmail in item.AdditionalEmails)
            {
                if (!string.IsNullOrWhiteSpace(addEmail) && !emailList.Any(e => e.Value == addEmail.Trim()))
                {
                    emailList.Add(new EmailAddress
                    {
                        Value = addEmail.Trim(),
                        Type = "home"
                    });
                }
            }

            if (emailList.Count > 0)
                newContact.EmailAddresses = emailList;

            if (!string.IsNullOrWhiteSpace(item.Address))
            {
                newContact.Addresses = new List<Address>
                {
                    new Address
                    {
                        StreetAddress = item.Address.Trim(),
                        Type = "work"
                    }
                };
            }

            if (options.SetOrganization && !string.IsNullOrWhiteSpace(item.CurrAccDesc))
            {
                newContact.Organizations = new List<Organization>
                {
                    new Organization
                    {
                        Name = item.CurrAccDesc.Trim(),
                        Title = item.CurrAccTypeName
                    }
                };
            }

            if (options.IncludeNote)
            {
                string noteText = $"Foxoft Cari Hesab: {item.CurrAccCode}\nNöv: {item.CurrAccTypeName}";
                newContact.Biographies = new List<Biography>
                {
                    new Biography
                    {
                        Value = noteText,
                        ContentType = "TEXT_PLAIN"
                    }
                };
            }

            var request = service.People.CreateContact(newContact);
            return await request.ExecuteAsync(ct);
        }

        public async Task<(int added, int skipped, int failed)> ExportContactsAsync(
            IList<GoogleContactWizardItemVM> items,
            GoogleContactExportOptions options,
            IProgress<GoogleContactExportProgress> progress,
            CancellationToken ct = default)
        {
            int added = 0;
            int skipped = 0;
            int failed = 0;

            HashSet<string> existingPhones = new(StringComparer.OrdinalIgnoreCase);
            if (options.SkipDuplicates)
            {
                existingPhones = await GetExistingPhoneNumbersAsync(ct);
            }

            var selectedItems = items.Where(x => x.Selected).ToList();
            int total = selectedItems.Count;

            for (int i = 0; i < selectedItems.Count; i++)
            {
                if (ct.IsCancellationRequested)
                    break;

                var item = selectedItems[i];
                string contactDisplayName = !string.IsNullOrWhiteSpace(item.CurrAccDesc) ? item.CurrAccDesc : item.CurrAccCode;

                if (options.SkipDuplicates && !string.IsNullOrWhiteSpace(item.PhoneNum))
                {
                    string norm = NormalizePhone(item.PhoneNum);
                    if (!string.IsNullOrEmpty(norm) && existingPhones.Contains(norm))
                    {
                        skipped++;
                        item.Status = Properties.Resources.Form_GoogleContactWizard_Status_Skipped;
                        progress.Report(new GoogleContactExportProgress
                        {
                            CurrentIndex = i + 1,
                            TotalCount = total,
                            CurrAccCode = item.CurrAccCode,
                            ContactName = contactDisplayName,
                            Message = $"{contactDisplayName} ({item.PhoneNum}) - {Properties.Resources.Form_GoogleContactWizard_Status_Skipped}",
                            IsSuccess = true,
                            IsSkipped = true
                        });
                        continue;
                    }
                }

                try
                {
                    item.Status = Properties.Resources.Form_GoogleContactWizard_Status_Processing;
                    await CreateContactAsync(item, options, ct);

                    added++;
                    item.Status = Properties.Resources.Form_GoogleContactWizard_Status_Success;
                    item.ErrorMessage = null;

                    if (!string.IsNullOrWhiteSpace(item.PhoneNum))
                    {
                        string norm = NormalizePhone(item.PhoneNum);
                        if (!string.IsNullOrEmpty(norm))
                            existingPhones.Add(norm);
                    }

                    progress.Report(new GoogleContactExportProgress
                    {
                        CurrentIndex = i + 1,
                        TotalCount = total,
                        CurrAccCode = item.CurrAccCode,
                        ContactName = contactDisplayName,
                        Message = $"✓ {contactDisplayName} ({item.PhoneNum}) - {Properties.Resources.Form_GoogleContactWizard_Status_Success}",
                        IsSuccess = true,
                        IsSkipped = false
                    });

                    // Small delay to prevent API quota throttling
                    await Task.Delay(60, ct);
                }
                catch (Exception ex)
                {
                    failed++;
                    item.Status = Properties.Resources.Form_GoogleContactWizard_Status_Failed;
                    item.ErrorMessage = ex.Message;

                    progress.Report(new GoogleContactExportProgress
                    {
                        CurrentIndex = i + 1,
                        TotalCount = total,
                        CurrAccCode = item.CurrAccCode,
                        ContactName = contactDisplayName,
                        Message = $"✗ {contactDisplayName} ({item.PhoneNum}) - {Properties.Resources.Form_GoogleContactWizard_Status_Failed}: {ex.Message}",
                        IsSuccess = false,
                        IsSkipped = false
                    });
                }
            }

            return (added, skipped, failed);
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
                // Permissions setting is optional
            }
        }

        // Backward compatibility method
        public void Contact()
        {
            _ = TestConnectionAsync(CancellationToken.None);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _peopleService?.Dispose();
                _peopleService = null;
                _disposed = true;
            }
        }
    }
}
