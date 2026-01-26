// File: AppCode/EntityValidationHelper.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Foxoft.AppCode
{
    public static class EntityValidationHelper
    {
        public static bool TryValidate(object entity, out string message)
        {
            var ctx = new ValidationContext(entity);
            var results = new List<ValidationResult>();

            bool ok = Validator.TryValidateObject(entity, ctx, results, validateAllProperties: true);
            message = ok ? "" : string.Join("\n", results.Select(x => "- " + x.ErrorMessage));
            return ok;
        }
    }
}
