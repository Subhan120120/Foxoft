using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Reflection;

namespace Foxoft
{
    public static class AutoMapper<TSource, TTarget>
    where TTarget : new()
    {
        public static TTarget Map(TSource source)
        {
            if (source == null) return default;

            TTarget target = new TTarget();

            var sourceProps = typeof(TSource).GetProperties();
            var targetProps = typeof(TTarget).GetProperties();

            foreach (var sProp in sourceProps)
            {
                var tProp = targetProps.FirstOrDefault(p =>
                    p.Name == sProp.Name &&
                    p.PropertyType == sProp.PropertyType &&
                    p.CanWrite);

                if (tProp != null)
                {
                    tProp.SetValue(target, sProp.GetValue(source));
                }
            }

            return target;
        }

        public static List<TTarget> MapList(IEnumerable<TSource> sourceList)
        {
            if (sourceList == null) return new List<TTarget>();

            return sourceList
                .Where(x => x != null)
                .Select(Map)
                .ToList();
        }
    }

}
