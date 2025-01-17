using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public class TrInstallmentViewModel
    {
        public int InstallmentId { get; set; }
        public Guid InvoiceHeaderId { get; set; }
        public DateTime DocumentDate { get; set; }
        public string PaymentPlanCode { get; set; }
        public decimal Amount { get; set; }
        public decimal Commission { get; set; } // Commission added to the total amount
        public string CurrencyCode { get; set; }
        public float ExchangeRate { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingBalance { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal DueAmount { get; set; } // Amount due as of the current date
    }


}
