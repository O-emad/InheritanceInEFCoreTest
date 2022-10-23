using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Domain
{
    public class Transaction : BaseEntity
    {
        public double Amount { get; set; }
        [StringLength(150)]
        public string? Number { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public Guid? ToAccountId { get; set; }
        public Account? ToAccount { get; set; }
        public Guid? FromAccountId { get; set; }
        public Account? FromAccount { get; set; }
    }

    public enum TransactionDirection
    {
        In = 0,
        Out
    }
}
