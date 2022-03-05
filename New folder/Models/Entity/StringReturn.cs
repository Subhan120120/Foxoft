using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models
{
    [NotMapped]
    public class GetNextDocNum
    {
        public string Value { get; set; }
    }
}
