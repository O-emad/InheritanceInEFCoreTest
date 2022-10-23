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
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDTO>();
            CreateMap<InvoiceForCreationDTO, Invoice>();
            CreateMap<InvoiceForUpdateDTO, Invoice>();
            CreateMap<BaseInvoiceDTO, Invoice>();
        }
    }
}
