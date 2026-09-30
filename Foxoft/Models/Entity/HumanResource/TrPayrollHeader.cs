// File: Models/TrPayrollHeader.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Foxoft.Models
{
    public class TrPayrollHeader
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CurrAccCode { get; set; }

        [ForeignKey(nameof(CurrAccCode))]
        public DcCurrAcc DcCurrAcc { get; set; } = null!;

        [Required]
        public Guid PayrollPeriodId { get; set; }

        [ForeignKey(nameof(PayrollPeriodId))]
        public DcPayrollPeriod PayrollPeriod { get; set; } = null!;

        private decimal _grossSalary;
        private decimal _netSalary;

        [NotMapped]
        public decimal GrossSalary
        {
            get
            {
                if (Lines != null && Lines.Count > 0)
                {
                    return Lines
                        .Where(l => l.PayrollItemType == PayrollItemType.Salary ||
                                    l.PayrollItemType == PayrollItemType.Bonus ||
                                    l.PayrollItemType == PayrollItemType.Overtime)
                        .Sum(l => l.AmountLoc != 0 ? l.AmountLoc : (l.ExchangeRate == 0 ? l.Amount : Math.Round(l.Amount / (decimal)l.ExchangeRate, 2)));
                }
                return _grossSalary;
            }
            set => _grossSalary = value;
        }

        [NotMapped]
        public decimal NetSalary
        {
            get
            {
                if (Lines != null && Lines.Count > 0)
                {
                    decimal gross = GrossSalary;
                    decimal deductions = Lines
                        .Where(l => l.PayrollItemType == PayrollItemType.Tax ||
                                    l.PayrollItemType == PayrollItemType.Insurance ||
                                    l.PayrollItemType == PayrollItemType.Deduction)
                        .Sum(l => l.AmountLoc != 0 ? l.AmountLoc : (l.ExchangeRate == 0 ? l.Amount : Math.Round(l.Amount / (decimal)l.ExchangeRate, 2)));
                    return gross - deductions;
                }
                return _netSalary;
            }
            set => _netSalary = value;
        }

        public ICollection<TrPayrollLine> Lines { get; set; } = new HashSet<TrPayrollLine>();
    }
}
