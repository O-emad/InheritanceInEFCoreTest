using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Services.Helpers.ResourceParameters.Base
{
    public class BaseResourceParameters 
    {
        const int maxPageSize = 20;
        public string? SearchQuery { get; set; }
        public string? FilterQuery { get; set; }
        public int? PageNumber { get; set; } = 1;
        private int? _pageSize = 10;
        public int? PageSize
        {
            get => _pageSize;

            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
