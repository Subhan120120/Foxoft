using System;
using System.ComponentModel;

namespace Foxoft.Models.ViewModel
{
    public class ReturnCartItemVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public Guid InvoiceLineId { get; set; }
        public Guid InvoiceHeaderId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string? Barcode { get; set; }
        public string ProductDesc { get; set; } = string.Empty;

        public decimal OriginalQty { get; set; }
        public decimal AlreadyReturnedQty { get; set; }
        public decimal MaxReturnableQty { get; set; }

        private decimal _returnQty;
        public decimal ReturnQty
        {
            get => _returnQty;
            set
            {
                if (_returnQty != value)
                {
                    _returnQty = value;
                    OnPropertyChanged(nameof(ReturnQty));
                    OnPropertyChanged(nameof(Amount));
                    OnPropertyChanged(nameof(AmountLoc));
                    OnPropertyChanged(nameof(NetAmount));
                    OnPropertyChanged(nameof(NetAmountLoc));
                }
            }
        }

        public decimal Price { get; set; }
        public decimal PriceLoc { get; set; }
        public decimal PosDiscount { get; set; }

        public decimal Amount => Math.Round(ReturnQty * Price, 2);
        public decimal AmountLoc => Math.Round(ReturnQty * PriceLoc, 2);

        public decimal NetAmount => Math.Round(ReturnQty * Price * (100m - PosDiscount) / 100m, 2);
        public decimal NetAmountLoc => Math.Round(ReturnQty * PriceLoc * (100m - PosDiscount) / 100m, 2);

        public float ExchangeRate { get; set; } = 1;
        public string CurrencyCode { get; set; } = "AZN";
        public int? UnitOfMeasureId { get; set; }
        public decimal? ProductCost { get; set; }
        public float VatRate { get; set; }
        public string? SerialNumberCode { get; set; }
        public string? LineDescription { get; set; }
        public string? SalesPersonCode { get; set; }
        public string? WorkerCode { get; set; }
    }
}
