﻿using InheritanceInEFCoreTest.Domain;
using InheritanceInEFCoreTest.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.DTO
{
    public class AccountDTO : BaseAccountDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Transaction>? InTransaction { get; set; }
        public List<Transaction>? OutTransaction { get; set; }
    }
}
