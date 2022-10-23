using AutoMapper;
using InheritanceInEFCoreTest.Domain;
using InheritanceInEFCoreTest.DTO;
using InheritanceInEFCoreTest.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<TransactionForCreationDTO, Transaction>();
            CreateMap<TransactionForUpdateDTO, Transaction>();
            CreateMap<BaseTransactionDTO, Transaction>();
        }
    }
}
