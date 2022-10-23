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
    public class TransactionController : BaseController<Transaction, BaseTransactionDTO>
    {
        private readonly ITransactionServiceRepository TransactionService;

        public TransactionController(ITransactionServiceRepository TransactionService, IMapper mapper)
            : base(mapper, TransactionService)
        {
            this.TransactionService = TransactionService ?? throw new ArgumentNullException(nameof(TransactionService));
        }


    }
}
