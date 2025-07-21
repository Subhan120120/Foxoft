using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public partial class UnDeliveredViewModel
    {
        public TrInvoiceLine TrInvoiceLine { get; set; }
        public TrInvoiceHeader TrInvoiceHeader { get; set; }
        public decimal ReturnQty { get; set; }
        public decimal RemainingQty { get; set; }
    }
}
