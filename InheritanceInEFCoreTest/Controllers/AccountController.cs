using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InheritanceInEFCoreTest.Domain;
using InheritanceInEFCoreTest.DTO.Base;
using InheritanceInEFCoreTest.Services;
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
    public class AccountController : BaseController<Account, BaseAccountDTO>
    {
        private readonly IAccountServiceRepository AccountService;

        public AccountController(IAccountServiceRepository AccountService, IMapper mapper)
            : base(mapper, AccountService)
        {
            this.AccountService = AccountService ?? throw new ArgumentNullException(nameof(AccountService));
        }


    }
}
