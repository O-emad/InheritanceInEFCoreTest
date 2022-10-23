using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Services.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);


        public PagedList()
        {

        }
        public PagedList(List<T> collection) : base(collection)
        {

        }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
            : base(items)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }


        public static PagedList<T> Create(IQueryable<T> source, int? pageNmber, int? pageSize)
        {
            
            var count = source.Count();
            if (pageSize is null || pageNmber is null)
            {
                pageSize = count;
                pageNmber = 1;
            }
            var items = source.Skip((pageNmber.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
            return new PagedList<T>(items, count, pageNmber.Value, pageSize.Value);
        }
    }
}
