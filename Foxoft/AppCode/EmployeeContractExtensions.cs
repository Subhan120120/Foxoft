using Foxoft.Models;
using System;
using System.Linq;

namespace Foxoft
{
    public static class EmployeeContractExtensions
    {
        public static (decimal BaseSalary, string CurrencyCode) GetEffectiveSalary(this TrEmployeeContract contract, DateTime date, string defaultCurrency = "AZN")
        {
            if (contract == null || contract.Addenda == null || contract.Addenda.Count == 0)
                return (0, defaultCurrency);

            var activeAddendum = contract.Addenda
                .Where(a => a.StartDate.Date <= date.Date && (a.EndDate == null || a.EndDate.Value.Date >= date.Date))
                .OrderByDescending(a => a.StartDate)
                .FirstOrDefault();

            if (activeAddendum != null)
            {
                string curr = !string.IsNullOrEmpty(activeAddendum.CurrencyCode) ? activeAddendum.CurrencyCode.Trim() : defaultCurrency;
                return (activeAddendum.BaseSalary, curr);
            }

            var firstAddendum = contract.Addenda.OrderBy(a => a.StartDate).FirstOrDefault();
            if (firstAddendum != null)
            {
                string curr = !string.IsNullOrEmpty(firstAddendum.CurrencyCode) ? firstAddendum.CurrencyCode.Trim() : defaultCurrency;
                return (firstAddendum.BaseSalary, curr);
            }

            return (0, defaultCurrency);
        }

        public static (decimal BaseSalary, string CurrencyCode) GetEffectiveSalaryForPeriod(this TrEmployeeContract contract, DateTime periodStart, DateTime periodEnd, string defaultCurrency = "AZN")
        {
            if (contract == null || contract.Addenda == null || contract.Addenda.Count == 0)
                return (0, defaultCurrency);

            var activeAddendum = contract.Addenda
                .Where(a => a.StartDate.Date <= periodEnd.Date && (a.EndDate == null || a.EndDate.Value.Date >= periodStart.Date))
                .OrderByDescending(a => a.StartDate)
                .FirstOrDefault();

            if (activeAddendum != null)
            {
                string curr = !string.IsNullOrEmpty(activeAddendum.CurrencyCode) ? activeAddendum.CurrencyCode.Trim() : defaultCurrency;
                return (activeAddendum.BaseSalary, curr);
            }

            var firstAddendum = contract.Addenda.OrderBy(a => a.StartDate).FirstOrDefault();
            if (firstAddendum != null)
            {
                string curr = !string.IsNullOrEmpty(firstAddendum.CurrencyCode) ? firstAddendum.CurrencyCode.Trim() : defaultCurrency;
                return (firstAddendum.BaseSalary, curr);
            }

            return (0, defaultCurrency);
        }
    }
}
