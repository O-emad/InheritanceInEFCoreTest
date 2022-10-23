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
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountForCreationDTO, Account>();
            CreateMap<AccountForUpdateDTO, Account>();
            CreateMap<BaseAccountDTO, Account>();
        }
    }
}
