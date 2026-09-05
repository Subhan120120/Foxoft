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
        private bool _alreadyExists;
        private Guid? _existingPayrollHeaderId;

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
                }
            }
        }

        public decimal GrossSalary => BaseSalary + Bonus;

        public decimal NetSalary => GrossSalary - Deduction;

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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}