using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineBooking.ViewModel.PaginatedList
{
    public class PaginatedListView<T>
    {
        public int PageIndex { get; }
        public int TotalPages { get; }
        public int TotalItems { get; }
        public List<T> Items { get; }

        public PaginatedListView(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = items.Count;
            Items = items;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static PaginatedListView<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedListView<T>(items, count, pageIndex, pageSize);
        }
    }
}
