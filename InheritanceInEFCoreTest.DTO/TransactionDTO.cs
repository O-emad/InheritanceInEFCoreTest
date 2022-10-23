using InheritanceInEFCoreTest.Domain;
using InheritanceInEFCoreTest.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.DTO
{
    public class TransactionDTO : BaseTransactionDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Account? FromAccount { get; set; }
        public Account? ToAccount { get; set; }
    }
}
