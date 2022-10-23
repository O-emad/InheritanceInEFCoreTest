using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Domain
{
    public class Invoice : Transaction
    {
        public int InvoiceNumber { get; set; }
        [StringLength(500)]
        public string? Notes { get; set; }
        public DateTime PayedAt { get; set; }
    }
}
