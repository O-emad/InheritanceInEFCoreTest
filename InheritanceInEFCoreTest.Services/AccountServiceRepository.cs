using InheritanceInEFCoreTest.Data;
using InheritanceInEFCoreTest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceInEFCoreTest.Services
{
    public class AccountServiceRepository : BaseServiceRepository<Account>, IAccountServiceRepository
    {
        public AccountServiceRepository(WorkFlowContext context) : base(context)
        {
        }

        public override Account GetById(Guid id)
        {
            if (Exists(id))
            {
                return context.Accounts.Include(a=>a.InTransaction).Include(a=>a.OutTransaction)
                    .FirstOrDefault(i => i.Id == id) ?? new Account() { Id = Guid.Empty };
            }
            return new Account() { Id = Guid.Empty };
        }
    }
}
