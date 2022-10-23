using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.DTO.Base
{
    public class BaseAccountDTO
    {
        [StringLength(150)]
        [Required]
        public string? Name { get; set; }
        public AccountType Type { get; set; }
        public double Balance { get; set; }
    }
}
