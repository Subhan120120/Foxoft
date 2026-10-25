using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Foxoft.Models.ViewModel
{
    public class InvoiceOcrResult
    {
        public string? DocumentNumber { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string? VendorName { get; set; }
        public string? Currency { get; set; }
        public string? Notes { get; set; }
        public List<InvoiceOcrLineVM> Lines { get; set; } = new();

        public int InputTokens { get; set; }
        public int OutputTokens { get; set; }
        public int TotalTokens { get; set; }
        public string ModelUsed { get; set; } = string.Empty;
        public decimal ActualCostUsd { get; set; }
        public decimal CreditRequired { get; set; }
    }

    public class InvoiceOcrLineVM : INotifyPropertyChanged
    {
        private bool _selected = true;
        private int _lineNumber;
        private string? _ocrBarcode;
        private string? _ocrProductCode;
        private string? _ocrProductName;
        private string? _matchedProductCode;
        private string? _matchedProductName;
        private string? _matchedBarcode;
        private decimal _qty = 1m;
        private int? _unitOfMeasureId;
        private string? _unitOfMeasureName;
        private decimal _price;
        private decimal _amount;
        private float _vatRate;
        private string? _lineDescription;
        private bool _isMatched;
        private string _matchStatus = string.Empty;

        public bool Selected
        {
            get => _selected;
            set => SetField(ref _selected, value);
        }

        public int LineNumber
        {
            get => _lineNumber;
            set => SetField(ref _lineNumber, value);
        }

        public string? OcrBarcode
        {
            get => _ocrBarcode;
            set => SetField(ref _ocrBarcode, value);
        }

        public string? OcrProductCode
        {
            get => _ocrProductCode;
            set => SetField(ref _ocrProductCode, value);
        }

        public string? OcrProductName
        {
            get => _ocrProductName;
            set => SetField(ref _ocrProductName, value);
        }

        public string? MatchedProductCode
        {
            get => _matchedProductCode;
            set => SetField(ref _matchedProductCode, value);
        }

        public string? MatchedProductName
        {
            get => _matchedProductName;
            set => SetField(ref _matchedProductName, value);
        }

        public string? MatchedBarcode
        {
            get => _matchedBarcode;
            set => SetField(ref _matchedBarcode, value);
        }

        public decimal Qty
        {
            get => _qty;
            set
            {
                if (SetField(ref _qty, value))
                    UpdateAmount();
            }
        }

        public int? UnitOfMeasureId
        {
            get => _unitOfMeasureId;
            set => SetField(ref _unitOfMeasureId, value);
        }

        public string? UnitOfMeasureName
        {
            get => _unitOfMeasureName;
            set => SetField(ref _unitOfMeasureName, value);
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (SetField(ref _price, value))
                    UpdateAmount();
            }
        }

        public decimal Amount
        {
            get => _amount;
            set => SetField(ref _amount, value);
        }

        public float VatRate
        {
            get => _vatRate;
            set => SetField(ref _vatRate, value);
        }

        public string? LineDescription
        {
            get => _lineDescription;
            set => SetField(ref _lineDescription, value);
        }

        public bool IsMatched
        {
            get => _isMatched;
            set => SetField(ref _isMatched, value);
        }

        public string MatchStatus
        {
            get => _matchStatus;
            set => SetField(ref _matchStatus, value);
        }

        public void UpdateAmount()
        {
            Amount = Math.Round(_qty * _price, 2);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
