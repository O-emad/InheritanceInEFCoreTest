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
    public class ExpensesController : BaseController<Expenses, BaseExpensesDTO>
    {
        private readonly IExpensesServiceRepository ExpensesService;

        public ExpensesController(IExpensesServiceRepository ExpensesService, IMapper mapper)
            : base(mapper, ExpensesService)
        {
            this.ExpensesService = ExpensesService ?? throw new ArgumentNullException(nameof(ExpensesService));
        }


    }
}
