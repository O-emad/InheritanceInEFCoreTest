using InheritanceInEFCoreTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Services
{
    public interface IInvoiceServiceRepository: IBaseServiceRepository<Invoice>
    {

    }
}
