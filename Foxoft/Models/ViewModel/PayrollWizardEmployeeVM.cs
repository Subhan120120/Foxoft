using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Foxoft.Models.ViewModel
{
    public class PayrollWizardEmployeeVM : INotifyPropertyChanged
    {
        private bool _selected = true;
        private string _currAccCode = string.Empty;
        private string _employeeName = string.Empty;
        private string? _departmentName;
        private string? _positionName;
        private decimal _baseSalary;
        private decimal _bonus;
        private decimal _deduction;
        private string _currencyCode = Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";
        private float _exchangeRate = 1f;
        private bool _alreadyExists;
        private Guid? _existingPayrollHeaderId;
        private decimal _previousBalance;
        private bool _paySelected = true;
        private decimal _payAmount;
        private string? _cashRegisterCode;
        private string? _paymentDocumentNumber;
        private int? _paymentMethodId;
        private string? _paymentDescription;
        private string _paymentCurrencyCode = Properties.Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";
        private float _paymentExchangeRate = 1f;

        public bool Selected
        {
            get => _selected;
            set { if (_selected != value) { _selected = value; OnPropertyChanged(); } }
        }

        public string CurrAccCode
        {
            get => _currAccCode;
            set { if (_currAccCode != value) { _currAccCode = value; OnPropertyChanged(); } }
        }

        public string EmployeeName
        {
            get => _employeeName;
            set { if (_employeeName != value) { _employeeName = value; OnPropertyChanged(); } }
        }

        public string? DepartmentName
        {
            get => _departmentName;
            set { if (_departmentName != value) { _departmentName = value; OnPropertyChanged(); } }
        }

        public string? PositionName
        {
            get => _positionName;
            set { if (_positionName != value) { _positionName = value; OnPropertyChanged(); } }
        }

        public decimal BaseSalary
        {
            get => _baseSalary;
            set
            {
                if (_baseSalary != value)
                {
                    _baseSalary = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(GrossSalary));
                    OnPropertyChanged(nameof(NetSalary));
                    OnPropertyChanged(nameof(GrossSalaryLoc));
                    OnPropertyChanged(nameof(NetSalaryLoc));
                    OnPropertyChanged(nameof(AmountLoc));
                    OnPropertyChanged(nameof(BalanceAfterPayroll));
                }
            }
        }

        public decimal Bonus
        {
            get => _bonus;
            set
            {
                if (_bonus != value)
                {
                    _bonus = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(GrossSalary));
                    OnPropertyChanged(nameof(NetSalary));
                    OnPropertyChanged(nameof(GrossSalaryLoc));
                    OnPropertyChanged(nameof(NetSalaryLoc));
                    OnPropertyChanged(nameof(AmountLoc));
                    OnPropertyChanged(nameof(BalanceAfterPayroll));
                }
            }
        }

        public decimal Deduction
        {
            get => _deduction;
            set
            {
                if (_deduction != value)
                {
                    _deduction = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NetSalary));
                    OnPropertyChanged(nameof(NetSalaryLoc));
                    OnPropertyChanged(nameof(AmountLoc));
                    OnPropertyChanged(nameof(BalanceAfterPayroll));
                }
            }
        }

        public decimal GrossSalary => BaseSalary + Bonus;

        public decimal NetSalary => GrossSalary - Deduction;

        public string CurrencyCode
        {
            get => _currencyCode;
            set
            {
                if (_currencyCode != value)
                {
                    _currencyCode = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(GrossSalaryLoc));
                    OnPropertyChanged(nameof(NetSalaryLoc));
                    OnPropertyChanged(nameof(AmountLoc));
                    OnPropertyChanged(nameof(BalanceAfterPayroll));
                }
            }
        }

        public float ExchangeRate
        {
            get => _exchangeRate;
            set
            {
                if (_exchangeRate != value)
                {
                    _exchangeRate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(GrossSalaryLoc));
                    OnPropertyChanged(nameof(NetSalaryLoc));
                    OnPropertyChanged(nameof(AmountLoc));
                    OnPropertyChanged(nameof(BalanceAfterPayroll));
                }
            }
        }

        public decimal GrossSalaryLoc
        {
            get
            {
                decimal rate = ExchangeRate == 0 ? 1m : (decimal)ExchangeRate;
                return Math.Round(GrossSalary / rate, 2);
            }
        }

        public decimal NetSalaryLoc
        {
            get
            {
                decimal rate = ExchangeRate == 0 ? 1m : (decimal)ExchangeRate;
                return Math.Round(NetSalary / rate, 2);
            }
        }

        public decimal AmountLoc => NetSalaryLoc;

        public bool AlreadyExists
        {
            get => _alreadyExists;
            set
            {
                if (_alreadyExists != value)
                {
                    _alreadyExists = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public string Status => AlreadyExists
            ? Properties.Resources.Form_PayrollWizard_Status_Exists
            : Properties.Resources.Form_PayrollWizard_Status_New;

        public Guid? ExistingPayrollHeaderId
        {
            get => _existingPayrollHeaderId;
            set { if (_existingPayrollHeaderId != value) { _existingPayrollHeaderId = value; OnPropertyChanged(); } }
        }

        public decimal PreviousBalance
        {
            get => _previousBalance;
            set
            {
                if (_previousBalance != value)
                {
                    _previousBalance = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(BalanceAfterPayroll));
                }
            }
        }

        public decimal BalanceAfterPayroll => PreviousBalance + NetSalaryLoc;

        public bool PaySelected
        {
            get => _paySelected;
            set
            {
                if (_paySelected != value)
                {
                    _paySelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal PayAmount
        {
            get => _payAmount;
            set
            {
                if (_payAmount != value)
                {
                    _payAmount = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? CashRegisterCode
        {
            get => _cashRegisterCode;
            set
            {
                if (_cashRegisterCode != value)
                {
                    _cashRegisterCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? PaymentDocumentNumber
        {
            get => _paymentDocumentNumber;
            set
            {
                if (_paymentDocumentNumber != value)
                {
                    _paymentDocumentNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public int? PaymentMethodId
        {
            get => _paymentMethodId;
            set
            {
                if (_paymentMethodId != value)
                {
                    _paymentMethodId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? PaymentDescription
        {
            get => _paymentDescription;
            set
            {
                if (_paymentDescription != value)
                {
                    _paymentDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PaymentCurrencyCode
        {
            get => _paymentCurrencyCode;
            set
            {
                if (_paymentCurrencyCode != value)
                {
                    _paymentCurrencyCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public float PaymentExchangeRate
        {
            get => _paymentExchangeRate;
            set
            {
                if (_paymentExchangeRate != value)
                {
                    _paymentExchangeRate = value;
                    OnPropertyChanged();
                }
            }
        }

        public void ApplyBalanceToPayAmount(string? payCurrency = null, float? payExchangeRate = null)
        {
            if (!string.IsNullOrEmpty(payCurrency))
                PaymentCurrencyCode = payCurrency;
            if (payExchangeRate.HasValue && payExchangeRate.Value > 0)
                PaymentExchangeRate = payExchangeRate.Value;

            decimal targetBalanceLoc = BalanceAfterPayroll > 0 ? BalanceAfterPayroll : 0;
            decimal rate = PaymentExchangeRate <= 0 ? 1m : (decimal)PaymentExchangeRate;
            PayAmount = Math.Round(targetBalanceLoc * rate, 2);
            PaySelected = PayAmount > 0;
        }

        public void ApplyNetSalaryToPayAmount(string? payCurrency = null, float? payExchangeRate = null)
        {
            if (!string.IsNullOrEmpty(payCurrency))
                PaymentCurrencyCode = payCurrency;
            if (payExchangeRate.HasValue && payExchangeRate.Value > 0)
                PaymentExchangeRate = payExchangeRate.Value;

            decimal targetSalaryLoc = NetSalaryLoc > 0 ? NetSalaryLoc : 0;
            decimal rate = PaymentExchangeRate <= 0 ? 1m : (decimal)PaymentExchangeRate;
            PayAmount = Math.Round(targetSalaryLoc * rate, 2);
            PaySelected = PayAmount > 0;
        }

        public void ResetPayAmount(string? payCurrency = null, float? payExchangeRate = null)
        {
            if (!string.IsNullOrEmpty(payCurrency))
                PaymentCurrencyCode = payCurrency;
            if (payExchangeRate.HasValue && payExchangeRate.Value > 0)
                PaymentExchangeRate = payExchangeRate.Value;

            PayAmount = 0;
            PaySelected = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
