using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Foxoft.Models.ViewModel
{
    public enum ContactNameFormat
    {
        DescAsFullName = 0,
        FirstAndLastName = 1
    }

    public class GoogleContactExportOptions
    {
        public ContactNameFormat NameFormat { get; set; } = ContactNameFormat.DescAsFullName;
        public bool AddPrefix { get; set; } = false;
        public string Prefix { get; set; } = "[Foxoft] ";
        public bool IncludeNote { get; set; } = true;
        public bool SetOrganization { get; set; } = true;
        public bool SkipDuplicates { get; set; } = true;
    }

    public class GoogleContactExportProgress
    {
        public int CurrentIndex { get; set; }
        public int TotalCount { get; set; }
        public string CurrAccCode { get; set; } = string.Empty;
        public string ContactName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public bool IsSkipped { get; set; }
    }

    public class GoogleContactWizardItemVM : INotifyPropertyChanged
    {
        private bool _selected = true;
        private string _status = string.Empty;
        private string? _errorMessage;
        private bool _existsInGoogle;
        private string? _googleContactName;

        public bool Selected
        {
            get => _selected;
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CurrAccCode { get; set; } = string.Empty;
        public string CurrAccDesc { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public string? PhoneNum { get; set; }
        public string? CleanPhoneNum { get; set; }
        public List<string> AdditionalPhoneNumbers { get; set; } = new();
        public string? Email { get; set; }
        public List<string> AdditionalEmails { get; set; } = new();
        public string? Address { get; set; }
        public CurrAccType CurrAccTypeCode { get; set; }
        public string CurrAccTypeName { get; set; } = string.Empty;
        public bool ExistsInGoogle
        {
            get => _existsInGoogle;
            set
            {
                if (_existsInGoogle != value)
                {
                    _existsInGoogle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? GoogleContactName
        {
            get => _googleContactName;
            set
            {
                if (_googleContactName != value)
                {
                    _googleContactName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string GoogleStatus { get; set; } = string.Empty;

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool HasPhone => !string.IsNullOrWhiteSpace(PhoneNum) || AdditionalPhoneNumbers.Count > 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
