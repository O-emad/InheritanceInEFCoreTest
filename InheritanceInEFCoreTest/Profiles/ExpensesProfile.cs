using AutoMapper;
using InheritanceInEFCoreTest.Domain;
using InheritanceInEFCoreTest.DTO.Base;
using InheritanceInEFCoreTest.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Profiles
{
    public class ExpensesProfile : Profile
    {
        public ExpensesProfile()
        {
            CreateMap<Expenses, ExpensesDTO>();
            CreateMap<ExpensesForCreationDTO, Expenses>();
            CreateMap<ExpensesForUpdateDTO, Expenses>();
            CreateMap<BaseExpensesDTO, Expenses>();
        }
    }
}
