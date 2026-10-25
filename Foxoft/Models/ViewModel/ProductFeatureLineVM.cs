using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Foxoft.Models.ViewModel
{
    public enum FeatureMatchStatus
    {
        Empty = 0,
        Matched = 1,
        NotFound = 2
    }

    public class ProductFeatureLineVM : INotifyPropertyChanged
    {
        private int _featureTypeId;
        private string _featureTypeName = string.Empty;
        private int _order;
        private string? _aiExtractedValue;
        private string? _matchedFeatureCode;
        private string? _matchedFeatureDesc;
        private string? _suggestedNewCode;
        private string? _suggestedNewDesc;
        private FeatureMatchStatus _status = FeatureMatchStatus.Empty;
        private bool _canCreate;
        private string? _notes;

        public int FeatureTypeId
        {
            get => _featureTypeId;
            set => SetField(ref _featureTypeId, value);
        }

        public string FeatureTypeName
        {
            get => _featureTypeName;
            set => SetField(ref _featureTypeName, value);
        }

        public int Order
        {
            get => _order;
            set => SetField(ref _order, value);
        }

        public string? AiExtractedValue
        {
            get => _aiExtractedValue;
            set => SetField(ref _aiExtractedValue, value);
        }

        public string? MatchedFeatureCode
        {
            get => _matchedFeatureCode;
            set => SetField(ref _matchedFeatureCode, value);
        }

        public string? MatchedFeatureDesc
        {
            get => _matchedFeatureDesc;
            set => SetField(ref _matchedFeatureDesc, value);
        }

        public string? SuggestedNewCode
        {
            get => _suggestedNewCode;
            set => SetField(ref _suggestedNewCode, value);
        }

        public string? SuggestedNewDesc
        {
            get => _suggestedNewDesc;
            set => SetField(ref _suggestedNewDesc, value);
        }

        public FeatureMatchStatus Status
        {
            get => _status;
            set => SetField(ref _status, value);
        }

        public bool CanCreate
        {
            get => _canCreate;
            set => SetField(ref _canCreate, value);
        }

        public string? Notes
        {
            get => _notes;
            set => SetField(ref _notes, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
