using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft
{
    public class ReportVM
    {
        public ReportVM()
        {
        }

        public ReportVM(List<TrInvoiceLine> TrInvoiceLines)
        {
            this.TrInvoiceLines = TrInvoiceLines;
        }

        public ReportVM(List<TrInvoiceLine> TrInvoiceLines, List<TrInvoiceHeader> TrInvoiceHeaders)
            : this(TrInvoiceLines)
        {
            this.TrInvoiceHeaders = TrInvoiceHeaders;
        }

        public List<TrInvoiceLine> TrInvoiceLines { get; set; }
        public List<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
    }
}
