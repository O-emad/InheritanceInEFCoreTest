using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.DTO.Base
{
    public class BaseExpensesDTO : BaseTransactionDTO
    {
        public DateTime IssuedAt { get; set; }
        [StringLength(150)]
        public string? Supplier { get; set; }

    }
}
