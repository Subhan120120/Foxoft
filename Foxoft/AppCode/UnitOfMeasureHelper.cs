using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Foxoft
{
    public static class UnitOfMeasureHelper
    {
        private class UomNode
        {
            public int UnitOfMeasureId { get; set; }
            public decimal ConversionRate { get; set; }
            public int? ParentUnitOfMeasureId { get; set; }
            public bool IsBasic { get; set; }
        }

        private static ConcurrentDictionary<int, UomNode>? _cache;
        private static readonly object _syncLock = new();

        public static void InvalidateCache()
        {
            lock (_syncLock)
            {
                _cache = null;
            }
        }

        private static ConcurrentDictionary<int, UomNode> EnsureCache()
        {
            if (_cache != null)
                return _cache;

            lock (_syncLock)
            {
                if (_cache != null)
                    return _cache;

                var dict = new ConcurrentDictionary<int, UomNode>();
                try
                {
                    using var db = new subContext();
                    var list = db.DcUnitOfMeasures.AsNoTracking().ToList();
                    foreach (var u in list)
                    {
                        dict[u.UnitOfMeasureId] = new UomNode
                        {
                            UnitOfMeasureId = u.UnitOfMeasureId,
                            ConversionRate = u.ConversionRate > 0 ? u.ConversionRate : 1m,
                            ParentUnitOfMeasureId = u.ParentUnitOfMeasureId,
                            IsBasic = u.IsBasic
                        };
                    }
                    _cache = dict;
                }
                catch
                {
                    // Fallback for design-time or disconnected context without poisoning cache
                    return dict;
                }

                return _cache;
            }
        }

        public static decimal GetConversionMultiplierToBasic(int uomId)
        {
            var cache = EnsureCache();
            if (cache == null || !cache.TryGetValue(uomId, out var node))
                return 1m;

            decimal multiplier = 1m;
            var current = node;
            var visited = new HashSet<int>();

            while (current != null && !current.IsBasic && visited.Add(current.UnitOfMeasureId))
            {
                multiplier *= current.ConversionRate;

                if (current.ParentUnitOfMeasureId.HasValue &&
                    cache.TryGetValue(current.ParentUnitOfMeasureId.Value, out var parentNode))
                {
                    current = parentNode;
                }
                else
                {
                    break;
                }
            }

            return multiplier > 0 ? multiplier : 1m;
        }
    }
}
