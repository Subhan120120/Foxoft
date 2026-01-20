using System;
using System.Collections.Generic;

namespace Foxoft.Models
{
    public class DcEmployee
    {
        public int Id { get; set; }

        public string CurrAccCode { get; set; } = null!;

        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        public decimal DefaultBaseSalary { get; set; }

        // Navigation
        //public ICollection<TrPayrollHeader> PayrollHeaders { get; set; } = new List<TrPayrollHeader>();
    }
}
