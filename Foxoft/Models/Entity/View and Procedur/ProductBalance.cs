using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    public class ProductBalance
    {
        [Key]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }


        public virtual DcProduct DcProduct { get; set; }
    }
}
