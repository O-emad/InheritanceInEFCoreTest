using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Domain
{
    public class Expenses :Transaction
    {
        public DateTime IssuedAt { get; set; }
        [StringLength(150)]
        public string? Supplier { get; set; }
    }
}
