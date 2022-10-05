using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public class RetailSale
    {
        [Key]
        public string trInvoiceLineId { get; set; }
    }
}
