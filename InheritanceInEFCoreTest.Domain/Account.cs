using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Domain
{
    public class Account : BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string? Name { get; set; }
        public AccountType Type { get; set; }
        public double Balance { get; set; }
        [InverseProperty(nameof(Transaction.ToAccount))]
        public List<Transaction>? InTransaction { get; set; } = new List<Transaction>();
        [InverseProperty(nameof(Transaction.FromAccount))]
        public List<Transaction>? OutTransaction { get; set; } = new List<Transaction>();
    }


    public enum AccountType
    {
        BankAccount = 0,
        Treasury

    }
}
