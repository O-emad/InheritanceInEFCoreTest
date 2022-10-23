using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.DTO.Base
{
    public class BaseTransactionDTO
    {
        public double Amount { get; set; }
        [StringLength(150)]
        public string? Number { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public Guid? ToAccountId { get; set; }
        public Guid? FromAccountId { get; set; }

    }
}


