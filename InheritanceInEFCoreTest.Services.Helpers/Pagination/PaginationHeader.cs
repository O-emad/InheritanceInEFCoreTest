using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Services.Helpers
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? SearchQuery { get; set; }
        public string? PreviousPageLink { get; set; }
        public string? NextPageLink { get; set; }
    }
}
