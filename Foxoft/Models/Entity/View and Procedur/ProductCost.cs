using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft.Models.Entity
{
    public static class SqlFunctions
    {
        [DbFunction("GetProductCost", "dbo")]
        public static decimal GetProductCost(string productCode, DateTime? dateTime = null)
        {
            throw new NotSupportedException();
        }
    }
}
