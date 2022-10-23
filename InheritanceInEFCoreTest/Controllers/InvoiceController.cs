using AutoMapper;
using InheritanceInEFCoreTest.Domain;
using InheritanceInEFCoreTest.DTO.Base;
using InheritanceInEFCoreTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class InvoiceController : BaseController<Invoice, BaseInvoiceDTO>
    {
        private readonly IInvoiceServiceRepository InvoiceService;

        public InvoiceController(IInvoiceServiceRepository InvoiceService, IMapper mapper)
            : base(mapper, InvoiceService)
        {
            this.InvoiceService = InvoiceService ?? throw new ArgumentNullException(nameof(InvoiceService));
        }


    }
}
