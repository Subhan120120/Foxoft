using System;
using System.Collections.Generic;
using System.Linq;

namespace Foxoft
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList()
        {
        }

        public PaginatedList(List<T> items, int totalPages, int pageIndex)
        {
            PageIndex = pageIndex;
            TotalPages = totalPages;

            AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 0;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex < TotalPages - 1;
            }
        }

        protected static PaginatedList<T> CreatePaginatedList(IQueryable<T> source, int pageIndex)
        {
            pageIndex = pageIndex < 0 ? 0 : pageIndex;
            int count = source.Count();
            int totalPages = (count < 12) ? 1 : (int)Math.Ceiling(count / 12.0);
            pageIndex = totalPages < pageIndex ? --totalPages : pageIndex;
            var items = source.Skip(pageIndex * 12).Take(12).ToList();
            return new PaginatedList<T>(items, totalPages, pageIndex);
        }
    }
}
